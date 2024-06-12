namespace MockDataSource.SamplesRepositories;


public abstract class SampleTasksRepository
{

  public static IEnumerable<CommonSolution.Entities.Task> Tasks => new[]
  {
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "Full",
      description = "Find out what you can not do, than go and do it!",
      priority = 1,      
      deadlineDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
    },
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "Has non-expired Deadline Date",
      deadlineDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
      priority = 1
    },
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "Has non-expired Deadline Date & Time",
      deadlineDateTime = DateTime.Today.AddDays(1),
      priority = 2
    },
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "Has Expired Deadline Date",
      deadlineDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
    },
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "Has Expired Deadline Date & Time",
      deadlineDateTime = DateTime.Today.AddDays(-1)
    },
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "With Starting Date but Without Ending Date (& Time)",
      startingDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
    },

    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "With Starting Date & Time but Without Ending Date (& Time)",
      startingDateTime = DateTime.Today.AddDays(-1)
    },
    
    new CommonSolution.Entities.Task
    {
      ID = Guid.NewGuid().ToString(),
      title = "With Same Starting Date and Ending Date",
      startingDateTime = DateTime.Today,
      endingDateTime = DateTime.Today
    },
    
  };

}