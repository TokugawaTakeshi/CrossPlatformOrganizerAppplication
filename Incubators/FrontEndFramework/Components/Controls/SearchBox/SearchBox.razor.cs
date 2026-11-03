using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Buttons.Plain;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.Frontend.Helpers;


namespace FrontEndFramework.Components.Controls.SearchBox;


public partial class SearchBox : 
    Microsoft.AspNetCore.Components.ComponentBase,
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough
{

  public const string CSS_NAMESPACE = "SearchBox--YDF";
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public required EventCallback<string?> onNewSearchRequestEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public byte minimalCharactersCountForSearchRequest { get; set; } = 1;
  
  [Microsoft.AspNetCore.Components.Parameter] public string? placeholder { get; set; }
  [Microsoft.AspNetCore.Components.Parameter] public string? accessibilityGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] public bool disabled { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter] public bool ableToSubmitRequestByEnterKey { get; set; } = false;
  [Microsoft.AspNetCore.Components.Parameter] public bool emptySearchRequestAsResetting { get; set; } = false;

  protected string? _mustSynchronizeDisplayingSearchRequestWith = null;
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? mustSynchronizeDisplayingSearchRequestWith
  {
    get => _mustSynchronizeDisplayingSearchRequestWith;
    set
    {
      this._mustSynchronizeDisplayingSearchRequestWith = value;
      this.inputtedSearchRequest = this._mustSynchronizeDisplayingSearchRequestWith ?? "";
    }
  }
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  
  protected Button searchingRequestEmittingButton = null!;
  
  protected string inputtedSearchRequest = "";
  protected bool isTooltipDisplaying = false;
  
  
  protected static readonly uint INVALID_REQUEST_TOOLTIP_DISPLAYING_DURATION__SECONDS = 3;

  
  protected async System.Threading.Tasks.Task submitSearchRequest() {

    if (this.inputtedSearchRequest.Length == 0 && this.emptySearchRequestAsResetting)
    {
      await this.onNewSearchRequestEventHandler.InvokeAsync(null);
      return;
    }


    if (this.inputtedSearchRequest.Length < this.minimalCharactersCountForSearchRequest) {
      
      this.isTooltipDisplaying = true;

      await System.Threading.Tasks.Task.Delay(
        TimeSpan.FromSeconds(SearchBox.INVALID_REQUEST_TOOLTIP_DISPLAYING_DURATION__SECONDS)
      );

      this.isTooltipDisplaying = false;
      
      return;
      
    }

    
    await this.onNewSearchRequestEventHandler.InvokeAsync(this.inputtedSearchRequest);

  }

  protected void onInputToInputElement(ChangeEventArgs eventArguments)
  {
    this.inputtedSearchRequest = eventArguments.Value?.ToString() ?? "";
  }
  
  protected async System.Threading.Tasks.Task onPressKeyDuringInputElementFocusedIn(KeyboardEventArgs eventArguments) {

    if (eventArguments.Key != "Enter")
    {
      return;
    }
    

    if (this.ableToSubmitRequestByEnterKey) {
      await this.submitSearchRequest();
      return;
    }

    
    await this.searchingRequestEmittingButton.focus();
    
  }

  protected async System.Threading.Tasks.Task resetSearchRequest()
  {

    this.inputtedSearchRequest = "";
    await this.onNewSearchRequestEventHandler.InvokeAsync(null);
  }
  
  
  /* ─── CSS classes ──────────────────────────────────────────────────────────────────────────────────────────────── */
  private string classAttributeValueForRootElement => YDF_ComponentsHelper.GenerateClassAttributeValueForRootElement(
    new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement
    {
      CSS_Namespace = SearchBox.CSS_NAMESPACE,
      rootElementHTML_Attributes = this.rootElementHTML_Attributes,
      otherInternalCSS_Classes = new List<string>().
          AddElementToEndIf("SearchBox--YDF__DisabledState", this.disabled)
    }
  );
  
}