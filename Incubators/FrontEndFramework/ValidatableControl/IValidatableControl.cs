namespace FrontEndFramework.ValidatableControl;


public interface IValidatableControl
{
  
  IValidatableControl HighlightInvalidInput();
  
  
  IRootElementOffsetCoordinates GetRootElementOffsetCoordinates();

  struct IRootElementOffsetCoordinates
  {
    public uint top { get; init; }
    public uint left { get; init; }
  }
  
  
  IValidatableControl Focus();
  
  void ResetValidityHighlightingToInitial();

}