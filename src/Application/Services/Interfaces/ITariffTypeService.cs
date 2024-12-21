using Application.Models.TariffTypes;
using Core.Entities;

namespace Application.Services.Interfaces;

public interface ITariffTypeService
{
    Task<TariffType> AddTariffAsync(CreateTariffTypeModel tariffTypeDto);
}