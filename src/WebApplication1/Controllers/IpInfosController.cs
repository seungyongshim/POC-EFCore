using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpInfosController : ControllerBase
    {
        private readonly AUMSContext _context;

        public IpInfosController(AUMSContext context)
        {
            _context = context;
        }

        // GET: api/IpInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInfo>>> GetIpInfos()
        {
            return await _context.IpInfos.ToListAsync();
        }

        // GET: api/IpInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInfo>> GetIpInfo(int id)
        {
            var ipInfo = await _context.IpInfos.FindAsync(id);

            if (ipInfo == null)
            {
                return NotFound();
            }

            return ipInfo;
        }

        // PUT: api/IpInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInfo(int id, IpInfo ipInfo)
        {
            if (id != ipInfo.IpInfoId)
            {
                return BadRequest();
            }

            _context.Entry(ipInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInfoExists(id))
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

        // POST: api/IpInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IpInfo>> PostIpInfo(IpInfo ipInfo)
        {
            _context.IpInfos.Add(ipInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInfo", new { id = ipInfo.IpInfoId }, ipInfo);
        }

        // DELETE: api/IpInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIpInfo(int id)
        {
            var ipInfo = await _context.IpInfos.FindAsync(id);
            if (ipInfo == null)
            {
                return NotFound();
            }

            _context.IpInfos.Remove(ipInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IpInfoExists(int id)
        {
            return _context.IpInfos.Any(e => e.IpInfoId == id);
        }
    }
}
