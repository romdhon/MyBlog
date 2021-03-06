using System.Collections.Generic;
using System.Linq;

namespace Blogger.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _UserList;
        public MockUserRepository()
        {
            _UserList = new List<User>()
            {
                new User{UserID=1, Name="Romdon",Username="romdon@gmail.com",Password="12345",UserPosition=Position.Admin,UserStat=1},
                new User{UserID=2, Name="Hasnan",Username="hasnan@gmail.com",Password="12345",UserPosition=Position.NormalUser,UserStat=0}
            };
        }
        public User GetUser(int id)
        {
            return _UserList.FirstOrDefault(a => a.UserID == id);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _UserList;
        }

        public User AddUser(User user)
        {
            user.UserID = _UserList.Max(e => e.UserID) + 1;
            user.Password = "12345";
            user.UserStat = 1;
            _UserList.Add(user);
            return user;
        }
    }
}