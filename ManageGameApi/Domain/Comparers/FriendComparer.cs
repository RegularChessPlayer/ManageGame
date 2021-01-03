using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Comparers
{
    public class FriendComparer : IEqualityComparer<Friend>
    {
        public bool Equals(Friend x,  Friend y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.Id == y.Id ;

        }

        public int GetHashCode(Friend obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashFriendName = obj.Name == null ? 0 : obj.Name.GetHashCode();

            int hashFriendId = obj.Id.GetHashCode();

            return hashFriendName ^ hashFriendId;
        }
    }
}
