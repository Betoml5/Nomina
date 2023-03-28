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
            return contenedor.Empleado.OrderBy(x => x);
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
    }
}
