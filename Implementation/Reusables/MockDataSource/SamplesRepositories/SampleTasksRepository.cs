namespace MockDataSource.SamplesRepositories;


public abstract class SampleTasksRepository
{

  public static IEnumerable<CommonSolution.Entities.Task.Task> Tasks =>
  [

    /* ━━━ Incompleted ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    /* ┅┅┅ Full ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
    new()
    {
      ID = Guid.NewGuid().ToString(),
      title = "Full Task 1 / Associated Date",
      description = "This one has the deadline date",
      priority = 1,
      customFolder = SampleTasksCustomFoldersRepository.Notables.somedayMaybe,
      deadlineDate = new DateOnly(2025, 7, 30)
    },
    
    /* ━━━ Organized by Custom Folders ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    new()
    {
      ID = Guid.NewGuid().ToString(),
      title = "Check the email from bank",
      priority = 1,
      customFolder = SampleTasksCustomFoldersRepository.Notables.checkASAP
    },
    //
    // new()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Check the notification from the tax inspection",
    //   priority = 1,
    //   customFolder = SampleTasksCustomFoldersRepository.Notables.checkASAP
    // },
    //
    // new()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Modify the main visual of YDEE library",
    //   customFolder = SampleTasksCustomFoldersRepository.Notables.DependsOnExternalFactors.waitingForReply
    // },
    //
    // new()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Modify the main visual of YDF library",
    //   customFolder = SampleTasksCustomFoldersRepository.Notables.DependsOnExternalFactors.waitingForStateChange
    // },
    
    /* ━━━ Completed ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    new()
    {
      ID = Guid.NewGuid().ToString(),
      title = "Contact with advertisement agency",
      isCompleted = true
    }
    //- ━━━  TODO 棚卸 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    // new()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Full",
    //   description = "Find out what you can not do, than go and do it!",
    //   priority = 1,      
    //   deadlineDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
    // },
    //
    // new()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Has non-expired Deadline Date",
    //   deadlineDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
    //   priority = 1
    // },
    //
    // new ()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Has non-expired Deadline Date & Time",
    //   deadlineDateTime = DateTime.Today.AddDays(1),
    //   priority = 2
    // },
    //
    // new ()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Has Expired Deadline Date",
    //   deadlineDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
    // },
    //
    // new ()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "Has Expired Deadline Date & Time",
    //   deadlineDateTime = DateTime.Today.AddDays(-1)
    // },
    //
    // new ()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "With Starting Date but Without Ending Date (& Time)",
    //   startingDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
    // },
    //
    // new ()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "With Starting Date & Time but Without Ending Date (& Time)",
    //   startingDateTime = DateTime.Today.AddDays(-1)
    // },
    //
    // new ()
    // {
    //   ID = Guid.NewGuid().ToString(),
    //   title = "With Same Starting Date and Ending Date",
    //   startingDateTime = DateTime.Today,
    //   endingDateTime = DateTime.Today
    // }

  ];

}