using SearchFight.Core;

namespace SearchFight.Service
{
  public interface ISearchService
  {
    SearchManager GetSearchResults(string query);
  }
}
