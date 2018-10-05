using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVigilancia.Common.Database.Models;

namespace SistemaDeVigilancia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementDetectionController : ControllerBase
    {
        private SistemaDeVigilanciaContext sistemaDeVigilanciaContext;
        public MovementDetectionController(SistemaDeVigilanciaContext sistemaDeVigilanciaContext)
        {
            this.sistemaDeVigilanciaContext = sistemaDeVigilanciaContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() => { return new ObjectResult(sistemaDeVigilanciaContext.Set<MovementDetection>()); });
        }
        
        [HttpPost]
        public async void Post([FromBody] MovementDetection movement)
        {
            await sistemaDeVigilanciaContext.Set<MovementDetection>().AddAsync(movement);
            await sistemaDeVigilanciaContext.SaveChangesAsync();
        }
    }
}
