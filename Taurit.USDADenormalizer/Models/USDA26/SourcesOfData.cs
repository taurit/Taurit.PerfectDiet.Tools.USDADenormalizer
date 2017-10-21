using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// Sources of Data File (file name = DATA_SRC). This file (Table 15) provides a citation to the DataSrc_ID
    /// in the Sources of Data Link file.
    /// </summary>
    public class SourcesOfData
    {
        /// <summary>
        /// Unique number identifying the reference/source.
        /// </summary>
        public string DataSrcId { get; set; }

        /// <summary>
        /// List of authors for a journal article or name of sponsoring organization for other documents.
        /// </summary>
        public string Authors { get; set; }

        /// <summary>
        /// Title of article or name of document, such as a report from a company or trade association.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Year article or document was published.
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// Name of the journal in which the article was published.
        /// </summary>
        public string Journal { get; set; }

        /// <summary>
        /// Volume number for journal articles, books, or reports; city where sponsoring organization is located.
        /// </summary>
        public string VolCity { get; set; }

        /// <summary>
        /// Issue number for journal article; State where the sponsoring organization is located.
        /// </summary>
        public string IssueState { get; set; }

        /// <summary>
        /// Starting page number of article/document.
        /// </summary>
        public string StartPage { get; set; }

        /// <summary>
        /// Ending page number of article/document.
        /// </summary>
        public string EndPage { get; set; }

    }

}
