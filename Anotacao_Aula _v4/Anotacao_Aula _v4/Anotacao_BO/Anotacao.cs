using Anotacao_Consts;
using System.Xml.Serialization;
using Compromissos_Models2Api;
using ToolBox;

namespace Anotacao_BO
{
    [Serializable]
    public struct RegistoAnotacao
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Nome { get; set; }
        
        [XmlElement]
        public string Aula { get; set; }
        
        [XmlElement]
        public Tipo Tipo { get; set; }
        
        [XmlElement]
        public bool Revisto { get; set; }

        public override string? ToString()
        {
            return $"{Revisto}\t{Id}, {Nome}, {Aula}, {Tipo}";
        }
    }
  
    public class Anotacao
    {   public int Id { get; set; }
        public string Nome { get; set; }
        public string Aula { get; set; }

        public Tipo Tipo { get; set; }

        public bool Revisto { get; set; }


        //Constructs
        public Anotacao(string nome, string aula, Tipo tipo, bool revisto)
        {
            Id = GetNewId.Instancia.Proximo;
            Revisto = false;
            Nome = nome;
            Aula = aula;
            Tipo = tipo;

        }

        public Anotacao(RegistoAnotacao anotacao) 
        {
            Id = anotacao.Id;
            Nome = anotacao.Nome;
            Aula = anotacao.Aula;
            Tipo= anotacao.Tipo;
            Revisto= anotacao.Revisto;
        }

        public RegistoAnotacao RegistoAnotacao()
        {
            return new RegistoAnotacao
            {
                Id=this.Id,
                Nome=this.Nome,
                Aula=this.Aula,
                Tipo=this.Tipo,
                Revisto=this.Revisto,
            };
        }

        public AnotacaoRegistoResponse RegistoAnotacaoResponse()
        {
            return new AnotacaoRegistoResponse
            {
                Id = this.Id,
                Nome = this.Nome,
                Aula = this.Aula,
                Tipo = this.Tipo,
                Revisto = this.Revisto,
              
            };
        }

        public override string ToString()
        {
            return $"{Revisto}\t{Id}, {Nome}, {Aula}, {Tipo}";
        }
    }
}