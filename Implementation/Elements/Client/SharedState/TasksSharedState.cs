﻿using System.Diagnostics;
using CommonSolution.Gateways;
using Utils;
using YamatoDaiwaCS_Extensions.Exceptions;


namespace Client.SharedState;


internal abstract class TasksSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => TasksSharedState.onStateChanged?.Invoke();

  private static ITaskGateway? _taskGateway;
  private static ITaskGateway taskGateway =>
      TasksSharedState._taskGateway ??
      (TasksSharedState._taskGateway = ClientDependencies.Injector.gateways().Task);


  /* ━━━ 選択 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static CommonSolution.Entities.Task? _currentlySelectedTask = null;
  public static CommonSolution.Entities.Task? currentlySelectedTask
  {
    get => TasksSharedState._currentlySelectedTask;
    set
    {
      TasksSharedState._currentlySelectedTask = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  
  /* ━━━ 取得 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static List<CommonSolution.Entities.Task> _tasksSelection = new();
  public static List<CommonSolution.Entities.Task> tasksSelection
  {
    get => TasksSharedState._tasksSelection;
    private set
    {
      TasksSharedState._tasksSelection = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

  
  private static uint _totalTasksCountInDataSource = 0;
  public static uint totalTasksCountInDataSource
  {
    get => TasksSharedState._totalTasksCountInDataSource;
    private set
    {
      TasksSharedState._totalTasksCountInDataSource = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static uint _totalTasksCountInSelection = 0;
  public static uint totalTasksCountInSelection
  {
    get => TasksSharedState._totalTasksCountInSelection;
    private set
    {
      TasksSharedState._totalTasksCountInSelection = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static string? _searchingByFullOrPartialTitleOrDescription = null;
  public static string? searchingByFullOrPartialTitleOrDescription
  {
    get => TasksSharedState._searchingByFullOrPartialTitleOrDescription;
    private set
    {
      TasksSharedState._searchingByFullOrPartialTitleOrDescription = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

  public static bool _onlyTasksWithAssociatedDate = false;
  public static bool onlyTasksWithAssociatedDate
  {
    get => TasksSharedState._onlyTasksWithAssociatedDate;
    private set
    {
      TasksSharedState._onlyTasksWithAssociatedDate = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  public static bool _onlyTasksWithAssociatedDateTime = false;
  public static bool onlyTasksWithAssociatedDateTime
  {
    get => TasksSharedState._onlyTasksWithAssociatedDateTime;
    private set
    {
      TasksSharedState._onlyTasksWithAssociatedDateTime = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  

  private static bool _isWaitingForTasksSelectionRetrieving = true;
  public static bool isWaitingForTasksSelectionRetrieving
  {
    get => TasksSharedState._isWaitingForTasksSelectionRetrieving;
    private set
    {
      TasksSharedState._isWaitingForTasksSelectionRetrieving = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _isTasksSelectionBeingRetrievedNow = false;
  public static bool isTasksSelectionBeingRetrievedNow
  {
    get => TasksSharedState._isTasksSelectionBeingRetrievedNow;
    private set
    {
      TasksSharedState._isTasksSelectionBeingRetrievedNow = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _hasTasksSelectionRetrievingErrorOccurred = false;
  public static bool hasTasksSelectionRetrievingErrorOccurred
  {
    get => TasksSharedState._hasTasksSelectionRetrievingErrorOccurred;
    private set
    {
      TasksSharedState._hasTasksSelectionRetrievingErrorOccurred = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

  public static bool isTasksRetrievingInProgressOrNotStartedYet => 
      TasksSharedState.isWaitingForTasksSelectionRetrieving || TasksSharedState.isTasksSelectionBeingRetrievedNow;
  
  public static async System.Threading.Tasks.Task retrieveTasksSelection(
    ITaskGateway.SelectionRetrieving.RequestParameters? requestParameters = null,
    bool mustResetSearchingByFullOrPartialTitleOrDescription = false,
    bool mustResetFilteringByAssociatedDate = false,
    bool mustResetFilteringByAssociatedDateTime = false
  )
  {

    if (TasksSharedState.isTasksSelectionBeingRetrievedNow)
    {
      return;      
    }


    TasksSharedState.currentlySelectedTask = null;
    TasksSharedState.isWaitingForTasksSelectionRetrieving = false;
    TasksSharedState.isTasksSelectionBeingRetrievedNow = true;
    TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = false;

    if (mustResetSearchingByFullOrPartialTitleOrDescription)
    {
      TasksSharedState.searchingByFullOrPartialTitleOrDescription = null;
    }
    else
    {
      TasksSharedState.searchingByFullOrPartialTitleOrDescription =
          requestParameters?.SearchingByFullOrPartialTitleOrDescription ??
          TasksSharedState.searchingByFullOrPartialTitleOrDescription;
    }

    if (mustResetFilteringByAssociatedDate)
    {
      TasksSharedState.onlyTasksWithAssociatedDate = false;
    }
    else
    {
      TasksSharedState.onlyTasksWithAssociatedDate =
          requestParameters?.OnlyTasksWithAssociatedDate ??
          TasksSharedState.onlyTasksWithAssociatedDate;
    }

    if (mustResetFilteringByAssociatedDateTime)
    {
      TasksSharedState.onlyTasksWithAssociatedDateTime = false;
    }
    else
    {
      TasksSharedState.onlyTasksWithAssociatedDateTime =
          requestParameters?.OnlyTasksWithAssociatedDateTime ??
          TasksSharedState.onlyTasksWithAssociatedDateTime;

      if (TasksSharedState.onlyTasksWithAssociatedDateTime && TasksSharedState.onlyTasksWithAssociatedDate)
      {
        TasksSharedState.onlyTasksWithAssociatedDate = false;
      }
      
    }

    
    ITaskGateway.SelectionRetrieving.ResponseData responseData;
    
    try
    {

      responseData = await ClientDependencies.Injector.gateways().Task.RetrieveSelection(
        new ITaskGateway.SelectionRetrieving.RequestParameters
        {
          SearchingByFullOrPartialTitleOrDescription = TasksSharedState.searchingByFullOrPartialTitleOrDescription,
          OnlyTasksWithAssociatedDate = TasksSharedState.onlyTasksWithAssociatedDate,
          OnlyTasksWithAssociatedDateTime = TasksSharedState.onlyTasksWithAssociatedDateTime
        }
      );

    }
    catch (Exception exception)
    {
      
      TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = true;
      TasksSharedState.isTasksSelectionBeingRetrievedNow = false;
      Debug.WriteLine(exception);
      
      return;
      
    }


    TasksSharedState.tasksSelection = responseData.Items.ToList();
    TasksSharedState.totalTasksCountInSelection = responseData.TotalItemsCountInSelection;
    TasksSharedState.totalTasksCountInDataSource = responseData.TotalItemsCount;
    
    TasksSharedState.isTasksSelectionBeingRetrievedNow = false;

  }
  

  
  /* ━━━ 追加 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static async System.Threading.Tasks.Task addTask(
    CommonSolution.Gateways.ITaskGateway.Adding.RequestData requestData
  )
  {

    string newTaskID;
    
    try
    {
      newTaskID = (await TasksSharedState.taskGateway.Add(requestData)).AddedTaskID;
    }
    catch (Exception exception)
    {
      throw new DataSubmittingFailedException("新規課題追加中不具合が発生", exception);
    }


    // TODO やっぱり完全に課題を返してほしいが、但しコピー
    CommonSolution.Entities.Task newTask = new()
    {
      ID = newTaskID,
      title = requestData.Title,
      description = requestData.Description,
      isComplete = requestData.IsComplete,
    };

    TasksSharedState.tasksSelection = TasksSharedState.tasksSelection.AddElementsToStart(newTask);

  }
  
  
  /* ━━━ 更新 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static bool _isTaskBeingUpdatedNow = false;
  public static bool isTaskBeingUpdatedNow
  {
    get => TasksSharedState._isTaskBeingUpdatedNow;
    private set
    {
      TasksSharedState._isTaskBeingUpdatedNow = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  public static async System.Threading.Tasks.Task updateTask(
    CommonSolution.Gateways.ITaskGateway.Updating.RequestData requestData
  )
  {

    TasksSharedState.isTaskBeingUpdatedNow = true;

    try
    {
      await ClientDependencies.Injector.gateways().Task.Update(requestData);
    }
    catch (Exception exception)
    {
      throw new DataRetrievingFailedException($"ID「${requestData.ID}」課題の更新中エラーが発生。", exception);
    }
    finally
    {
      TasksSharedState.isTaskBeingUpdatedNow = false;
    }
    
    
    CommonSolution.Entities.Task targetTask = TasksSharedState.tasksSelection.Single(task => task.ID == requestData.ID);

    targetTask.title = requestData.Title;
    targetTask.description = requestData.Description;

  }

  public static async System.Threading.Tasks.Task toggleTaskCompletion(string targetTaskID)
  {

    try
    {
      await ClientDependencies.Injector.gateways().Task.ToggleCompletion(targetTaskID);
    }
    catch (Exception exception)
    {
      throw new DataRetrievingFailedException($"ID「${ targetTaskID }」課題の更新中エラーが発生。", exception);
    }
    

    CommonSolution.Entities.Task targetTask = TasksSharedState.tasksSelection.Single(task => task.ID == targetTaskID);
    targetTask.isComplete = !targetTask.isComplete; 
    
    TasksSharedState.NotifyStateChanged();

  } 
  
}
