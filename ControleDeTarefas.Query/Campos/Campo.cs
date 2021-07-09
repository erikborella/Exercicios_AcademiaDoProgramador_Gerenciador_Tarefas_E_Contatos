namespace ControleDeTarefas.Query.Campos
{
    public class Campo<T> : CampoBase
    {
        public T Valor { get => (T)valor; set => valor = value; }
        public string Nome { get => nome; set => nome = value; }

        internal Campo(string nome, T valor = default, Modelo modeloRef = null)
        {
            Valor = valor;
            Nome = nome;
            this.modeloRef = modeloRef;
        }

    }
}
