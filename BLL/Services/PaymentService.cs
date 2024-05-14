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
    public class PaymentService
    {
        public static List<PaymentDTO> Get()
        {
            var data = DataAccessFactory.PaymentData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }
        public static PaymentDTO Get(int id)
        {
            var data = DataAccessFactory.PaymentData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDTO>(data);
            return mapped;
        }
        public static void Create(PaymentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Payment>(obj);
            DataAccessFactory.PaymentData().Create(mapped);
        }
        public static void Update(PaymentDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Payment>(appdetail);
            DataAccessFactory.PaymentData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentData().Delete(id);
        }
    }
}
