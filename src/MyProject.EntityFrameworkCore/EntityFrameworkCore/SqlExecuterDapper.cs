using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Castle.Core.Logging;
using MyProject.Public;
using Dapper;

namespace MyProject.EntityFrameworkCore
{
    public class SqlExecuterDapper : ISqlExecuterDapper, ITransientDependency
    {
        //
        // 摘要:
        //     Reference to the logger to write logs.
        public ILogger Logger { protected get; set; }

        public IDbConnection GetConnection()
        {
            IDbConnection db = new SqlConnection("Server=127.0.0.1; Database=MyProjectDb; User=sa; Password=123456; Trusted_Connection=True");
            /// db.Open();
            return db;
        }


        public SqlExecuterDapper(ILogger logger)
        {
            Logger = logger;
        }


        /// <summary>
        /// 执行给定的命令
        /// </summary>
        /// <param name="sql">命令字符串</param>
        /// <param name="parameters">要应用于命令字符串的参数</param>
        /// <returns>执行命令后由数据库返回的结果</returns>
        public int Execute(string sql, bool needWriteLog = true, params object[] parameters)
        {
            if (needWriteLog)
                Logger.InfoFormat(sql, parameters);
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    int k = 0;
                    if (parameters.Length == 0)
                        k = conn.Execute(sql);
                    else
                        k = conn.Execute(sql, parameters);



                    conn.Close();

                    return k;
                }


            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }

        }

        public IEnumerable<dynamic> SqlQuery(string sql, object parameters)
        {
            return GetConnection().Query(sql, parameters);
        }


        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。
        /// </summary>
        /// <typeparam name="T">查询所返回对象的类型<peparam>
        /// <param name="sql">SQL 查询字符串</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数</param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, object parameters)
        {
            return GetConnection().Query<T>(sql, parameters);
        }

        public async Task<int> CountAsync(string table, string where = " 1=1 ")
        {

            return await GetConnection().QueryFirstOrDefaultAsync<int>($"SELECT COUNT(1) FROM {table} where {where}");
        }

        public async Task<IEnumerable<T>> SqlQueryAsync<T>(string sql)
        {
            return await GetConnection().QueryAsync<T>(sql);

        }

        public IEnumerable<T> SqlQuery<T>(string sql)
        {
            return GetConnection().Query<T>(sql);
        }

        public bool Execute(List<string> sql, bool needWriteLog = true)
        {
            if (sql.Count < 1)
                return true;

            using (var conn = GetConnection())
            {
                conn.Open();
                try
                {
                    var comm = conn.CreateCommand();
                    comm.CommandText = string.Join(';', sql.ToArray());
                    if (needWriteLog)
                        Logger.Info(comm.CommandText);
                    comm.ExecuteNonQuery();
                    //sql.ForEach(a =>
                    //{
                    //    comm.CommandText = a;
                    //    comm.ExecuteNonQuery();
                    //});
                    //tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                    //tran.Rollback();
                    throw;
                }
            }
        }
    }
}
