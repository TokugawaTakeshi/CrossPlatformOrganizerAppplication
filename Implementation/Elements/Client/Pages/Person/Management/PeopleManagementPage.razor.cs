using System.Diagnostics;
using Client.Pages.Person.Management.Localizations;
using Client.SharedGUI_Components.Managers.Person;
using Client.SharedState;
using CommonSolution.Gateways;
using CommonSolution.Restrictions;
using YamatoDaiwa.Frontend.GUI_Components.BlockingLoadingOverlay;
using YamatoDaiwa.Frontend.GUI_Components.Snackbar;


namespace Client.Pages.Person.Management;


public partial class PeopleManagementPage : Microsoft.AspNetCore.Components.ComponentBase
{

  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private CommonSolution.Entities.Person? activePerson = null;
  
  private string personManagerAdditionalCSS_Class =>
      this.activePerson is not null ? "PeopleManagementPage-PersonManager__VisibleAtNarrowScreens" : "";
  
  private readonly PeopleManagementPageLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new PeopleManagementPageJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new PeopleManagementPageEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };


  /* ━━━ Livecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override void OnInitialized()
  {
    PeopleSharedState.onStateChanged += base.StateHasChanged;
    PeopleSharedState.onSelectedPersonHasChanged += this.onPersonHasBeenSelected;
  }
  
  
  /* ━━━ Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Person Selecting ─────────────────────────────────────────────────────────────────────────────────────────── */
  private void onPersonHasBeenSelected(CommonSolution.Entities.Person newPerson)
  {
    this.activePerson = newPerson;
  }
  
  
  /* ─── Adding of New Person ─────────────────────────────────────────────────────────────────────────────────────── */
  private PersonManager personManager = null!;
  
  private void onClickStartingOfNewPersonInputtingButton()
  {
    this.activePerson = null;
    this.personManager.beginInputNewPersonData();
  }
  
  private async System.Threading.Tasks.Task onNewPersonInputtingCompleted(
    PersonGateway.Adding.RequestData newPersonData
  )
  {
    
    BlockingLoadingOverlay.display();

    CommonSolution.Entities.Person newPerson;
    
    try
    {
      newPerson = await PeopleSharedState.addPerson(
        newPersonData, 
        mustRetrieveUnfilteredPeopleIfNewOneDoesNotSatisfyingTheCurrentFilteringConditions: true
      );
    }
    catch (Exception exception)
    {

      _ = Snackbar.displayForAWhile(
        message: this.localization.errorMessages.personAddingFailed,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );

      Debug.WriteLine(exception);
      
      return;

    }
    finally
    {
      BlockingLoadingOverlay.hide();  
    }

    this.personManager.utilizePersonEditing();
    this.activePerson = newPerson;
    
    _ = Snackbar.displayForAWhile(
      message: this.localization.successMessages.personAddingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ─── Editing of Existing Person ───────────────────────────────────────────────────────────────────────────────── */
  private async System.Threading.Tasks.Task onExistingPersonEditingCompleted(
    PersonGateway.Updating.RequestData updatedPersonData
  )
  {
    
     BlockingLoadingOverlay.display();

    try
    {
      await PeopleSharedState.updatePerson(updatedPersonData);
    }
    catch (Exception exception)
    {

      _ = Snackbar.displayForAWhile(
        message: this.localization.errorMessages.personUpdatingFailed,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );
      
      Debug.WriteLine(exception.ToString());
      return;

    }
    finally
    {
      BlockingLoadingOverlay.hide();  
    }
  
    this.personManager.utilizePersonEditing();
    
    _ = Snackbar.displayForAWhile(
      message: this.localization.successMessages.personUpdatingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ─── Deleting of Existing Task ────────────────────────────────────────────────────────────────────────────────── */
  private async System.Threading.Tasks.Task onDeletePerson()
  {

    if (this.activePerson is null)
    {
      throw new Exception("\"onDeletePerson\" method has been called while \"activePerson\" is still \"null\".");
    }
    
    
    BlockingLoadingOverlay.display();

    try
    {
      await PeopleSharedState.deletePerson(this.activePerson.ID);
    } catch (Exception exception)
    {
      
      _ = Snackbar.displayForAWhile(
        message: this.localization.errorMessages.personDeletingFailed,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );
      
      Debug.WriteLine(exception.ToString());
      return;
      
    }
    finally
    {
      BlockingLoadingOverlay.hide();  
    }

    this.personManager.utilizePersonEditing();

    this.activePerson = null;
    
    _ = Snackbar.displayForAWhile(
      message: this.localization.successMessages.personDeletingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }


}