using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Website
{
    public class AsciiAnalyzer:StandardAnalyzer
    {
        
        public AsciiAnalyzer(Version matchVersion) : this(matchVersion, StandardAnalyzer.STOP_WORDS_SET)
        {
        }

        /// <summary>Builds an analyzer with the given stop words.</summary>
        /// <param name="matchVersion">Lucene version to match See <see cref="T:Lucene.Net.Util.Version">above</see> /&gt;
        /// </param>
        /// <param name="stopWords">stop words 
        /// </param>
        public AsciiAnalyzer(Version matchVersion, ISet<string> stopWords):base(matchVersion, stopWords)
        {
        }
        

        /// <summary>Builds an analyzer with the stop words from the given file.</summary>
        /// <seealso cref="M:Lucene.Net.Analysis.WordlistLoader.GetWordSet(System.IO.FileInfo)">
        /// </seealso>
        /// <param name="matchVersion">Lucene version to match See <see cref="T:Lucene.Net.Util.Version">above</see> /&gt;
        /// </param>
        /// <param name="stopwords">File to read stop words from 
        /// </param>
        public AsciiAnalyzer(Version matchVersion, FileInfo stopwords) : this(matchVersion, WordlistLoader.GetWordSet(stopwords))
        {
        }

        /// <summary>Builds an analyzer with the stop words from the given reader.</summary>
        /// <seealso cref="M:Lucene.Net.Analysis.WordlistLoader.GetWordSet(System.IO.TextReader)">
        /// </seealso>
        /// <param name="matchVersion">Lucene version to match See <see cref="T:Lucene.Net.Util.Version">above</see> /&gt;
        /// </param>
        /// <param name="stopwords">Reader to read stop words from 
        /// </param>
        public AsciiAnalyzer(Version matchVersion, TextReader stopwords)
            : this(matchVersion, WordlistLoader.GetWordSet(stopwords))
        {
        }

        public override TokenStream ReusableTokenStream(string fieldName, TextReader reader)
        {
            return new ASCIIFoldingFilter(base.ReusableTokenStream(fieldName, reader));
        }
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            return new ASCIIFoldingFilter(base.TokenStream(fieldName, reader));            
        }
    }
}