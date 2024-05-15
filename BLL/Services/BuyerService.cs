using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BuyerService
    {
        public static List<BuyerDTO> Get()
        {
            var data = DataAccessFactory.BuyerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BuyerDTO>>(data);
            return mapped;
        }
        public static BuyerDTO Get(int id)
        {
            var data = DataAccessFactory.BuyerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BuyerDTO>(data);
            return mapped;
        }
        public static void Create(BuyerDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Buyer>(obj);
            DataAccessFactory.BuyerData().Create(mapped);
        }
        public static void Update(BuyerDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Buyer>(appdetail);
            DataAccessFactory.BuyerData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BuyerData().Delete(id);
        }
        ///new
        public static FavPropertyDTO BuyerFavProperty(int id)
        {
            var data = DataAccessFactory.BuyerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, FavPropertyDTO>();
                c.CreateMap<Property , PropertyDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FavPropertyDTO>(data);
            return mapped;

        }
        public static List<LikedPropertyDTO> LikedProperty(string id)
        {
            var data = DataAccessFactory.LikedPropertyData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LikedProperty, LikedPropertyDTO>();
                c.CreateMap<Buyer, BuyerDTO>();
                c.CreateMap<Property, PropertyDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<LikedPropertyDTO>>(data);
            return mapped;

        }

        public static void PropertyLiked(LikedPropertyDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LikedPropertyDTO, LikedProperty>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LikedProperty>(obj);
            DataAccessFactory.LikedPropertyData().Create(mapped);
        }
    }
}
