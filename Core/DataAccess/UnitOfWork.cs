using System;
using System.Collections.Concurrent;
using Asp.netCore_MVC_.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Asp.netCore_MVC_.Core.DataAccess
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;
        protected ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string, object>();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public virtual IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            try
            {
                var key = typeof (TEntity).FullName;
                if (_repositories.ContainsKey(key))
                    return _repositories[key] as IRepository<TEntity>;
                else
                {
                    var repository = new EFRepository<TEntity>(_context);
                    _repositories[key] = repository;
                    return repository;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("message" + ex.Message);
            }

            throw new Exception("message");
        }

        public int Commit()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //var msg = string.Empty;

                //foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    foreach (var validationError in validationErrors.ValidationErrors)
                //        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                //var fail = new Exception(msg, dbEx);
                ////Debug.WriteLine(fail.Message, fail);
                //throw fail;

                throw dbEx;
            }
        }


        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
