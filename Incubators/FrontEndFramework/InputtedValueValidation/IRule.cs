namespace FrontEndFramework.InputtedValueValidation;


public interface IRule
{
  
  public bool MustFinishValidationIfValueIsInvalid { get; init; }
  
  public Result Check(object rawValue);

  public struct Result
  {
    public bool IsValid { get; init; }
    public string? ErrorMessage { get; init; }
  }
  
  
}