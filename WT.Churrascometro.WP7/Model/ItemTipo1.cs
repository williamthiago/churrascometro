using System.Xml.Serialization;
namespace WT.Churrascometro.WP7.Model
{
    public class ItemTipo1
    {
        [XmlAttribute]
        public string Nome { get; set; }

        [XmlAttribute]
        public decimal Peso { get; set; }
    }
}