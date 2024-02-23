using Anotacao_Consts;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Compromissos_Models2Api
{
    public class AnotacaoRegistoRequest
    {
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