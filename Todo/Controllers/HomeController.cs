using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        //[Route("/")]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.Todos.ToList());
        
        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id, 
            [FromServices] AppDbContext context
            )
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody]TodoModel model,[FromServices] AppDbContext context)
        {
            context.Todos.Add(model);
            context.SaveChanges();

            return Created($"/{model.Id}",model);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute]int id,
            [FromBody]TodoModel model, 
            [FromServices] AppDbContext context)
        {
            var model_up = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model_up.Title = model.Title;
            model_up.Done = model_up.Done;  
            context.Todos.Update(model_up);
            context.SaveChanges();
            return Ok(model_up);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute]int id,
            [FromServices] AppDbContext context
        )
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }

    }
}