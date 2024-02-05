using CurrencyController.Models.Dto;
using CurrencyConverter.Data;
using CurrencyConverter.Entities;

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
            return _currencyConverterContext.Users.ToList();
        }

        public User Create(UserForCreation userDto)
        {
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
      
    }
}
