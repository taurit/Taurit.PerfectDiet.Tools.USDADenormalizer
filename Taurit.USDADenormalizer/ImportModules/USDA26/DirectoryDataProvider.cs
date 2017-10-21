using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Taurit.USDADenormalizer.Models.USDA26;

namespace Taurit.USDADenormalizer.ImportModules.USDA26
{
    /// <summary>
    ///     Reads original database's data from one of the formats it's distributed in (directory containing CSV files)
    /// </summary>
    public class DirectoryDataProvider : IUsdaDataProvider
    {
        private readonly string DatabasePathASCII;
        private readonly int DatabaseVersion;

        private readonly ITextReader FileReader;

        public DirectoryDataProvider(string databasePathAscii, int databaseVersion, ITextReader fileReaderParam)
        {
            DatabasePathASCII = databasePathAscii;
            DatabaseVersion = databaseVersion;
            FileReader = fileReaderParam;

            if (DatabaseVersion != 26)
                throw new ArgumentException("Only version 26 of the database is supported by this class");

            // Read and parse CSV data from the files
        }

        // Principal files - names
        private string FileNameFoodDescription => Path.Combine(DatabasePathASCII, "FOOD_DES.txt");

        private string FileNameNutrientData => Path.Combine(DatabasePathASCII, "NUT_DATA.txt");
        private string FileNameWeight => Path.Combine(DatabasePathASCII, "WEIGHT.txt");
        private string FileNameFootnote => Path.Combine(DatabasePathASCII, "FOOTNOTE.txt");

        // Support files - names
        private string FileNameFoodGroupDescription => Path.Combine(DatabasePathASCII, "FD_GROUP.txt");

        private string FileNameLangualFactor => Path.Combine(DatabasePathASCII, "LANGUAL.txt");
        private string FileNameLangualFactorsDescription => Path.Combine(DatabasePathASCII, "LANGDESC.txt");
        private string FileNameNutrientDefinition => Path.Combine(DatabasePathASCII, "NUTR_DEF.txt");
        private string FileNameSourceCode => Path.Combine(DatabasePathASCII, "SRC_CD.txt");
        private string FileNameDataDerivation => Path.Combine(DatabasePathASCII, "DERIV_CD.txt");
        private string FileNameSourcesOfData => Path.Combine(DatabasePathASCII, "DATA_SRC.txt");
        private string FileNameSourcesOfDataLink => Path.Combine(DatabasePathASCII, "DATSRCLN.txt");

        public List<DataDerivation> GetDataDerivation()
        {
            return ReadCSV<DataDerivation>(FileNameDataDerivation);
        }

        public List<FoodDescription> GetFoodDescription()
        {
            return ReadCSV<FoodDescription>(FileNameFoodDescription);
        }

        public List<FoodGroupDescription> GetFoodGroupDescription()
        {
            return ReadCSV<FoodGroupDescription>(FileNameFoodGroupDescription);
        }

        public List<Footnote> GetFootnote()
        {
            return ReadCSV<Footnote>(FileNameFootnote);
        }

        public List<LangualFactor> GetLangualFactor()
        {
            return ReadCSV<LangualFactor>(FileNameLangualFactor);
        }

        public List<LangualFactorsDescription> GetLangualFactorsDescription()
        {
            return ReadCSV<LangualFactorsDescription>(FileNameLangualFactorsDescription);
        }

        public List<NutrientData> GetNutrientData()
        {
            return ReadCSV<NutrientData>(FileNameNutrientData);
        }

        public List<NutrientDefinition> GetNutrientDefinition()
        {
            return ReadCSV<NutrientDefinition>(FileNameNutrientDefinition);
        }

        public List<SourceCode> GetSourceCode()
        {
            return ReadCSV<SourceCode>(FileNameSourceCode);
        }

        public List<SourcesOfData> GetSourcesOfData()
        {
            return ReadCSV<SourcesOfData>(FileNameSourcesOfData);
        }

        public List<SourcesOfDataLink> GetSourcesOfDataLink()
        {
            return ReadCSV<SourcesOfDataLink>(FileNameSourcesOfDataLink);
        }

        public List<Weight> GetWeight()
        {
            return ReadCSV<Weight>(FileNameWeight);
        }

        /// <summary>
        ///     Parse CSV file under a given path into list of objects
        /// </summary>
        /// <typeparam name="T">type of class containing public properties in the same order as in csv file</typeparam>
        /// <param name="fileName">path of the file to load</param>
        /// <returns></returns>
        private List<T> ReadCSV<T>(string fileName)
        {
            var entries = new List<T>();
            using (var reader = FileReader.OpenTextReader(fileName))
            {
                var csv = new CsvReader(reader, new Configuration
                {
                    Delimiter = "^",
                    Quote = '~',
                    HasHeaderRecord = false
                });
                entries = csv.GetRecords<T>().ToList();
            }

            return entries;
        }
    }
}