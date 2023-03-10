using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yyyy.Data;
using yyyy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yyyy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    { 
        private readonly StockDBContext _context;


        public StocksController(StockDBContext context)
        {
            _context = context;
        }


        // GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            //var stocks = await _context.Stocks.ToListAsync();
            return await _context.Stocks.ToListAsync();
            //return Ok(stocks);
        }


        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet]
        [Route("{id}")]
        //public async Task<ActionResult> GetStock([FromRoute] int id)
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            // var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.StockId == id);
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            // return Ok(stock);
            return stock;
        }


        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        [HttpPost]
        //public async Task<ActionResult> AddStock([FromBody] Stock stockRequest)
        public async Task<ActionResult<Stock>> PostStock(Stock stockRequest)
        {
            //stockRequest.StockId = int.NewGuid();
            await _context.Stocks.AddAsync(stockRequest);
            await _context.SaveChangesAsync();


            //return Ok(stockRequest);
            return CreatedAtAction("GetStock", new { id = stockRequest.StockId }, stockRequest);

        }





        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        // [HttpPut]
        // [Route("{id}")]
        //public async Task<IActionResult> PutStock([FromRoute] int id, Stock UpdateStock)
        // {
        //     var stock = await _context.Stocks.FindAsync(id);
        //     if (stock == null)
        //     {
        //         return NotFound();
        //     }
        //     stock.NomStock = UpdateStock.NomStock;
        //     stock.IndexShortCut = UpdateStock.IndexShortCut;
        //     stock.PrixActuel = UpdateStock.PrixActuel;
        //     stock.PrixInitial = UpdateStock.PrixInitial;
        //     //stock.Changement = UpdateStock.Changement;
        //     //stock.PercentChangement = UpdateStock.PercentChangement;


        //     await _context.SaveChangesAsync();

        //     return Ok(stock);
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock s)
        {
            if (id != s.StockId)
            {
                return BadRequest();
            }

            _context.Entry(s).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // return NoContent();
            return CreatedAtAction("GetStock", new { id = s.StockId }, s);
        }




        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            //return NoContent();
            return CreatedAtAction("GetStock", new { id = stock.StockId }, stock);

        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.StockId == id);
        }

    }





    //// GET: api/<StocksController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //// GET api/<StocksController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<StocksController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<StocksController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<StocksController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}

