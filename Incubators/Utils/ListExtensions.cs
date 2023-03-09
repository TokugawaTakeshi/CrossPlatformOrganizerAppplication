namespace Utils;


public static class ListExtensions
{

  public static List<TElement> AddElementsToEnd<TElement> (
    this List<TElement> self,
    params TElement[] newElements
  ) {

    foreach (TElement element in newElements)
    {
      self.Add(element);   
    }

    return self;

  }
  
  public static List<TElement> AddElementToEndIf<TElement>(
    this List<TElement> self,
    TElement newElement,
    Func<TElement?, bool> condition
  )
  {

    if (condition(newElement))
    {
      self.Add(newElement);
    }

    return self;

  }

  public static string StringifyEachElementAndJoin<TElement>(
    this List<TElement> self,
    string separator
  )
  {
    return String.Join(separator, self);
  }

}