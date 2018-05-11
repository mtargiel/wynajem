﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MistrzowieWynajmu.Models.Interfaces;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetProperties()
        {
            return new JsonResult(_propertyRepository.GetAllProperties());
        }
        [HttpPost("[action]")]
        public IActionResult AddProperty([FromBody] Property property)
        {
            return NotFound();
        }

        [HttpPut("[action]")]
        public IActionResult Update(Property property)
        {
            _propertyRepository.EditProperty(property);
        }
    }
}