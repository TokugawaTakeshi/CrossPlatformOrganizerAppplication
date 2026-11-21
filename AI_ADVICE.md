## Cause

In `TasksFoldersList.razor` you pass a method group (`onSelectFolderEventHandler`) to the `onSelectFolderEventHandler` parameter of `TasksFoldersListItem`. That parameter is declared as **nullable**:

```csharp
// Item/TasksFoldersListItem.razor.cs
public Microsoft.AspNetCore.Components.EventCallback<TaskCustomFolder>? onSelectFolderEventHandler { get; set; }
```

`EventCallback<T>` is a **struct**, so `EventCallback<T>?` is really `Nullable<EventCallback<T>>`. The Razor compiler only turns a method into an event callback (through `EventCallback.Factory.Create(this, method)`) when the parameter type is exactly `EventCallback` or `EventCallback<T>`. For `Nullable<…>` it doesn't do that, and C# has no implicit conversion from a method group to `Nullable<EventCallback<T>>`, so you get the error.

## Fix: make the callback parameters non-nullable

You don't need nullability here. A `default(EventCallback<T>)` already means "no handler": `HasDelegate` is `false` and `InvokeAsync` does nothing and returns a completed task. Your other components (`TaskCard`, `PersonManager`, `PeopleViewer`, etc.) already use non-nullable callbacks.

**`Item/TasksFoldersListItem.razor.cs`**
```csharp
[Parameter] public EventCallback onInteractiveLabelClickedInViewingModeEventHandler { get; set; }
[Parameter] public EventCallback<TaskCustomFolder> onSelectFolderEventHandler { get; set; }

// usages: drop the "?."
this.onInteractiveLabelClickedInViewingModeEventHandler.InvokeAsync();
this.onSelectFolderEventHandler.InvokeAsync(this.taskCustomFolder);
```

**`TasksFoldersList.razor.cs`**
```csharp
[Parameter] public EventCallback<TaskCustomFolder> onTaskCustomFolderSelected { get; set; }

private async Task onSelectFolderEventHandler(TaskCustomFolder taskCustomFolder)
{
  this.selectedTaskCustomFolderID = taskCustomFolder.ID;
  await this.onTaskCustomFolderSelected.InvokeAsync(taskCustomFolder);
}
```

You don't need to change either `.razor` markup file. `TasksFoldersListItem.razor:147` forwards its callback to the nested `TasksFoldersList`, and that still compiles because both sides are now the same type. Any other place that passes a method to these parameters will also compile once they're non-nullable.

If you really want to keep the `?`, you'd have to wrap the method yourself in the markup: `onSelectFolderEventHandler=@(EventCallback.Factory.Create<TaskCustomFolder>(this, onSelectFolderEventHandler))`. That's noisy and gives you nothing extra, so I don't recommend it.

## Two related bugs in `TasksFoldersList.razor.cs` (fix them at the same time)

1. **Null `await` crash:** `await this.onTaskCustomFolderSelected?.InvokeAsync(...)` evaluates to `await null` when no handler is set, which throws `NullReferenceException`. Making the parameter non-nullable, as above, removes this.
2. **Initial selection never applies:** the constructor reads `initiallySelectedCustomFolder`, but Blazor sets parameters after the constructor runs, so the value there is always `null`. Move that logic into a lifecycle method:
   ```csharp
   protected override void OnInitialized()
   {
     this.selectedTaskCustomFolderID = this.initiallySelectedCustomFolder?.ID;
   }
   ```

Say the word and I'll apply these changes.