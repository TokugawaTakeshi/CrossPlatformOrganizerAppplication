namespace FrontEndFramework.InputtedValueValidation;


public interface ContextDependentInputtedValueValidationRule {
 
  Func<Object, bool> Checker { get; init; }
 
  string ErrorMessage { get; init; }
 
  bool MustFinishValidationIfValueIsInvalid { get; init; }
 
}
