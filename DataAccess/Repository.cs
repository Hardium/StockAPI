using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {

        /// <summary>
        /// Contexte de données
        /// </summary>
        protected StockContext _context;

        /// <summary>
        /// Utilisé dans le Dispose
        /// </summary>
        private bool _disposed { get; set; }

        /// <summary>
        /// Constructeur avec injection du contexte
        /// </summary>
        /// <param name="context"></param>
        public Repository(StockContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass 
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                    if (_context != null)
                        _context.Dispose();
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }

    }
}
