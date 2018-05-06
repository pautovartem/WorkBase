using LogicLayer.DTO;
using LogicLayer.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> Registation(UserDTO userDTO);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        void EditUser(UserDTO userDTO);
        void RemoveUser(UserDTO userDTO);
        void Dispose();
    }
}
