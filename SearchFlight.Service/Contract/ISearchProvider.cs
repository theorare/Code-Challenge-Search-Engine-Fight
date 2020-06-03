namespace SearchFight.Service
{
  public interface ISearchProvider<T> where T:class
  {
    T Search(string query);
  }
}
