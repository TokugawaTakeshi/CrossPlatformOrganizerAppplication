namespace Utils.Pagination;


public class PaginationCollection<TItem>
{

  public readonly uint PagesCount;

  public List<List<TItem>> PagesContent = new List<List<TItem>>();

  public PaginationCollection(
    List<TItem> flatCollection,
    uint itemsCountPerPaginationPage,
    byte pagesNumerationFrom = 1
  )
  {
      
    uint pagesCount = (uint)Math.Ceiling((double)flatCollection.Count / itemsCountPerPaginationPage);

    uint elementStartingPositionForCurrentPage = 0;
    uint elementEndingPositionForCurrentPage = itemsCountPerPaginationPage;

    uint lastPageNumber = pagesNumerationFrom == 0 ? pagesCount : pagesCount + 1;

    for (int pageNumber = pagesNumerationFrom; pageNumber < lastPageNumber; pageNumber++)
    {

      PagesContent[pageNumber] = flatCollection.
        GetRange((int)elementStartingPositionForCurrentPage, (int)elementEndingPositionForCurrentPage);

      elementStartingPositionForCurrentPage = elementStartingPositionForCurrentPage + itemsCountPerPaginationPage;
      elementEndingPositionForCurrentPage = elementStartingPositionForCurrentPage + itemsCountPerPaginationPage;
    }

    PagesCount = pagesCount;
  }
}