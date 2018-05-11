using Microsoft.EntityFrameworkCore;
using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _dbContext;

       

        public OwnerRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public int AddOwner(Owner owner)
        {
            if (owner == null)
            {
                throw new Exception("Owner nie może być null");
            }

            _dbContext.Owners.Add(owner);
            _dbContext.SaveChanges();

            return owner.OwnerId;
        }

        public Owner GetOwner(int ownerId)
        {
            if (ownerId<=0)
            {
                throw new Exception("OwnerId nie może być mniejsze niż 0");
            }

           return  _dbContext.Owners.Where(x => x.OwnerId == ownerId).FirstOrDefault();
        }
    }
}
