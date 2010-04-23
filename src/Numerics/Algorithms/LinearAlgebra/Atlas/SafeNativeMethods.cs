﻿// <copyright file="SafeNativeMethods.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://mathnet.opensourcedotnet.info
//
// Copyright (c) 2009 Math.NET
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

/* This file is automatically generated - do not modify it. 
   Change SafeNativeMethods.include instead.
   Last generated on: 4/23/2010 10:04:39 AM
*/

using System.Runtime.InteropServices;
using System.Security;

namespace MathNet.Numerics.Algorithms.LinearAlgebra.Atlas
{
    /// <summary>
    /// P/Invoke methods to the native math libraries.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        /// <summary>
        /// Name of the native DLL.
        /// </summary>
        private const string DllName = "MathNET.Numerics.ATLAS.dll";

        #region BLAS
        
        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void s_axpy(int n, float alpha, float[] x, [In, Out] float[] y);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void d_axpy(int n, double alpha, double[] x, [In, Out] double[] y);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void c_axpy(int n, ref Complex32 alpha, Complex32[] x, [In, Out] Complex32[] y);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void z_axpy(int n, ref Complex alpha, Complex[] x, [In, Out] Complex[] y);
        
        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void s_scale(int n, float alpha, [Out] float[] x);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void d_scale(int n, double alpha, [Out] double[] x);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void c_scale(int n, ref Complex32 alpha, [In, Out] Complex32[] x);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void z_scale(int n, ref Complex alpha, [In, Out] Complex[] x);
        
        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float s_dot_product(int n, float[] x, float[] y);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double d_dot_product(int n, double[] x, double[] y);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Complex32 c_dot_product(int n, Complex32[] x, Complex32[] y);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Complex z_dot_product(int n, Complex[] x, Complex[] y);
        
        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void s_matrix_multiply(Transpose transA, Transpose transB, int m, int n, int k, float alpha, float[] x, float[] y, float beta, [In, Out]float[] c);
        
        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void d_matrix_multiply(Transpose transA, Transpose transB, int m, int n, int k, double alpha, double[] x, double[] y, double beta, [In, Out]double[] c);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void c_matrix_multiply(Transpose transA, Transpose transB, int m, int n, int k, ref Complex32 alpha, Complex32[] x, Complex32[] y, ref Complex32 beta, [In, Out]Complex32[] c);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void z_matrix_multiply(Transpose transA, Transpose transB, int m, int n, int k, ref Complex alpha, Complex[] x, Complex[] y, ref Complex beta, [In, Out]Complex[] c);

        #endregion BLAS
        
		#region LAPACK

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void s_cholesky_factor(int n, [In, Out] float[] a);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void d_cholesky_factor(int n, [In, Out] double[] a);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void c_cholesky_factor(int n, [In, Out] Complex32[] a);

        [DllImport(DllName, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void z_cholesky_factor(int n, [In, Out] Complex[] a);

		#endregion LAPACK


    }
}