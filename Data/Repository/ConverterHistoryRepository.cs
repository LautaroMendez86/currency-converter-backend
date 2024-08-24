using System.Runtime.InteropServices.JavaScript;
using CurrencyController.Models.Dto;
using CurrencyConverter.Data;
using CurrencyConverter.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CurrencyController.Data.Repository;
public class ConverterHistoryRepository
{
    private readonly CurrencyConverterContext _currencyConverterContext;
    public ConverterHistoryRepository(CurrencyConverterContext currencyConverterContext)
    {
        _currencyConverterContext = currencyConverterContext;
    }
    public List<ConverterHistory> GetConverterHistory(int userId)
    {
       return _currencyConverterContext.ConverterHistories.Where(history => history.UserId == userId).Include(history => history.CurrencyFrom).Include(history => history.CurrencyTo).OrderByDescending(history => history.Date).ToList();
    }

    public bool CanConvert(int userId)
    {
        var user = _currencyConverterContext.Users?.Where(user => user.Id == userId).Include(user => user.Subscription).First();
        
        if (user == null || user.Subscription?.TotalAvailableConversions == null)
        {
            return true;
        }

        int limit = user.Subscription.TotalAvailableConversions.Value;

        int conversionCount = _currencyConverterContext.ConverterHistories
            .Where(history => history.UserId == userId && history.Date > DateTime.Now.AddMonths(-1))
            .Count();

        return conversionCount < limit;
    }

    public void AddConverterHistory(ConverterHistoryDto converterHistory)
    {
        ConverterHistory converterHistoryEntity = new ConverterHistory
        {
            UserId = converterHistory.UserId,
            Date = converterHistory.Date,
            CurrencyToId = converterHistory.CurrencyTo,
            CurrencyFromId = converterHistory.CurrencyFrom,
            Amount = converterHistory.Amount,
            Result = converterHistory.Result
        };
        
        _currencyConverterContext.ConverterHistories.Add(converterHistoryEntity);
        _currencyConverterContext.SaveChanges();
    }
}