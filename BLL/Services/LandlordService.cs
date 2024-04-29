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
    public class LandlordService
    {
        public static List<LandlordDTO> Get()
        {
            var data = DataAccessFactory.LandlordData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Landlord, LandlordDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<LandlordDTO>>(data);
            return mapped;
        }
        public static LandlordDTO Get(int id)
        {
            var data = DataAccessFactory.LandlordData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Landlord, LandlordDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LandlordDTO>(data);
            return mapped;
        }
        public static void Create(LandlordDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LandlordDTO, Landlord>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Landlord>(obj);
            DataAccessFactory.LandlordData().Create(mapped);
        }
        public static void Update(LandlordDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LandlordDTO, Landlord>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Landlord>(appdetail);
            DataAccessFactory.LandlordData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.LandlordData().Delete(id);
        }
    }
}
