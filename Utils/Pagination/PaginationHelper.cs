namespace Utils.Pagination
{
  public class PaginationHelper
  {

    public static PaginationCollection<Item> SplitListToPaginationCollection<Item>(
      List<Item> flatCollection,
      uint itemsCountPerPaginationPage,
      byte pagesNumerationFrom = 1
    )
    {

      uint pagesCount = (uint)Math.Ceiling((double)flatCollection.Count / itemsCountPerPaginationPage);

      uint elementStartingPositionForCurrentPage = 0;
      uint elementEndingPositionForCurrentPage = itemsCountPerPaginationPage;

      uint lastPageNumber = pagesNumerationFrom == 0 ? pagesCount : pagesCount + 1;

      PaginationCollection<Item> paginationCollection = new PaginationCollection<Item>(pagesCount);

      for (int pageNumber = pagesNumerationFrom; pageNumber < lastPageNumber; pageNumber++)
      {

        paginationCollection.PagesContent[pageNumber] = flatCollection.
            GetRange((int)elementStartingPositionForCurrentPage, (int)elementEndingPositionForCurrentPage);

        elementStartingPositionForCurrentPage = elementStartingPositionForCurrentPage + itemsCountPerPaginationPage;
        elementEndingPositionForCurrentPage = elementStartingPositionForCurrentPage + itemsCountPerPaginationPage;
      }

      return paginationCollection;
    }
  }
}
