using System.Globalization;
using Client.SharedComponents.Viewers.People.Localizations;
using CommonSolution.Gateways;
using Client.SharedState;
using Microsoft.AspNetCore.Components;


namespace Client.SharedComponents.Viewers.People;


public partial class PeopleViewer : Microsoft.AspNetCore.Components.ComponentBase 
{

  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.EventCallback<string> onClickPersonAddingButtonEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  
  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly PeopleViewerLocalization localization = 
      ClientConfigurationRepresentative.MustForceDefaultLocalization ?
          new PeopleViewerEnglishLocalization() :
          CultureInfo.CurrentCulture.Name switch
          {
            SupportedCultures.JAPANESE => new PeopleViewerJapaneseLocalization(),
            _ => new PeopleViewerEnglishLocalization()
          };

  
  /* ━━━ Livecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    PeopleSharedState.onStateChanged += base.StateHasChanged;
    await PeopleSharedState.retrievePeopleSelection();
  }
  
  
  /* ━━━ Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Person Selecting ─────────────────────────────────────────────────────────────────────────────────────────── */
  private void onSelectPerson(CommonSolution.Entities.Person targetPerson)
  {
    PeopleSharedState.currentlySelectedPerson = targetPerson;
  }

  
  /* ─── People Retrieving ────────────────────────────────────────────────────────────────────────────────────────── */
  private async System.Threading.Tasks.Task onNewPersonSearchingRequestByFullOrPartialNameOrItsSpellHasBeenEmitted(
    string? newPersonSearchingRequestByFullOrPartialNameOrItsSpell
  ) 
  {
    await PeopleSharedState.retrievePeopleSelection(
      new PersonGateway.SelectionRetrieving.RequestParameters
      {
        SearchingByFullOrPartialNameOrItsSpell = newPersonSearchingRequestByFullOrPartialNameOrItsSpell
      },
      mustResetSearchingByFullOrPartialNameOrItsSpell: newPersonSearchingRequestByFullOrPartialNameOrItsSpell is null
    );
  }
  
  private async System.Threading.Tasks.Task onClickPeopleSelectionRetrievingRetryingButton()
  {
    await PeopleSharedState.retrievePeopleSelection();
  }
  
  private async void onClickFilteringResettingButton()
  {
    await PeopleSharedState.retrievePeopleSelection(mustResetSearchingByFullOrPartialNameOrItsSpell: true);
  }
  
  
  /* ─── Adding of New Task ───────────────────────────────────────────────────────────────────────────────────────── */
  private System.Threading.Tasks.Task onClickPersonAddingButton()
  {
    return this.onClickPersonAddingButtonEventHandler.InvokeAsync(null);
  }
  
  
  /* ━━━ Rendering ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool mustDisableSearchBox =>
      PeopleSharedState.isPeopleRetrievingInProgressOrNotStartedYet ||
      PeopleSharedState.totalPeopleCountInDataSource == 0;
  
  private const byte LOADING_PLACEHOLDER_CARDS_COUNT = 12;
  
}
