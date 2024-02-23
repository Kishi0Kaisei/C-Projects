namespace ToolBox
{
    public class GetNewId
    {
        private static GetNewId instancia;
        private static int contador = 0;

        private GetNewId() { }

        public int Proximo => ++contador;

        public static GetNewId Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GetNewId();
                }
                return instancia;
            }
        }

        public void ResetProximo(int novoInicioContador)
        {
            contador = novoInicioContador;
        }
    }
}
