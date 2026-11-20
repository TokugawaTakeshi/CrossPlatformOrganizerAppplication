namespace Client.SharedGUI_Components.Managers.TasksFolders;


public partial class TasksFoldersManager : YamatoDaiwa.Frontend.GUI_Components.Controls.Validatables.InputtableControl 
{
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
}