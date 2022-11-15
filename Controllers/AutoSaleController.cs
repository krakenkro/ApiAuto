using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAuto.Model;
using WebApplication2.Data;

namespace WebApiAuto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoSaleController : ControllerBase
    {
        private readonly ILogger<AutoSaleController> _logger;
        private readonly ApplicationContext _dbConext;

        public AutoSaleController(ILogger<AutoSaleController> logger, ApplicationContext context)
        {
            _dbConext = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoSale>>> Get()
        {
            if (_dbConext.AutoSales == null)
            {
                return NotFound();
            }
            return await _dbConext.AutoSales.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutoSale>> GetAuto(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var info = await _dbConext.AutoSales.FirstOrDefaultAsync(m => m.Id == Id);

            if (info == null)
            {
                return NotFound();
            }

            return info;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AutoSale>>> Post(AutoSale info)
        {
            _dbConext.AutoSales.Add(info);
            await _dbConext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuto), new { id = info.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid? Id, AutoSale info)
        {
            if (Id != info.Id)
            {
                return BadRequest();
            }
            _dbConext.Entry(info).State = EntityState.Modified;
            try
            {
                await _dbConext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid? Id)
        {
            if (_dbConext.AutoSales == null)
            {
                return NotFound();
            }
            var info = await _dbConext.AutoSales.FirstOrDefaultAsync(m => m.Id == Id);

            if (info == null)
            {
                return NotFound();
            }

            _dbConext.AutoSales.Remove(info);
            await _dbConext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("Id")]
        public async Task<ActionResult> Patch(Guid Id, AutoSale info)
        {
            var auto = await _dbConext.AutoSales.SingleAsync(x => x.Id == Id);
            auto.Brand = info.Brand;
            auto.ProductionYear = info.ProductionYear;  
            auto.Price = info.Price;
            auto.BodyType = info.BodyType; 
            auto.EngineVolume = info.EngineVolume;
            auto.CustomsCleared = info.CustomsCleared; 
            auto.Comment = info.Comment;

            await _dbConext.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoExists(Guid? Id)
        {
            return (_dbConext.AutoSales?.Any(e => e.Id == Id)).GetValueOrDefault();
        }
    }
}
