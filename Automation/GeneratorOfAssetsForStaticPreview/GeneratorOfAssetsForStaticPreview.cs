using CommonSolution.Entities;
using Task = CommonSolution.Entities.Task;

using System.Text.Json.Nodes;
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

  }


  /* ━━━ Business Rules ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static void GenerateBusinessRules()
  {
    
    JsonObject businessRules = new();
    
    businessRules.SetProperty("Task.Title.IS_REQUIRED", Task.Title.IS_REQUIRED);
    businessRules.SetProperty("Task.Title.MINIMAL_CHARACTERS_COUNT", Task.Title.MINIMAL_CHARACTERS_COUNT);
    businessRules.SetProperty("Task.Title.MAXIMAL_CHARACTERS_COUNT", Task.Title.MAXIMAL_CHARACTERS_COUNT);
    
    businessRules.SetProperty("Person.FamilyName.IS_REQUIRED", Person.FamilyName.IS_REQUIRED);
    businessRules.SetProperty("Person.FamilyName.MINIMAL_CHARACTERS_COUNT", Person.FamilyName.MAXIMAL_CHARACTERS_COUNT);
    
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
  

  /* ━━━ Dummy Date ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
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
    
    streamWriter.Write(JsonConvert.SerializeObject(dummyData));
    streamWriter.Close();
    
  }
  
}