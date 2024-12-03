using AnalyzerSE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerSE.Models
{
    public interface IAnalyzer
    {
        string Name { get; }
        AnalyzerResult Analyze(string filePath);
    }
}