using CurrencyController.Models.Dto;
using CurrencyConverter.Data;
using CurrencyConverter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CurrencyController.Data.Repository
{
    public class UserRepository
    {
        private CurrencyConverterContext _currencyConverterContext;
        public UserRepository(CurrencyConverterContext currencyConverterContext)
        {
            _currencyConverterContext = currencyConverterContext;
        }
        public List<User> Index()
        {
            return _currencyConverterContext.Users
                .Include(u => u.Favourites)
                .Include(u => u.Subscription)
                .ToList();
        }

        public User? GetOne(int id)
        {
            return _currencyConverterContext.Users
                .Include(u => u.Subscription)
                .Single(u => u.Id == id);
        }

        public User Create(UserForCreation userDto)
        {

            if (_currencyConverterContext.Users.Any(u => u.Username == userDto.Username))
            {
                throw new Exception($"El username {userDto.Username} ya existe");
            }
            
            User user = new()
            {
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
                SubscriptionId = 1
            };

            _currencyConverterContext.Users.Add(user);
            _currencyConverterContext.SaveChanges();

            return user;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _currencyConverterContext.Users.FirstOrDefault(p => p.Username == authRequestBody.Username && p.Password == authRequestBody.Password);
        }

        public void UpdateSubscription(User user)
        {
            var existingUser = _currencyConverterContext.Users.Find(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado");
            }

            existingUser.SubscriptionId = user.SubscriptionId; 
            _currencyConverterContext.SaveChanges();
        }
    }
}
