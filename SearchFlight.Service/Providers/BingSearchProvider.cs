using SearchFight.Core;
using System.Configuration;
using System.Net;

namespace SearchFight.Service
{
  public class BingSearchProvider : ISearchProvider<BingWebSearchResponse>
  {
    public BingWebSearchResponse Search(string query)
    {
      string bingWebSearchApiKeyUrl = ConfigurationManager.AppSettings[Constants.BING_WEB_SEARCH_API_URL];
      string bingWebSearchApiKey1 = ConfigurationManager.AppSettings[Constants.BING_WEB_SEARCH_API_KEY_1];
      string bingWebSearchApiKeyHeaderName = ConfigurationManager.AppSettings[Constants.BING_WEB_SEARCH_API_KEY_HEADER_NAME];

      var webRequest = WebRequest.Create(string.Format(bingWebSearchApiKeyUrl, query));
      webRequest.Headers[bingWebSearchApiKeyHeaderName] = bingWebSearchApiKey1;

      using (var httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
      {
        return HttpResponseHandler.GetDeserializedObjectFromResponse<BingWebSearchResponse>(httpWebResponse);
      }
    }
  }
}
