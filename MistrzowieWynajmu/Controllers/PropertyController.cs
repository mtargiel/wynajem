using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAddressRepository _addressRepository;

        public PropertyController(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository, IAddressRepository addressRepository)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _addressRepository = addressRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetProperties()
        {
            return new JsonResult(_propertyRepository.GetAllProperties());
        }
        [HttpPost("[action]")]
        public IActionResult AddProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = _ownerRepository.GetOwner(property.Owner.OwnerId);
            if (owner == null)
            {
                return NotFound("Nie można znaleźć właściciela");
            }

            var address = _addressRepository.GetAddress(property.Address.AddressId);
            if (address == null)
            {
                return NotFound("Nie można znaleźć adresu");
            }

            _propertyRepository.AddProperty(property, address, owner);

            return new JsonResult(property);
        }
        [HttpGet("[action]")]
        public IActionResult GetProperty(int propertyId)
        {
            if (propertyId<=0)
            {
                return BadRequest("PropertyID nie może być mniejsze niż 0");
            }

            return new JsonResult(_propertyRepository.GetProperty(propertyId));
        }

        [HttpPost("[action]")]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _propertyRepository.UpdateProperty(property);
            return new JsonResult(property);
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteProperty(int propertyId)
        {
            if (propertyId <= 0)
            {
                return BadRequest("PropertyID nie może być mniejsze niż 0");
            }
            var property = _propertyRepository.GetProperty(propertyId);
            if (property == null)
            {
                return NotFound("Nie można znaleźć property");
            }
            var owner = _ownerRepository.GetOwner(property.Owner.OwnerId);
            if (owner == null)
            {
                return NotFound("Nie można znaleźć właściciela");
            }
            var address = _addressRepository.GetAddress(property.Address.AddressId);
            if (address == null)
            {
                return NotFound("Nie można znaleźć adresu");
            }

            _propertyRepository.DeleteProperty(property, address, owner);


            return new JsonResult(property);
        }
    }
}