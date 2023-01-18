using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IConnectRepository
    {
        Task<User?> Get(string mail, string pass);
    }
}
