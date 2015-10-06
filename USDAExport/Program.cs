using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDADenormalizer.ImportModules;
using USDADenormalizer.Models.USDA26;

namespace USDAExport
{
    /// <summary>
    /// A simple aplication that use USDADenormalizer Portable Class Library to load
    /// USDA Database in original format and export it to a range of other supported formats
    /// </summary>
    class Program
    {
        /// <summary>
        /// Application entry point.
        /// Opens USDA Nutrient database (revision 26), denormalizes it using UsdaDenormalizer library
        /// and writes result to a CSV file with a specified name.
        /// </summary>
        /// <param name="args">
        /// [0] path to the directory containing ASCII version of database
        /// [2] path to the output CSV file
        /// </param>
        static void Main(string[] args)
        {
            // check if input is valid
            if (args.Length > 1)
            {
                string inputDirectoryPath = args[0];
                string outputCsvPath = args[1];

                if (System.IO.Directory.Exists(inputDirectoryPath))
                {
                    // read nutrient data from files in filesystem to object model in memory
                    DirectoryDataProvider dataProvider = new DirectoryDataProvider(inputDirectoryPath, 26, new WindowsTextReader());
                    DatabaseRepresentation dbModel = new DatabaseRepresentation(dataProvider);

                    // create denormalized (flat) model based using database data
                    DenormalizedModel denormalizedModel = new DenormalizedModel(dbModel);
                    // write flat model into CSV file as one big table
                    using (var writer = System.IO.File.CreateText(outputCsvPath))
                    {
                        CsvHelper.CsvWriter csvWriter = new CsvHelper.CsvWriter(writer);
                        csvWriter.WriteRecords(denormalizedModel.FoodItems);
                    }
                }
                else
                {
                    throw new ArgumentException("Specified directory does not exist or you don't have an access to it: " + inputDirectoryPath);
                }
            }
            else
            {
                throw new ArgumentException("No arguments were provided.");
            }

        }
    }
}
