namespace Client.StaticPreview;


using BusinessRules.Enterprise;
using MockDataSource;
using Newtonsoft.Json;


public class DummyDataForStaticPreviewPreparator
{

  private static readonly string OUTPUT_FILE_NAME_WITH_EXTENSION = "StaticPreviewDummyData.json";

  public static void Prepare()
  {
    
    MockDataSource mockDataSource = MockDataSource.GetInstance();

    DummyData dummyData = new(people: mockDataSource.People);
    
    StreamWriter streamWriter = new StreamWriter(
      path: Path.Combine(Directory.GetCurrentDirectory(), OUTPUT_FILE_NAME_WITH_EXTENSION), 
      append: false
    );
    
    streamWriter.Write(JsonConvert.SerializeObject(dummyData));
    
    streamWriter.Close();
  }


  private struct DummyData
  {
    private List<Person> people;

    public DummyData(List<Person> people)
    {
      this.people = people;
    }
  }
}
