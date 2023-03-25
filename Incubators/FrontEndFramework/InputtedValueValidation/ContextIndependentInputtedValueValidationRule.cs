namespace FrontEndFramework.InputtedValueValidation;


public interface ContextIndependentInputtedValueValidationRule {
 
  Func<Object, bool> Checker { get; init; }
 
  string ErrorMessage { get; init; }
 
  bool MustFinishValidationIfValueIsInvalid { get; init; }
 
}
