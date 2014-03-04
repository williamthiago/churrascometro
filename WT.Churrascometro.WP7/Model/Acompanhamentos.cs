using System.Collections.Generic;
using System.Xml.Serialization;

namespace WT.Churrascometro.WP7.Model
{
    public class Acompanhamentos
    {
        [XmlElement("Acompanhamento")]
        public List<Acompanhamento> Itens { get; set; }
    }
}