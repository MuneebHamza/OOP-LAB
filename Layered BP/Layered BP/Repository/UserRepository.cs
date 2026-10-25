using Layered_BP.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.userrepo
{
    class UserRepository
    {
        private readonly string _filepath = "user.txt";
        public void save(User user)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                writer.WriteLine(user.ToString());
            }
        }

        public void SaveAll(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, false))
            {
                foreach (var User in users)
                {
                    writer.WriteLine(User.ToString());
                }
            }
        }

        public string getField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }

        public List<User> GetAll()
        {
            List<User> Users = new List<User>();

            if (!File.Exists(_filepath))
                return Users;

            using (StreamReader read = new StreamReader(_filepath))
            {
                string details;
                while ((details = read.ReadLine()) != null)
                {
                    // 1. Create a new User object (assuming your User class has a default constructor or properties with set)
                    User u = new User();

                    // 2. Assign values using your getField method
                    u.UserID = int.Parse(getField(details, 1));
                    u.UserName = getField(details, 2);
                    u.Membership = getField(details, 3);
                    u.TotalSpent = float.Parse(getField(details, 4));

                    // 3. Add the populated user to the list
                    Users.Add(u);
                }
            }

            return Users;
        }

        public void clearAll()
        {
            File.WriteAllText(_filepath, string.Empty);
        }
    }
}

