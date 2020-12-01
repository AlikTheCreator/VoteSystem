using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.RegionPolicyAggregate;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IRegionRepository
    {
        void CreateRegion(Region region);
        void UpdateRegion(Region region);
    }
}
