namespace Client.StaticPreview;


using BusinessRules.Enterprise;
using MockDataSource;
using Newtonsoft.Json;


public class DummyDataForStaticPreviewPreparator
{

  public static void Prepare()
  {
    
    MockDataSource mockDataSource = MockDataSource.GetInstance();

    DummyData dummyData = new(people: mockDataSource.People);
    
    StreamWriter streamWriter = new StreamWriter(path: "StaticPreviewDummyData.json", append: false);
    
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
