using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<List<IIS.Domain.Entities.Structure.Group>> GetAllAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task CreateAsync(CreateGroupDto dto)
        {
            var group = new IIS.Domain.Entities.Structure.Group
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                CourseNumber = dto.CourseNumber,
                DepartmentId = dto.DepartmentId,
                CreatedAt = DateTime.UtcNow,
            };

            await _groupRepository.AddAsync(group);
        }
    }
}
