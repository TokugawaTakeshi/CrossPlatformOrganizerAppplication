using FrontEndFramework.InputtedValueValidation;


namespace Client.Data.FromUser.Entities.Task;


public class TaskDescriptionInputtedDataValidation : InputtedValueValidation
{
  
  public TaskDescriptionInputtedDataValidation(
    bool? isInputRequired,
    Func<bool>? requirementChecker,
    string? requiredValueIsMissingValidationErrorMessage,
    IRule[]? staticRules,
    IRule[]? contextDependentRules = null
  ) : base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired ?? true,
    requirementChecker,
    requiredValueIsMissingValidationErrorMessage,
    staticRules,
    contextDependentRules
  ) {
    
  }
  
}