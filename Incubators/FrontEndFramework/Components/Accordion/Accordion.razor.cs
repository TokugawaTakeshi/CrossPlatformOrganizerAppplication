using YamatoDaiwa.Frontend.Animations;
using YamatoDaiwa.Frontend.GUI_Components.Abstractions;
using YamatoDaiwa.Frontend.Helpers;


namespace FrontEndFramework.Components.Accordion;


[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class Accordion : 
    Microsoft.AspNetCore.Components.ComponentBase, 
    IHTML_AttributesFallthrough,
    IFlexibleExternalCSS_ClassesSpecifyingForRootElement,
    IAsyncDisposable
{

  public const string CSS_NAMESPACE = "Accordion--YDF";
  
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required string title { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required bool? initiallyExpanded { get; set; } = null;
  
  
  /* ━━━ Events ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<bool> onExpandingStartedEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<bool> onExpandingEndedEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<bool> onCollapsingStartedEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<bool> onCollapsingEndedEventHandler { get; set; }
  
    /* ━━━ Child Content ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
  
  
  
  protected Microsoft.AspNetCore.Components.ElementReference rootElement;
  
  protected CollapsingAnimation? collapsingAnimation;
  
  protected bool isExpanded = false;
  
  [Microsoft.AspNetCore.Components.Inject]
  protected Microsoft.JSInterop.IJSRuntime javaScriptRuntime { get; set; } = null!;
  
  
  /* ━━━ Actions Handing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected async Task onClickButton()
  {

    if (this.collapsingAnimation is null)
    {
      return;  
    }
    

    if (this.isExpanded)
    {

      await this.onCollapsingStartedEventHandler.InvokeAsync();
      
      await this.collapsingAnimation.Animate(
        new CollapsingAnimation.CompoundParameter
        {
          animatedElement = this.rootElement,
          duration__seconds = 1
        }
      );
      
      await this.onCollapsingEndedEventHandler.InvokeAsync();
      
      this.isExpanded = false;
      
      return;
      
    }
    
    
    await this.onExpandingStartedEventHandler.InvokeAsync();
    
    this.isExpanded = true;
    
    await this.onExpandingEndedEventHandler.InvokeAsync();
    
  }
  
  
  /* ━━━ Theming ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public enum StandardThemes { regular }

  protected internal static Type? CustomThemes;

  public static void defineThemes(Type CustomThemes)
  {
    YDF_ComponentsHelper.ValidateCustomTheme(CustomThemes);
    Accordion.CustomThemes = CustomThemes;
  }

  protected string _theme = nameof(Accordion.StandardThemes.regular);

  [Microsoft.AspNetCore.Components.Parameter]
  [
    System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Performance", 
      "BL0007", 
      Justification = "Optimized equivalent is too complex: https://stackoverflow.com/a/79302962/4818123."
    )
  ]
  public object theme
  {
    get => this._theme;
    set => YDF_ComponentsHelper.
        AssignThemeIfItIsValid<Accordion.StandardThemes>(value, Accordion.CustomThemes, ref this._theme);
  }

  protected internal static bool mustConsiderThemesCSS_ClassesAsCommon = YDF_ComponentsHelper.areThemesCSS_ClassesCommon;

  public static void considerThemesAsCommon()
  {
    Accordion.mustConsiderThemesCSS_ClassesAsCommon = true;
  }

  [Microsoft.AspNetCore.Components.Parameter]
  public bool areThemesCSS_ClassesCommon { get; set; } =
      YDF_ComponentsHelper.areThemesCSS_ClassesCommon || Accordion.mustConsiderThemesCSS_ClassesAsCommon;


  /* ─── Geometry ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardGeometricVariations { regular, minimalistic }

  protected internal static Type? CustomGeometricVariations;

  public static void defineGeometricVariations(Type CustomGeometricVariations)
  {
    YDF_ComponentsHelper.ValidateCustomGeometricVariation(CustomGeometricVariations);
    Accordion.CustomGeometricVariations = CustomGeometricVariations;
  }

  protected string _geometricVariation = nameof(Accordion.StandardGeometricVariations.regular);

  [Microsoft.AspNetCore.Components.Parameter]
  [
    System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Performance", 
      "BL0007", 
      Justification = "Optimized equivalent is too complex: https://stackoverflow.com/a/79302962/4818123."
    )
  ]
  public object geometricVariation
  {
    get => this._geometricVariation;
    set => YDF_ComponentsHelper.AssignGeometricVariationIfItIsValid<Accordion.StandardGeometricVariations>(
      value, Accordion.CustomGeometricVariations, ref this._geometricVariation
    );
  }


  /* ─── Decoration ───────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardDecorativeVariations { regular, minimalistic }

  protected internal static Type? CustomDecorativeVariations;

  public static void defineDecorativeVariations(Type CustomDecorativeVariations) {
    YDF_ComponentsHelper.ValidateCustomDecorativeVariation(CustomDecorativeVariations);
    Accordion.CustomDecorativeVariations = CustomDecorativeVariations;
  }

  protected string _decorativeVariation = nameof(Accordion.StandardDecorativeVariations.regular);

  [Microsoft.AspNetCore.Components.Parameter]
  [
    System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Performance", 
      "BL0007", 
      Justification = "Optimized equivalent is too complex: https://stackoverflow.com/a/79302962/4818123."
    )
  ]
  public required object decorativeVariation
  {
    get => _decorativeVariation;
    set => YDF_ComponentsHelper.AssignDecorativeVariationIfItIsValid<Accordion.StandardDecorativeVariations>(
      value, Accordion.CustomDecorativeVariations, ref this._decorativeVariation
    );
  }
  
  
  /* ━━━ CSS Classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Root Element ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementModifierCSS_Class { get; set; } = null;

  [Microsoft.AspNetCore.Components.Parameter]
  public string[]? rootElementModifierCSS_Classes { get; set; } = null;

  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementSpaceSeparatedModifierCSS_Classes { get; set; } = null;

  private string classAttributeValueForRootElement => YDF_ComponentsHelper.GenerateClassAttributeValueForRootElement(
    new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement
    {
      CSS_Namespace = Accordion.CSS_NAMESPACE,
      theme = new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement.Theme
      {
        activeOne = this._theme,
        standardOnes = typeof(Accordion.StandardThemes),
        customOnes = Accordion.CustomThemes,
        areThemesCSS_ClassesCommon = this.areThemesCSS_ClassesCommon 
      },
      geometricVariation = new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement.GeometricVariation
      {
        activeOne = this._geometricVariation,
        standardOnes = typeof(Accordion.StandardGeometricVariations),
        customOnes = Accordion.CustomGeometricVariations
      },
      decorativeVariation = new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement.DecorativeVariation
      {
        activeOne = this._decorativeVariation,
        standardOnes = typeof(Accordion.StandardDecorativeVariations),
        customOnes = Accordion.CustomDecorativeVariations
      },
      externalSpaceSeparatedCSS_Classes =
          ((IFlexibleExternalCSS_ClassesSpecifyingForRootElement)this).rootElementSpaceSeparatedExternalCSS_Classes
    }
  );

  
  /* ┅┅┅ Panel ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  [Microsoft.AspNetCore.Components.Parameter]
  public required IEnumerable<string> panelAdditionalCSS_Classes { get; set; } = [];
  
  private string composePanelSpaceSeparatedCSS_Classes(string namespaceCSS_Class) => String.Join(
    " ",
    new List<string> { namespaceCSS_Class }.Concat(this.panelAdditionalCSS_Classes)
  );
  
  
  /* ━━━ IDs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Instance ID ──────────────────────────────────────────────────────────────────────────────────────────────── */
  protected readonly string INSTANCE_ID = Accordion.generateInstanceID();
  protected static uint counterForBasicID_Generating = 0;

  public static string generateInstanceID()
  {
    Accordion.counterForBasicID_Generating++;
    return $"ACCORDION--YDF-{ Accordion.counterForBasicID_Generating }";
  }

  
  /* ─── Elements HTML IDs ────────────────────────────────────────────────────────────────────────────────────────── */
  protected readonly string BUTTON_HTML_ID;
  protected readonly string PANEL_HTML_ID;
  
  
  /* ━━━ Constructor ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public Accordion()
  {
    this.BUTTON_HTML_ID = $"{ this.INSTANCE_ID }-BUTTON";
    this.PANEL_HTML_ID = $"{ this.INSTANCE_ID }-PANEL";
  }
  
  
  /* ━━━ Lifecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override void OnInitialized()
  {
    base.OnInitialized();
    this.collapsingAnimation = new CollapsingAnimation(this.javaScriptRuntime);
  }

  public async ValueTask DisposeAsync()
  {
    if (this.collapsingAnimation is not null)
    {
      await this.collapsingAnimation.DisposeAsync();
    }
  }
  
}

