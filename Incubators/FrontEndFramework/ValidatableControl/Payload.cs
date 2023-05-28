namespace FrontEndFramework.ValidatableControl;


using InputtedValueValidation = FrontEndFramework.InputtedValueValidation.InputtedValueValidation; 
using InputtedValueValidationResult = FrontEndFramework.InputtedValueValidation.Result;


public class Payload<TValue, TValidation> where TValidation: InputtedValueValidation
{

  protected readonly string BLAZOR_REFERENCE_ID;
  
  protected TValue value;
  
  protected readonly TValidation validation;
  
  protected InputtedValueValidationResult validationResult;
  
  public TValue Value
  {
    get => this.value;
    set {
      this.value = value;
      this.validationResult = this.validation.Validate(this.value);
    }
  }


  public Payload(
    TValue initialValue, 
    TValidation validation,
    string? blazorReferenceID = null
  ) {
    
    this.value = initialValue;
    this.validation = validation;
    this.validationResult = this.validation.Validate(initialValue);

    this.BLAZOR_REFERENCE_ID = blazorReferenceID ?? generateAssociatedComponentBlazorReferenceID();

  }


  public bool IsInvalid => !this.validationResult.IsValid;
  public string[] ValidationErrorsMessages => this.validationResult.ErrorsMessages;

  public TValue GetExpectedToBeValidValue()
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