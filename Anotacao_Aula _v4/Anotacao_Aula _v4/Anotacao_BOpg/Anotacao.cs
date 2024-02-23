using Anotacao_Consts;
using Compromissos_Models2Api;

namespace Anotacao_BOpg
{


    public class Anotacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Aula { get; set; }
        public Tipo Tipo { get; set; }
        public bool Revisto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="aula"></param>
        /// <param name="tipo"></param>
        /// <param name="revisto"></param>
        /// <exception cref="ArgumentNullException"></exception>

        //Constructs
        public Anotacao(string nome, string aula, Tipo tipo, bool revisto)
        {

            Revisto = false;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Aula = aula ?? throw new ArgumentNullException(nameof(aula));
            Tipo = tipo;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="aula"></param>
        /// <param name="tipo"></param>
        /// <param name="revisto"></param>

        public Anotacao(int id, string nome, string aula, Tipo tipo, bool revisto) : this(nome, aula, tipo, revisto)
        {
            Id = id;
            Revisto = revisto;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Revisto}\t{Id}, {Nome}, {Aula}, {Tipo}";
        }
    }
}