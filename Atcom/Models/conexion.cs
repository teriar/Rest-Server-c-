using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EjercicioPractico.Models

{
    public class Conexion
    {
        private static string connString = @"Server=DESKTOP-C28GO1Q;;Database=scriptEvaluacion;User Id=usuario1;Password=163c9781b3;";

        protected SqlConnection conn = new SqlConnection(connString);


        public List<ClienteModel> WithStoreProdecure()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Select_Clientes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["IdCliente"]);
                            String Nombre = Convert.ToString(reader["Nombre"]);
                            String telefono = Convert.ToString(reader["Telefono"]);
                            String Email = Convert.ToString(reader["Email"]);
                            int CodigoPais = Convert.ToInt32(reader["CodigoPais"]);
                            String Descripcion = Convert.ToString(reader["Descripcion"]);

                            clientes.Add(new ClienteModel { IdCliente = id, Nombre = Nombre, Telefono = telefono, Email = Email, CodigoPais = CodigoPais, Descripcion = Descripcion });


                        }
                    }

                }
            }

            return clientes;
        }


        public List<ClienteModel> witEntity()
        {
            String descripcion = "";
            List<ClienteModel> lista = new List<ClienteModel>();
            var optionsBuilder = new DbContextOptionsBuilder<myDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-C28GO1Q;;Database=scriptEvaluacion;User Id=usuario1;Password=163c9781b3;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True") ;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            using (var dbContext = new myDbContext(optionsBuilder.Options))
                {
               

                var getClientes = dbContext.Clientes
                        .ToList();

                foreach (var cliente in getClientes)
                {

                    int codigo = cliente.CodigoPais;

                    var getPais = dbContext.pais
                     .Where(pais => pais.Codigo == codigo).ToList();

                    foreach (var pais in getPais)
                    {
                        descripcion = pais.Descripcion;
                    }
                    lista.Add(new ClienteModel { IdCliente = (int)cliente.IdCliente, Nombre = cliente.Nombre, Telefono = cliente.Telefono, Email = cliente.Email,
                        CodigoPais = cliente.CodigoPais, Descripcion = descripcion });
                    }


                }
            
            return lista;
        }

    }
}
