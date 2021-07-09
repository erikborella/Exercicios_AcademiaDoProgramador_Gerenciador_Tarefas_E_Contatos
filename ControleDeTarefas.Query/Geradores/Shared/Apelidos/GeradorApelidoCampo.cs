using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query.Campos;

namespace ControleDeTarefas.Query.Geradores.Shared.Apelidos
{
    public class GeradorApelidoCampo
    {
        private int contador = 1;
        public string PegarApelido(CampoBase campo)
        {
            string nomeFormal = PegarNomeFormal(campo);

            return $"{nomeFormal}_{campo.nome}";
        }

        private string PegarNomeFormal(CampoBase campo)
        {
            string nomeFormal;

            if (campo.modeloRef != null)
                nomeFormal = campo.modeloRef.NomeFormal.ToLower();
            else
            {
                nomeFormal = $"c{contador}";
                contador++;
            }

            return nomeFormal;
        }
    }
}
