using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNUsuario
    {
        private CDUsuario objcdusuario = new CDUsuario();

        public List<Usuario> Listar()
        {
            return objcdusuario.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if(obj.NombreCompleto == string.Empty)
            {
                Mensaje += "Ingrese el nombre del usuario\n";
            }

            if (obj.NroDocumento == string.Empty)
            {
                Mensaje += "Ingrese el número de documento\n";
            }

            if (obj.Clave == string.Empty)
            {
                Mensaje += "Ingrese la clave\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcdusuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NombreCompleto == string.Empty)
            {
                Mensaje += "Ingrese el nombre del usuario\n";
            }

            if (obj.NroDocumento == string.Empty)
            {
                Mensaje += "Ingrese el número de documento\n";
            }

            if (obj.Clave == string.Empty)
            {
                Mensaje += "Ingrese la clave\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcdusuario.Editar(obj, out Mensaje);
            }
        }

        public bool EliminarUsuario(Usuario obj, out string Mensaje)
        {
            return objcdusuario.EliminarUsuario(obj, out Mensaje);
        }
    }
}
