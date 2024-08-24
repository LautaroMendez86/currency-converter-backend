using CurrencyController.Data.Repository;
using CurrencyController.Models.Dto;
using CurrencyConverter.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyRepository _currencyRepository;
        private readonly ConverterHistoryRepository _converterHistoryRepository;
        public CurrencyController(CurrencyRepository currencyRepository, ConverterHistoryRepository converterHistoryRepository)
        {
            _currencyRepository = currencyRepository;
            _converterHistoryRepository = converterHistoryRepository;
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

        [HttpPost("convert")]
        public IActionResult Convert(CurrencyConversionDto currencyConversionDto)
        {
            try
            {
                bool canConvert = _converterHistoryRepository.CanConvert(currencyConversionDto.UserId);
        
                if (!canConvert)
                {
                    return BadRequest(new { success = false, message = "Alcanzaste el límite de intentos." });
                }
        
                double result = _currencyRepository.Convert(currencyConversionDto);

                return Ok(new { success = true, result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Ocurrió un error inesperado.", details = ex.Message });
            }
        }

        [HttpGet("import-currencies")]
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

        [HttpPost("search")]
        public IActionResult Search(String query)
        {
            try
            {
                List<Currency> result = _currencyRepository.SearchByString(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    }
