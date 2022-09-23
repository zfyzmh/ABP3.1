using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyProject.EntityFrameworkCore.Models
{
    /// <summary>
    /// 测试实体类 
    /// </summary>
    public class Test:Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DefaultValue(50)]
        public string FName { get; set; }
    }
}
