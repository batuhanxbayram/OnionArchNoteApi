﻿using NoteApi.Application.Interfaces.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Mapper.AutoMapper
{
    public class Mapper : IMapper
    {
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }
    }
}
