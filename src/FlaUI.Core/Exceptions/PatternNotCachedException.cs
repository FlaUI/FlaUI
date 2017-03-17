using System;
using System.Runtime.Serialization;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Exceptions
{
    [Serializable]
    public class PatternNotCachedException : NotCachedException
    {
        private const string DefaultMessage = "The requested pattern is not cached";
        private const string DefaultMessageWithData = "The requested pattern '{0}' is not cached";

        public PatternNotCachedException() : base(DefaultMessage)
        {
        }

        public PatternNotCachedException(PatternId pattern)
            : base(String.Format(DefaultMessageWithData, pattern))
        {
            Pattern = pattern;
        }

        public PatternNotCachedException(string message, PatternId pattern)
            : base(message)
        {
            Pattern = pattern;
        }

        public PatternNotCachedException(PatternId pattern, Exception innerException)
            : base(String.Format(DefaultMessageWithData, pattern), innerException)
        {
            Pattern = pattern;
        }

        public PatternNotCachedException(string message, PatternId pattern, Exception innerException)
            : base(message, innerException)
        {
            Pattern = pattern;
        }

        protected PatternNotCachedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
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
