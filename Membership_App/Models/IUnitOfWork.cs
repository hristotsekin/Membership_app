using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Membership_App.Entities;

namespace Membership_App.Models
{
    public interface IUnitOfWork : IDisposable
    {

        int Complete();
    }
}
