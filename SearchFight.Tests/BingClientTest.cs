using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SearchFight.Core;
using SearchFight.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Tests
{
    [TestClass]
    public class BingClientTest
    {
        ISearchProvider<BingWebSearchResponse> MakeJointer()
        {
            return new BingWebSearchResponse() as ISearchProvider<BingWebSearchResponse>;
        }

        private BingSearchProvider _bingSearchProvider;

        [TestInitialize]
        public void Init()
        {
            _bingSearchProvider = new BingSearchProvider();
        }

        [TestMethod]
        public void GetBingResultsCount()
        {
            var query = "java .net";

            var serviceMock = Mock.Of<ISearchProvider<BingSearchProvider>>
                (m => m.Search(query).GetType().Name == nameof(BingWebSearchResponse));

            var result = _bingSearchProvider.Search(query);

            Assert.IsInstanceOfType(result, typeof(long));
        }

        [TestMethod]
        public void SearchNotNull()
        {
            var query = "java .net";

            var result = _bingSearchProvider.Search(query);

            Assert.IsNotNull(result);
        }
    }
}
