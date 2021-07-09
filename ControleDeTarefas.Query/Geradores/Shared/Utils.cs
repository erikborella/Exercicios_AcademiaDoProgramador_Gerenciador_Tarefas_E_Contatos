using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query.Campos;

namespace ControleDeTarefas.Query.Geradores.Shared
{
    internal static class Utils
    {
        internal static string PegarValorParaDB(object valor)
        {
            string valorRetorno = (valor == null) ? "NULL" : $"\'{valor}\'";

            return valorRetorno;
        }

        internal static string PegarValorParaDB(CampoBase campo)
        {

            if (campo == null || campo.valor == null)
                return PegarValorParaDB((object) null);

            if (campo is CampoRelacionavelBase)
            {
                return PegarValorParaDB((campo as CampoRelacionavelBase).Valor.Id);
            }

            if (campo.valor is Enum)
            {
                try
                {
                    return PegarValorParaDB((campo.valor as Enum).ToString("D"));
                }
                catch (Exception)
                { }
            }

            return PegarValorParaDB(campo.valor);
        }
    }
}
