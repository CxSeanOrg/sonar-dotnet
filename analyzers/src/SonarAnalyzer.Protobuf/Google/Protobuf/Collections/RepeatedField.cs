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

using System.Collections;

namespace Google.Protobuf.Collections;

public class RepeatedField<T> : IList<T>, IReadOnlyList<T>
{
    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int CalculateSize(FieldCodec<T> codec)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedOutputStream output, FieldCodec<T> codec)
    {
        throw new NotImplementedException();
    }

    public void Add(T item) =>
        throw new NotImplementedException();

    public void Add(RepeatedField<T> items) =>
        throw new NotSupportedException();

    public void AddRange(IEnumerable<T> items) =>
        throw new NotImplementedException();

    public void AddEntriesFrom(CodedInputStream stream, FieldCodec<T> codec) =>
        throw new NotSupportedException();

    public RepeatedField<T> Clone() =>
        throw new NotSupportedException();
    public int IndexOf(T item) => throw new NotImplementedException();
    public void Insert(int index, T item) => throw new NotImplementedException();
    public void RemoveAt(int index) => throw new NotImplementedException();
    public void Clear() => throw new NotImplementedException();
    public bool Contains(T item) => throw new NotImplementedException();
    public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();
    public bool Remove(T item) => throw new NotImplementedException();
    public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}
