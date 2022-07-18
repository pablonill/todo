using AutoMapper;
using Data;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Config
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Todo, TodoDTO>();
            CreateMap<TodoDTO, Todo>();
        }
    }
}
