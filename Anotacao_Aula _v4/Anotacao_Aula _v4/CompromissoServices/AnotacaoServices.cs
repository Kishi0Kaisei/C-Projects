using Anotacao_BL;

namespace CompromissoServices
{
    public class AnotacaoServices
    {
        private readonly Lazy<Anotacao_BR> _anotacoes =
            new Lazy<Anotacao_BR>(() => new Anotacao_BR());

        public Anotacao_BR Anotacoes => _anotacoes.Value;
    }
}