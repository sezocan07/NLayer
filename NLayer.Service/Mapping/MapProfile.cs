using System;
using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
	public class MapProfile:Profile
	{
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
	}
}

