using CSharpSqlDataBaseAssignment.Entities;
using CSharpSqlDataBaseAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSqlDataBaseAssignment.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity? CreateRole(string roleName)
        {
            try
            {
                var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
                roleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });
                return roleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in CreateRole: {ex.Message}");
                return null;
            }
        }

        public RoleEntity? GetRoleByRoleName(string roleName)
        {
            try
            {
                var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
                return roleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetRoleByRoleName: {ex.Message}");
                return null;
            }
        }

        public RoleEntity? GetRoleById(int id)
        {
            try
            {
                var roleEntity = _roleRepository.Get(x => x.Id == id);
                return roleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetRoleById: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<RoleEntity>? GetRoles()
        {
            try
            {
                var roles = _roleRepository.GetAll();
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetRoles: {ex.Message}");
                return null;
            }
        }

        public RoleEntity? UpdateRole(RoleEntity roleEntity)
        {
            try
            {
                var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
                return updatedRoleEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in UpdateRole: {ex.Message}");
                return null;
            }
        }

        public void DeleteRole(int id)
        {
            try
            {
                _roleRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in DeleteRole: {ex.Message}");
            }
        }

    }

}
