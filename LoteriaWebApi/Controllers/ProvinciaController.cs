using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace AgendaWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly IProvinciaLN gObjProvinciaLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public ProvinciaController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("AgendaBD");
            gObjProvinciaLN = new ProvinciaLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult< List<Provincia>> recProvinciaPA()
        {
            List<Provincia> lObjRespuesta = new List<Provincia>();

            try
            {
                lObjRespuesta = gObjProvinciaLN.recProvinciaPA();

                // Convierte la lista de Usuario a una lista de UserDto excluyendo el campo 'Clave'
                var ListaProvincia = lObjRespuesta.Select(u => new Provincia
                {
                    IdProvincia = u.IdProvincia,
                    Codigo = u.Codigo,
                    provincia = u.provincia

                }).ToList();

                return Ok(ListaProvincia); // Retorna un HTTP 200 con la lista de usuarios.
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




        [Route("[action]/{pProvincia}")]
        [HttpGet]
        public Provincia recProvinciaXId_PA(int pProvincia)
        {
            Provincia lObjRespuesta = new Provincia();

            try
            {
                lObjRespuesta = gObjProvinciaLN.recProvinciaPAXId(pProvincia);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insProvinciaPA([FromBody] Provincia pProvincia)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjProvinciaLN.insProvinciaPA(pProvincia);
                    return Ok(pProvincia);
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
        public IActionResult modProvinciaPA([FromBody] Provincia pProvincia)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjProvinciaLN.modProvinciaPA(pProvincia);
                    return Ok(pProvincia);
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

        [Route("[action]/{pProvincia}")]
        [HttpDelete]
        public IActionResult delProvinciaPA(int pProvincia)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lProvincia = gObjProvinciaLN.recProvinciaPAXId(pProvincia);
                    if (lProvincia != null)
                    {
                        gObjProvinciaLN.delProvinciaPA(lProvincia);
                        return Ok(lProvincia);
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
