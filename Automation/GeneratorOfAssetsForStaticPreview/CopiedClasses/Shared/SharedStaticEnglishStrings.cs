namespace GeneratorOfAssetsForStaticPreview.CopiedClasses.Shared;
// namespace Client.Resources.Localizations;


internal class SharedStaticEnglishStrings: SharedStaticStrings
{

  internal override string availableDependingOnLanguageSpace { get; init; } = " "; 
  
  internal override string buildDataRetrievingOrSubmittingFailedPoliteMessage(string dynamicPart)
  {
    return "We sincerely apologize for the inconvenience, but it seems a challenge has arisen in processing your request. " +
        $"{ dynamicPart } " +
        "Our team has been alerted to this matter, and they are currently working diligently to investigate and " +
          "resolve it as swiftly as possible. " +
        "Thank you for your patience and understanding. We deeply regret any disruption this may have caused.";
  }

  internal override CommonWords commonWords { get; } = new()
  {
    unknown = "Unknown",
    yearsOld = "Years"
  };

  internal override Genders genders { get; } = new()
  {
    male = "male",
    female = "female"
  };

  private SharedStaticEnglishStrings() {}

  private static SharedStaticEnglishStrings? singleInstance = null;
  
  public static SharedStaticStrings SingleInstance =>
      SharedStaticEnglishStrings.singleInstance ?? 
      (SharedStaticEnglishStrings.singleInstance = new SharedStaticEnglishStrings());
  
}