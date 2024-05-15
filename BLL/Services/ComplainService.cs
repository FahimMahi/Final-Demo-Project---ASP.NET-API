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
    public class ComplainService
    {
        public static ComplainDTO Get(int id)
        {
            var data = DataAccessFactory.ComplainData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Complain, ComplainDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<ComplainDTO>(data);
            return ret;
        }

        public static void Create(ComplainDTO complainDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComplainDTO, Complain>();
            });
            var mapper = new Mapper(config);
            var complain = mapper.Map<Complain>(complainDTO);
            DataAccessFactory.ComplainData().Create(complain);
        }

        public static List<ComplainDTO> Get()
        {
            var data = DataAccessFactory.ComplainData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Complain, ComplainDTO>();
            });
            var mapper = new Mapper(config);
            var retdata = mapper.Map<List<ComplainDTO>>(data);
            return retdata;
        }

        public static void Delete(int id)
        {
            DataAccessFactory.ComplainData().Delete(id);
        }

        public static void Update(int id, ComplainDTO complainDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComplainDTO, Complain>();
            });
            var mapper = new Mapper(config);
            var complain = mapper.Map<Complain>(complainDTO);
            DataAccessFactory.ComplainData().Update(complain);
        }
    }
}
