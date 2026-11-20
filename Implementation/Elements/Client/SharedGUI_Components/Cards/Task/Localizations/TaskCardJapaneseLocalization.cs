namespace Client.SharedGUI_Components.Cards.Task.Localizations;


internal record TaskCardJapaneseLocalization() : TaskCardLocalization(
  
  badges:
  
      new TaskCardLocalization.Badges(
        date: "日付",
        dateTime: "日時"
      )
  
);