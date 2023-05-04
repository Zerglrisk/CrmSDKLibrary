using System;

namespace CrmSdkLibrary.Definition.CrmValue
{
    public ref partial struct CrmValueReader
    {
        public bool GetBoolean()
        {
            //ReadOnlySpan<byte> span = HasValueSequence ? ValueSequence.ToArray() : ValueSpan;

            //if (TokenType == JsonTokenType.True)
            //{
            //    Debug.Assert(span.Length == 4);
            //    return true;
            //}
            //else if (TokenType == JsonTokenType.False)
            //{
            //    Debug.Assert(span.Length == 5);
            //    return false;
            //}
            //else
            //{
            //    throw ThrowHelper.GetInvalidOperationException_ExpectedBoolean(TokenType);
            //}
            throw new NotImplementedException();
        }

        public string GetString()
        {
            throw new NotImplementedException();
        }
    }
}
