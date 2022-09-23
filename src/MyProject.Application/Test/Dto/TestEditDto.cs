using Abp.AutoMapper;
using MyProject.EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    [AutoMap(typeof(Test))]
    public class TestEditDto:TestDto
    {
    }
}
