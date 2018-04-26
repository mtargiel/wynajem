using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
       // private readonly DatabaseContext databaseContext;

        public PropertyRepository()
        {

        }
        public List<Property> GetAll()
        {
            throw new NotImplementedException();
        }

        public Property GetProperty(int propertyId)
        {
            throw new NotImplementedException();
        }
    }
}
