/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2023 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System.IO;
using System.Text;

namespace Google.Protobuf;

public class CodedOutputStream
{
    private readonly Stream stream;

    public CodedOutputStream(Stream stream) =>
        this.stream = stream;

    public static int ComputeEnumSize(int value) =>
        ComputeInt32Size(value);

    public static int ComputeStringSize(string value)
    {
        var count = Encoding.UTF8.GetByteCount(value);
        return ComputeRawVarint32Size((uint)count) + count;
    }

    public static int ComputeInt32Size(int value) =>
        value >= 0
            ? ComputeRawVarint32Size((uint)value)
            : 10;

    public static int ComputeMessageSize(IMessage message)
    {
        throw new NotImplementedException();
    }

    public void Flush() =>
        stream.Flush();

    public void WriteRawTag(byte value) =>
        stream.WriteByte(value);

    public void WriteBool(bool value) =>
        stream.WriteByte(value ? (byte)1 : (byte)0);

    public void WriteLength(int value) =>
        WriteInt32(value);

    public void WriteInt32(int value)
    {
        if (value >= 0)
        {
            WriteRawVariant32((uint)value);
        }
        else
        {
            WriteRawVariant64((ulong)value);
        }
    }

    public void WriteEnum(int value) =>
        WriteInt32(value);

    public void WriteString(string value)
    {
        byte[] buff = Encoding.UTF8.GetBytes(value);
        WriteLength(buff.Length);
        stream.Write(buff, 0, buff.Length); // ToDo: This is likely slow, we should optimize it with internal buffers
    }

    public void WriteMessage(IMessage message)
    {
        throw new NotImplementedException();
    }

    private static int ComputeRawVarint32Size(uint value)
    {
        var mask = 0xffffffff;
        for (var size = 1; size < 6; size++)
        {
            mask <<= 7;
            if ((value & mask) == 0)
            {
                return size;
            }
        }
        throw new ArgumentOutOfRangeException(nameof(value));
    }

    private void WriteRawVariant32(uint value)
    {
        var buff = SonarAnalyzer.Protobuf.Encoder.ToVariant(value);
        stream.Write(buff, 0, buff.Length);
    }

    private void WriteRawVariant64(ulong value)
    {
        throw new NotImplementedException();
    }
}
