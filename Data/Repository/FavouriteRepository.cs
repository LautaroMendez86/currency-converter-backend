using CurrencyController.Models.Dto;
using CurrencyConverter.Data;
using CurrencyConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyController.Data.Repository
{
    public class FavouriteRepository
    {
        public CurrencyConverterContext _context;
        public FavouriteRepository(CurrencyConverterContext context)
        {
            _context = context;
        }

        public List<Currency> Index(int userId)
        {
            return _context.Favourites
                .Where(favourite => favourite.UserId == userId)
                .Include(fav => fav.Currency)
                .GroupBy(fav => fav.CurrencyId)
                .Select(fav => fav.First().Currency)
                .ToList();
        }

        public void Create(FavouriteToCreateAndDelete favourite)
        {
            try
            {
            Favourite newFavourite = new()
            {
                UserId = favourite.UserId,
                CurrencyId = favourite.CurrencyId
            };

            _context.Favourites.Add(newFavourite);
            _context.SaveChanges();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(FavouriteToCreateAndDelete favouriteDto)
        {
            try
            {
            Favourite deletedFavourite = _context.Favourites.FirstOrDefault(favourite => favourite.UserId == favouriteDto.UserId && favourite.CurrencyId == favouriteDto.CurrencyId);
            
            if(deletedFavourite == null)
            {
                throw new Exception("Favourite not found");
            }

            _context.Favourites.Remove(deletedFavourite);
            _context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<int> GetCurrenciesId(int userId)
        {
            return _context.Favourites
                .Where(favourite => favourite.UserId == userId)
                .Include(fav => fav.Currency)
                .GroupBy(fav => fav.CurrencyId)
                .Select(fav => fav.First().CurrencyId)
                .ToList();
        }
    }
}
