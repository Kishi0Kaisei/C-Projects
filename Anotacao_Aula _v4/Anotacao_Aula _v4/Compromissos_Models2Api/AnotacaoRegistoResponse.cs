using Anotacao_Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Compromissos_Models2Api
{
    public class AnotacaoRegistoResponse
    {
        [property: JsonPropertyName("id")]
        public int Id { get; set; }

        [property: JsonPropertyName("nome")]
        public string Nome { get; set; }

        [property: JsonPropertyName("aula")]
        public string Aula { get; set; }

        [property: JsonPropertyName("tipo")]
        public Tipo Tipo { get; set; }

        [property: JsonPropertyName("revisto")]
        public bool Revisto { get; set; }
    }
}
