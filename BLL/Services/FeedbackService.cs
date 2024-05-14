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
    public class FeedbackService
    {

        public static List<FeedbackDTO> Get()
        {
            var data = DataAccessFactory.FeedbackData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Feedback, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<FeedbackDTO>>(data);
            return mapped;
        }
        public static FeedbackDTO Get(int id)
        {
            var data = DataAccessFactory.FeedbackData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Feedback, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FeedbackDTO>(data);
            return mapped;
        }
        public static void Create(FeedbackDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackDTO, Feedback>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Feedback>(obj);
            DataAccessFactory.FeedbackData().Create(mapped);
        }
        public static void Update(FeedbackDTO appdetail)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FeedbackDTO, Feedback>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Feedback>(appdetail);
            DataAccessFactory.FeedbackData().Update(mapped);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.FeedbackData().Delete(id);
        }
    }
}
