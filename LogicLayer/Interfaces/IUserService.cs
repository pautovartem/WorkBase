using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDTO);
        void EditUser(UserDTO userDTO);
        void RemoveUser(UserDTO userDTO);
        void Dispose();
    }
}
