using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D2_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            try
            {
                _authorService.Add(author);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("AddAuthor", e.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Post", new { Id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Author author)
        {
            var current = _authorService.Get(id);

            if(current == null)
            {
                return NotFound();
            }

            try
            {
               current =  _authorService.Update(author);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("PutAuthor", e.Message);
                return BadRequest(ModelState);
            }

            return Ok(current);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.Get(id);

            if (author == null)
                return NotFound();

            _authorService.Remove(author);

            return NoContent();
        }

    }
}
