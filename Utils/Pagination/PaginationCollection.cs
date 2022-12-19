namespace Utils.Pagination;


public class PaginationCollection<TItem>
{

  public readonly uint PagesCount;
  
  private readonly TItem[][] _pagesContent;
  

  public PaginationCollection(
    List<TItem> flatCollection,
    uint itemsCountPerPaginationPage
  )
  {
    
    uint pagesCount = (uint)Math.Ceiling((double)flatCollection.Count / itemsCountPerPaginationPage);

    uint elementStartingPositionForCurrentPage = 0;
    uint elementEndingPositionForCurrentPage = itemsCountPerPaginationPage;

    _pagesContent = new TItem[pagesCount][];

    for (uint pageIndex = 0; pageIndex < pagesCount; pageIndex++)
    {
      _pagesContent[pageIndex] = flatCollection.
        GetRange((int)elementStartingPositionForCurrentPage, (int)elementEndingPositionForCurrentPage).
        ToArray();
      
      elementStartingPositionForCurrentPage = elementStartingPositionForCurrentPage + itemsCountPerPaginationPage;
      elementEndingPositionForCurrentPage = elementStartingPositionForCurrentPage + itemsCountPerPaginationPage;
    }

    PagesCount = pagesCount;
  }
  
  public TItem[] GetItemsArrayOfPageWithIndex(uint targetIndex)
  {
    return _pagesContent[targetIndex];
  }

  public TItem[] GetItemsArrayOfPageWithNumber(uint targetPageNumber)
  {
    return _pagesContent[targetPageNumber - 1];
  }
  
  public List<TItem> GetItemsListOfPageWithIndex(uint targetIndex)
  {
    return _pagesContent[targetIndex].ToList();
  }

  public List<TItem> GetItemsListOfPageWithNumber(uint targetPageNumber)
  {
    return _pagesContent[targetPageNumber - 1].ToList();
  }
}
