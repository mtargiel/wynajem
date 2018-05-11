using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PropertyRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public int AddProperty(Property property, Address address, Owner owner)
        {
            if (property == null)
            {
                throw new Exception("Brakuje obiektu property");
            }
            if (address == null)
            {
                throw new Exception("Brakuje obiektu address");

            }
            if (owner == null)
            {
                throw new Exception("Brakuje obiektu owner");
            }

            property.PropertyId = 0;
            property.Owner = owner;
            property.Address = address;


            _databaseContext.Properties.Add(property);
            _databaseContext.SaveChanges();

            return property.PropertyId;
        }

        public void DeleteProperty(Property property, Address address, Owner owner)
        {
            if (property == null)
            {
                throw new Exception("Brakuje obiektu property");
            }
            if (address == null)
            {
                throw new Exception("Brakuje obiektu address");

            }

            if (owner == null)
            {
                throw new Exception("Brakuje obiektu owner");
            }

            _databaseContext.Properties.Remove(property);
            _databaseContext.Addresses.Remove(address);
            _databaseContext.Owners.Remove(owner);
            _databaseContext.SaveChanges();
        }

        public List<Property> GetAllProperties()
        {
            return _databaseContext.Properties.ToList();
        }

        public Property GetProperty(int propertyId)
        {
            if (propertyId<=0)
            {
                throw new Exception("Id nie może być mniejsze od 0");
            }
            return _databaseContext.Properties.
                Where(x => x.PropertyId == propertyId).
                FirstOrDefault();
        }

        public int UpdateProperty(Property property)
        {
            if (property == null)
            {
                throw new Exception("Property nie może być null");
            }
            _databaseContext.Properties.Update(property);
            return property.PropertyId;
        }
    }
}
