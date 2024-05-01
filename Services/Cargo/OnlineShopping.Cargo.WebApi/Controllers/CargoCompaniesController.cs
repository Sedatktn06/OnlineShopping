using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;
    private readonly IMapper _mapper;

    public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
    {
        _cargoCompanyService = cargoCompanyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cargoCompanies = await _cargoCompanyService.TGetAllAsync();
        return Ok(cargoCompanies);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _cargoCompanyService.TInsertAsync(_mapper.Map<CargoCompany>(createCargoCompanyDto));
        return Ok("Kargo şirketi oluşturuldu.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _cargoCompanyService.TDeleteAsync(id);
        return Ok("Kargo şirketi kaldırıldı.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var cargoCompany = await _cargoCompanyService.TGetByIdAsync(c=> c.Id == id);
        return Ok(cargoCompany);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        await _cargoCompanyService.TUpdateAsync(_mapper.Map<CargoCompany>(updateCargoCompanyDto));
        return Ok("Kargo şirketi güncellendi.");
    }
}
