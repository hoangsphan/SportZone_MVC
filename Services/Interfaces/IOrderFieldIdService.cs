using SportZone_MVC.DTOs;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IOrderFieldIdService
    {
        /// <summary>
        /// Tạo OrderFieldId từ Order và FieldId
        /// </summary>
        Task<OrderFieldIdDTO> CreateOrderFieldIdAsync(int orderId, int fieldId);

        /// <summary>
        /// Lấy OrderFieldIds theo OrderId
        /// </summary>
        Task<IEnumerable<OrderFieldIdDTO>> GetOrderFieldIdsByOrderIdAsync(int orderId);

        /// <summary>
        /// Lấy OrderFieldIds theo FieldId
        /// </summary>
        Task<IEnumerable<OrderFieldIdDTO>> GetOrderFieldIdsByFieldIdAsync(int fieldId);
    }
}
