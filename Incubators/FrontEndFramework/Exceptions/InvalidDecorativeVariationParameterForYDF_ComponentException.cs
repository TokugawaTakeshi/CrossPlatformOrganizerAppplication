namespace FrontEndFramework.Exceptions;


public class InvalidDecorativeVariationParameterForYDF_ComponentException : ArgumentException
{

  public InvalidDecorativeVariationParameterForYDF_ComponentException(): base(
    message: 
      "The value of the \"decoration\" attribute (which is also the Blazor component parameter) must be either the element " +
      "of \"StandardDecorativeVariations\" enumeration or element of custom enumeration preliminary registered via " +
      "\"defineCustomGeometricVariations\" static method while specified value is neither of."
  ) {
    
  }

}