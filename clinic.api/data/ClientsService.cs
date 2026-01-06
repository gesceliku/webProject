using System;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data
{
    public class ClientsService
    {
        private AppDbContext _context;
        public ClientsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clients>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }


        public Task<Clients> GetClientByUsernameAsync(string clientUn)
        {
            var clientDb = _context.Clients
                .FirstOrDefaultAsync(a => a.username.Equals(clientUn));

            return clientDb;
        }

        public async Task AddNewClientAsync(Clients newClient)
        {

            await _context.Clients.AddAsync(newClient);
            await  _context.SaveChangesAsync();
        }

        public async Task DeleteClientByUsernameAsync(string clientUn)
        {
            var clientDb = await _context.Clients.FirstOrDefaultAsync(a => a.username.Equals(clientUn));
            if (clientDb != null)
            {
                _context.Clients.Remove(clientDb);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateClientByUsernameAsync(string clientUn, Clients updatedClient)
        {
            var clientDb =  await _context.Clients.FirstOrDefaultAsync(a => a.username.Equals(clientUn));
            if (clientDb != null)
            {
                clientDb.Fullname = updatedClient.Fullname;
                _context.Clients.Update(clientDb);
                await _context.SaveChangesAsync();
            }
        }


    }
}
