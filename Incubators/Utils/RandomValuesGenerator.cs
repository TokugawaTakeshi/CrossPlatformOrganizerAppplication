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
      return RandomizerFactory.GetRandomizer(new FieldOptionsEmailAddress()).Generate();
    }

    public static string GenerateRandomJapanesePhoneNumber()
    {
      return RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = @"\d{10,11}" }).Generate();
    }
  }
}
