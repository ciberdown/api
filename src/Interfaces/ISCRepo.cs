using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.StudentCoures;
using api.Helpers;
using api.Models;
using api.src.Dtos.StudentCoures;

namespace api.Interfaces
{
    public interface ISCRepo
    {
        public Task<List<StudentCourse>?> Get(SCObjectQuery query);
        public Task<StudentCourse?> Update(UpdateSCDto updateSCDto);
        public Task<StudentCourse?> Create(CreateScDto createDto);
        public Task<bool> Delete(DeleteSCDto deleteSCDto);
    }
}