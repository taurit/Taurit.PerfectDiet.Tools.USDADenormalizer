using System;
using System.IO;
using CsvHelper;
using Taurit.USDADenormalizer.ImportModules.USDA26;
using Taurit.USDADenormalizer.Models.USDA26;

namespace USDAExport
{
    /// <summary>
    ///     A simple aplication that use USDADenormalizer Portable Class Library to load
    ///     USDA Database in original format and export it to a range of other supported formats
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Application entry point.
        ///     Opens USDA Nutrient database (revision 26), denormalizes it using UsdaDenormalizer library
        ///     and writes result to a CSV file with a specified name.
        /// </summary>
        /// <param name="args">
        ///     [0] path to the directory containing ASCII version of database
        ///     [1] path to the output CSV file
        /// </param>
        private static void Main(string[] args)
        {
            // check if input is valid
            if (args.Length > 1)
            {
                var inputDirectoryPath = args[0];
                var outputCsvPath = args[1];

                if (Directory.Exists(inputDirectoryPath))
                {
                    // read nutrient data from files in filesystem to object model in memory
                    var dataProvider = new DirectoryDataProvider(inputDirectoryPath, 26, new WindowsTextReader());
                    var dbModel = new DatabaseRepresentation(dataProvider);

                    // create denormalized (flat) model based using database data
                    var denormalizedModel = new DenormalizedModel(dbModel);
                    // write flat model into CSV file as one big table
                    using (var writer = File.CreateText(outputCsvPath))
                    {
                        var csvWriter = new CsvWriter(writer);
                        csvWriter.WriteRecords(denormalizedModel.FoodItems);
                    }
                }
                else
                {
                    throw new ArgumentException(
                        "Specified directory does not exist or you don't have an access to it: " + inputDirectoryPath);
                }
            }
            else
            {
                throw new ArgumentException("No arguments were provided.");
            }
        }
    }
}