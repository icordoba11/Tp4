using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp4
{
    [Serializable]
    public class Pasajero
    {
        public string Nombre { get; set; }
        public string CodigoVuelo { get; set; }

        public Pasajero() { }
        public Pasajero(string nombre, string codigoVuelo)
        {
            Nombre = nombre;
            CodigoVuelo = codigoVuelo;
        }
    }
}
