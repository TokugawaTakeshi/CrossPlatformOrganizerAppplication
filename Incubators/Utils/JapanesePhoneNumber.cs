using System.Text.RegularExpressions;
using YamatoDaiwaCS_Extensions;


namespace Utils;


public class JapanesePhoneNumber
{

  public static byte DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH = 4;

  public static readonly Regex VALID_PATTERN__WIHTOUT_DASHES = new(@"^\d{10,11}$"); 
  
  public static string Format(string phoneNumber)
  {
    string phoneNumber__digitsOnly = phoneNumber.RemoveAllSpecifiedCharacters(new[] {'-'});
    int firstNDashPosition = phoneNumber__digitsOnly.Length % JapanesePhoneNumber.DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH;
    int secondNDashPosition = firstNDashPosition + JapanesePhoneNumber.DIGITS_COUNT_IN_TWO_LAST_PORTIONS_DIVIDED_BY_NDASH;

    return $"{ phoneNumber__digitsOnly[..firstNDashPosition] }-" +
        $"{ phoneNumber__digitsOnly.Substring(firstNDashPosition, secondNDashPosition - firstNDashPosition) }-" +
        $"{ phoneNumber__digitsOnly[secondNDashPosition..] }";
  }

  public static bool IsValid(string potentialJapanesePhoneNumber)
  {
    return JapanesePhoneNumber.VALID_PATTERN__WIHTOUT_DASHES.IsMatch(
      potentialJapanesePhoneNumber.RemoveAllSpecifiedCharacters(new[] {'-'})
    );
  }
  
}