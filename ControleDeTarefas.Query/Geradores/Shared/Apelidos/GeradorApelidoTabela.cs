using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores.Shared.Apelidos
{
    public class GeradorApelidoTabela : IEnumerable
    {
        int contador = 1;
        Dictionary<string, string> apelidos = new Dictionary<string, string>();

        public string this[Modelo o]
        {
            get {
                string chave = PegarNomeClasse(o);

                if (!apelidos.ContainsKey(chave))
                    this.Add(o);
                
                return apelidos[chave];
            }
        }

        public void Add(Modelo o)
        {
            string chave = PegarNomeClasse(o);

            if (apelidos.ContainsKey(chave))
                return;

            string apelido = $"T{contador}";
            apelidos.Add(chave, apelido);

            contador++;
        }

        public IEnumerator GetEnumerator()
        {
            return apelidos.GetEnumerator();
        }

        private string PegarNomeClasse(object o)
        {
            return o.GetType().FullName;
        }
    }
}
