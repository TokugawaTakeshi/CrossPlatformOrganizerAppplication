namespace FrontEndFramework.Exceptions;


public class CustomYDF_GeometricVariationIsNotEnumerationException : ArgumentException
{
  public CustomYDF_GeometricVariationIsNotEnumerationException() : base(
    message: "The custom geometric variations must the be defined with enumeration."
  ) {}
}