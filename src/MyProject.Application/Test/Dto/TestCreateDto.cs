using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    [AutoMap(typeof(Test))]
    public class TestCreateDto:TestDto
    {
    }
}
