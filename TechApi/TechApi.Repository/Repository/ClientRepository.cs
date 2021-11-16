using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechApi.Database.Context;
using TechApi.Database.DBModels;
using TechApi.DTO;
using TechApi.DTO.Util;
using TechApi.Repository.Interfaces;
using TechApi.Repository.Queries;
using TechApi.Repository.Util;

namespace TechApi.Repository.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly TechApiContext context;

        public ClientRepository(TechApiContext _context)
        {
            context = _context;
        }

        public async Task<ResponseResultDTO> DeleteClient(int id)
        {
            Client clientFromDatabase = await context.Clients.SingleOrDefaultAsync(client => client.Id == id);

            ResponseResultDTO resultDTO = new()
            {
                Data = id
            };

            if (LogicValidations.ValidataIfDataIsNull(clientFromDatabase))
            {                
                return resultDTO;
            }
            
            try
            {
                resultDTO.Success = true;
                context.Clients.Remove(clientFromDatabase);
                await Save();                
            }
            catch (Exception ex)
            {
                resultDTO.Success = false;
                resultDTO.ErrorMsg = ex.Message;
            }          
            return resultDTO;
        }

        public async Task<ResponseResultDTO> GetClient(int id)
        {
            Client clientFromDatabase = await context.Clients.SingleOrDefaultAsync(client => client.Id == id);

            ResponseResultDTO resultDTO = new() 
            {
                Data = null
            };
            if (LogicValidations.ValidataIfDataIsNull(clientFromDatabase))
            {
                return resultDTO;
            }

            resultDTO.Success = true;
            resultDTO.Data = new ClientDTO()
            {
                Id = clientFromDatabase.Id,
                Name = clientFromDatabase.Name,
            };
            return resultDTO;
        }

        public ResponseResultDTO GetClients(int limit, int from)
        {
            List<Client> clientsFromDatabase = context.Clients.FromSqlRaw(sql: String
                    .Format(QueriesSQL.GetClientsByLimit, from, limit)).ToList();

            List<ClientDTO> clients = new();
            clientsFromDatabase.ForEach(client => {
                clients.Add(new() 
                {
                    Id = client.Id,
                    Name = client.Name
                });
            });

            return new ResponseResultDTO ()
            {
                Success = true,
                Data = clients
            }; ;
        }

        public async Task<ResponseResultDTO> PostClient(ClientDTO model)
        {
            ResponseResultDTO resultDTO = new()
            {
                Data = model,
                Success = true
            };

            try
            {
                Client newClient = new() 
                { 
                    Name = model.Name
                };                
                await context.Clients.AddAsync(newClient);
                await Save();
                model.Id = newClient.Id;
                resultDTO.Data = model;
            }
            catch (Exception ex)
            {
                resultDTO.Success = false;
                resultDTO.ErrorMsg = ex.Message;
            }            
            return resultDTO;
        }

        public async Task<ResponseResultDTO> PutClient(ClientDTO model)
        {
            Client clientFromDatabase = await context.Clients.SingleOrDefaultAsync(client => client.Id == model.Id);
            ResponseResultDTO resultDTO = new()
            {
                Data = model
            };

            if (LogicValidations.ValidataIfDataIsNull(clientFromDatabase))
            {
                return resultDTO;
            }

            try
            {
                resultDTO.Success = true;
                clientFromDatabase.Name = model.Name;
                context.Clients.Update(clientFromDatabase);
                await Save();
            }
            catch (Exception ex)
            {
                resultDTO.Success = false;
                resultDTO.ErrorMsg = ex.Message;
            }
            return resultDTO;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}