using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using webapi_csharp.Modelos;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPBooks rpCli = new RPBooks();
            return Ok(rpCli.ObtenerBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPBooks rpCli = new RPBooks();

            var cliRet = rpCli.ObtenerBook(id);

            if (cliRet == null)
            {
                var nf = NotFound("El libro " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("add")]
        public IActionResult AgregarBook(Book nuevoBook)
        {
            RPBooks rpCli = new RPBooks();
            rpCli.Agregar(nuevoBook);
            return CreatedAtAction(nameof(AgregarBook), nuevoBook);
        }

        [HttpPut("up/{id}")]
        public IActionResult UpdateBook(Book nuevoBook, int id)
        {
            RPBooks rpCli = new RPBooks();

            var cliRet = rpCli.ObtenerBook(id);

            if (cliRet == null)
            {
                var nf = NotFound("El libro " + id.ToString() + " no existe.");
                return nf;
            }

            rpCli.UpdateBook(nuevoBook,id);

            return Ok(rpCli.ObtenerBooks());
        }

        [HttpDelete("rm/{id}")]
        public IActionResult DeleteBook(int id)
        {
            RPBooks rpCli = new RPBooks();

            var cliRet = rpCli.ObtenerBook(id);

            if (cliRet == null)
            {
                var nf = NotFound("El libro " + id.ToString() + " no existe.");
                return nf;
            }

            rpCli.DeleteBook(id);

            return Ok(rpCli.ObtenerBooks());
        }
    }
}
