using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    [AutoMap(typeof(Test))]
    public class TestDto:EntityDto
    {
        public string FName { get; set; }
    }
}
