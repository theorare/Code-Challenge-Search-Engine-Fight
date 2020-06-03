namespace SearchFight.Core
{
  public class SearchManager
  {
       public SearchManager(string name, int googleResults, int bingResults) 
       {
           Name = name;
           GoogleResults = googleResults;
           BingResults = bingResults;
       }

       public string Name { get; set; }
       public int GoogleResults { get; set; }
       public int BingResults { get; set; }
       public int GetTotalResults => GoogleResults + BingResults;
  }

}
