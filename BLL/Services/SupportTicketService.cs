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
    public class SupportTicketService
    {
        public static List<SupportTicketDTO> Get()
        {
            var data = DataAccessFactory.SupportTicketData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SupportTicket, SupportTicketDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SupportTicketDTO>>(data);
            return mapped;
        }
        public static SupportTicketDTO Get(int id)
        {
            var data = DataAccessFactory.SupportTicketData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SupportTicket, SupportTicketDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SupportTicketDTO>(data);
            return mapped;
        }
        public static void Create(SupportTicketDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SupportTicketDTO, SupportTicket>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SupportTicket>(obj);
            mapped.CreatedAt = DateTime.Now;
            DataAccessFactory.SupportTicketData().Create(mapped);
        }
        public static void Update(SupportTicketDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SupportTicketDTO, SupportTicket>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SupportTicket>(appdetail);
            mapped.UpdatedAt = DateTime.Now;
            DataAccessFactory.SupportTicketData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.SupportTicketData().Delete(id);
        }
    }
}
