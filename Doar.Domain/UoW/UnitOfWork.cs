using System;
using Doar.Domain.Context;
using Doar.Domain.Interface;

namespace Doar.Domain.UoW {
    public class UnitOfWork : IUnitOfWork {

        private readonly DoarContext _context;
        private bool _disposed;

        public UnitOfWork(DoarContext context) {            
            _context = context;
        }

        public void BeginTransaction() {
            _disposed = false;
        }

        public int Commit() {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing) {
            if(!_disposed) {
                if(disposing) {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }    
    }
}
