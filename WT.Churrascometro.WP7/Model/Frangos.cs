using System.Collections.Generic;
using System.Xml.Serialization;

namespace WT.Churrascometro.WP7.Model
{
    public class Frangos
    {
        [XmlElement("Frango")]
        public List<Frango> Itens { get; set; }
    }
}