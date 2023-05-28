namespace FrontEndFramework.InputtedValueValidation;


public struct Result
{
  public string[] ErrorsMessages { get; init; }
  public bool IsValid => this.ErrorsMessages.Length > 0;
}
