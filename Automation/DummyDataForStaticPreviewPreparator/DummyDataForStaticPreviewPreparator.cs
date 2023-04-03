using CommonSolution.Entities;
using Newtonsoft.Json;
using Task = CommonSolution.Entities.Task;


namespace DummyDataForStaticPreviewPreparator;


public class DummyDataForStaticPreviewPreparator
{

  private static readonly string OUTPUT_FILE_NAME_WITH_EXTENSION = "StaticPreviewDummyData.json";

  // https://www.jetbrains.com/help/rider/Run_Debug_Configuration_dotNet_Static_Method.html
  public static void Main()
  {
    
    MockDataSource.MockDataSource mockDataSource = MockDataSource.MockDataSource.GetInstance();

    DummyData dummyData = new()
    {
      People = mockDataSource.People,
      Tasks = mockDataSource.Tasks
    };
    
    string solutionPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../"));
    
    StreamWriter streamWriter = new(
      path: Path.Combine(solutionPath, "Infrastructure", "Elements", "Client", "StaticPreview"), 
      append: false
    );

    streamWriter.Write(JsonConvert.SerializeObject(dummyData));
    
    streamWriter.Close();

  }


  private struct DummyData
  {
    public required List<Person> People { get; init; }
    public required List<Task> Tasks { get; init; }
  }
  
}