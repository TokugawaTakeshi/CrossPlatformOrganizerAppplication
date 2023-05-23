using System.Reflection;


namespace FrontEndFramework.InputtedValueValidation;


public class ValidatableControlsGroup
{

  public static bool HasInvalidInputs(object controlsPayload)
  {

    Type parameterType = controlsPayload.GetType();

    foreach (FieldInfo fieldInfo in parameterType.GetFields())
    {

      object? potentialControlPayload = fieldInfo.GetValue(controlsPayload); 
      
      if (potentialControlPayload is not ValidatableControl.Payload controlPayload)
      {
        throw new ArgumentException(
          "The controlsPayload must be tuple with values of \"ValidatableControl.Payload\" type."
        );
      }

      
      if (controlPayload.IsInvalid)
      {
        return true;
      }
      
    }
    
    return false;
    
  }

  public static void PointOutValidationErrors(
    object controlsPayload, string scrollingContainerHTML_ID
  ) {

    Type parameterType = controlsPayload.GetType();
    bool isCurrentControlTheFirstInvalidOne = true;
    

    foreach (FieldInfo fieldInfo in parameterType.GetFields())
    {

      object? potentialControlPayload = fieldInfo.GetValue(controlsPayload); 
      
      if (potentialControlPayload is not ValidatableControl.Payload controlPayload)
      {
        throw new ArgumentException(
          "The controlsPayload must be tuple with values of \"ValidatableControl.Payload\" type."
        );
      }


      if (!controlPayload.IsInvalid)
      {
        continue;
      }
      
    }
    
    
  }
  
}