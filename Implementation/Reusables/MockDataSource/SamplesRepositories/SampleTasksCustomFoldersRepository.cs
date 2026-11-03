using CommonSolution.Entities.Task;


namespace MockDataSource.SamplesRepositories;


public abstract class SampleTasksCustomFoldersRepository
{
  
  public static readonly List<TaskCustomFolder> taskCustomFolders = [];

  public static readonly HierarchicalRelationshipsMap hierarchicalRelationshipsMap = [];
  
  public static void SetRelationships()
  {
    HierarchicalRelationshipsMap.SetRelationshipsForCollection(
      items: SampleTasksCustomFoldersRepository.taskCustomFolders,
      hierarchicalRelationshipsMap: SampleTasksCustomFoldersRepository.hierarchicalRelationshipsMap,
      ID_PropertyKey: nameof(TaskCustomFolder.ID),
      parentPropertyKey: nameof(TaskCustomFolder.parent),
      childrenListPropertyKey: nameof(TaskCustomFolder.children)
    );
  } 
  
  private static TaskCustomFolder registerOne(
    TaskCustomFolder targetTaskCustomFolder,
    HierarchicalRelationshipsMap? parent_sRelationshipsMap = null
  )
  {
    SampleTasksCustomFoldersRepository.taskCustomFolders.Add(targetTaskCustomFolder);
    parent_sRelationshipsMap?.Add(targetTaskCustomFolder.ID, new HierarchicalRelationshipsMap());
    return targetTaskCustomFolder;
  }
  
  
  /* ━━━ Order Counter ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract class OrderCounter
  {
    
    /* [ Approach ] For counting with 1, the elements' count is more than levels  */
    private static readonly Dictionary<uint, uint> countersByLevels = [];

    public static uint incrementForLevelAndGetValue(uint targetLevel_numerationFrom1)
    {

      if (!OrderCounter.countersByLevels.TryGetValue(targetLevel_numerationFrom1, out uint _))
      {
        OrderCounter.countersByLevels.Add(targetLevel_numerationFrom1, 0);
      }
      
      return ++OrderCounter.countersByLevels[targetLevel_numerationFrom1];
      
    }
    
