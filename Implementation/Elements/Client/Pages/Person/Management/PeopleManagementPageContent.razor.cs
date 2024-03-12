using System.Diagnostics;
using Client.Pages.Person.Management.Localizations;

using Client.SharedState;

using System.Globalization;
using Client.SharedComponents.Managers.Person;
using CommonSolution.Gateways;
using FrontEndFramework.Components.BlockingLoadingOverlay;
using FrontEndFramework.Components.Snackbar;


namespace Client.Pages.Person.Management;


public partial class PeopleManagementPageContent : Microsoft.AspNetCore.Components.ComponentBase
{

  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private CommonSolution.Entities.Person? activePerson = null;
  
  private string personManagerAdditionalCSS_Class =>
      this.activePerson is not null ? "PeopleManagementPage-PersonManager__VisibleAtNarrowScreens" : "";
  
  private readonly PeopleManagementPageLocalization localization = 
      ClientConfigurationRepresentative.MustForceDefaultLocalization ?
          new PeopleManagementPageEnglishLocalization() :
          CultureInfo.CurrentCulture.Name switch
          {
            SupportedCultures.JAPANESE => new PeopleManagementPageJapaneseLocalization(),
            _ => new PeopleManagementPageEnglishLocalization()
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
    
    BlockingLoadingOverlayService.displayBlockingLoadingOverlay();

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

      _ = SnackbarService.displaySnackbarForAWhile(
        message: this.localization.errorMessages.personAddingFailed,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );

      Debug.WriteLine(exception);
      
      return;

    }
    finally
    {
      BlockingLoadingOverlayService.dismissBlockingLoadingOverlay();  
    }

    this.personManager.utilizePersonEditing();
    this.activePerson = newPerson;
    
    _ = SnackbarService.displaySnackbarForAWhile(
      message: this.localization.successMessages.personAddingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ─── Editing of Existing Person ───────────────────────────────────────────────────────────────────────────────── */
  private async System.Threading.Tasks.Task onExistingPersonEditingCompleted(
    PersonGateway.Updating.RequestData updatedPersonData
  )
  {
    
    BlockingLoadingOverlayService.displayBlockingLoadingOverlay();

    try
    {
      await PeopleSharedState.updatePerson(updatedPersonData);
    }
    catch (Exception exception)
    {

      _ = SnackbarService.displaySnackbarForAWhile(
        message: this.localization.errorMessages.personUpdatingFailed,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );
      
      Debug.WriteLine(exception.ToString());
      return;

    }
    finally
    {
      BlockingLoadingOverlayService.dismissBlockingLoadingOverlay();  
    }
  
    this.personManager.utilizePersonEditing();
    
    _ = SnackbarService.displaySnackbarForAWhile(
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
    
    
    BlockingLoadingOverlayService.displayBlockingLoadingOverlay();

    try
    {
      await PeopleSharedState.deletePerson(this.activePerson.ID);
    } catch (Exception exception)
    {
      
      _ = SnackbarService.displaySnackbarForAWhile(
        message: this.localization.errorMessages.personDeletingFailed,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );
      
      Debug.WriteLine(exception.ToString());
      return;
      
    }
    finally
    {
      BlockingLoadingOverlayService.dismissBlockingLoadingOverlay();  
    }

    this.personManager.utilizePersonEditing();

    this.activePerson = null;
    
    _ = SnackbarService.displaySnackbarForAWhile(
      message: this.localization.successMessages.personDeletingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }


}