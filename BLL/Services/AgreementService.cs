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
    public class AgreementService
    {

        public static AgreementDTO Get(int id)
        {
            var data = DataAccessFactory.AgreementData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Agreement, AgreementDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<AgreementDTO>(data);
            return ret;
        }

        public static void Create(AgreementDTO agreement)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgreementDTO, Agreement>();
            });
            var mapper = new Mapper(config);
            var agreementEntity = mapper.Map<Agreement>(agreement);
            DataAccessFactory.AgreementData().Create(agreementEntity);
        }

        public static List<AgreementDTO> Get(string type)
        {
            var data = DataAccessFactory.AgreementData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Agreement, AgreementDTO>();
            });
            var mapper = new Mapper(config);
            var retData = mapper.Map<List<AgreementDTO>>(data);
            return retData;
        }

        public static void Update(int id, AgreementDTO agreement)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgreementDTO, Agreement>();
            });
            var mapper = new Mapper(config);
            var agreementEntity = mapper.Map<Agreement>(agreement);
            agreementEntity.Id = id;
            DataAccessFactory.AgreementData().Update(agreementEntity);
        }

        public static void Delete(int id)
        {
            DataAccessFactory.AgreementData().Delete(id);
        }
    }
}
