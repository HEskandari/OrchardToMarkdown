using System.IO;
using NLog.Config;

namespace OrchardToMarkdown
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SimpleConfigurator.ConfigureForConsoleLogging();

			var file = new FileInfo(@"C:\Dropbox\Dropbox\NewSite\posts export.xml");
            var converter = new MarkdownConverter();

            converter.Convert(file);
            
        }
    }
}
