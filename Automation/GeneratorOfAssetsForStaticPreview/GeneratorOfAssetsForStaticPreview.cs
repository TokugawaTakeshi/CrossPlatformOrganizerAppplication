using System.Text.Json;
using CommonSolution.Entities;
using Task = CommonSolution.Entities.Task.Task;

using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using GeneratorOfAssetsForStaticPreview.CopiedClasses.Pages.Task.Management;
using GeneratorOfAssetsForStaticPreview.CopiedClasses.SharedComponents.Controls.TasksFilteringPanel;
using GeneratorOfAssetsForStaticPreview.CopiedClasses.SharedComponents.Viewers.Tasks;
using Newtonsoft.Json;


namespace GeneratorOfAssetsForStaticPreview;


public class GeneratorOfAssetsForStaticPreview
{

  private static readonly string SOLUTION_PATH = Path.GetFullPath(
    Path.Combine(Directory.GetCurrentDirectory(), "../../../../../")
  );

  
  public static void Main()
  {
    GeneratorOfAssetsForStaticPreview.GenerateDummyData();
    GeneratorOfAssetsForStaticPreview.GenerateBusinessRules();
    GeneratorOfAssetsForStaticPreview.GenerateStringResources();
  }


  /* ━━━ Business Rules ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static void GenerateBusinessRules()
  {
    
    JsonObject businessRules = new();
    
    businessRules.SetProperty("Task.Title.IS_REQUIRED", Task.Title.IS_REQUIRED);
    businessRules.SetProperty("Task.Title.MINIMAL_CHARACTERS_COUNT", Task.Title.MINIMAL_CHARACTERS_COUNT);
    businessRules.SetProperty("Task.Title.MAXIMAL_CHARACTERS_COUNT", Task.Title.MAXIMAL_CHARACTERS_COUNT);
    
    businessRules.SetProperty("Person.FamilyName.IS_REQUIRED", Person.FamilyName.IS_REQUIRED);
    businessRules.SetProperty(
      "Person.FamilyName.MINIMAL_CHARACTERS_COUNT", 
      Person.FamilyName.MAXIMAL_CHARACTERS_COUNT
    );
    
    StreamWriter streamWriter = new(
      path: Path.Combine(
        SOLUTION_PATH, 
        "Implementation", 
        "Elements", 
        "Client", 
        "StaticPreview",
        "BusinessRules.json"
      ), 
      append: false
    );
    
    streamWriter.Write(businessRules);
    streamWriter.Close();
    
  }
  

  /* ━━━ Dummy Data ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private record DummyData
  {
    public required List<Person> People { get; init; }
    public required List<Task> Tasks { get; init; }
  }

  private static void GenerateDummyData()
  {
    
    MockDataSource.MockDataSource mockDataSource = MockDataSource.MockDataSource.GetInstance();
    
    DummyData dummyData = new()
    {
      People = mockDataSource.People,
      Tasks = mockDataSource.Tasks
    };
    
    StreamWriter streamWriter = new(
      path: Path.Combine(
        SOLUTION_PATH, 
        "Implementation", 
        "Elements", 
        "Client", 
        "StaticPreview",
        "StaticPreviewDummyData.json"
      ), 
      append: false
    );
    
    streamWriter.Write(JsonConvert.SerializeObject(dummyData, Formatting.Indented));
    streamWriter.Close();
    
  }
  
  
  /* ━━━ String Resources ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static void GenerateStringResources()
  {

    JsonObject stringResources = new();
    
    GeneratorOfAssetsForStaticPreview.temp1(
      stringResources,
      new Dictionary<string, TasksManagementPageLocalization>
      {
        { "$english", new TasksManagementPageEnglishLocalization() },
        { "$japanese", new TasksManagementPageJapaneseLocalization() }
      }
    );

    GeneratorOfAssetsForStaticPreview.temp2(
      stringResources,
      new Dictionary<string, TasksViewerLocalization>
      {
        { "$english", new TasksViewerEnglishLocalization() },
        { "$japanese", new TasksViewerJapaneseLocalization() }
      }
    );
    
    TasksFilteringPanelLocalizationGeneratorForStaticPreview.Generate(
      stringResources,
      new Dictionary<string, TasksFilteringPanelLocalization>
      {
        { "$english", new TasksFilteringPanelEnglishLocalization() },
        { "$japanese", new TasksFilteringPanelJapaneseLocalization() }
      }
    );
    
    // PersonCardLocalization personCardEnglishLocalization = new PersonCardEnglishLocalization();
    // SharedStaticStrings sharedStaticEnglishStrings = SharedStaticEnglishStrings.SingleInstance;
    //
    // // Case 1 Simple
    // stringResources.SetProperty(
    //   "components.Cards.Person.$english.metadata.name", 
    //   personCardEnglishLocalization.metadata.name
    // );
    //
    // // Case 2 Template function
    // stringResources.SetProperty(
    //   "shared.$english.buildDataRetrievingOrSubmittingFailedPoliteMessage",
    //   sharedStaticEnglishStrings.buildDataRetrievingOrSubmittingFailedPoliteMessage("{{ dynamicPart }}")
    // );
    //
    // stringResources.SetProperty(
    //   "shared.$english.commonWords.unknown",
    //   sharedStaticEnglishStrings.commonWords.unknown
    // );
    //
    // stringResources.SetProperty(
    //   "shared.$english.commonWords.yearsOld",
    //   sharedStaticEnglishStrings.commonWords.yearsOld
    // );

    StreamWriter streamWriter = new(
      path: Path.Combine(
        SOLUTION_PATH, 
        "Implementation", 
        "Elements", 
        "Client", 
        "StaticPreview",
        "StringResourcesForStaticPreview.json"
      ), 
      append: false
    );
    
    streamWriter.Write(
      stringResources.ToJsonString(
        new JsonSerializerOptions
        {
          Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, 
          TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
          WriteIndented = true
        }
      )
    );
    
    streamWriter.Close();

  }

  // TODO Move 
  private static void temp1(
    JsonObject stringResources,
    Dictionary<string, TasksManagementPageLocalization> languageKeysAndLocalizations
  )
  {

    foreach (KeyValuePair<string, TasksManagementPageLocalization> entry in languageKeysAndLocalizations)
    {
      
      stringResources.SetProperty(
        $"{ entry.Key }.pages.task.management.filteringModalDialog.title", 
        entry.Value.filteringModalDialog.title
      );
      
      stringResources.SetProperty(
        $"{ entry.Key }.pages.task.management.taskManagerActivationGuidance", 
        entry.Value.taskManagerActivationGuidance
      );
      
    }
    
  }
  
  // TODO Move
  private static void temp2(
    JsonObject stringResources,
    Dictionary<string, TasksViewerLocalization> languageKeysAndLocalizations
  )
  {

    foreach (KeyValuePair<string, TasksViewerLocalization> entry in languageKeysAndLocalizations)
    {
      
      stringResources.SetProperty(
        $"{ entry.Key }.components.viewers.tasks.searchBox.placeholder", 
        entry.Value.searchBox.placeholder
      );
      
      stringResources.SetProperty(
        $"{ entry.Key }.components.viewers.tasks.searchBox.accessibilityGuidance", 
        entry.Value.searchBox.accessibilityGuidance
      );
      
    }
    
  }
  
}