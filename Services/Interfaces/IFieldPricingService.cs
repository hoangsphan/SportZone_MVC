using SportZone_MVC.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IFieldPricingService
    {
        Task<IEnumerable<FieldPricingDto>> GetAllFieldPricingsAsync();
        Task<FieldPricingDto?> GetFieldPricingByIdAsync(int id);
        Task<IEnumerable<FieldPricingDto>> GetFieldPricingsByFieldIdAsync(int fieldId);
        Task<FieldPricingDto> CreateFieldPricingAsync(FieldPricingCreateDto createDto);
        Task<FieldPricingDto?> UpdateFieldPricingAsync(int id, FieldPricingUpdateDto updateDto);
        Task<bool> DeleteFieldPricingAsync(int id);
    }
}