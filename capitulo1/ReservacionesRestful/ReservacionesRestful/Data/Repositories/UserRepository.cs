﻿using ReservacionesRestful.Bussiness.Entities;

namespace ReservacionesRestful.Data.Repositories
{
    public class UserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(User user) { 
            _dbContext.Users.Add(user);
            var result = _dbContext.SaveChanges();//commit
            return result;
        }
        public User FindById(int id) { 
            var result = _dbContext.Users.Find(id);
            if (result != null)
                return result;
            else
                throw new Exception($"User {id} no existe!!");
        }
        public List<User> GetAll() {
            return _dbContext.Users.ToList();
        }
    }
}