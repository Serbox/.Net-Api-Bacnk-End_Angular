using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularPrueba.Server.Data;
using AngularPrueba.Server.Models;

namespace AngularPrueba.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoData _empleadoData;
        public EmpleadoController(EmpleadoData empleadoData)
        {
            _empleadoData = empleadoData;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _empleadoData.Lista();
            return StatusCode( StatusCodes.Status200OK,lista);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtener(int id)
        {
            Empleado objeto= await _empleadoData.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, objeto);

        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Empleado objeto)
        {
            bool Respuesta = await _empleadoData.Crear(objeto);
            return StatusCode(StatusCodes.Status200OK,new {isSuccess = Respuesta});

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] Empleado objeto)
        {
            bool Respuesta = await _empleadoData.Editar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = Respuesta });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar([FromBody] int id)
        {
            bool Respuesta = await _empleadoData.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = Respuesta });

        }
    }
}
