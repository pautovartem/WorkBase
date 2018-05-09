﻿using DAL.Interfaces;
using Data.EF;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public WorkBaseContext Database { get; set; }

        public UserRepository(WorkBaseContext db)
        {
            Database = db;
        }

        public IEnumerable<User> GetAll()
        {
            return Database.UsersProfiles;
        }

        public User Get(string id)
        {
            return Database.UsersProfiles.Find(id);
        }

        public void Create(User item)
        {
            Database.UsersProfiles.Add(item);
        }

        public void Update(User item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            User user = Database.UsersProfiles.Find(id);
            if (user != null)
                Database.UsersProfiles.Remove(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return Database.UsersProfiles.Where(predicate).ToList();
        }
    }
}
