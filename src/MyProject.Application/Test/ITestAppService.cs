using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    public interface ITestAppService : IAsyncCrudAppService<TestDto, int, TestQueryDto, TestCreateDto, TestEditDto> { }
}
