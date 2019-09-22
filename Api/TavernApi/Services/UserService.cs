using System;
using System.Collections.Generic;
using System.Linq;
using TavernApi.Models.Identity;

namespace TavernApi.Services
{
    public interface IUserService
    {
        User AuthenticateWithEmail(string email, string password);
        User AuthenticateWithUsername(string username, string password);
        User GetById(long id);
        IEnumerable<User> GetAll();
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(long id);
    }
    
    public class UserService : IUserService
    {
        private readonly TavernContext _context;
        
        public UserService(TavernContext context)
        {
            _context = context;
        }
        
        public User AuthenticateWithEmail(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;
            
            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        public User AuthenticateWithUsername(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;
            
            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        public User GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password is required", nameof(password));
            
            if (_context.Users.Any(x => x.Username == user.Username))
                throw new Exception("Username already taken.");
            
            if (_context.Users.Any(x => x.Email == user.Email))
                throw new Exception("Email already taken.");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User user, string password = null)
        {
            var oldUser = _context.Users.Find(user.Id);
            
            if (oldUser == null)
                throw new ArgumentException("The user must exist in the database.", nameof(user));

            if (oldUser.Username != user.Username)
            {
                if (_context.Users.Any(x => x.Username == user.Username))
                    throw new Exception("Username " + user.Username + " is already taken");

                oldUser.Username = user.Username;
            }
            
            if (oldUser.Email != user.Email)
            {
                if (_context.Users.Any(x => x.Email == user.Email))
                    throw new Exception("Email " + user.Email + " is already taken");

                oldUser.Email = user.Email;
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                oldUser.PasswordHash = passwordHash;
                oldUser.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(oldUser);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be null, empty or whitespace.");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                if (computedHash.Where((t, i) => t != storedHash[i]).Any())
                    return false;
            }
            
            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be null, empty or whitespace.");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}