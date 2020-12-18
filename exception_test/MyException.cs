using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
namespace exception_test
{
    [Serializable]
    public sealed class Exception<TExceptionArgs> : Exception, ISerializable
        where TExceptionArgs : ExceptionArgs
    {
        private const String c_args = "Args";
        private TExceptionArgs m_args; // This is the true data of this exception. Exception is just a wrapper
        public TExceptionArgs Args
        {
            get
            {
                return m_args;
            }
        }
        public Exception(String message = null, Exception inner_exception = null) : this(null, message, inner_exception)
        {
        }
        public Exception(TExceptionArgs args, String message = null, Exception inner_exception = null) : base(message, inner_exception)
        {
            m_args = args;
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)
            ]
        private Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            m_args = (TExceptionArgs)info.GetValue(c_args, typeof(TExceptionArgs));
        }

        // 序列化方法是公共的
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(c_args, context);
            base.GetObjectData(info, context);
        }
        public override string Message
        {
            get
            {
                String baseMsg = base.Message;
                return m_args==null? baseMsg: base.Message + m_args.Message;
            }
        }
        public override bool Equals(object obj)
        {
            Exception<ExceptionArgs> other = obj as Exception<ExceptionArgs>;
            if(other == null)
            {
                return false;
            }
            else
            {
                return Object.Equals(m_args, other.Args) && base.Equals(obj); // if this is not the inheritance obj of base, it can not enter in this statement.
            }
        }
    }

    

    public abstract class ExceptionArgs
    {
        public virtual String Message
        {
            get
            {
                return String.Empty;
            }
        }
    }
}
