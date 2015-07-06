using System.IO;
using System.Xml.Serialization;

namespace OrchardToMarkdown
{
    public class OrchardDeserializer
    {
        public Orchard Deserialize(FileInfo file)
        {
            var serializer = new XmlSerializer(typeof(Orchard));

            using (var fs = file.OpenRead())
            using (var reader = new StreamReader(fs))
            {
                return (Orchard) serializer.Deserialize(reader);
            }
        }
    }
}