using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;
using System.Data.Common;

namespace RowLevelSecuritySample.EntityFramework
{
    public class SessionContextDbConnectionInterceptor(IHttpContextAccessor httpContextAccessor) : DbConnectionInterceptor
    {
        public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
        {
            base.ConnectionOpened(connection, eventData);

            var userId = GetUserId();
            if (userId.HasValue)
            {
                var cmd = CreateCommand(connection, userId.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public override async Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData,
            CancellationToken cancellationToken = new CancellationToken())
        {
            await base.ConnectionOpenedAsync(connection, eventData, cancellationToken);

            var userId = GetUserId();
            if (userId.HasValue)
            {
                var cmd = CreateCommand(connection, userId.Value);
                await cmd.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private int? GetUserId()
        {
            if (httpContextAccessor.HttpContext != null
                && httpContextAccessor.HttpContext.Request.Headers.TryGetValue("user-id", out var headerUserId))
                return int.Parse(headerUserId.ToString());

            return null;
        }

        private static DbCommand CreateCommand(DbConnection connection, int userId)
        {
            var cmd = connection.CreateCommand();

            var param = cmd.CreateParameter();
            param.ParameterName = "@key";
            param.Value = "UserId";
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@value";
            param.Value = userId;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = @"sp_set_session_context";
            return cmd;
        }
    }
}
