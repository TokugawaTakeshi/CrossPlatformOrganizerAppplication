namespace Client.SharedGUI_Components.Cards.Task.Localizations;


internal record TaskCardEnglishLocalization() : TaskCardLocalization(
  
  badges:
  
      new TaskCardLocalization.Badges(
        date: "Date",
        dateTime: "Date and Time"
      )
  
);
