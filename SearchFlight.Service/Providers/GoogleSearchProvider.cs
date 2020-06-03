using SearchFight.Core;
using System.Configuration;
using System.Net;

namespace SearchFight.Service
{
  public class GoogleSearchProvider : ISearchProvider<GoogleCustomSearchResponse>
  {
    public GoogleCustomSearchResponse Search(string query)
    {
      string googleCustomSearchApiKeyUrl = ConfigurationManager.AppSettings[Constants.GOOGLE_CUSTOM_SEARCH_API_KEY_URL];
      string googleSearchEngine = ConfigurationManager.AppSettings[Constants.GOOGLE_SEARCH_ENGINE];
      string googleCustomSearchApiKey = ConfigurationManager.AppSettings[Constants.GOOGLE_CUSTOM_SEARCH_API_KEY];

      using (var httpWebResponse = (HttpWebResponse)WebRequest.Create(string.Format(googleCustomSearchApiKeyUrl, googleCustomSearchApiKey, googleSearchEngine, query)).GetResponse())
      {
        return HttpResponseHandler.GetDeserializedObjectFromResponse<GoogleCustomSearchResponse>(httpWebResponse);
      }
    }
  } 
}
