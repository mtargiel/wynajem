using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseContext _dbContext;
        public AddressRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public int AddAddress(Address address)
        {
            if (address == null)
            {
                throw new Exception("Adres nie może być null");
            }
            _dbContext.Addresses.Add(address);
            return address.AddressId;
        }

        public Address GetAddress(int AddresId)
        {
            if (AddresId<=0)
            {
                throw new Exception("AdressId nie może być mniejsze niż 0");

            }
            return _dbContext.Addresses.Where(x => x.AddressId == AddresId).FirstOrDefault();
        }
    }
}
