using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyProject.EntityFrameworkCore.Models;

namespace MyProject
{
    [AutoMap(typeof(Test))]
    public class TestQueryDto : PagedResultRequestDto
    {
    }
}