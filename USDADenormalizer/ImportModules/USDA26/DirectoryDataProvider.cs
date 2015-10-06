using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDADenormalizer.Models.USDA26;

namespace USDADenormalizer.ImportModules
{
    /// <summary>
    /// Reads original database's data from one of the formats it's distributed in (directory containing CSV files)
    /// </summary>
    public class DirectoryDataProvider : IUsdaDataProvider
    {
        private string DatabasePathASCII;
        private int DatabaseVersion;

        // Principal files - names
        private string FileNameFoodDescription { get { return Path.Combine(this.DatabasePathASCII, "FOOD_DES.txt"); } }
        private string FileNameNutrientData { get { return Path.Combine(this.DatabasePathASCII, "NUT_DATA.txt"); } }
        private string FileNameWeight { get { return Path.Combine(this.DatabasePathASCII, "WEIGHT.txt"); } }
        private string FileNameFootnote { get { return Path.Combine(this.DatabasePathASCII, "FOOTNOTE.txt"); } }

        // Support files - names
        private string FileNameFoodGroupDescription { get { return Path.Combine(this.DatabasePathASCII, "FD_GROUP.txt"); } }
        private string FileNameLangualFactor { get { return Path.Combine(this.DatabasePathASCII, "LANGUAL.txt"); } }
        private string FileNameLangualFactorsDescription { get { return Path.Combine(this.DatabasePathASCII, "LANGDESC.txt"); } }
        private string FileNameNutrientDefinition { get { return Path.Combine(this.DatabasePathASCII, "NUTR_DEF.txt"); } }
        private string FileNameSourceCode { get { return Path.Combine(this.DatabasePathASCII, "SRC_CD.txt"); } }
        private string FileNameDataDerivation { get { return Path.Combine(this.DatabasePathASCII, "DERIV_CD.txt"); } }
        private string FileNameSourcesOfData { get { return Path.Combine(this.DatabasePathASCII, "DATA_SRC.txt"); } }
        private string FileNameSourcesOfDataLink { get { return Path.Combine(this.DatabasePathASCII, "DATSRCLN.txt"); } }

        ITextReader FileReader;

        public DirectoryDataProvider(string databasePathAscii, int databaseVersion, ITextReader fileReaderParam)
        {
            this.DatabasePathASCII = databasePathAscii;
            this.DatabaseVersion = databaseVersion;
            this.FileReader = fileReaderParam;

            if (this.DatabaseVersion != 26)
                throw new ArgumentException("Only version 26 of the database is supported by this class");

            // Read and parse CSV data from the files
        }

        /// <summary>
        /// Parse CSV file under a given path into list of objects
        /// </summary>
        /// <typeparam name="T">type of class containing public properties in the same order as in csv file</typeparam>
        /// <param name="fileName">path of the file to load</param>
        /// <returns></returns>
        private List<T> ReadCSV<T>(string fileName)
        {
            List<T> entries = new List<T>();
            using (TextReader reader = this.FileReader.OpenTextReader(fileName))
            {
                var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration()
                {
                    Delimiter = "^",
                    Quote = '~',
                    HasHeaderRecord = false
                });
                entries = csv.GetRecords<T>().ToList();
            }

            return entries;
        }

        public List<DataDerivation> GetDataDerivation()
        {
            return ReadCSV<DataDerivation>(this.FileNameDataDerivation);
        }

        public List<FoodDescription> GetFoodDescription()
        {
            return ReadCSV<FoodDescription>(this.FileNameFoodDescription);
        }

        public List<FoodGroupDescription> GetFoodGroupDescription()
        {
            return ReadCSV<FoodGroupDescription>(this.FileNameFoodGroupDescription);
        }

        public List<Footnote> GetFootnote()
        {
            return ReadCSV<Footnote>(this.FileNameFootnote);
        }

        public List<LangualFactor> GetLangualFactor()
        {
            return ReadCSV<LangualFactor>(this.FileNameLangualFactor);
        }

        public List<LangualFactorsDescription> GetLangualFactorsDescription()
        {
            return ReadCSV<LangualFactorsDescription>(this.FileNameLangualFactorsDescription);
        }

        public List<NutrientData> GetNutrientData()
        {
            return ReadCSV<NutrientData>(this.FileNameNutrientData);
        }

        public List<NutrientDefinition> GetNutrientDefinition()
        {
            return ReadCSV<NutrientDefinition>(this.FileNameNutrientDefinition);
        }

        public List<SourceCode> GetSourceCode()
        {
            return ReadCSV<SourceCode>(this.FileNameSourceCode);
        }

        public List<SourcesOfData> GetSourcesOfData()
        {
            return ReadCSV<SourcesOfData>(this.FileNameSourcesOfData);

        }

        public List<SourcesOfDataLink> GetSourcesOfDataLink()
        {
            return ReadCSV<SourcesOfDataLink>(this.FileNameSourcesOfDataLink);

        }

        public List<Weight> GetWeight()
        {
            return ReadCSV<Weight>(this.FileNameWeight);

        }
    }
}
