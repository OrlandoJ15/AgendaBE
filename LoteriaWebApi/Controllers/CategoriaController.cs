using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace AgendaWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatergoriaController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly ICategoriaLN gObjCategoriaLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public CatergoriaController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("AgendaBD");
            gObjCategoriaLN = new CategoriaLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult< List<Categoria>> recCategoriaPA()
        {
            List<Categoria> lObjRespuesta = new List<Categoria>();

            try
            {
                lObjRespuesta = gObjCategoriaLN.recCategoriaPA();

                // Convierte la lista de Usuario a una lista de UserDto excluyendo el campo 'Clave'
                var ListaCategoroa = lObjRespuesta.Select(u => new Categoria
                {
                    IdCategoria = u.IdCategoria,
                    Nombre = u.Nombre
                }).ToList();

                return Ok(ListaCategoroa); // Retorna un HTTP 200 con la lista de usuarios.
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




        [Route("[action]/{pCategoria}")]
        [HttpGet]
        public Categoria recCategoriaXId_PA(int pCategoria)
        {
            Categoria lObjRespuesta = new Categoria();

            try
            {
                lObjRespuesta = gObjCategoriaLN.recCategoriaPAXId(pCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insCategoriaPA([FromBody] Categoria pCategoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjCategoriaLN.insCategoriaPA(pCategoria);
                    return Ok(pCategoria);
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
        public IActionResult modCategoriaPA([FromBody] Categoria pCategoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjCategoriaLN.modCategoriaPA(pCategoria);
                    return Ok(pCategoria);
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

        [Route("[action]/{pCategoria}")]
        [HttpDelete]
        public IActionResult delCategoriaPA(int pCategoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lCategortia = gObjCategoriaLN.recCategoriaPAXId(pCategoria);
                    if (lCategortia != null)
                    {
                        gObjCategoriaLN.delCategoriaPA(lCategortia);
                        return Ok(lCategortia);
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
