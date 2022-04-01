using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Controllers;

[Route("api/[controller]")] // api/todo
[ApiController]

public class TodoSevenController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetItems([FromServices]ApiDbContext context)
    {
        var myMessage = $"Mohamad went to the market to buy .Net7 features on {DateTime
        .UtcNow} - Today's Month is {DateTime
        .Now
        .Month}";

        var items = await context.Items.ToListAsync();
        return Ok(items);
    }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromServices]ApiDbContext context, int? id!!)
        {

            var item = await context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if(item == null)
                return NotFound();

            return Ok(item);
        }
}