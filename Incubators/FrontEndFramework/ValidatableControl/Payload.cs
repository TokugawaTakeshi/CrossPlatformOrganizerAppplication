namespace FrontEndFramework.ValidatableControl;


using InputtedValueValidation = FrontEndFramework.InputtedValueValidation.InputtedValueValidation; 
using InputtedValueValidationResult = FrontEndFramework.InputtedValueValidation.Result;


public class Payload
{

  protected object? value;
  
  protected readonly InputtedValueValidation validation;
  
  protected InputtedValueValidationResult validationResult;

  protected Func<IValidatableControl> componentInstanceAccessor;
  
  public object? Value
  {
    get => this.value;
    set {
      this.value = value;
      this.validationResult = this.validation.Validate(this.value);
    }
  }


  public Payload(
    object initialValue, 
    InputtedValueValidation validation,
    Func<IValidatableControl> componentInstanceAccessor
  ) {
    
    this.value = initialValue;
    this.validation = validation;
    this.validationResult = this.validation.Validate(initialValue);
    this.componentInstanceAccessor = componentInstanceAccessor;

  }


  public bool IsInvalid => this.validationResult.IsValid;
  public string[] ValidationErrorsMessages => this.validationResult.ErrorsMessages;

  public TValue GetExpectedToBeValidValue<TValue>()
  {

    if (this.IsInvalid)
    {
      throw new Exception("Contrary os expectations, the value is invalid.");
    }


    if (this.Value is TValue narrowedValidValue)
    {
      return narrowedValidValue;
    }


    throw new Exception("The actual type is difference target one.");

  }


  public IValidatableControl GetComponentInstance()
  {

    IValidatableControl componentInstance = this.componentInstanceAccessor.Invoke();

    // if (componentInstance is null)
    // {
    //   throw new Exception("The \"componentInstanceAccessor\" is still \"null\"");
    // }

    
    return componentInstance;
    
  }
  
}