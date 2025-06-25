using QuickBite.Web.Models.DTO;

namespace QuickBite.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO> SendAsync(RequestDTO requestDTO, bool withBearer = true);
    }
}
