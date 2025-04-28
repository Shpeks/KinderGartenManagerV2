using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using DAL.Data;
using DAL.Entities;

namespace DAL.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null) return null;

            return new UserDTO
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
            };
        }

        public async Task UserUpdateAsync(UserDTO userDTO)
        {
            var userEntity = await _context.Users.FindAsync(userDTO.Id);
            if (userEntity == null) return; 

            userEntity.FirstName = userDTO.FirstName;
            userEntity.LastName = userDTO.LastName;

            await _context.SaveChangesAsync();
        }

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            var userEntity = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
    }
}
