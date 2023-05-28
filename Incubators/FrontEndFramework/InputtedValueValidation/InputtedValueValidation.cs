namespace FrontEndFramework.InputtedValueValidation;


public abstract class InputtedValueValidation
{

  public interface ILocalization
  {
    public string RequiredInputIsMissingValidationErrorMessage { get; }
  }

  public static ILocalization Localization = new InputtedValueValidationEnglishLocalization();

  
  protected readonly Func<object, bool> HasValueBeenOmitted;
  
  protected readonly Func<bool> IsInputRequired;
  protected readonly string RequiredInputIsMissingValidationErrorMessage;

  
  public interface IRule
  {
  
    public bool MustFinishValidationIfValueIsInvalid { get; init; }
  
    public CheckingResult Check(object rawValue);

    public struct CheckingResult
    {
      public string? ErrorMessage { get; init; }
      public bool IsValid => this.ErrorMessage is not null;
    }
  
  }
  
  protected IRule[] StaticRules;
  protected IRule[] ContextDependentRules;
  
  
  protected InputtedValueValidation(
    Func<object, bool> hasValueBeenOmitted,
    bool? isInputRequired = null,
    Func<bool>? inputRequirementChecker = null,
    string? requiredInputIsMissingValidationErrorMessage = null,
    IRule[]? staticRules = null,
    IRule[]? contextDependentRules = null
  )
  {
    
    HasValueBeenOmitted = hasValueBeenOmitted;

    if (isInputRequired is not null)
    {
      
      IsInputRequired = () => (bool)isInputRequired;

      if (inputRequirementChecker is not null)
      {
        throw new ArgumentException(
          "The \"isInputRequired\" and \"inputRequirementChecker\" parameters are incompatible. " +
          "Please specify one of them."
        );
      }
      
    } else if (inputRequirementChecker is not null)
    {
      IsInputRequired = inputRequirementChecker;
    } else
    {
      throw new ArgumentException(
      "Either \"isInputRequired\" or \"inputRequirementChecker\" must be specified (but not both)."
      );
    }
    
    this.RequiredInputIsMissingValidationErrorMessage =
        requiredInputIsMissingValidationErrorMessage ??
        InputtedValueValidation.Localization.RequiredInputIsMissingValidationErrorMessage;

    
    this.StaticRules = staticRules ?? Array.Empty<IRule>();
    this.ContextDependentRules = contextDependentRules ?? Array.Empty<IRule>();
    
    // TODO 【 次のプールリクエスト以降 】 AsynchronousRules
    // TODO 【 次のプールリクエスト以降 】　SsynchronousChecksCallback

  }


  public Result Validate(object rawValue)
  {

    bool isInputRequired = this.IsInputRequired();
    
    if (this.HasValueBeenOmitted(rawValue))
    {
      return new Result()
      {
        ErrorsMessages = isInputRequired ? new[] { this.RequiredInputIsMissingValidationErrorMessage } : Array.Empty<string>() 
      };
    }
    
    
    List<string> validationErrorsMessages = new ();

    foreach (IRule staticValidationRule in this.StaticRules)
    {

      IRule.CheckingResult checkingCheckingResult = staticValidationRule.Check(rawValue);

      if (checkingCheckingResult.ErrorMessage is not null)
      {

        validationErrorsMessages.Add(checkingCheckingResult.ErrorMessage);

        if (staticValidationRule.MustFinishValidationIfValueIsInvalid)
        {
          break;
        }

      }
    }
    
    if (validationErrorsMessages.Count > 0)
    {
      return new Result()
      {
        ErrorsMessages = validationErrorsMessages.ToArray()
      };
    }
    
    
    foreach (IRule contextDependentValidationRule in this.ContextDependentRules)
    {

      IRule.CheckingResult checkingCheckingResult = contextDependentValidationRule.Check(rawValue);

      if (checkingCheckingResult.ErrorMessage is not null)
      {

        validationErrorsMessages.Add(checkingCheckingResult.ErrorMessage);

        if (contextDependentValidationRule.MustFinishValidationIfValueIsInvalid)
        {
          break;
        }

      }
    }
    
    if (validationErrorsMessages.Count > 0)
    {
      return new Result()
      {
        ErrorsMessages = validationErrorsMessages.ToArray()
      };
    }


    this.executeAsynchronousValidationIfAny(rawValue);
    
    
    return new Result()
    {
      ErrorsMessages = Array.Empty<string>()
    };

  }


  protected void executeAsynchronousValidationIfAny(object rawValue)
  {
    // TODO 【 次のプールリクエスト以降 】　Async validation errors
  }
  
}