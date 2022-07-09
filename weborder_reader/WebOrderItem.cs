using System.Xml.Serialization;

namespace weborder_reader
{
    public class WebOrderItem
    {
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public decimal Quantity { get; set; }
    }
}
