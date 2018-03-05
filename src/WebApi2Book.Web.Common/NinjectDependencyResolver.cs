﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Ninject;

namespace WebApi2Book.Web.Common
{
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;

        public IKernel Container
        {
            get { return _container; }
        }

        public NinjectDependencyResolver(IKernel container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
