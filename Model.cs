using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OrchardToMarkdown
{
    [Serializable]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Orchard
    {
        public OrchardRecipe Recpie { get; set; }

        public OrchardData Data { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardData
    {
        [XmlElement("BlogPost", Form = XmlSchemaForm.Unqualified)]
        public OrchardDataBlogPost[] BlogPost { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardDataBlogPost
    {
        [XmlElement("BodyPart", Form = XmlSchemaForm.Unqualified)]
        public OrchardDataBlogPostBodyPart BodyPart { get; set; }

        [XmlElement("CommonPart", Form = XmlSchemaForm.Unqualified)]
        public OrchardDataBlogPostCommonPart CommonPart { get; set; }

        [XmlElement("AutoroutePart", Form = XmlSchemaForm.Unqualified)]
        public OrchardDataBlogPostAutoroutePart AutoroutePart { get; set; }

        [XmlElement("TitlePart", Form = XmlSchemaForm.Unqualified)]
        public OrchardDataBlogPostTitlePart TitlePart { get; set; }

        [XmlElement("TagsPart", Form = XmlSchemaForm.Unqualified)]
        public OrchardDataBlogPostTagsPart TagsPart { get; set; }

        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Status { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardDataBlogPostBodyPart
    {
        [XmlAttribute]
        public string Text { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardDataBlogPostCommonPart
    {
        [XmlAttribute]
        public string Owner { get; set; }

        [XmlAttribute]
        public string Container { get; set; }

        [XmlAttribute]
        public string CreatedUtc { get; set; }

        [XmlAttribute]
        public string PublishedUtc { get; set; }

        [XmlAttribute]
        public string ModifiedUtc { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardDataBlogPostAutoroutePart
    {
        [XmlAttribute]
        public string Alias { get; set; }

        [XmlAttribute]
        public string UseCustomPattern { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardDataBlogPostTitlePart
    {
        [XmlAttribute]
        public string Title { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardDataBlogPostTagsPart
    {
        [XmlAttribute]
        public string Tags { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class OrchardRecipe
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Author { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ExportUtc { get; set; }
    }
}