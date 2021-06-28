using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Controladores
{
    public interface IControlavel<T>
    {
        bool Inserir(T registro);

        bool Editar(T registro, string[] campos = null);

        bool Excluir(int id);

        T BuscarRegistroPorId(int id);

        T[] BuscarRegistros();

        string NomeTabela { get; }
    }
}
