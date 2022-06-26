using InnovateQ.Assignment.API.Models;

namespace InnovateQ.Assignment.API.JWT
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
