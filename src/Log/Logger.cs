using System;
using PipServices.Commons.Config;
using System.Text;
using PipServices.Commons.Refer;
using PipServices.Components.Info;

namespace PipServices.Components.Log
{
    public abstract class Logger : ILogger, IReconfigurable, IReferenceable
    {
        protected LogLevel _level = LogLevel.Info;
        protected string _source = null;

        protected Logger()
        { }

        public LogLevel Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public virtual void Configure(ConfigParams config)
        {
            _level = LogLevelConverter.ToLogLevel(
                config.GetAsObject("level") ?? _level);
            _source = config.GetAsStringWithDefault("source", _source);
        }

        public virtual void SetReferences(IReferences references)
        {
            var contextInfo = references.GetOneOptional<ContextInfo>(
                new Descriptor("pip-services", "context-info", "*", "*", "1.0"));
            if (contextInfo != null && _source == null)
                _source = contextInfo.Name;
        }

        protected abstract void Write(LogLevel level, string correlationId, Exception error, string message);

        protected string ComposeError(Exception error)
        {
            var builder = new StringBuilder();

            while (error != null)
            {
                if (builder.Length > 0)
                    builder.Append(" Caused by error: ");

                builder.Append(error.Message)
                    .Append(" StackTrace: ")
                    .Append(error.StackTrace);

                error = error.InnerException;
            }

            return builder.ToString();
        }

        protected void FormatAndWrite(LogLevel level, string correlationId, Exception error, string message, object[] args)
        {
            var mes = !string.IsNullOrWhiteSpace(message) ? message : string.Empty;
            if (args != null && args.Length > 0)
                mes = string.Format(mes, args);

            Write(level, correlationId, error, mes);
        }

        public void Log(LogLevel level, string correlationId, Exception error, string message, params object[] args)
        {
            FormatAndWrite(level, correlationId, error, message, args);
        }

        public void Fatal(string correlationId, string message, params object[] args)
        {
            FormatAndWrite(LogLevel.Fatal, correlationId, null, message, args);
        }

        public void Fatal(string correlationId, Exception error, string message = null, params object[] args)
        {
            FormatAndWrite(LogLevel.Fatal, correlationId, error, message, args);
        }

        public void Error(string correlationId, string message, params object[] args)
        {
            FormatAndWrite(LogLevel.Error, correlationId, null, message, args);
        }

        public void Error(string correlationId, Exception error, string message = null, params object[] args)
        {
            FormatAndWrite(LogLevel.Error, correlationId, error, message, args);
        }

        public void Warn(string correlationId, string message, params object[] args)
        {
            FormatAndWrite(LogLevel.Warn, correlationId, null, message, args);
        }

        public void Warn(string correlationId, Exception error, string message = null, params object[] args)
        {
            FormatAndWrite(LogLevel.Warn, correlationId, error, message, args);
        }

        public void Info(string correlationId, string message, params object[] args)
        {
            FormatAndWrite(LogLevel.Info, correlationId, null, message, args);
        }

        public void Info(string correlationId, Exception error, string message = null, params object[] args)
        {
            FormatAndWrite(LogLevel.Info, correlationId, error, message, args);
        }

        public void Debug(string correlationId, string message, params object[] args)
        {
            FormatAndWrite(LogLevel.Debug, correlationId, null, message, args);
        }

        public void Debug(string correlationId, Exception error, string message = null, params object[] args)
        {
            FormatAndWrite(LogLevel.Debug, correlationId, error, message, args);
        }

        public void Trace(string correlationId, string message, params object[] args)
        {
            FormatAndWrite(LogLevel.Trace, correlationId, null, message, args);
        }

        public void Trace(string correlationId, Exception error, string message = null, params object[] args)
        {
            FormatAndWrite(LogLevel.Trace, correlationId, error, message, args);
        }
    }
}