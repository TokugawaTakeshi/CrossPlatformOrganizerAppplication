namespace MockDataSource;


public class SerializableHierarchicalCollectionData<Item>
{
  
  public required Item[] items { get; init; }
  public required Dictionary<string, object> hierarchicalRelationshipsMap { get; init; }
  public required string ID_PROPERTY_KEY { get; init; }
  public required string PARENT_PROPERTY_KEY { get; init; }
  public required string LIST_OF_CHILDREN_PROPERTY_KEY { get; init; }
  
}