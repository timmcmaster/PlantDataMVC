using Common.Logging;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Framework.DAL.EF
{
    public class EFLoggingInterceptor : IDbCommandInterceptor
    {
        private static readonly ILog _log = LogManager.GetLogger<EFLoggingInterceptor>();

        private void WriteLog(string format, params object[] args)
        {
            _log.Debug(m => m(format, args));
        }

        #region IDbCommandInterceptor implementation

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText);
        }
        #endregion
    }
}
