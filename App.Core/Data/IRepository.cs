using LinqToDB.SchemaProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace App.Core.Data
{
    public interface IRepository : IDisposable
    {
        IDbConnection GetDbConnection();

        void BulkCopy<T>(IEnumerable<T> lst);

        //IRepository Config(string connectionString, string dataProviderName);

        void CreateTable(Type entityType);

        void Delete<T>(T entity);

        void Delete<T>(Expression<Func<T, bool>> exp) where T : class;

        IQueryable<T> GetTable<T>() where T : class;

        void Insert<T>(T entity);

        void InsertOrReplace<T>(T entity);

        IQueryable<T> Query<T>() where T : class;

        IEnumerable<T> Query<T>(string sql);

        List<TableSchema> QuerySchemas(string tableLikePattern = null);

        void Update<T>(T entity);
    }
}
