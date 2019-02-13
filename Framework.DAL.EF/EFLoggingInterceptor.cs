using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using Common.Logging;

namespace Framework.DAL.EF
{
    /// <inheritdoc />
    /// <summary>
    ///     <P>This class implements EF database logging via the Entity Framework database command interceptor. </P>
    ///     <P>The interceptor is currently initialized via the web.config for the WebApi application. </P>
    /// </summary>
    public class EfLoggingInterceptor : IDbCommandInterceptor
    {
        private static readonly ILog _log = LogManager.GetLogger<EfLoggingInterceptor>();

        private void WriteLog(string format, params object[] args)
        {
            _log.Debug(m => m(format, args));
        }

        /// <summary>
        ///     Write SQL command parameter values to debug log/s
        /// </summary>
        /// <param name="cmd">The command object</param>
        private void WriteParameters(DbCommand cmd)
        {
            for (var i = 0; i < cmd.Parameters.Count; i++)
            {
                if (cmd.Parameters[i].Value != null)
                {
                    var i1 = i;
                    _log.Debug(m => m("Query param {0}: {1}", i1, cmd.Parameters[i1].Value));
                }
            }
        }

        #region IDbCommandInterceptor implementation
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
            WriteParameters(command);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
            WriteParameters(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
            WriteParameters(command);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
            WriteParameters(command);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
            WriteParameters(command);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
            WriteParameters(command);
        }
        #endregion
    }
}