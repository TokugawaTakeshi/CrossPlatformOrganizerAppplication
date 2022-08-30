namespace Utils.Pagination
{
  public class PaginationCollection<Item>
  {

    public readonly uint PagesCount;

    public List<List<Item>> PagesContent = new List<List<Item>>();

    public PaginationCollection(uint pagesCount)
    {
      PagesCount = pagesCount;
    }
  }
}
