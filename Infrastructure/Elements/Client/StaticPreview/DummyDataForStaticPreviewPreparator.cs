using System.Diagnostics;
using Task = BusinessRules.Enterprise.Tasks.Task;

namespace Client.StaticPreview;


using BusinessRules.Enterprise;
using MockDataSource;
using Newtonsoft.Json;


public class DummyDataForStaticPreviewPreparator
{

  private static readonly string OUTPUT_FILE_NAME_WITH_EXTENSION = "StaticPreviewDummyData.json";

  // https://www.jetbrains.com/help/rider/Run_Debug_Configuration_dotNet_Static_Method.html
  public static void Prepare()
  {
    
    MockDataSource mockDataSource = MockDataSource.GetInstance();
    
    Debug.WriteLine(JsonConvert.SerializeObject(mockDataSource.People));

    DummyData dummyData = new()
    {
      people = mockDataSource.People,
      tasks = mockDataSource.Tasks
    };

    string projectPath = "D:\\IntelliJ IDEA\\Experiments\\ExperimentalNativeCSharpApplication\\Infrastructure\\Elements\\Client";
    
    StreamWriter streamWriter = new StreamWriter(
     path: Path.Combine(projectPath, "StaticPreview", OUTPUT_FILE_NAME_WITH_EXTENSION), 
     append: false
    );
    
    streamWriter.Write(JsonConvert.SerializeObject(dummyData));
    
    streamWriter.Close();

  }


  private struct DummyData
  {
    public List<Person> people;
    public List<Task> tasks;
  }
}
