using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Common.Logging
{
    public class LoggerUtils
    {
        private ILog log;

        public string TypeName { get; set; }
        public string MethodName { get; set; }
        public string UserName { get; set; }

        public LoggerUtils(Type type)
        {
            this.TypeName = type.Name;
            log = LogManager.GetLogger(type);
        }

        public LoggerUtils(string name)
        {
            this.TypeName = name;
            log = LogManager.GetLogger(name);
        }

        public bool IsDebugEnabled()
        {
            return log.IsDebugEnabled;
        }

        public bool IsInfoEnabled()
        {
            return log.IsInfoEnabled;
        }

        public void Debug(string methodName, params object[] parameters)
        {
            if (log.IsDebugEnabled)
            {
                methodName = this.GetLogDetail(methodName, parameters);
                this.MethodName = methodName;
                //log.Debug(new StringBuilder().Append(" [").Append(_UserName).Append("] - ").Append(methodName).ToString());
                log.Debug(new StringBuilder().Append(methodName).ToString());
            }
        }

        public void Info(string methodName, params object[] parameters)

        {
            if (log.IsInfoEnabled)
            {
                methodName = this.GetLogDetail(methodName, parameters);
                this.MethodName = methodName;
                //log.Info(new StringBuilder().Append(" [").Append(_UserName).Append("] - ").Append(methodName).ToString());
                log.Info(new StringBuilder().Append(methodName).ToString());
            }
        }

        public void Fatal(string methodName, params object[] parameters)
        {
            if (log.IsFatalEnabled)
            {
                methodName = this.GetLogDetail(methodName, parameters);
                this.MethodName = methodName;
                //log.Fatal(new StringBuilder().Append(" [").Append(_UserName).Append("] - ").Append(methodName).ToString());
                log.Fatal(new StringBuilder().Append(methodName).ToString());
            }
        }

        public void Error(Exception ex)
        {
            if (log.IsErrorEnabled)
            {
                //log.Error(new StringBuilder().Append(" [").Append(_UserName).Append("] - ").ToString(), ex);
                log.Error(ex);
            }
        }

        private string GetLogDetail(string methodName, object[] parameters)
        {
            if (parameters.Length > 0)
            {
                StringBuilder param = new StringBuilder();
                object obj;
                foreach (object o in parameters)
                {
                    if (o != null)
                    {
                        if (Convert.GetTypeCode(o) == TypeCode.Object)
                        {
                            if (o.GetType().GetGenericTypeDefinition() == typeof(List<>))
                            {
                                obj = "list[" + ((IList)o).Count + "]";
                            }
                            else
                            {
                                obj = o;
                            }
                        }
                        else if (Convert.GetTypeCode(o) == TypeCode.DateTime)
                        {
                            obj = ((DateTime)o).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            obj = o;
                        }
                    }
                    else
                    {
                        obj = "null";
                    }

                    if (param.Length == 0)
                    {
                        param.Append("(").Append(CommonUtils.ObjToString(obj));
                        continue;
                    }
                    param.Append(", ").Append(CommonUtils.ObjToString(obj));
                }
                param.Append(")");
                methodName += param.ToString();
            }
            return methodName;
        }
    }
}
