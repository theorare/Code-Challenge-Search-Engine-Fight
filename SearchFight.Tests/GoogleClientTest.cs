using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SearchFight.Core;
using SearchFight.Service;

namespace SearchFight.Tests
{
    [TestClass]
    public class GoogleClientTest//<T> where T : GoogleCustomSearchResponse, new()
    {
        ISearchProvider<GoogleCustomSearchResponse> MakeJointer()
        {
            return new GoogleCustomSearchResponse() as ISearchProvider<GoogleCustomSearchResponse>;
        }

        private GoogleSearchProvider _googleSearchProvider;

        [TestInitialize]
        public void Init()
        {
            _googleSearchProvider = new GoogleSearchProvider();
        }

        [TestMethod]
        public void GetGoogleResultsCount()
        {
            var query = "java .net";

            var serviceMock = Mock.Of<ISearchProvider<GoogleSearchProvider>>
                (m => m.Search(query).GetType().Name == nameof(GoogleCustomSearchResponse));

            var result = _googleSearchProvider.Search(query);

            Assert.IsInstanceOfType(result, typeof(long));
        }

        

        [TestMethod]
        public void SearchNotNull()
        {
            var query = "java .net";

            var result = _googleSearchProvider.Search(query);
            
            Assert.IsNotNull(result);
        }
    }
}
