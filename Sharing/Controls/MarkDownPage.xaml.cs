using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Markdig;

namespace Sharing.Controls
{
    /// <summary>
    /// MarkDownPage.xaml 的互動邏輯
    /// </summary>
    public partial class MarkDownPage : UserControl
    {
        public MarkDownPage()
        {
            InitializeComponent();

            CreateHtml();
        }

        private void CreateHtml()
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();

            var sourceText = Properties.Resources.MarkDown;
            var markdownText = Markdig.Markdown.ToHtml(sourceText, pipeline);
            const string ouputPath = "result.html";
            File.WriteAllText(ouputPath, markdownText);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Parameter}") { CreateNoWindow = true });
        }
    }
}
