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
    public class MembershipService
    {
        public static List<MembershipDTO> Get()
        {
            var data = DataAccessFactory.MembershipData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Membership, MembershipDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MembershipDTO>>(data);
            return mapped;
        }
        public static MembershipDTO Get(int id)
        {
            var data = DataAccessFactory.MembershipData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Membership, MembershipDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MembershipDTO>(data);
            return mapped;
        }
        public static void Create(MembershipDTO obj)
        { 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<MembershipDTO, Membership>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Membership>(obj);
            mapped.CreatedAt = DateTime.Now;
            mapped.StartDate = DateTime.Now;
            mapped.Status = "Pending";
            DataAccessFactory.MembershipData().Create(mapped);
        }
        public static void Update(MembershipDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<MembershipDTO, Membership>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Membership>(appdetail);
            mapped.UpdatedAt = DateTime.Now;
            DataAccessFactory.MembershipData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.MembershipData().Delete(id);
        }
    }
}
