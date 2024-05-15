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
        public static IRepo<Landlord, int> LandlordData()
        {
            return new LandlordRepo();
        }
        public static IRepo<Management, int> ManagementData()
        {
            return new ManagementRepo();
        }
        public static IRepoPropertyBidding<Bidding, int> BiddingData()
        {
            return new BiddingRepo();
        }
        public static IRepoPropertyBidding<Property, int> PropertyData()
        {
            return new PropertyRepo();
        }
        
        public static IRepo<Payment, int> PaymentData()
        {
            return new PaymentRepo();
        }

        public static IRepo<Review, int> ReviewData()
        {
            return new ReviewRepo();
        }

        public static IRepo<SupportTicket, int> SupportTicketData()
        {
            return new SupportTicketRepo();
        }

        public static IRepo<Membership, int> MembershipData()
        {
            return new MembershipRepo();
        }
        public static IRepo<Feedback, int> FeedbackData()
        {
            return new FeedbackRepo();
        }
        public static IRepoLikedProperty<LikedProperty, int> LikedPropertyData() 
        {
            return new BuyerRepo();
        }

    }
}
