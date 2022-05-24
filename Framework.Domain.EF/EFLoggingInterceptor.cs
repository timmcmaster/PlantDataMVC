using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
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
                    Log.Debug($"Query param {i1}: {cmd.Parameters[i1].Value}");
                }
            }
        }

        #region IDbCommandInterceptor implementation

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return result;
        }

        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return result;
        }

        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new ValueTask<InterceptionResult<object>>(result);
        }

        public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new ValueTask<InterceptionResult<int>>(result);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return result;
        }

        public override object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return result;
        }

        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return result;
        }

        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new ValueTask<DbDataReader>(result);
        }

        public override ValueTask<object> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object result, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new ValueTask<object>(() => result);
        }

        public override ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new ValueTask<int>(result);
        }

        public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);
        }

        public override Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            Log.Debug($"IsAsync: {eventData.IsAsync}, Command Text: {command.CommandText}");
            WriteParameters(command);

            return new Task(null);
        }
        #endregion
    }
}