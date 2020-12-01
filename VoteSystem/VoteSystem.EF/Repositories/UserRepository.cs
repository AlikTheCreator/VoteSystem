using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Repositories;

namespace VoteSystem.EF.Repositories
{
    class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Users.Add(user);
                voteContext.SaveChangesAsync();
            }
        }

        public List<User> GetAllUsersForRegion(int regionId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.ToList().Where(u => u.RegionId == regionId).ToList();
            }           
        }

        public bool IsInRegion(int regionId, int userId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.FirstOrDefault(u => u.Id == userId).RegionId == regionId;
            }
        }

        public void UpdateUser(User user)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                User usertemp = voteContext.Users.FirstOrDefault(u => u.Id == user.Id);
                usertemp = user;
                voteContext.SaveChangesAsync();
            }
        }
    }
}
