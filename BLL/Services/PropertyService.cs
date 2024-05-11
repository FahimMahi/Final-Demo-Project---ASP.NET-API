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
    public class PropertyService
    {
        public static List<PropertyDTO> Get()
        {
            var data = DataAccessFactory.PropertyData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Property, PropertyDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PropertyDTO>>(data);
            return mapped;
        }

        public static PropertyDTO Get(int id)
        {
            var data = DataAccessFactory.PropertyData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Property, PropertyDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PropertyDTO>(data);
            return mapped;
        }


        public static List<PropertyDTO> Get(string type)
        {
            var data = DataAccessFactory.PropertyData().Read(type);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Property, PropertyDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PropertyDTO>>(data);
            return mapped;
        }

        public static PropertyBiddingDTO PropertyWithBidding(int id)
        {
            var data = DataAccessFactory.PropertyData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Property, PropertyBiddingDTO>();
                c.CreateMap<Bidding, BiddingDTO>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PropertyBiddingDTO>(data);
            return mapped;

        }



        public static void Create(PropertyDTO property)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PropertyDTO, Property>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Property>(property);
            DataAccessFactory.PropertyData().Create(mapped);

        }

        public static void Update(PropertyDTO property)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PropertyDTO, Property>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Property>(property);
            DataAccessFactory.PropertyData().Update(mapped);

        }

    }
}
