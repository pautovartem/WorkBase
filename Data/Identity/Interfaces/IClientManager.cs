using Data.Entities;
using System;

namespace Data.Identity.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(User item);
    }
}
