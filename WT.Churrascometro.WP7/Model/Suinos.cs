using System.Collections.Generic;
using System.Xml.Serialization;

namespace WT.Churrascometro.WP7.Model
{
    public class Suinos
    {
        [XmlElement("Suino")]
        public List<Suino> Itens { get; set; }
    }
}