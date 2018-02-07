// This file contains things that were not available in older .Net versions.

#if NET35
namespace System
{
    public delegate void Action<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);
}
#endif
