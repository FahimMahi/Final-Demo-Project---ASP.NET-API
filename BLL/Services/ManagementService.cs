using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ManagementService
    {
        public static List<ManagementDTO> Get()
        {
            var data = DataAccessFactory.ManagementData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Management, ManagementDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ManagementDTO>>(data);
            return mapped;
        }
        public static ManagementDTO Get(int id)
        {
            var data = DataAccessFactory.ManagementData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Management, ManagementDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ManagementDTO>(data);
            return mapped;
        }
        public static void Create(ManagementDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagementDTO, Management>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Management>(obj);
            DataAccessFactory.ManagementData().Create(mapped);
        }
        public static void Update(ManagementDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ManagementDTO, Management>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Management>(appdetail);
            DataAccessFactory.ManagementData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ManagementData().Delete(id);
        }
    }
}
