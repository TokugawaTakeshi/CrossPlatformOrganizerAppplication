namespace FrontEndFramework.InputtedValueValidation;


public abstract class InputtedValueValidation
{

  // TODO https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/41
  public abstract Func<object, bool> OmittedValueChecker { get; }
  
  
  // TODO ① どちらか必須、両方はダメ
  public bool? IsInputRequired { protected get; init; }
  public Func<bool>? RequirementChecker { protected get; init; }

  public string RequiredInputIsMissingValidationErrorMessage { protected get; init; } = 
      "This filed is required. Please fill it."; // TODO Localization

  public Dictionary<string, ContextIndependentInputtedValueValidationRule> ContextIndependentInputtedValueValidationRules
  {
    protected get; init;
  } = new();

  public Dictionary<string, ContextDependentInputtedValueValidationRule> ContextDependentInputtedValueValidationRule
  {
    protected get; init;
  } = new();

  
  // TODO ① 
  private bool _isInputRequired
  {
    get
    {
    
      if (this.IsInputRequired is not null)
      {
        // TODO ?? falseは論理上予定
        return this.IsInputRequired　?? false;
      }


      if (this.RequirementChecker is not null)
      {
        return this.RequirementChecker();
      }


      return false;
      
    }
    
  }
  

  public Result Validate(object rawValue)
  {

    if (this.OmittedValueChecker(rawValue))
    {
      return new Result()
      {
        IsValid = !this._isInputRequired,
        ErrorsMessages = this._isInputRequired ? 
            Array.Empty<string>() : 
            new[] { this.RequiredInputIsMissingValidationErrorMessage }
      };
    }
    
    
    bool isValueStillValid = true;
    List<string> validationErrorsMessages = new ();
    
    foreach (
      ContextIndependentInputtedValueValidationRule contextIndependentInputtedValueValidationRule in 
      this.ContextIndependentInputtedValueValidationRules.Values
    ) {
 
      if (!contextIndependentInputtedValueValidationRule.Checker(rawValue)) {
 
        isValueStillValid = false;
        validationErrorsMessages.Add(contextIndependentInputtedValueValidationRule.ErrorMessage);
 
        if (contextIndependentInputtedValueValidationRule.MustFinishValidationIfValueIsInvalid) {
          break;
        }
 
      }
 
    }

    if (!isValueStillValid)
    {
      return new Result()
      {
        IsValid = false,
        ErrorsMessages = validationErrorsMessages.ToArray()
      };
    }
    
    
    foreach (
      ContextDependentInputtedValueValidationRule contextDependentInputtedValueValidationRule in 
      this.ContextIndependentInputtedValueValidationRules.Values
    ) {
 
      if (!contextDependentInputtedValueValidationRule.Checker(rawValue)) {
 
        isValueStillValid = false;
        validationErrorsMessages.Add(contextDependentInputtedValueValidationRule.ErrorMessage);
 
        if (contextDependentInputtedValueValidationRule.MustFinishValidationIfValueIsInvalid) {
          break;
        }
 
      }
 
    }

    if (!isValueStillValid)
    {
      return new Result()
      {
        IsValid = false,
        ErrorsMessages = validationErrorsMessages.ToArray()
      };
    }
    
    
    return new Result()
    {
      IsValid = true,
      ErrorsMessages = Array.Empty<string>()
    };
    
  }

  
  /* === Localization =============================================================================================== */
  public interface ILocalization
  {
    public string RequiredInputIsMissingValidationErrorMessage { get; }
  }

  public static ILocalization localization = new InputtedValueValidationEnglishLocalization();

}