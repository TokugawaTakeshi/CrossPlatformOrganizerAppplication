using System.Text.Json.Nodes;


using Locale = string;


namespace GeneratorOfAssetsForStaticPreview.CopiedClasses.SharedComponents.Controls.TasksFilteringPanel;


internal abstract class TasksFilteringPanelLocalizationGeneratorForStaticPreview
{

  private const string COMMON_PATH = "components.controls.tasksFilteringPanel";
  
  public static void Generate(
    JsonObject outputObjectWorkpiece,
    Dictionary<Locale, TasksFilteringPanelLocalization> languageKeysAndLocalizations
  )
  {

    foreach (KeyValuePair<Locale,TasksFilteringPanelLocalization> entry in languageKeysAndLocalizations)
    {
      
      outputObjectWorkpiece.SetProperty(
        $"{ entry.Key }.${ COMMON_PATH }.titles.summary",
        entry.Value.titles.summary
      );
      
      outputObjectWorkpiece.SetProperty(
        $"{ entry.Key }.${ COMMON_PATH }.titles.custom",
        entry.Value.titles.custom
      );
      
      outputObjectWorkpiece.SetProperty(
        $"{ entry.Key }.${ COMMON_PATH }.summaryCategories.all",
        entry.Value.titles.custom
      );
      
      outputObjectWorkpiece.SetProperty(
        $"{ entry.Key }.${ COMMON_PATH }.summaryCategories.associatedWithDateAndTime",
        entry.Value.titles.custom
      );
      
      outputObjectWorkpiece.SetProperty(
        $"{ entry.Key }.${ COMMON_PATH }.summaryCategories.associatedWithDate",
        entry.Value.titles.custom
      );
      
    }
    
  }
  
}