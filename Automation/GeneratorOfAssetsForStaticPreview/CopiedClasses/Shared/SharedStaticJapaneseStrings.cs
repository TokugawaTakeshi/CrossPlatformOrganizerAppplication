namespace GeneratorOfAssetsForStaticPreview.CopiedClasses.Shared;
// namespace Client.Resources.Localizations;


internal class SharedStaticJapaneseStrings: SharedStaticStrings
{

  internal override string availableDependingOnLanguageSpace { get; init; } = ""; 
  
  internal override string buildDataRetrievingOrSubmittingFailedPoliteMessage(string dynamicPart)
  {
    return "申し訳ございませんが、リクエストの処理中に問題が発生しているようです。" +
        $"{ dynamicPart } " +
        "弊社のチームはこの問題を把握し、迅速に調査および解決に取り組んでおります。 " +
        "ご不便をおかけし、誠に申し訳ございません。この件がお客様に与えた影響に深くお詫び申し上げます。";
  }
  
  internal override CommonWords commonWords { get; } = new()
  {
    unknown = "不明",
    yearsOld = "際"
  };

  internal override Genders genders { get; } = new()
  {
    male = "男性",
    female = "女性"
  };


  private SharedStaticJapaneseStrings() {}

  private static SharedStaticJapaneseStrings? singleInstance = null;
  
  public static SharedStaticStrings SingleInstance =>
    SharedStaticJapaneseStrings.singleInstance ?? 
    (SharedStaticJapaneseStrings.singleInstance = new SharedStaticJapaneseStrings());
  
}