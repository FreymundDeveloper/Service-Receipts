using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BackendAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly BackendAPIContext _context;

        public ReceiptController(BackendAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all Receipt Data.")]
        [SwaggerResponse(200, "OK", typeof(Historic))]
        [SwaggerResponse(500, "Server Error.")]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {
            return await _context.Receipts.ToListAsync();
        }
    }
}