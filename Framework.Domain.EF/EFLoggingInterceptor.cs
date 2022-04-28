using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Common.Logging;
using System.Threading.Tasks;
using System.Threading;

namespace Framework.Domain.EF
{
    /// <inheritdoc />
    /// <summary>
    ///     <P>This class implements EF database logging via the Entity Framework database command interceptor. </P>
    ///     <P>The interceptor is currently initialized via the web.config for the WebApi application. </P>
    /// </summary>
    public class EfLoggingInterceptor : DbCommandInterceptor
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

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return result;
        }

        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return result;
        }

        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return result;
        }

        public override Task<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task<InterceptionResult<DbDataReader>>(() => result);
        }

        public override Task<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task<InterceptionResult<object>>(() => result);
        }

        public override Task<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task<InterceptionResult<int>>(() => result);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return result;
        }

        public override object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return result;
        }

        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return result;
        }

        public override Task<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task<DbDataReader>(() => result);
        }

        public override Task<object> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object result, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task<object>(() => result);
        }

        public override Task<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task<int>(() => result);
        }

        public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);
        }

        public override Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            WriteLog("IsAsync: {0}, Command Text: {1}", eventData.IsAsync, command.CommandText);
            WriteParameters(command);

            return new Task(null);
        }
        #endregion
    }
}