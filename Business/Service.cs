using System;
using DataAccess;

namespace Business
{
    public class Service : IDisposable
    {
        /// <summary>
        ///     Repository
        /// </summary>
        protected readonly IProductRepository _repository;

        public Service(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        /// <summary>
        ///     Utilisé dans le Dispose
        /// </summary>
        private bool _disposed { get; set; }

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
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                    if (_repository != null)
                        _repository.Dispose();

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}