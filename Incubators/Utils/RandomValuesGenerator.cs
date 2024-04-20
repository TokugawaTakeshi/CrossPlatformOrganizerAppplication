using System.Data;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;


namespace Utils;


public abstract class RandomValuesGenerator
{

  public static string GetRandomEmailAddress()
  {
    return RandomizerFactory.GetRandomizer(new FieldOptionsEmailAddress()).Generate() ?? 
        throw new DataException("No email address has been received from by random data source.");
  }

  public static string GenerateRandomJapanesePhoneNumber()
  {
    return RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = @"\d{10,11}" }).Generate() ?? 
        throw new DataException("No phone number has been received from by random data source.");
  }
  
}