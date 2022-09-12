using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MyProject;
using Abp.Application.Services.Dto;

namespace MyProject
{
    [AutoMap(typeof(Test))]
    public class TestQueryDto: PagedResultRequestDto
    {
    }
}
