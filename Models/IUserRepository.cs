using System.Collections.Generic;

namespace Blogger.Models
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUser();
    }
}