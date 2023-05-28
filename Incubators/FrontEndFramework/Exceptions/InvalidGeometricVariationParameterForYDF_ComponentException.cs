namespace FrontEndFramework.Exceptions;


public class InvalidGeometricVariationParameterForYDF_ComponentException : ArgumentException
{

  public InvalidGeometricVariationParameterForYDF_ComponentException(): base(
    message: 
      "The value of the \"geometry\" attribute (which is also the Blazor component parameter) must be either the element " +
      "of \"StandardGeometricVariations\" enumeration or element of custom enumeration preliminary registered via " +
      "\"defineCustomGeometricVariations\" static method while specified value is neither of."
  ) {
    
  }

}