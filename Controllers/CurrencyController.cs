using CurrencyController.Data.Repository;
using CurrencyController.Models.Dto;
using CurrencyConverter.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        public CurrencyRepository _currencyRepository;
        public CurrencyController(CurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<Currency> currencies = _currencyRepository.Index();

                return Ok(currencies);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CurrencyForCreation currencyDto)
        {
            try
            {
                Currency currency = _currencyRepository.Create(currencyDto);

                return Ok(currency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(CurrencyForUpdate currencyDto)
        {
            try
            {
                _currencyRepository.Update(currencyDto);

                return Ok("Moneda actualizada exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _currencyRepository.Delete(id);

                return Ok("Moneda eliminada exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("import-external-currency")]
        public async Task<IActionResult> ImportExternalCurrencies()
        {
            try
            {
                await _currencyRepository.ImportExternalCurrencies();
                return Ok("Monedas importadas correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al importar monedas externas: " + ex.Message);
            }
        }
    }
    }
