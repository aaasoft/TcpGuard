using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TcpGuard.Core
{
    public class EncryptedStream : Stream
    {
        private Stream targetStream;

        public EncryptedStream(Stream targetStream)
        {
            this.targetStream = targetStream;
        }

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {

        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {

        }
    }
}
