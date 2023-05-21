namespace FrontEndFramework.ValidatableControl;


using InputtedValueValidation = FrontEndFramework.InputtedValueValidation.InputtedValueValidation; 
using InputtedValueValidationResult = FrontEndFramework.InputtedValueValidation.Result;


public class Payload
{

  protected readonly string BLAZOR_REFERENCE_ID;
  
  protected string _value;
  
  protected readonly InputtedValueValidation validation;
  
  protected InputtedValueValidationResult validationResult;
  
  public string Value
  {
    get => _value;
    set {
      this._value = value;
      this.validationResult = this.validation.Validate(this._value);
    }
  }


  public Payload(
    string initialValue, 
    InputtedValueValidation validation,
    string? blazorReferenceID = null
  ) {
    
    this._value = initialValue;
    this.validation = validation;
    this.validationResult = this.validation.Validate(initialValue);

    this.BLAZOR_REFERENCE_ID = blazorReferenceID ?? Payload.generateAssociatedComponentBlazorReferenceID();

  }


  public bool IsInvalid => !this.validationResult.IsValid;

  public string[] ValidationErrorsMessages => this.validationResult.ErrorsMessages;

  public string GetExpectedToBeValidValue()
  {

    if (this.IsInvalid)
    {
      throw new Exception("Contrary os expectations, the value is invalid.");
    }


    return this.Value;

  }
  
  
  /* === Routines =================================================================================================== */
  /* --- IDs generating ------------------------------------------------------------------------------------------- */
  protected static uint counterForAssociatedComponentBlazorReferenceID_Generating = 0;

  protected static string generateAssociatedComponentBlazorReferenceID() {
    Payload.counterForAssociatedComponentBlazorReferenceID_Generating++;
    return $"VALIDATABLE_CONTROL-{ Payload.counterForAssociatedComponentBlazorReferenceID_Generating }";
  }
  
}