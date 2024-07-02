using CommonSolution.Entities.Task;

namespace MockDataSource.SamplesRepositories;


public abstract class SampleTasksCustomFoldersRepository
{

  public abstract class Notables
  {
    
    TaskCustomFolder checkASAP = new()
    {
      ID = Guid.NewGuid().ToString(),
      title = "Check ASAP",
      order = 1
    };
    
    TaskCustomFolder somedayMaybe = new()
    {
      ID = Guid.NewGuid().ToString(),
      title = "Someday / Maybe",
      order = 2
    };
    
    TaskCustomFolder atTrain = new()
    {
      ID = Guid.NewGuid().ToString(),
      title = "At Train",
      order = 2
    };
    
  }
    
}