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
   public class RoleRepository : IRoleRepository
    {
        ProjectContext _context;

        public RoleRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(RolePM item)
        {
            _context.Roles.Add(ToRole(item));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RolePM item)
        {
            _context.Roles.Remove(ToRole(item));
            await _context.SaveChangesAsync();
        }

        public async Task<List<RolePM>> GetAllAsync()
        {

            return ToRolePMList(await _context.Roles.ToListAsync());
        }

        public async Task<RolePM> GetByIdAsync(int id)
        {
            return ToRolePM(await _context.Roles.FindAsync(id));
        }

        public async Task UpdateAsync(RolePM item)
        {
            _context.Roles.Attach(ToRole(item));
            _context.Entry(ToRole(item)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }








        private RolePM ToRolePM(Role Role)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Role, RolePM>());
            var rolesPM = Mapper.Map<Role, RolePM>(Role);
            Mapper.Reset();
            return rolesPM;
        }

        private Role ToRole(RolePM RolePM)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RolePM, Role>());
            var roles = Mapper.Map<RolePM, Role>(RolePM);
            Mapper.Reset();
            return roles;
        }

        private List<RolePM> ToRolePMList(List<Role> Roles)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Role, RolePM>());
            var RolePMList = new List<RolePM>();
            foreach (var VARIABLE in Roles)
            {
                RolePMList.Add(Mapper.Map<Role, RolePM>(VARIABLE));
            }
            Mapper.Reset();
            return RolePMList;
        }
    }
}
