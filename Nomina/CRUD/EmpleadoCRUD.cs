using Microsoft.EntityFrameworkCore;
using Nomina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.CRUD
{
    public class EmpleadoCRUD
    {

        NominaContext contenedor = new();


        public IEnumerable<Empleado> Obtener()
        {

            return contenedor.Empleado
                .Include(x => x.IdCategoriaNavigation).OrderBy(x => x);
        }

        public Empleado ObtenerPorId(Empleado Empleado)
        {
            return contenedor.Empleado.Find(Empleado);
        }

        public void Crear (Empleado Empleado)
        {

            if (Empleado != null)
            {
                contenedor.Empleado.Add(Empleado);
                contenedor.SaveChanges();
                contenedor.Entry(Empleado).Reload();
            }

        }

        public void Actualizar (Empleado Empleado)
        {
            if (Empleado != null)
            {
                contenedor.Empleado.Update(Empleado);
                contenedor.SaveChanges();
                contenedor.Entry(Empleado).Reload();
            }
        }

        public void Eliminar(Empleado Empleado)
        {
            if (Empleado != null)
            {
                contenedor.Empleado.Remove(Empleado);
                contenedor.SaveChanges();
            }
        }

        public void CambiarEstadoPorId(Empleado Empleado)
        {
            if (Empleado != null)
            {
                if (Empleado.Activo == 1)
                    Empleado.Activo = 0;
                else Empleado.Activo = 1;
            }
            contenedor.SaveChanges();
            contenedor.Entry(Empleado).Reload();
        }

        public int ObtenerPorCategoria(int Id) {
            return contenedor.Empleado.Where(x => x.IdCategoria == Id).Count();
        }
    }
}
