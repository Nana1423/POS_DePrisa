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
    internal class CategoriaServices
    {
        private DCategoria dCategoria;

        public CategoriaServices()
        {
            dCategoria = new DCategoria();
        }

        public DataSet listarCategoria()
        {
            return dCategoria.ListarCategorias();
        }

        public ResultadoOperacion guardar(Categoria categoria)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();

            if (categoria is null)
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "La categoria no puede ser nula";
                return resultado;
            }

            if (dCategoria.validarCategoriaUnica(categoria))
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "El nombre de la categoria ya existe";
                return resultado;
            }

            if (!dCategoria.GuardarCategoria(categoria))
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "Error al guardar la categoria";
                return resultado;
            }

            resultado.IsExitoso = true;
            resultado.Mensaje = "Categoria guardada con éxito";
            return resultado;
        }

        public ResultadoOperacion actualizarCategoria(Categoria categoria)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();

            if (categoria is null)
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "La categoria no puede ser nula";
                return resultado;
            }

            if (dCategoria.validarCategoriaUnica(categoria))
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "El nombre de la categoria ya existe";
                return resultado;
            }

            if (!dCategoria.actualizarCategoria(categoria))
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "Error al actualizar la categoria";
                return resultado;
            }

            resultado.IsExitoso = true;
            resultado.Mensaje = "Categoria actualizada con éxito";
            return resultado;

        }

        public DataSet buscar(String nombre)
        {
            return dCategoria.buscarCategoria(nombre);
        }



    }
}
