using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UserModel
{
    class User
    {
        public int UserID { get; set; }
        public string UserName {  get; set; }
        public string Membership {  get; set; }
        public float TotalSpent { get; set; }

        public User() { }

        public User(int userID, string userName, string membership, float totalSpent)
        {
            UserID = userID;
            UserName = userName;
            Membership = membership;
            TotalSpent = totalSpent;
        }

        public override string ToString()
        {
            return $"{UserID},{UserName},{Membership},{TotalSpent}";
        }
    }
}
