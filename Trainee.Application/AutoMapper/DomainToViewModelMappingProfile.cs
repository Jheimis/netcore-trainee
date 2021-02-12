using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Trainee.Application.ViewModels;
using Trainee.Domain.Models;

namespace Trainee.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
