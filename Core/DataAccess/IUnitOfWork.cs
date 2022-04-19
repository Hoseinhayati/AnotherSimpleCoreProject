using System;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_MVC_.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        int Commit();
    }
}
