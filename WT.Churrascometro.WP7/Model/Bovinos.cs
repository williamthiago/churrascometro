using System.Collections.Generic;
using System.Xml.Serialization;

namespace WT.Churrascometro.WP7.Model
{
    public class Bovinos
    {
        [XmlElement("Bovino")]
        public List<Bovino> Itens { get; set; }
    }
}