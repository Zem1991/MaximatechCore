using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Infrastructure.Context.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            IEnumerable<Department> result = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(result);
        }
    }
}