    public static uint resetForLevelThenIncrementAndGetValue(uint targetLevel_numerationFrom1)
    {
      OrderCounter.countersByLevels[targetLevel_numerationFrom1] = 0;
      return OrderCounter.incrementForLevelAndGetValue(targetLevel_numerationFrom1);
    }
    
  }
  
  public static class Notables
  {

    static Notables()
    {
      EagerStaticInitialization.InitializeDecoratedRecursively(typeof(SampleTasksCustomFoldersRepository.Notables));
    }
    
    /* ━━━ Check ASAP ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    public static readonly TaskCustomFolder checkASAP = SampleTasksCustomFoldersRepository.registerOne(
      new TaskCustomFolder
      {
        ID = Guid.NewGuid().ToString(),
        label = "Check ASAP",
        orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(1)
      }
    );
    
    
    /* ━━━ Someday Maybe ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    public static readonly TaskCustomFolder somedayMaybe = SampleTasksCustomFoldersRepository.registerOne(
      new TaskCustomFolder
      {
        ID = Guid.NewGuid().ToString(),
        label = "Someday / Maybe",
        orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(1)
      }
    );
    
    
    /* ━━━ During Waiting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    public static readonly TaskCustomFolder duringWaiting = SampleTasksCustomFoldersRepository.registerOne(
      new TaskCustomFolder
      {
        ID = Guid.NewGuid().ToString(),
        label = "During Waiting",
        orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(1)
      },
      SampleTasksCustomFoldersRepository.hierarchicalRelationshipsMap
    );
    
    [EagerStaticInitialization]
    public static class DuringWaiting
    {
    
      public static readonly HierarchicalRelationshipsMap hierarchicalRelationshipsMap = 
          SampleTasksCustomFoldersRepository.hierarchicalRelationshipsMap[Notables.duringWaiting.ID];
      
    
      /* ┅┅┅ Able to Use Laptop ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
      public static readonly TaskCustomFolder ableToUseLaptop = SampleTasksCustomFoldersRepository.registerOne(
        new TaskCustomFolder
        {
          ID = Guid.NewGuid().ToString(),
          label = "Able to Use Laptop",
          orderAmongSiblings = OrderCounter.resetForLevelThenIncrementAndGetValue(2)
        },
        SampleTasksCustomFoldersRepository.Notables.DuringWaiting.hierarchicalRelationshipsMap
      );
      
      [EagerStaticInitialization]
      public static class AbleToUseLaptop
      {
        
        public static readonly HierarchicalRelationshipsMap hierarchicalRelationshipsMap = 
          SampleTasksCustomFoldersRepository.Notables.DuringWaiting.hierarchicalRelationshipsMap
                [Notables.DuringWaiting.ableToUseLaptop.ID];
        
        public static readonly TaskCustomFolder internetConnectionAvailable = SampleTasksCustomFoldersRepository.registerOne(
          new TaskCustomFolder
          {
            ID = Guid.NewGuid().ToString(),
            label = "Internet Connection Available",
            orderAmongSiblings = OrderCounter.resetForLevelThenIncrementAndGetValue(3)
          },
          SampleTasksCustomFoldersRepository.Notables.DuringWaiting.AbleToUseLaptop.hierarchicalRelationshipsMap
        );
        
        public static readonly TaskCustomFolder internetConnectionNotAvailable = SampleTasksCustomFoldersRepository.registerOne(
          new TaskCustomFolder
          {
            ID = Guid.NewGuid().ToString(),
            label = "Internet Connection not Available",
            orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(3)
          },
          SampleTasksCustomFoldersRepository.Notables.DuringWaiting.AbleToUseLaptop.hierarchicalRelationshipsMap
        );
        
      } 
      
      
      /* ┅┅┅ Unable to Use Laptop ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
      public static readonly TaskCustomFolder unableToUseLaptop = SampleTasksCustomFoldersRepository.registerOne(
        new TaskCustomFolder
        {
          ID = Guid.NewGuid().ToString(),
          label = "Unable to Use Laptop",
          orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(2)
        },
        SampleTasksCustomFoldersRepository.Notables.DuringWaiting.hierarchicalRelationshipsMap
      );
    
    }

    
    /* ━━━ Depends on External Factors ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
    public static readonly TaskCustomFolder dependsOnExternalFactors = SampleTasksCustomFoldersRepository.registerOne(
      new TaskCustomFolder
      {
        ID = Guid.NewGuid().ToString(),
        label = "Depends on External Factors",
        orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(1)
      },
      SampleTasksCustomFoldersRepository.hierarchicalRelationshipsMap
    );

    [EagerStaticInitialization]
    public static class DependsOnExternalFactors
    {
      
       public static readonly HierarchicalRelationshipsMap hierarchicalRelationshipsMap = 
          SampleTasksCustomFoldersRepository.hierarchicalRelationshipsMap[Notables.dependsOnExternalFactors.ID];
      
      public static readonly TaskCustomFolder waitingForReply = SampleTasksCustomFoldersRepository.registerOne(
        new TaskCustomFolder
        {
          ID = Guid.NewGuid().ToString(),
          label = "Waiting for Reply",
          orderAmongSiblings = OrderCounter.resetForLevelThenIncrementAndGetValue(2)
        },
        SampleTasksCustomFoldersRepository.Notables.DependsOnExternalFactors.hierarchicalRelationshipsMap
      );
        
      public static readonly TaskCustomFolder waitingForStateChange = SampleTasksCustomFoldersRepository.registerOne(
        new TaskCustomFolder
          {
          ID = Guid.NewGuid().ToString(),
          label = "Waiting for State Change",
          orderAmongSiblings = OrderCounter.incrementForLevelAndGetValue(2)
        },
        SampleTasksCustomFoldersRepository.Notables.DependsOnExternalFactors.hierarchicalRelationshipsMap
      );
      
    }

  }
  
}