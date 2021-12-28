using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Services
{
    public class Service
    {
        protected IMapper Mapper { get; }

        public Service(IServiceProvider serviceProvider)
        {
            Mapper = serviceProvider.GetService<IMapper>();
        }
    }
}
