using System.Threading.Tasks;
using TechApi.DTO;
using TechApi.DTO.Util;

namespace TechApi.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<ResponseResultDTO> DeleteClient(int id);

        Task<ResponseResultDTO> GetClient(int id);

        ResponseResultDTO GetClients(int limit, int from);        

        Task<ResponseResultDTO> PostClient(ClientDTO model);

        Task<ResponseResultDTO> PutClient(ClientDTO model);

        Task Save();
    }
}