using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IRegulationFacilityService
    {
        Task<List<RegulationFacility>> GetAllRegulationFacilities();
        Task<RegulationFacility?> GetRegulationFacilityById(int id);
        Task<List<RegulationFacility>> GetRegulationFacilitiesByFacilityId(int facId);
        Task<ServiceResponse<RegulationFacility>> CreateRegulationFacility(RegulationFacilityDto dto);
        Task<ServiceResponse<RegulationFacility>> UpdateRegulationFacility(int id, RegulationFacilityDto dto);
        Task<ServiceResponse<RegulationFacility>> DeleteRegulationFacility(int id);
        Task<List<RegulationFacility>> SearchRegulationFacilities(string text);
    }
}