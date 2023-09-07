using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EjercicioPractico.Models
{
    public class ClienteModel
    {
      
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int CodigoPais { get; set; }

        public string Descripcion { get; set; }

        public List<ClienteModel> traerClientesStore()
        {
            Conexion conexion = new Conexion();

            List<ClienteModel> clientes = conexion.WithStoreProdecure();

            return clientes;
        }

        public List<ClienteModel> traerClientesEntity()
        {
            Conexion conexion = new Conexion();

            List<ClienteModel> clientes = conexion.witEntity();

            return clientes;
        }

    }

    public class Cliente
    {
        [Key]
        public decimal IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int CodigoPais { get; set; }

        
    }


    }
