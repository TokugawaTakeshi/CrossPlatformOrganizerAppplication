namespace FrontEndFramework.InputtedValueValidation;


public struct Result
{
  public bool IsValid { get; init; }
  public string[] ErrorsMessages { get; init; }
}