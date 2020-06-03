namespace SearchFight.Core
{
  public class GoogleCustomSearchResponse
  {
    public GoogleSearchInformation SearchInformation { get; set; }
  }

  public class GoogleSearchInformation
  {
    public int TotalResults { get; set; }
  }
}
