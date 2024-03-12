namespace Client.Resources.Localizations;


internal abstract class SharedStaticStrings
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

  internal record ModalDialog
  {
    internal required string title { get; init; }
    internal required string question { get; init; }
  }
  
}