namespace MockDataSource;


[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal sealed class EagerStaticInitialization : Attribute
{
  
  public static void InitializeDecoratedRecursively(Type targetClass)
  {
    
    foreach (Type type in EagerStaticInitialization.EnumerateNestedTypesRecursively(targetClass))
    {
    
      if (type.IsDefined(typeof(EagerStaticInitialization), inherit: false))
      {
        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
      }
      
    }
    
  }
  
  private static IEnumerable<Type> EnumerateNestedTypesRecursively(Type root)
  {
     
      yield return root;

      const System.Reflection.BindingFlags flags = 
          System.Reflection.BindingFlags.Public | 
          System.Reflection.BindingFlags.NonPublic;

      foreach (Type nestedType in root.GetNestedTypes(flags))
      {
        foreach (Type type in EnumerateNestedTypesRecursively(nestedType))
        {
          yield return type;
        }
      }
  }
  
}
