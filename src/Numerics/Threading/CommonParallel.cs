﻿// <copyright file="CommonParallel.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://mathnet.opensourcedotnet.info
// Copyright (c) 2009-2010 Math.NET
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

namespace MathNet.Numerics.Threading
{
    using System;

#if !SILVERLIGHT
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
#endif

    /// <summary>
    /// Used to simplify parallel code, particularly between the .NET 4.0 and Silverlight Code.
    /// </summary>
    internal static class CommonParallel
    {
        /// <summary>
        /// Executes a for loop in which iterations may run in parallel. 
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="body">The body to be invoked for each iteration.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="body"/> argument is null.</exception>
        /// <exception cref="AggregateException">At least one invocation of the body threw an exception.</exception>
        public static void For(int fromInclusive, int toExclusive, Action<int> body)
        {
#if SILVERLIGHT
            Parallel.For(fromInclusive, toExclusive, body);
#else
            if (Control.DisableParallelization || Control.NumberOfParallelWorkerThreads < 2)
            {
                for (var index = fromInclusive; index < toExclusive; index++)
                {
                    body(index);
                }
            }
            else
            {
                Parallel.ForEach(
                    Partitioner.Create(fromInclusive, toExclusive),
                    new ParallelOptions { MaxDegreeOfParallelism = Control.NumberOfParallelWorkerThreads },
                    (range, loopState) =>
                    {
                        for (var i = range.Item1; i < range.Item2; i++)
                        {
                            body(i);
                        }
                    });
            }
#endif
        }

        /// <summary>
        /// Aggregates a function over a loop.
        /// </summary>
        /// <param name="fromInclusive">Starting index of the loop.</param>
        /// <param name="toExclusive">Ending index of the loop</param>
        /// <param name="body">The function to aggregate.</param>
        /// <returns>The sum of the function over the loop.</returns>
        public static double Aggregate(int fromInclusive, int toExclusive, Func<int, double> body)
        {
            var sync = new object();
            var sum = 0.0;

#if SILVERLIGHT
            Parallel.For(
                fromInclusive, 
                toExclusive, 
                () => 0.0, 
                (i, localData) => localData += body(i), 
                localResult =>
                {
                    lock (sync)
                    {
                        sum += localResult;
                    }
                });
#else

            if (Control.DisableParallelization || Control.NumberOfParallelWorkerThreads < 2)
            {
                for (var index = fromInclusive; index < toExclusive; index++)
                {
                    sum += body(index);
                }
            }
            else
            {
                Parallel.ForEach(
                    Partitioner.Create(fromInclusive, toExclusive),
                    new ParallelOptions { MaxDegreeOfParallelism = Control.NumberOfParallelWorkerThreads },
                    () => 0.0,
                    (range, loopState, localData) =>
                    {
                        for (var i = range.Item1; i < range.Item2; i++)
                        {
                            localData += body(i);
                        }

                        return localData;
                    },
                    localResult =>
                    {
                        lock (sync)
                        {
                            sum += localResult;
                        }
                    });
            }
#endif
            return sum;
        }

        /// <summary>
        /// Executes each of the provided actions inside a discrete, asynchronous task. 
        /// </summary>
        /// <param name="actions">An array of actions to execute.</param>
        /// <exception cref="ArgumentException">The actions array contains a null element.</exception>
        /// <exception cref="AggregateException">An action threw an exception.</exception>
        public static void Invoke(params Action[] actions)
        {
            Parallel.Invoke(actions);        
        }
    }
}