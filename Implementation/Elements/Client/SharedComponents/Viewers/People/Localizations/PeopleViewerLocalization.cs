using Client.Resources.Localizations;


namespace Client.SharedComponents.Viewers.People.Localizations;


public abstract record PeopleViewerLocalization
{
  
  internal record SearchBox
  {
    internal required string placeholder { get; init; }
    internal required string accessibilityGuidance { get; init; }
  }
  
  internal abstract SearchBox searchBox { get; init; }
  
  
  internal abstract PeopleViewerLocalization.Buttons buttons { get; init; } 
  
  internal record Buttons
  {
    internal required SharedStaticStrings.ButtonWithVisibleLabel personAdding { get; init; }
    internal required SharedStaticStrings.ButtonWithVisibleLabel retryingOfDataRetrieving { get; init; }
    internal required SharedStaticStrings.ButtonWithVisibleLabel immediateAddingOfFirstPerson { get; init; }
    
    internal required SharedStaticStrings.ButtonWithVisibleLabel resettingOfFiltering { get; init; }
    internal required SharedStaticStrings.ButtonWithVisibleLabel tasksFiltering { get; init; }
  }
  
  
  internal abstract Errors errors { get; init; }
  
  internal record Errors
  {
    internal required SharedStaticStrings.MessageWithTitleAndDescription tasksRetrieving { get; init; }
  }

  
  internal abstract Guidances guidances { get; init; }
  
  internal record Guidances
  {
    internal required string noItemsAvailable { get; init; }
    internal required string noItemsFound { get; init; }
  }
  
}