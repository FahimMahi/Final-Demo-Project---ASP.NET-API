using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Buyer, int> BuyerData()
        {
            return new BuyerRepo();
        }
    }
}
