namespace UtilsIncubator;


public static class StringExtensions
{

  public static bool IsNonEmpty(this string self)
  {
    return !String.IsNullOrEmpty(self);
  }
  
}