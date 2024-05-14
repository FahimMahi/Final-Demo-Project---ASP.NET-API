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
    public class BiddingService
    {
        public static void Create(BiddingDTO bid)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BiddingDTO, Bidding>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Bidding>(bid);
            DataAccessFactory.BiddingData().Create(mapped);

        }


        public static List<BiddingDTO> Get(string id)
        {
            var data = DataAccessFactory.BiddingData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Bidding, BiddingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BiddingDTO>>(data);
            return mapped;
        }


        //for heighest bidding
        public static BiddingDTO Get(int id)
        {
            var data = DataAccessFactory.BiddingData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Bidding, BiddingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BiddingDTO>(data);
            return mapped;
        }

        public static List<BiddingDTO> Delete(int pid, int bid)
        {
            var data = DataAccessFactory.BiddingData().Delete(pid, bid);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Bidding, BiddingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BiddingDTO>>(data);
            return mapped;
        }

    }
}
