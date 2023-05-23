using FrontEndFramework.InputtedValueValidation;


namespace Client.Data.FromUser.Entities.Task;


public class TaskTitleInputtedDataValidation : InputtedValueValidation
{

  public TaskTitleInputtedDataValidation(
    bool? isInputRequired = null,
    Func<bool>? requirementChecker = null,
    string? requiredValueIsMissingValidationErrorMessage = null,
    IRule[]? staticRules = null,
    IRule[]? contextDependentRules = null
  ) : base(
    omittedValueChecker: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired ?? true,
    requirementChecker,
    requiredValueIsMissingValidationErrorMessage,
    staticRules,
    contextDependentRules
  ) {
    
  }
}