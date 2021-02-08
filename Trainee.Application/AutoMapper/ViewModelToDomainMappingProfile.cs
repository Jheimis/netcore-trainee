using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Trainee.Application.ViewModels;
using Trainee.Domain.Models;

namespace Trainee.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}
