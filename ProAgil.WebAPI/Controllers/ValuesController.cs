using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);   
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }

            //return _context.Eventos.ToList();

            /*
            return new Evento[]
            {
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular e .NET Core",
                    Local = "Belo Horizonte",
                    Lote = "1 Lote",
                    QtdPessoas = 100,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Angular e Suas Novidades",
                    Local = "Porto Alegre",
                    Lote = "2 Lote",
                    QtdPessoas = 200,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                }
            };
            */
        }

        // GET api/values/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(result);   
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno");
            }

        }
    }
}