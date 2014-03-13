using System.Collections.Generic;
using System.Xml.Serialization;

namespace WT.Churrascometro.WP7.Model
{
    public class Opcoes
    {
        [XmlElement("Opcao")]
        public List<Opcao> Itens { get; set; }
    }
}