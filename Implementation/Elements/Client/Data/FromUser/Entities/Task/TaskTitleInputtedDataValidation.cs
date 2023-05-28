using FrontEndFramework.InputtedValueValidation;


namespace Client.Data.FromUser.Entities.Task;


public class TaskTitleInputtedDataValidation : InputtedValueValidation
{

  public TaskTitleInputtedDataValidation(
    bool? isInputRequired = null,
    Func<bool>? requirementChecker = null,
    string? requiredInputIsMissingValidationErrorMessage = null,
    IRule[]? staticRules = null,
    IRule[]? contextDependentRules = null
  ) : base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired ?? true,
    requirementChecker,
    requiredInputIsMissingValidationErrorMessage,
    staticRules,
    contextDependentRules
  ) {
    
  }
}