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

        [HttpPost("convert")]
        public IActionResult Convert(CurrencyConversionDto currencyConversionDto)
        {
            try
            {
                double result = _currencyRepository.Convert(currencyConversionDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
