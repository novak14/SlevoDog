using Catalog.Configuration;
using Catalog.Dal.Entities;
using Catalog.Dal.Repository.Abstraction;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;



namespace Catalog.Dal.Repository.Implementation
{
    public class SaleRepository : ISaleRepository
    {
        private readonly CatalogOptions _options;

        public SaleRepository(IOptions<CatalogOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _options = options.Value;
        }

        public IEnumerable<Sale> LoadAll()
        {
            IEnumerable<Sale> sale = new List<Sale>();
            string sql = @"Select * from Sale WHERE bDisabled = 0";

            using (var connection = new SqlConnection(_options.connectionString))
            {
                sale = connection.Query<Sale>(sql);
            }
            return sale;
        }

        public Sale LoadById(int id)
        {
            Sale sale = new Sale();

            string sql = @"SELECT * FROM Sale
                        LEFT JOIN Comments 
                        ON Sale.Id = Comments.FkSale
                        AND Comments.Disabled = 0
                        WHERE Sale.bDisabled = 0 AND Sale.Id = @Id";

            using (var connection = new SqlConnection(_options.connectionString))
            {
                sale = connection.Query<Sale, Comments, Sale>(
                    sql,
                    (saleQuery, comments) =>
                    {
                        saleQuery.comments = comments;
                        return saleQuery;
                    }, new { Id = id }).FirstOrDefault();
            }

            //using (var connection = new SqlConnection(_options.connectionString))
            //{
            //    sale = connection.Query<Sale>(sql, new { Id = id }).FirstOrDefault();
            //}
            return sale;
        }
    }
}
