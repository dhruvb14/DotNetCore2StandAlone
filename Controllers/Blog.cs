using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore2StandAlone.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore2StandAlone.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {

        BloggingContext context = new BloggingContext();

        [HttpGet("[action]")]
        public IEnumerable<Blog> All()
        {
            var context = new BloggingContext();
            return context.Blogs;
        }

        [HttpGet("[action]")]
        public Blog Edit(int id)
        {
            return context.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
        }

        [HttpPut("[action]")]
        public IActionResult Save([FromBody]Blog entity)
        {
            if (ModelState.IsValid)
            {
                context.Blogs.Attach(entity);
                context.Entry(entity).Property(p => p.Url).IsModified = true;
                context.SaveChanges();
                return Ok(entity);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody]Blog entity)
        {
            if (ModelState.IsValid)
            {
                context.Blogs.Add(entity);
                context.SaveChanges();
                return Ok(entity);
            }
            return BadRequest(ModelState);
        }
    }
}
