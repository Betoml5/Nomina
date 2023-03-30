using Nomina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.CRUD
{
    public class CategoriaCRUD
    {

        NominaContext contenedor = new();

        public IEnumerable<Categoria> Obtener()
        {
            return contenedor.Categoria.OrderBy(x => x);
        }

        

    }
}
