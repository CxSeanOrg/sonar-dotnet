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

using System.Collections.Generic;
using System.Text;
using System;

namespace Google.Protobuf;

public class CodedOutputStream
{
    public static int ComputeEnumSize(int value)
    {
        throw new NotImplementedException();
    }

    public static int ComputeStringSize(string value)
    {
        throw new NotImplementedException();
    }

    public static int ComputeInt32Size(int value)
    {
        throw new NotImplementedException();
    }

    public static int ComputeMessageSize(IMessage message)
    {
        throw new NotImplementedException();
    }

    public void WriteRawTag(byte value)
    {
        throw new NotImplementedException();

    }

    public void WriteBool(bool value)
    {
        throw new NotImplementedException();

    }

    public void WriteInt32(int value)
    {
        throw new NotImplementedException();

        //if (value >= 0)
        //{
        //    WriteRawVarint32((uint)value);
        //}
        //else
        //{
        //    WriteRawVarint64((ulong)value);
        //}
    }

    public void WriteEnum(int value)
    {
        throw new NotImplementedException();

    }

    public void WriteString(string value)
    {
        throw new NotImplementedException();

        //int byteCount = Utf8Encoding.GetByteCount(value);
        //WriteLength(byteCount);
        //if (limit - position >= byteCount)
        //{
        //    if (byteCount == value.Length)
        //    {
        //        for (int i = 0; i < byteCount; i++)
        //        {
        //            buffer[position + i] = (byte)value[i];
        //        }
        //    }
        //    else
        //    {
        //        Utf8Encoding.GetBytes(value, 0, value.Length, buffer, position);
        //    }

        //    position += byteCount;
        //}
        //else
        //{
        //    byte[] bytes = Utf8Encoding.GetBytes(value);
        //    WriteRawBytes(bytes);
        //}
    }

    public void WriteMessage(IMessage message)
    {
        throw new NotImplementedException();
    }
}
