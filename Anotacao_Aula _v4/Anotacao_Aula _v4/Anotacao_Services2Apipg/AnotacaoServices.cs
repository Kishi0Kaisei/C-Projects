using Anotacao_BLpg;

namespace Anotacao_Services2Apipg
{
    public class AnotacaoServices
    {
        private readonly Lazy<Anotacao_BR> _anotacoes = new Lazy<Anotacao_BR>(() => new Anotacao_BR());

        public Anotacao_BR Anotacao=> _anotacoes.Value;
    }
}