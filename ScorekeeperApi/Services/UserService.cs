﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ScorekeeperApi.Models;
using MongoDB.Driver;

namespace ScorekeeperApi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _Users;

        public UserService(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Users = database.GetCollection<User>(settings.CollectionName);
        }

        public List<User> Get() =>
            _Users.Find(User => true).ToList();

        public User Get(string id) =>
            _Users.Find<User>(User => User.Id == id).FirstOrDefault();

        public User Create(User User)
        {
            _Users.InsertOne(User);
            return User;
        }

        public void Update(string id, User UserIn) =>
            _Users.ReplaceOne(User => User.Id == id, UserIn);

        public void Remove(User UserIn) =>
            _Users.DeleteOne(User => User.Id == UserIn.Id);

        public void Remove(string id) =>
            _Users.DeleteOne(User => User.Id == id);
    }
}