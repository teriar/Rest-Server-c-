using EjercicioPractico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EjercicioPractico.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteModel>> GetAll()
        {
            ClienteModel model = new ClienteModel();
            List<ClienteModel> listCLientes = model.traerClientesStore();
            return listCLientes;
        }

        [HttpGet("{all}")]
        public ActionResult<List<ClienteModel>> GetAllEntity()
        {
            ClienteModel model = new ClienteModel();
            List<ClienteModel> listCLientes = model.traerClientesEntity();
            return listCLientes;

        }
    }


}