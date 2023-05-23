using Microsoft.AspNetCore.Components;

namespace FrontEndFramework.ValidatableControl;

public interface IValidatableControl
{
  
  IValidatableControl HighlightInvalidInput();
  
  ElementReference GetRootElement();

  IValidatableControl Focus();
  
  void ResetStateToInitial();

}