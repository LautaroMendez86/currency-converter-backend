using CurrencyConverter.Entities;

namespace CurrencyController.Data.Repository;
using CurrencyConverter.Data;

public class SubscriptionRepository
{
    public CurrencyConverterContext _context;
    public SubscriptionRepository(CurrencyConverterContext context)
    {
        _context = context;
    }
    
    public List<Subscription> Index() => _context.Subscriptions.ToList();

}