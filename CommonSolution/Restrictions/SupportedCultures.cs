namespace CommonSolution.Restrictions;


public static class SupportedCultures
{

  public static class BCP_47_Tags
  {
    
    public const string JAPANESE = "ja-JP";
    public const string ENGLISH__UNITED_KINGDOM = "en-GB";
    
    public static readonly string[] All = [
      SupportedCultures.BCP_47_Tags.JAPANESE,
      SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM
    ];
    
  }
  
  public const string DEFAULT_BCP_47_TAG = SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM;
  
}