using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using NLog;

namespace OrchardToMarkdown
{
    public class PostWriter
    {
        private static readonly Logger Logger;

        static PostWriter()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Write(OrchardDataBlogPost post)
        {
            Logger.Info("Writing post with Id {0}", post.Id);

            var builder = WritePost(post);
            var fullpath = GetFullpath(post);
            var file = new FileInfo(fullpath);
            
            using (var fs = file.OpenWrite())
            {
                var bytes = new UTF8Encoding().GetBytes(builder.ToString());
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        private StringBuilder WritePost(OrchardDataBlogPost post)
        {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                WriteHeader(writer, post);
                WriteBody(writer, post);

                writer.Flush();
            }

            return builder;
        }

        private void WriteBody(StringWriter writer, OrchardDataBlogPost post)
        {
            var body = post.BodyPart.Text;
            writer.Write(body);
        }

        private static void WriteHeader(StringWriter writer, OrchardDataBlogPost post)
        {
            var tags = post.TagsPart.Tags.Split(',').Select(x => x.Trim());
            var categories = string.Join(" ", tags);
            var date = DateTime.Parse(post.CommonPart.PublishedUtc);
			var author = post.CommonPart.Owner.Replace(@"/User.UserName=", "");
            var title = post.TitlePart.Title;
            var route = post.AutoroutePart.Alias;

            writer.WriteLine("---");
            writer.WriteLine("layout: post");
            writer.WriteLine("title: \"{0}\"", title);
			writer.WriteLine("author: \"{0}\"", author);
            writer.WriteLine("date: {0}", date.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteLine("categories: {0}", categories);
            writer.WriteLine("---");
        }

        private static string GetFullpath(OrchardDataBlogPost post)
        {
            var date = DateTime.Parse(post.CommonPart.PublishedUtc);
            var title = post.TitlePart.Title;

            var escapedTitle = EncodeTitle(title);
            var filename = string.Format("{0}-{1:00}-{2:00}-{3}.markdown", date.Year, date.Month, date.Day, escapedTitle);
            var directory = @"C:\Temp\posts";
            var fullpath = Path.Combine(directory, filename);
            
            return fullpath;
        }

        private static string EncodeTitle(string title)
        {
            var escapedTitle = new StringBuilder();
            
            foreach (var c in title)
            {
                if (Char.IsPunctuation(c) ||
                    Char.IsSymbol(c)) continue;

                escapedTitle.Append(c);
            }

            return escapedTitle.ToString();
        }
    }
}