using System;
using System.IO;
using System.Linq;
using NLog;

namespace OrchardToMarkdown
{
    public class MarkdownConverter
    {
        private static readonly Logger Logger;

        static MarkdownConverter()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Convert(FileInfo exportFile)
        {
            Logger.Info("Deserializeing data from file...");

            var deserializer = new OrchardDeserializer();
            var writer = new PostWriter();
            var orchard = deserializer.Deserialize(exportFile);

            Logger.Info("Found {0} posts...", orchard.Data.BlogPost.Length);

            foreach (var post in orchard.Data.BlogPost)
            {
                Logger.Debug("Converting post {0}", post.Id);
                writer.Write(post);
            }
        }
    }
}