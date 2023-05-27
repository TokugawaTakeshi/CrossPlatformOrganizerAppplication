namespace FrontEndFramework.InputtedValueValidation;


public abstract class InputtedValueValidation
{

  protected readonly Func<object, bool> OmittedValueChecker;
  protected readonly Func<bool> RequirementChecker;

  
  public interface ILocalization
  {
    public string RequiredInputIsMissingValidationErrorMessage { get; }
  }

  public static ILocalization Localization = new InputtedValueValidationEnglishLocalization();

  protected readonly string RequiredInputIsMissingValidationErrorMessage;


  protected IRule[] StaticValidationRules;
  protected IRule[] ContextDependentRules;
  
  
  protected InputtedValueValidation(
    Func<object, bool> omittedValueChecker,
    bool? isInputRequired,
    Func<bool>? requirementChecker,
    string? requiredValueIsMissingValidationErrorMessage,
    IRule[]? staticRules,
    IRule[]? contextDependentRules
  )
  {
    
    OmittedValueChecker = omittedValueChecker;

    if (requirementChecker is not null)
    {
      
      RequirementChecker = requirementChecker;

      if (isInputRequired is not null)
      {
        throw new ArgumentException(
          "The \"requirementChecker\" and \"isInputRequired\" parameters are incompatible. " +
          "Please specify one of them."
        );
      }
      
    } else if (isInputRequired is not null)
    {
      RequirementChecker = () => (bool)isInputRequired;
    }
    else
    {
      throw new ArgumentException(
      "Either \"isInputRequired\" or \"requirementChecker\" must be specified (but not both)."
      );
    }
    
    
    this.RequiredInputIsMissingValidationErrorMessage =
        requiredValueIsMissingValidationErrorMessage ??
        InputtedValueValidation.Localization.RequiredInputIsMissingValidationErrorMessage;

    this.StaticValidationRules = staticRules ?? Array.Empty<IRule>();
    this.ContextDependentRules = contextDependentRules ?? Array.Empty<IRule>();

  }


  public Result Validate(object rawValue)
  {

    bool isInputRequired = this.RequirementChecker();
    
    if (this.OmittedValueChecker(rawValue))
    {
      return new Result()
      {
        IsValid = !isInputRequired,
        ErrorsMessages = isInputRequired ? 
            new[] { this.RequiredInputIsMissingValidationErrorMessage } :  
            Array.Empty<string>() 
            
      };
    }
    
    bool isValueStillValid = true;
    List<string> validationErrorsMessages = new ();

    foreach (IRule staticValidationRule in this.StaticValidationRules)
    {

      IRule.Result checkingResult = staticValidationRule.Check(rawValue);

      if (!checkingResult.IsValid)
      {

        isValueStillValid = false;
        validationErrorsMessages.Add(checkingResult.ErrorMessage);

        if (staticValidationRule.MustFinishValidationIfValueIsInvalid)
        {
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

}