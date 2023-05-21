using FrontEndFramework.InputtedValueValidation;


namespace Client.Data.FromUser.Entities.Task;


public class TaskTitleInputtedDataValidation : InputtedValueValidation
{

  // TODO https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/41
  public override Func<object, bool> OmittedValueChecker =>
      rawValue => rawValue is String && String.IsNullOrEmpty((string)rawValue);

}