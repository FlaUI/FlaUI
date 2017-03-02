using System;
using System.Runtime.Serialization;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class PatternNotSupportedException : NotSupportedException
    {
        private const string DefaultMessage = "The requested pattern is not supported";
        private const string DefaultMessageWithData = "The requested pattern '{0}' is not supported";

        public PatternNotSupportedException() : base(DefaultMessage)
        {
        }

        public PatternNotSupportedException(PatternId pattern) : base(String.Format(DefaultMessageWithData, pattern))
        {
            Pattern = pattern;
        }

        public PatternNotSupportedException(string message, PatternId pattern) : base(message)
        {
            Pattern = pattern;
        }

        public PatternNotSupportedException(PatternId pattern, Exception innerException) : base(String.Format(DefaultMessageWithData, pattern), innerException)
        {
            Pattern = pattern;
        }

        public PatternNotSupportedException(string message, PatternId pattern, Exception innerException) : base(message, innerException)
        {
            Pattern = pattern;
        }

        protected PatternNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Pattern = (PatternId)info.GetValue("Pattern", typeof(PatternId));
        }

        public PatternId Pattern { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            info.AddValue("Pattern", Pattern);
            base.GetObjectData(info, context);
        }
    }
}
