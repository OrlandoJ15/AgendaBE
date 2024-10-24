using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Interfaz;
using LogicaNegocio.Implementacion;
using NLog;
using Entidades.Models;

namespace AgendaWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCatergoriaController : ControllerBase
    {
        public IConfiguration lConfiguration;

        private readonly ISubCategoriaLN gObjSubCategoriaLN;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        
        public SubCatergoriaController(IConfiguration lConfig)
        {
            lConfiguration = lConfig;
            string lCadenaConexcion = lConfiguration.GetConnectionString("AgendaBD");
            gObjSubCategoriaLN = new SubCategoriaLN(lConfiguration);
        }


        [Route("[action]")]
        [HttpGet]
        public ActionResult< List<Subcategoria>> recSubCategoriaPA()
        {
            List<Subcategoria> lObjRespuesta = new List<Subcategoria>();

            try
            {
                lObjRespuesta = gObjSubCategoriaLN.recSubCategoriaPA();

                // Convierte la lista de Usuario a una lista de UserDto excluyendo el campo 'Clave'
                var ListaSubCategoria = lObjRespuesta.Select(u => new Subcategoria
                {
                    IdSubCategoria = u.IdSubCategoria,
                    Nombre = u.Nombre
                }).ToList();

                return Ok(ListaSubCategoria); // Retorna un HTTP 200 con la lista de usuarios.
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




        [Route("[action]/{pSubCategoria}")]
        [HttpGet]
        public Subcategoria recSubCategoriaXId_PA(int pSubCategoria)
        {
            Subcategoria lObjRespuesta = new Subcategoria();

            try
            {
                lObjRespuesta = gObjSubCategoriaLN.recSubCategoriaPAXId(pSubCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insSubCategoriaPA([FromBody] Subcategoria pSubCategoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjSubCategoriaLN.insSubCategoriaPA(pSubCategoria);
                    return Ok(pSubCategoria);
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
        public IActionResult modSubCategoriaPA([FromBody] Subcategoria pSubCategoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    gObjSubCategoriaLN.modSubCategoriaPA(pSubCategoria);
                    return Ok(pSubCategoria);
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

        [Route("[action]/{pSubCategoria}")]
        [HttpDelete]
        public IActionResult delSubCategoriaPA(int pSubCategoria)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lSubCategoria = gObjSubCategoriaLN.recSubCategoriaPAXId(pSubCategoria);
                    if (lSubCategoria != null)
                    {
                        gObjSubCategoriaLN.delSubCategoriaPA(lSubCategoria);
                        return Ok(lSubCategoria);
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
