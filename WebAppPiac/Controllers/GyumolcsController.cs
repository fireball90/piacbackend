using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPiac.Data;
using WebAppPiac.Models;

namespace WebAppPiac.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GyumolcsController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                try
                {
                    List<Gyumolcs> gyumolcsok = new List<Gyumolcs>(context.Gyumolcs.ToList());
                    return Ok(gyumolcsok);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }
        [HttpPost]

        public IActionResult Post(Gyumolcs gyumolcs)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                try
                {
                    context.Gyumolcs.Add(gyumolcs);
                    context.SaveChanges();
                    return Ok( "A gyümölcs hozzáadása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }

        [HttpPut]

        public IActionResult Put(Gyumolcs gyumolcs)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                try
                {
                    context.Gyumolcs.Update(gyumolcs);
                    context.SaveChanges();
                    return Ok($"A(z) {gyumolcs.Nev} hozzáadása sikeresen megtörtént."); ;
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }

        [HttpDelete]

        public IActionResult Delete(int Id)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                try
                {
                    Gyumolcs gyumolcs = new Gyumolcs();
                    gyumolcs.Id = Id;
                    context.Gyumolcs.Remove(gyumolcs);
                    context.SaveChanges();
                    return Ok($"A(z) {Id}. azonosítóval rendelkező gyümölcs törlése sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }
    }
}
