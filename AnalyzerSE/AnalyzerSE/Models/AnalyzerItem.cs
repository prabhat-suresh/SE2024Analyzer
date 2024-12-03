using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnalyzerSE.Models
{
    public class AnalyzerItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; } // Tracks whether the analyzer is selected
        public IAnalyzer AnalyzerInstance { get; set; } // Holds the actual analyzer logic
    }
}