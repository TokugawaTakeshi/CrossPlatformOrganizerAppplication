namespace FrontEndFramework.Exceptions;


public class CustomYDF_ThemeIsNotEnumerationException : ArgumentException
{
  public CustomYDF_ThemeIsNotEnumerationException(): base(
    message: "The custom themes must the be defined with enumeration."
  ) {}
}