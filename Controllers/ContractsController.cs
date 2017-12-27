using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2StandAlone.Controllers
{
    [Route("api/contacts")]
    public class ContactsController: Controller
    {
        // GET api/contacts
        [HttpGet]
        public IActionResult Get()
            {
            var result = new[] {
                new { FirstName = "John", LastName = "Doe" },
                new { FirstName = "Mike", LastName = "Smith" }
            };

            return Ok(result);
        }
    }
}
