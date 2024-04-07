using Dapper;
using Inmobiliaria.Infraestructura.Configuration.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Inmobiliaria.Infraestructura.Configuration.Extension
{
    public static class QueryExtension
    {
        public static async Task<T> ExecuteQueryAsync<T>(this ApplicationsContext SQL, string SqlQuery, object param) {

            using (var SqlConnection = new SqlConnection(SQL.Database.GetDbConnection().ConnectionString)) { 
            
                await SqlConnection.OpenAsync();
                return await SqlConnection.QueryFirstOrDefaultAsync<T>(SqlQuery, param);
            }

        }
    }
}
