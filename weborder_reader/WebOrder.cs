using System.Collections.Generic;
using System.Xml.Serialization;

namespace weborder_reader
{
    [XmlRoot(ElementName = "WebOrder")]
    public class WebOrder
    {
        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }

        [XmlElement(ElementName = "Date")]
        public XmlDateTime Date { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlArray(ElementName = "Items")]
        [XmlArrayItem("Item", Type = typeof(WebOrderItem))]
        public List<WebOrderItem> Items { get; set; }
    }
}
