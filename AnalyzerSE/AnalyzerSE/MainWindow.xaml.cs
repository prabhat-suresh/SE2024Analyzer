using AnalyzerSE.Models;
using AnalyzerSE.Services;
using Microsoft.Win32; // Required for OpenFileDialog
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnalyzerSE.ViewModels;

namespace AnalyzerSE
{

    public partial class MainWindow : Window
    {
        private List<string> studentFiles = new List<string>();
        private List<string> customAnalyzers = new List<string>();
        private List<string> selectedAnalyzers = new List<string>();

        private AnalyzerViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new AnalyzerViewModel();
            DataContext = viewModel;
            LoadDefaultAnalyzers();
        }

        private void LoadDefaultAnalyzers()
        {
            // Add default analyzers
            //lstAnalyzers.Items.Add("Cyclomatic Complexity");
            //lstAnalyzers.Items.Add("Case Checker");
            //viewModel.Analyzers.Add(new AnalyzerItem
            //{
            //    Name = "Cyclomatic Complexity",
            //    IsSelected = false,
            //    AnalyzerInstance = new CyclomaticComplexityAnalyzer()
            //});
            //viewModel.Analyzers.Add(new AnalyzerItem
            //{
            //    Name = "Case Checker",
            //    IsSelected = false,
            //    AnalyzerInstance = new CaseCheckerAnalyzer()
            //});
        }

        private void UploadStudentFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    studentFiles.Add(file);
                }
                MessageBox.Show($"{openFileDialog.FileNames.Length} student file(s) uploaded.");
            }
        }

        private void UploadCustomAnalyzer(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    customAnalyzers.Add(file);
                }
                MessageBox.Show($"{openFileDialog.FileNames.Length} custom analyzer(s) uploaded.");
            }
        }


        private void RunAnalysis(object sender, RoutedEventArgs e)
        {
            var analyzers = new List<IAnalyzer>
                {
                    new CyclomaticComplexityAnalyzer(),
                    new CaseCheckerAnalyzer()
                };

            string report = "Analysis Results:\n";

            foreach (var file in studentFiles)
            {
                foreach (var analyzer in analyzers)
                {
                    var result = analyzer.Analyze(file);
                    report += $"{result.AnalyzerName}: {result.Verdict} - {result.Details}\n";
                }
            }

            txtReport.Text = report;

            // Save report to file
            string filePath = "AnalysisReport.txt";
            System.IO.File.WriteAllText(filePath, report);
            MessageBox.Show($"Analysis report saved to {filePath}.");
        }
    }
}