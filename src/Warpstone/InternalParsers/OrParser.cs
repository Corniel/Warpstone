﻿namespace Warpstone.InternalParsers
{
    /// <summary>
    /// Parser that first applies the left parser and if it fails applies the right parser.
    /// </summary>
    /// <typeparam name="T">The parse result type of the parsers.</typeparam>
    /// <seealso cref="Warpstone.Parser{T}" />
    internal class OrParser<T> : Parser<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrParser{T}"/> class.
        /// </summary>
        /// <param name="first">The first parser that's tried.</param>
        /// <param name="second">The second parser that's applied if the first one fails.</param>
        internal OrParser(Parser<T> first, Parser<T> second)
        {
            First = first;
            Second = second;
        }

        /// <summary>
        /// Gets the first parser.
        /// </summary>
        internal Parser<T> First { get; }

        /// <summary>
        /// Gets the second parser.
        /// </summary>
        internal Parser<T> Second { get; }

        /// <inheritdoc/>
        internal override ParseResult<T> Parse(string input, int position)
        {
            ParseResult<T> firstResult = First.Parse(input, position);
            if (firstResult.Success)
            {
                return firstResult;
            }

            return Second.Parse(input, position);
        }
    }
}
