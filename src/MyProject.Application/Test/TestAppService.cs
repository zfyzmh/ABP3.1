using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using MyProject.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    [AbpAuthorize]
    public class TestAppService : AsyncCrudAppService<Test, TestDto, int, TestQueryDto, TestCreateDto, TestEditDto>, ITestAppService
    {
        private readonly IDbContextProvider<MyProjectDbContext> _provider;
        public TestAppService(IRepository<Test> repository, IDbContextProvider<MyProjectDbContext> provider) : base(repository)
        {
            _provider=provider; 
        }
        public object test()
        {
           return abpHelper.GetDB().Execute("INSERT INTO Test VALUES ('test')");

        }
    }
}
