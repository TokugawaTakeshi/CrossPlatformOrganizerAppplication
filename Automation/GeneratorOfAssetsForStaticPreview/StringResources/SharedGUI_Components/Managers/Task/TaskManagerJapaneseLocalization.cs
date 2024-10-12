/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Task;


internal record TaskManagerJapaneseLocalization : TaskManagerLocalization
{
  
  internal override string heading { get; } = "タスクマネージャー";
  
  internal override Buttons buttons { get; init; } = new()
  {
    taskEditing = new CommonStringResources.ButtonWithVisibleLabel { label = "課題を編集"},
    taskDeleting = new CommonStringResources.ButtonWithVisibleLabel { label = "課題を削除"},
    taskSaving = new CommonStringResources.ButtonWithVisibleLabel { label = "課題を保存"},
    terminatingOfEditing = new CommonStringResources.ButtonWithVisibleLabel { label = "編集停止"}
  };
  
  internal override Labels labels { get; init; } = new()
  {
    title = "見出し",
    status = "状態",
    priority = "優先順位",
    description = "詳細"
  };
  
  internal override TaskStatuses taskStatuses { get; init; } = new()
  {
    inProgress = "未完了",
    completed = "完了"
  };
  
  internal override TasksPriorities tasksPriorities { get; init; } = new()
  {
    one = "1 （今直ぐやる）",
    two = "2 （今直ぐやる課題が終わってから）",
    three = "3 （時間があれば）"
  };
  
  internal override Inputs inputs { get; } = new()
  {
    taskTitle = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "見出し",
      guidance = $"見出しを**{ CommonSolution.Entities.Task.Task.Title.MINIMAL_CHARACTERS_COUNT }~" + 
          $"{ CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT }**文字内入力して下さい。" 
          
    },
    taskDescription = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "記述",
      guidance = $"詳細を**{ CommonSolution.Entities.Task.Task.Description.MINIMAL_CHARACTERS_COUNT }文字以上**" + 
          "入力して下さい。" 
    }
  };
  
  internal override CommonStringResources.ModalDialog taskDeletingConfirmationModalDialog { get; init; } = new()
  {
    title = "削除確認",
    question = "この人の削除で宜しいでしょうか。"
  };
  
}