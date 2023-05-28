namespace Utils;


public class JapanesePhoneNumber
{

  public static byte DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH = 4;
  
  
  public static string Format(string phoneNumber)
  {
    string phoneNumber__digitsOnly = phoneNumber.RemoveAllSpecifiedCharacters(new[] {'-'});
    int firstNDashPosition = phoneNumber__digitsOnly.Length % JapanesePhoneNumber.DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH;
    int secondNDashPosition = firstNDashPosition + JapanesePhoneNumber.DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH;

    return $"{ phoneNumber__digitsOnly[..firstNDashPosition] }-" +
        $"{ phoneNumber__digitsOnly.Substring(firstNDashPosition, secondNDashPosition - firstNDashPosition) }-" +
        $"{ phoneNumber__digitsOnly[secondNDashPosition..] }";
  }
  
}