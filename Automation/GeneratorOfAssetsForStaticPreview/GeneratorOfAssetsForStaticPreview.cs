using CommonSolution.Entities;
using CommonSolution.Entities.Task;
using System.Text.Json.Nodes;
using CommonSolution.Fundamentals;
using GeneratorOfAssetsForStaticPreview.StringResources.Pages.Person.Management;
using GeneratorOfAssetsForStaticPreview.StringResources.Pages.Task.Management;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Lists.TasksFolders;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Lists.TasksFolders.Item;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Person;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Task;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.TasksFolders;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.People;
using GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.Tasks;
using MockDataSource;
using MockDataSource.SamplesRepositories;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.PugCSharpStaticPreview;


namespace GeneratorOfAssetsForStaticPreview;


internal class GeneratorOfAssetsForStaticPreview : AssetsProviderForStaticPreview
{

  private GeneratorOfAssetsForStaticPreview(): base(
    staticPreviewAbsolutePath: Path.GetFullPath(
      Path.Combine(Directory.GetCurrentDirectory(), "../../../../../Implementation/Elements/Client/StaticPreview")
    ),
    businessRulesOutputFileNameWithExtension: "BusinessRules.json",
    dataOutputFileNameWithExtension: "StaticPreviewMockData.json",
    stringResourcesOutputFileNameWithExtension: "StringResourcesForStaticPreview.json"
  )
  {}

  
  public static void Main()
  {
    new GeneratorOfAssetsForStaticPreview().GenerateAccess();
  }


  /* ━━━ Business Rules ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override System.Text.Json.Nodes.JsonObject GenerateBusinessRules()
  {
    return new JsonObject().SetProperties(
      new Dictionary<string, object>
      {
        { "Genders.Male", Genders.Male },
        { "Genders.Female", Genders.Female },
        { "Task.Title.IS_REQUIRED", CommonSolution.Entities.Task.Task.Title.IS_REQUIRED },
        { "Task.Title.MINIMAL_CHARACTERS_COUNT", CommonSolution.Entities.Task.Task.Title.MINIMAL_CHARACTERS_COUNT },
        { "Task.Title.MAXIMAL_CHARACTERS_COUNT", CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT },
        { "Person.FamilyName.IS_REQUIRED", Person.FamilyName.IS_REQUIRED },
        { "Person.FamilyName.MINIMAL_CHARACTERS_COUNT", Person.FamilyName.MAXIMAL_CHARACTERS_COUNT }
      }  
    );
  }
  

  /* ━━━ Dummy Data ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private record MockData
  {
    public required List<Person> people { get; init; }
    public required List<CommonSolution.Entities.Task.Task> tasks { get; init; }
    public required SerializableHierarchicalCollectionData<TaskCustomFolder> taskCustomFolders { get; init; }
  }

  protected override object GenerateData()
  {

    MockData mockData = new()
    {
      people = MockDataSource.MockDataSource.People,
      tasks = MockDataSource.MockDataSource.Tasks,
      taskCustomFolders = new SerializableHierarchicalCollectionData<TaskCustomFolder>
      {
        items = SampleTasksCustomFoldersRepository.taskCustomFolders.ToArray(),
        hierarchicalRelationshipsMap = SampleTasksCustomFoldersRepository.hierarchicalRelationshipsMap.ToPlainDictionary(),
        ID_PROPERTY_KEY = nameof(TaskCustomFolder.ID),
        PARENT_PROPERTY_KEY = nameof(TaskCustomFolder.parent),
        LIST_OF_CHILDREN_PROPERTY_KEY = nameof(TaskCustomFolder.children)
      }
    };

    return mockData;
    
  }
  
  
  /* ━━━ String Resources ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override System.Text.Json.Nodes.JsonObject GenerateStringResources()
  {

    JsonObject stringResources = new();

    PeopleManagementPageLocalizationGeneratorForStaticPreview.Generate(stringResources);
    TasksManagementPageLocalizationGeneratorForStaticPreview.Generate(stringResources);

    TasksFoldersListLocalizationGeneratorForStaticPreview.Generate(stringResources);
    TasksFoldersListItemLocalizationGeneratorForStaticPreview.Generate(stringResources);
    
    TasksFilteringPanelLocalizationGeneratorForStaticPreview.Generate(stringResources);
    TasksFoldersManagerLocalizationGeneratorForStaticPreview.Generate(stringResources);
    
    TasksViewerLocalizationGeneratorForStaticPreview.Generate(stringResources);
    PeopleViewerLocalizationGeneratorForStaticPreview.Generate(stringResources);
    
    TaskManagerLocalizationGeneratorForStaticPreview.Generate(stringResources);
    PersonManagerLocalizationGeneratorForStaticPreview.Generate(stringResources);

    return stringResources;

  }
  
}