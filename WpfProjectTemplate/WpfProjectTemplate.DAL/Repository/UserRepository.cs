using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WpfProjectTemplate.BLL.Interface.DAL;
using WpfProjectTemplate.BLL.PresentationModel;
using WpfProjectTemplate.DAL.EF;
using WpfProjectTemplate.DAL.Entities;

namespace WpfProjectTemplate.DAL.Repository
{
   public class UserRepository : IUserRepository
    {
        ProjectContext _context;

        public UserRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserPM item)
        {
            _context.Users.Add(ToUser(item));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserPM item)
        {
            _context.Users.Remove(ToUser(item));
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserPM>> GetAllAsync()
        {

            return  ToUserPMList(await _context.Users.ToListAsync());
        }

        public async Task<UserPM> GetByIdAsync(int id)
        {
            return ToUserPM(await _context.Users.FindAsync(id));
        }

        public async Task UpdateAsync(UserPM item)
        {
            _context.Users.Attach(ToUser(item));
            _context.Entry(ToUser(item)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }








        private UserPM ToUserPM(User user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserPM>());
            var usersPM = Mapper.Map<User, UserPM>(user);
            Mapper.Reset();
            return usersPM;
        }

        private User ToUser(UserPM userPM)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserPM, User>());
            var users = Mapper.Map<UserPM, User>(userPM);
            Mapper.Reset();
            return users;
        }

        private List<UserPM> ToUserPMList(List<User> users)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserPM>());
            var userPMList = new List<UserPM>();
            foreach (var VARIABLE in users)
            {
                userPMList.Add(Mapper.Map<User, UserPM>(VARIABLE));
            }
            Mapper.Reset();
            return userPMList;
        }
    }
}
