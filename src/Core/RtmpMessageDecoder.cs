namespace Belly.RtmpServer.Core;

using System;
using System.Buffers;

public class RtmpMessageDecoder
{
    private bool TryParse(ReadOnlySequence<byte> buffer, out SequencePosition consumed)
    {
        consumed = new SequencePosition();
        SequenceReader<byte> sequenceReader = new SequenceReader<byte>(buffer);

        return true;
    }
}