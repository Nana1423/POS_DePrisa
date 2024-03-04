using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.negocios
{
    internal class UsuarioServices
    {

        private DUsuario dUsuario;

        public UsuarioServices()
        {
            dUsuario = new DUsuario();
        }

        public ResultadoOperacion guardar(Usuario usuario)
        {

            ResultadoOperacion resultado = new ResultadoOperacion();


            if (!dUsuario.validarUsuarioUnico(usuario))
            {
                resultado.Mensaje = "El nombre de usuario ya existe";
                resultado.IsExitoso = false;
                return resultado;

            }

            if (!dUsuario.GuardarUsuario(usuario))
            {
                resultado.Mensaje = "Error al guardar el usuario";
                resultado.IsExitoso = false;
                return resultado;
            }

            resultado.Mensaje = "Usuario guardado con éxito";
            resultado.IsExitoso = true;
            return resultado;

        }

        public DataSet obtenerRoles()
        {
            DRol dRol = new DRol();
            return dRol.ListarRoles();
        }

        public DataSet listarUsuarios()
        {
            return dUsuario.ListarUsuarios();
        }   


    }
}
