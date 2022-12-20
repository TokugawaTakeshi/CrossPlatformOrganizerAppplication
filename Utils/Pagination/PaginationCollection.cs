namespace Utils.Pagination;


public class PaginationCollection<TItem>
{

  public readonly uint PagesCount;
  
  private readonly TItem[][] _pagesContent;
  

  public PaginationCollection(
    TItem[] flatCollection,
    uint itemsCountPerPaginationPage
  )
  {
    
    uint pagesCount = (uint)Math.Ceiling((double)flatCollection.Length / itemsCountPerPaginationPage);

    uint elementStartingIndexForCurrentPage = 0;

    _pagesContent = new TItem[pagesCount][];

    for (uint pageIndex = 0; pageIndex < pagesCount; pageIndex++)
    {
      _pagesContent[pageIndex] = flatCollection.
        Skip(pageIndex > 0 ? (int)elementStartingIndexForCurrentPage - 1 : 0).
        Take((int)itemsCountPerPaginationPage).
        ToArray();
      
      elementStartingIndexForCurrentPage = elementStartingIndexForCurrentPage + itemsCountPerPaginationPage;
      
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
  
}
