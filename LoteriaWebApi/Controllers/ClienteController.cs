using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace AgendaWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IClienteLN gObjUsuarioLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public ClienteController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("AgendaBD");
            gObjUsuarioLN = new ClienteLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Cliente>> recClientePA()
        {
            List<Cliente> lObjRespuesta = new List<Cliente>();

            try
            {
                lObjRespuesta = gObjUsuarioLN.recClientePA();

                // Convierte la lista de Usuario a una lista de UserDto excluyendo el campo 'Clave'
                var ListaUsuario = lObjRespuesta.Select(u => new Cliente
                {
                    IdCliente = u.IdCliente,
                    Nombre = u.Nombre,
                    Cedula = u.Cedula,
                    Telefono = u.Telefono,
                    Telefono2 = u.Telefono,
                    Email = u.Email,
                    Facebook = u.Facebook,
                    Instagram = u.Instagram,
                    Tiktok = u.Tiktok,
                    LinkedIn = u.LinkedIn,
                    Website = u.Website,
                    Strikes = u.Strikes,
                    Estado = u.Estado,
                    EstadoAzure = u.EstadoAzure,
                    AzureURL = u.AzureURL,
                    IdCategoria = u.IdCategoria,
                    IdProvincia = u.IdProvincia
                }).ToList();

                return Ok(ListaUsuario); // Retorna un HTTP 200 con la lista de usuarios.
            }
            catch (Exception lEx)
            {
                // Registrar el error, de manera similar al código anterior en .NET Framework
                gObjError.Error("SE HA PRODUCIDO UN ERROR. Detalle: " + lEx.Message +
                                "// " + (lEx.InnerException?.Message ?? "No Inner Exception") +
                                ". Método: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());

                // Retornar un InternalServerError con un código HTTP 500
                return StatusCode(StatusCodes.Status500InternalServerError, lEx.Message);
            }
        }




        [Route("[action]/{pIdCliente}")]
        [HttpGet]
        public Cliente recClienteXIdPA(int pIdCliente)
        {
            Cliente lObjRespuesta = new Cliente();

            try
            {
                lObjRespuesta = gObjUsuarioLN.recClientePAXId(pIdCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insClientePA([FromBody] Cliente pCliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjUsuarioLN.insClientePA(pCliente);
                    return Ok(pCliente);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
        }

        [Route("[action]")]
        [HttpPut]
        public IActionResult modClientePA([FromBody] Cliente pCliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjUsuarioLN.modClientePA(pCliente);
                    return Ok(pCliente);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
        }

        [Route("[action]/{pCliente}")]
        [HttpDelete]
        public IActionResult delClientePA(int pCliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lCliente = gObjUsuarioLN.recClientePAXId(pCliente);
                    if (lCliente != null)
                    {
                        gObjUsuarioLN.delClientePA(lCliente);
                        return Ok(lCliente);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
        }
    }

}
