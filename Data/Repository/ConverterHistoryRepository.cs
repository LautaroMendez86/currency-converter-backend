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