using CurrencyController.Models.Dto;
using CurrencyConverter.Data;
using CurrencyConverter.Entities;
using Newtonsoft.Json.Linq;

namespace CurrencyController.Data.Repository
{
    public class CurrencyRepository
    {
        public CurrencyConverterContext _currencyConverterContext;
        public CurrencyRepository(CurrencyConverterContext currencyConverterContext)
        {
            _currencyConverterContext = currencyConverterContext;
        }
        public List<Currency> Index()
        {
            return _currencyConverterContext.Currencies.ToList();
        }

        public Currency Create(CurrencyForCreation currencyDto)
        {
            try
            {
                Currency currency = new()
                {
                    Name = currencyDto.Name,
                    Symbol = currencyDto.Symbol,
                    Value = currencyDto.Value
                };

                _currencyConverterContext.Currencies.Add(currency);
                _currencyConverterContext.SaveChanges();

                return currency;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando la moneda", ex);
            }

        }

        public void Update(CurrencyForUpdate currencyDto)
        {
            try
            {
                Currency currency = _currencyConverterContext.Currencies.Find(currencyDto.Id);

                if (currency == null)
                {
                    throw new ArgumentException("Moneda no encontrada");
                }

                currency.Name = currencyDto.Name;
                currency.Symbol = currencyDto.Symbol;
                currency.Value = currencyDto.Value;

                _currencyConverterContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error actualizando la moneda", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Currency currency = _currencyConverterContext.Currencies.Find(id);

                if (currency == null)
                {
                    throw new ArgumentException("Moneda no encontrada");
                }

                _currencyConverterContext.Currencies.Remove(currency);
                _currencyConverterContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error eliminando la moneda", ex);
            }
        }

        public async Task ImportExternalCurrencies()
        {
            string api = "https://trustpilot.digitalshopuy.com/currency/all";

            using HttpClient client = new();

            try
            {

                HttpResponseMessage response = await client.GetAsync(api);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la importacion");
                }
                dynamic currencies = JObject.Parse(await response.Content.ReadAsStringAsync());
                dynamic rates = currencies.rates;
                dynamic names = currencies.names;
                 
                foreach (var key in names)
                {
                   JProperty obj = new(key);

                    Currency currencyEntity = new()
                    {
                        Name = obj.Name,
                        Value = rates[obj.Name].from,
                        Symbol = obj.Value.ToString()
                    };

                    _currencyConverterContext.Currencies.Add(currencyEntity);
                    _currencyConverterContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error importando monedas externas" + ex);
            }
        }

    }
}
