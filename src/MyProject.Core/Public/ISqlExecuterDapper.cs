using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Public
{
    public interface ISqlExecuterDapper
    {
        /// <summary>
        /// 执行给定的命令
        /// </summary>
        /// <param name="sql">命令字符串</param>
        /// <param name="parameters">要应用于命令字符串的参数</param>
        /// <returns>执行命令后由数据库返回的结果</returns>
        int Execute(string sql, bool needWriteLog = true, params object[] parameters);

        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。
        /// </summary>
        /// <typeparam name="T">查询所返回对象的类型<peparam>
        /// <param name="sql">SQL 查询字符串</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数</param>
        /// <returns></returns>
        //IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
        IEnumerable<T> SqlQuery<T>(string sql, object parameters);

        IEnumerable<dynamic> SqlQuery(string sql, object parameters);

        Task<int> CountAsync(string table, string where = " 1=1 ");

        Task<IEnumerable<T>> SqlQueryAsync<T>(string sql);

        IEnumerable<T> SqlQuery<T>(string sql);

        bool Execute(List<string> sql, bool needWriteLog = true);
    }
}
