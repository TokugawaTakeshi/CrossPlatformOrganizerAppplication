/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

namespace GeneratorOfAssetsForStaticPreview.StringResources.Common;


internal abstract class CommonStringResources
{

  internal abstract string availableDependingOnLanguageSpace { get; init; }
  
  internal abstract string buildDataRetrievingOrSubmittingFailedPoliteMessage(string dynamicPart);

  internal record CommonWords
  {
    internal required string unknown { get; init; }
    internal required string yearsOld { get; init; }
  }
  
  internal abstract CommonWords commonWords { get; }
  
  
  internal record Genders
  {
    internal required string male { get; init; }
    internal required string female { get; init; }
  }
  
  internal abstract Genders genders { get; }
  
  
  internal struct ButtonWithVisibleLabel
  {
    internal required string label { get; init; }
  }
  
  
  /* ━━━ Clickables ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract record Clickable;
  
  // TODO Get from YDF
  internal interface IClickableWithStaticLabel
  {
    internal string label { get; init; }
  }
  
  // TODO Get from YDF
  internal interface IClickableWithStaticAccessibilityGuidance
  {
    internal string accessibilityGuidance { get; init; }
  }

  // TODO Get from YDF
  internal interface IClickableWithDynamicAccessibilityGuidance<TTemplateVariables>
  {
    internal Func<TTemplateVariables, string> generateAccessibilityGuidance { get; init; }
  }
  
  
  internal struct IconButtonWithDynamicAccessibilityGuidance<TTemplateVariables>
  {
    internal required Func<TTemplateVariables, string> generateAccessibilityGuidance { get; init; }
  }
  
  
  /* ━━━ Inputtables ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal interface IInputtableWithStaticLabel
  {
    internal string label { get; init; }
  }  
  
  internal interface IInputtableWithStaticAccessibilityGuidance
  {
    internal string accessibilityGuidance { get; init; }
  }
  
  internal interface IInputtableWithDynamicAccessibilityGuidance<TTemplateVariables>
  {
    internal Func<TTemplateVariables, string> generateAccessibilityGuidance { get; init; }
  }
  
  
  internal struct MessageWithTitleAndDescription
  {
    internal required string title { get; init; }
    internal required string description { get; init; }
  }

  internal record ControlWithLabelAndGuidance
  {
    internal required string label { get; init; }
    internal required string guidance { get; init; }
  }

  internal record TextBoxWithStaticAccessibilityGuidanceOnly
  {
    internal required string accessibilityGuidance { get; init; }
  }

  internal record ModalDialog
  {
    internal required string title { get; init; }
    internal required string question { get; init; }
  }
  
}