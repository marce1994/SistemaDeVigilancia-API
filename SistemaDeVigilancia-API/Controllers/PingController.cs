using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVigilancia.Common.Database.Models;

namespace SistemaDeVigilancia_API.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        private SistemaDeVigilanciaContext sistemaDeVigilanciaContext;
        public PingController(SistemaDeVigilanciaContext sistemaDeVigilanciaContext) {
            this.sistemaDeVigilanciaContext = sistemaDeVigilanciaContext;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(()=> { return new ObjectResult(sistemaDeVigilanciaContext.Set<Ping>()); });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await Task.Run(() => { return new ObjectResult(sistemaDeVigilanciaContext.FindAsync<Ping>(id)); });
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]Ping value)
        {
            await sistemaDeVigilanciaContext.Set<Ping>().AddAsync(value);
            await sistemaDeVigilanciaContext.SaveChangesAsync();
        }

        // PUT api/values/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE api/values/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
