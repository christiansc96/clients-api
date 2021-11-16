using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechApi.DTO;
using TechApi.DTO.Util;
using TechApi.Repository.Interfaces;
using TechApi.Repository.Util;

namespace TechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public readonly IClientRepository clientRepository;

        public ClientsController(IClientRepository _clientRepository)
        {
            clientRepository = _clientRepository;
        }

        [HttpGet("{limit}/{from}")]
        public IActionResult GetClients(int limit, int from)
        {
            ResponseResultDTO resultDTO = clientRepository.GetClients(limit, from);
            if (LogicValidations.ValidataIfDataIsNull(resultDTO.Data))
            {
                return NotFound();
            }
            return Ok(resultDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            ResponseResultDTO resultDTO = await clientRepository.GetClient(id);
            if (LogicValidations.ValidataIfDataIsNull(resultDTO.Data))
            {
                return NotFound();
            }
            return Ok(resultDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(ClientDTO model)
        {
            ResponseResultDTO resultDTO = await clientRepository.PostClient(model);
            if (resultDTO.Success)
            {
                return Ok(resultDTO);
            }
            return BadRequest(resultDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutClient(ClientDTO model)
        {
            ResponseResultDTO resultDTO = await clientRepository.PutClient(model);
            if (resultDTO.Success)
            {
                return Ok(resultDTO);
            }
            return BadRequest(resultDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            ResponseResultDTO resultDTO = await clientRepository.DeleteClient(id);
            if (resultDTO.Success)
            {
                return Ok(resultDTO);                
            }
            return BadRequest(resultDTO);
        }
    }
}