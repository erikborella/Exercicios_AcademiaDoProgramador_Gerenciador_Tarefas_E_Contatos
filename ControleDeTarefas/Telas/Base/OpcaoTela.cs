namespace ControleDeTarefas.Telas.Base
{
    class OpcaoTela
    {
        private int n;
        private TelaBase tela;

        public OpcaoTela(int n, TelaBase tela)
        {
            this.n = n;
            this.tela = tela;
        }

        public int N { get => n; set => n = value; }
        public TelaBase Menu { get => tela; set => tela = value; }
    }
}
