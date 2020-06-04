using System;
using LightInject;
using System.Collections.Generic;
using System.Linq;
using SearchFight.Service;

namespace SearchFight
{
    class Program
    {
        /// <summary>
        /// Program Challenge - Bahwan CyberTek - Search Engine Result Battle Program
        /// Produced by Bharath
        /// </summary>
        /// <param name="args"></param>
      static void Main(string[] args)
      {
            // Dependency Injection configuration - LightInject is used
            DependencyConfiguration.Configure();

            // Decoupling service instances
            var searchService = DependencyConfiguration.Container.GetInstance<ISearchService>();
            var searchEngines = new List<Core.SearchManager>();

            try
            {
                // If no arguments entered when running exe file, it will ask input
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter the query to search....");
                    args = Console.ReadLine().Split('"');
                    args = args.Where(x => x.Length > 0 && !string.IsNullOrWhiteSpace(x)).ToArray();
                }

                // Search results for each query instance
                for (int i = 0; i < args.Length; i++)
                    searchEngines.Add(searchService.GetSearchResults(args[i]));

                searchEngines.ForEach(engines =>
                          Console.WriteLine(
                              string.Format("{0}: Google: {1} Bing Search: {2}"
                                  , engines.Name
                                  , engines.GoogleResults
                                  , engines.BingResults)));

                // Display Results
                Console.WriteLine("Google Winner: {0}", searchEngines.OrderByDescending(result => result.GoogleResults).FirstOrDefault().Name);
                Console.WriteLine("MSN Search Winner: {0}", searchEngines.OrderByDescending(result => result.BingResults).FirstOrDefault().Name);
                Console.WriteLine("Total Winner: {0}", searchEngines.OrderByDescending(result => result.GetTotalResults).FirstOrDefault().Name);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error has occured: {ex.Message}");
            }

            Console.ReadKey();
      
        }
    }
}
