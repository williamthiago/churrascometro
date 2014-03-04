using System.Xml.Serialization;

namespace WT.Churrascometro.WP7.Model
{
    public class ItemTipo2
    {
        [XmlAttribute]
        public string Nome { get; set; }

        [XmlAttribute]
        public string Medida { get; set; }
        
        [XmlAttribute]
        public decimal PesoA { get; set; }
        
        [XmlAttribute]
        public decimal PesoB { get; set; }
        
        [XmlAttribute]
        public decimal PesoC { get; set; }
        
        [XmlAttribute]
        public decimal PesoD { get; set; }
    }
}