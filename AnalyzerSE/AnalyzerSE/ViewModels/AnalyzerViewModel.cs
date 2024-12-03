using AnalyzerSE.Models;
using AnalyzerSE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerSE.ViewModels
{
    public class AnalyzerViewModel
    {
        public ObservableCollection<AnalyzerItem> Analyzers { get; set; }

        public AnalyzerViewModel()
        {
            // Initialize the dynamic list of analyzers
            Analyzers = new ObservableCollection<AnalyzerItem>
            {
                new AnalyzerItem { Name = "Cyclomatic Complexity", IsSelected = false, AnalyzerInstance = new CyclomaticComplexityAnalyzer() },
                new AnalyzerItem { Name = "Case Checker", IsSelected = false, AnalyzerInstance = new CaseCheckerAnalyzer() }
            };
        }
    }
}