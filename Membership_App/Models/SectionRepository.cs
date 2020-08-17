using Membership_App.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Membership_App.Models
{
    public class SectionRepository : GenericRepository<Section>, IRepository<Section>
    {
        private DbContext _context;

        public SectionRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}