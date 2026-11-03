using CommonSolution.Entities.Task;
using CommonSolution.Gateways.Task;

namespace Client.SharedState;


public class TaskCustomFolderSharedState
{
  
  /* ━━━ Reactivity ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal event Action? onStateChanged;
  private void NotifyStateChanged() => this.onStateChanged?.Invoke();

  
  /* ━━━ Data Source ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly TaskCustomFolderGateway taskCustomFolderGateway = ClientDependencies.Injector.gateways.TaskCustomFolder;
  
  
  /* ━━━ Instances Management ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static TaskCustomFolderSharedState? selfSingleInstance = null;
  
  public static TaskCustomFolderSharedState GetInstance()
  {
    return TaskCustomFolderSharedState.selfSingleInstance ??
        (TaskCustomFolderSharedState.selfSingleInstance = new TaskCustomFolderSharedState());
  }
  
  
  /* ━━━ Data Exchange ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Retrieving of Tree of All ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  public List<TaskCustomFolder> tasksCustomFoldersTree
  {
    get;
    set
    {
      field = value;
      this.NotifyStateChanged();
    }
  } = [];


  /* ╍╍╍ Loading ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */
  /* [ Theory ]
   * Not replaceable with struct.
   * 1. The will required logically useless empty contractor in struct case
   * 2. It will become unable to change the separate properties because of "Property 'N' access returns temporary value.
   *    Cannot modify struct member when accessed struct is not classified as a variable" error. */
  internal class Loading(Action notifyStateChanged)
  {
    
    /* ╍╍╍ Is Waiting for Tasks Custom Folders Retrieving ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */
    internal bool isWaitingForTasksCustomFoldersRetrieving
    {
      get;
      set
      {
        field = value;
        notifyStateChanged();
      }
    } = true;


    /* ╍╍╍ Are Tasks Custom Folders Being Retrieved Now ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */
    internal bool areTasksCustomFoldersBeingRetrievedNow
    {
      get;
      set
      {
        field = value;
        notifyStateChanged();
      }
    } = false;


    /* ╍╍╍ Has Tasks Custom Folders Retrieving Error Occurred ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */

    internal bool hasTasksCustomFoldersRetrievingErrorOccurred
    {
      get;
      set
      {
        field = value;
        notifyStateChanged();
      }
    } = false;


    /* ╍╍╍ Computed ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */
    internal bool isTasksCustomFoldersRetrievingInProgressOrNotStartedYet => 
      this.isWaitingForTasksCustomFoldersRetrieving || this.areTasksCustomFoldersBeingRetrievedNow;
    
  }
  
  private Loading _loading;
  
  internal Loading loading
  {
    get => this._loading;
    private set
    {
      this._loading = value;
      this.NotifyStateChanged();
    }
  }
  

  public async System.Threading.Tasks.Task retrieveTreeOfAll()
  {

    if (this.loading.areTasksCustomFoldersBeingRetrievedNow)
    {
      System.Diagnostics.Debug.WriteLine(
        "`taskCustomFolderSharedState.retrieveTreeOfAll` has been invoked during tasks retrieving. " +
        "If it is intentionally, the controls initiating the tasks retrieving should be blocked during the data retrieving. " +
        "If it is unintentionally, it means the lack of control on data flow thus should be investigated and prevented. "
      );
      return;      
    }
    
    
    this.loading = new Loading(this.NotifyStateChanged)
    {
      isWaitingForTasksCustomFoldersRetrieving = false,
      areTasksCustomFoldersBeingRetrievedNow = true,
      hasTasksCustomFoldersRetrievingErrorOccurred = false
    };
    
    
    TaskCustomFolder[] tasksCustomFoldersTree;

    try
    {

      tasksCustomFoldersTree = await this.taskCustomFolderGateway.RetrieveTreeOfAll(); 
      
    }
    catch
    {
      
      this.loading = new Loading(this.NotifyStateChanged)
      {
        isWaitingForTasksCustomFoldersRetrieving = false,
        areTasksCustomFoldersBeingRetrievedNow = false,
        hasTasksCustomFoldersRetrievingErrorOccurred = true
      };
      
      throw;
      
    }
    
    
    this.tasksCustomFoldersTree = tasksCustomFoldersTree.ToList();
    
    this.loading.areTasksCustomFoldersBeingRetrievedNow = false;
    
  }


  public TaskCustomFolderSharedState()
  {
    this._loading = new Loading(this.NotifyStateChanged);
  }
  
}