namespace Utils;


public static class DateOnlyExtensions
{
  
  public static DateOnly CreateDateOnlyFromISO8601_String(string ISO8601_String) {
    DateTime dateTime = DateTime.Parse(ISO8601_String, null, System.Globalization.DateTimeStyles.RoundtripKind);
    return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
  }

  public static string ToISO8601_String(this DateOnly self) {
    return self.ToString("yyyy-MM-dd");
  }
  
}