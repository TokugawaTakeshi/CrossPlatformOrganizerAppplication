using System.Data;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;


namespace Utils
{
  public abstract class RandomValuesGenerator
  {

    public static bool GetRandomBoolean()
    {
      return new Random().Next() > (Int32.MaxValue / 2);
    }

    public static byte GetRandomByte(byte minimalValue = Byte.MinValue, byte maximalValue = Byte.MaxValue)
    {
      return Convert.ToByte(new Random().Next(minValue: minimalValue, maxValue: maximalValue));
    }

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
}
