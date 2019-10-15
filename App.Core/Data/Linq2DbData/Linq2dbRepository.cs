using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.SchemaProvider;

namespace App.Core.Data.Linq2DbData
{
    public class Linq2dbRepository : IRepository
    {
        private string _connectionStringName;
        private string _dataProviderName;

        public void BulkCopy<T>(IEnumerable<T> lst)
        {
            this.GetDataConnection().BulkCopy(lst);
        }

        public Linq2dbRepository(string connectionStringName, string dataProviderName = "")
        {
            _connectionStringName = connectionStringName;
            _dataProviderName = dataProviderName;
        }

        public void CreateTable(Type entityType)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity)
        {
            this.GetDataConnection().Delete(entity);
        }

        public void Delete<T>(Expression<Func<T, bool>> exp) where T : class
        {
            this.GetDataConnection().Delete(exp);
        }

        public void Dispose()
        {

        }

        public IDbConnection GetDbConnection()
        {
            return GetDataConnection().Connection;
        }

        public DataConnection GetDataConnection()
        {
            return Linq2DbConnectionManager.Get(_connectionStringName);
        }

        public IQueryable<T> GetTable<T>() where T : class
        {
            return GetDataConnection().GetTable<T>();
        }

        public void Insert<T>(T entity)
        {
            GetDataConnection().Insert<T>(entity);
        }

        public void InsertOrReplace<T>(T entity)
        {
            GetDataConnection().InsertOrReplace<T>(entity);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return GetDataConnection().GetTable<T>();
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return GetDataConnection().Query<T>(sql);
        }

        public List<TableSchema> QuerySchemas(string tableLikePattern = null)
        {
            DataConnection dataConnection = this.GetDataConnection();
            GetSchemaOptions options = new GetSchemaOptions
            {
                GetProcedures = false,
                // TableNamePattern = tableLikePattern
            };
            List<TableSchema> tables = this.GetDataConnection().DataProvider.GetSchemaProvider().GetSchema(dataConnection, options).Tables;
            List<TableSchema> list2 = new List<TableSchema>();
            foreach (TableSchema schema in tables)
            {
                TableSchema item = new TableSchema
                {
                    ID = schema.ID,
                    CatalogName = schema.CatalogName,
                    SchemaName = schema.SchemaName,
                    TableName = schema.TableName,
                    Description = schema.Description,
                    IsDefaultSchema = schema.IsDefaultSchema,
                    IsView = schema.IsView,
                    IsProcedureResult = schema.IsProcedureResult,
                    TypeName = schema.TypeName,
                    IsProviderSpecific = schema.IsProviderSpecific,
                    Columns = new List<ColumnSchema>()
                };
                list2.Add(item);
                foreach (ColumnSchema schema3 in schema.Columns)
                {
                    ColumnSchema schema4 = new ColumnSchema
                    {
                        ColumnName = schema3.ColumnName,
                        ColumnType = schema3.ColumnType,
                        DataType = schema3.DataType,
                        SystemType = schema3.SystemType,
                        IsNullable = schema3.IsNullable,
                        IsIdentity = schema3.IsIdentity,
                        IsPrimaryKey = schema3.IsPrimaryKey,
                        PrimaryKeyOrder = schema3.PrimaryKeyOrder,
                        Description = schema3.Description,
                        MemberName = schema3.MemberName,
                        MemberType = schema3.MemberType,
                        ProviderSpecificType = schema3.ProviderSpecificType,
                        SkipOnInsert = schema3.SkipOnInsert,
                        SkipOnUpdate = schema3.SkipOnUpdate,
                        Length = schema3.Length,
                        Precision = schema3.Precision,
                        Scale = schema3.Scale
                    };
                    item.Columns.Add(schema4);
                }
            }
            return list2;
        }

        public void Update<T>(T entity)
        {
            this.GetDataConnection().Update<T>(entity);
        }
    }
}
