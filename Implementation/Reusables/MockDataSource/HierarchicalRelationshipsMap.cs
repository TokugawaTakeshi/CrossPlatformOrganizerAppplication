namespace MockDataSource;


public class HierarchicalRelationshipsMap: Dictionary<HierarchicalRelationshipsMap.EntityID, HierarchicalRelationshipsMap>
{

  public class EntityID(string value)
  {
    
    public static implicit operator EntityID(string value) => new(value);
    public static implicit operator string(EntityID entityID) => entityID.ToString();

    public override string ToString()
    {
      return value;
    }

    public override bool Equals(object? potentiallyOtherEntityID)
    {
      return potentiallyOtherEntityID is EntityID other && value == other.ToString();
    }

    public override int GetHashCode()
    {
      return value.GetHashCode();
    }
    
  }

  public override string ToString()
  {
     return HierarchicalRelationshipsMap.stringifyLevel(this, 0);
  }
  
  public Dictionary<string, object> ToPlainDictionary()
  {
    
    Dictionary<string, object> plainPlainDictionary = [];
    
     foreach (
       (
        HierarchicalRelationshipsMap.EntityID parentID, 
        HierarchicalRelationshipsMap childrenRelationships
       ) in this
     )
     {
       plainPlainDictionary.Add(parentID.ToString(), childrenRelationships.ToPlainDictionary());
     }
    
    return plainPlainDictionary;
    
  }
  
  public static void SetRelationshipsForCollection<Item>(
    IEnumerable<Item> items,
    HierarchicalRelationshipsMap hierarchicalRelationshipsMap,
    string ID_PropertyKey,
    string parentPropertyKey,
    string childrenListPropertyKey
  )
  {
    foreach (
      (
        HierarchicalRelationshipsMap.EntityID parentID, 
        HierarchicalRelationshipsMap childrenRelationships
      ) in hierarchicalRelationshipsMap
    )
    {
      HierarchicalRelationshipsMap.SetRelationshipsForParentAndChildren<Item>(
        items,
        parentID,
        childrenRelationships,
        ID_PropertyKey,
        parentPropertyKey,
        childrenListPropertyKey
      );
    }
  }
  
  
  private static void SetRelationshipsForParentAndChildren<Item>(
    IEnumerable<Item> items,
    string parentID,
    HierarchicalRelationshipsMap childrenRelationships,
    string ID_PropertyKey,
    string parentPropertyKey,
    string childrenListPropertyKey
  )
  {
    
    Item parent = items.Single(
      (Item item) => item?.GetType().GetProperty(ID_PropertyKey)?.GetValue(item)?.ToString() == parentID
    );

    IEnumerable<Item> children = childrenRelationships.Keys.Select(
      (HierarchicalRelationshipsMap.EntityID childID) => 
        items.Single(
          (Item item) => item?.GetType().GetProperty(ID_PropertyKey)?.GetValue(item)?.ToString() == childID
        )
    );

    parent?.GetType().GetProperty(childrenListPropertyKey)?.SetValue(parent, children.ToList());
    
    foreach(Item child in children)
    {
      child?.GetType().GetProperty(parentPropertyKey)?.SetValue(child, parent);
    }

    foreach (
      (
        HierarchicalRelationshipsMap.EntityID _parentID, 
        HierarchicalRelationshipsMap _childrenRelationships
      ) in childrenRelationships
    )
    {
      HierarchicalRelationshipsMap.SetRelationshipsForParentAndChildren<Item>(
        items,
        parentID: _parentID,
        childrenRelationships: _childrenRelationships,
        ID_PropertyKey,
        parentPropertyKey,
        childrenListPropertyKey
      );
    }
    
  }
  
  protected static string stringifyLevel(HierarchicalRelationshipsMap target, uint level)
  {

    if (target.Count == 0)
    {
      return "HierarchicalRelationshipsMap { Empty }";
    }
    
    List<string> stringifiedEntries = [];

    foreach((HierarchicalRelationshipsMap.EntityID key, HierarchicalRelationshipsMap childMap) in target)
    {
      stringifiedEntries.Add(
        childMap.Count == 0 ? 
            $"{ key }: {{ Empty }}" : 
            $"{ key }: {{{ HierarchicalRelationshipsMap.stringifyLevel(childMap, level + 1) }}}");
    }
    
    return "HierarchicalRelationshipsMap {\n" + String.Join('\n', stringifiedEntries) + "\n}";
    
  } 
  
}