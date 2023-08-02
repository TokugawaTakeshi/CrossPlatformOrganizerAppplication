namespace Utils.Pagination;


public class PaginationCollection<TItem>
{

  public readonly uint PagesCount;
  
  private readonly TItem[][] _itemsByPages;
  

  public PaginationCollection(
    TItem[] items,
    uint itemsCountPerPaginationPage
  )
  {
    
    this.PagesCount = (uint)Math.Ceiling((double)items.Length / itemsCountPerPaginationPage);

    uint elementStartingIndexForCurrentPage = 0;

    this._itemsByPages = new TItem[this.PagesCount][];

    for (uint pageIndex = 0; pageIndex < this.PagesCount; pageIndex++)
    {
      
      this._itemsByPages[pageIndex] = items.
        Skip(pageIndex > 0 ? (int)elementStartingIndexForCurrentPage - 1 : 0).
        Take((int)itemsCountPerPaginationPage).
        ToArray();
      
      elementStartingIndexForCurrentPage = elementStartingIndexForCurrentPage + itemsCountPerPaginationPage;
      
    }
    
  }
  
  public TItem[] GetItemsArrayOfPageWithIndex(uint targetIndex)
  {
    return _itemsByPages[targetIndex];
  }

  public TItem[] GetItemsArrayOfPageWithNumber(uint targetPageNumber)
  {
    return _itemsByPages[targetPageNumber - 1];
  }
  
}
