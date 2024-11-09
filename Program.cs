using System.Runtime.InteropServices;
using System.Security;

var result = CreatePod(long.MaxValue);
Console.WriteLine($"Result {result.a} {result.b}");

var result_with_destructor_workaround = CreateNonPod_HackyFix(long.MaxValue);
Console.WriteLine($"Result {result_with_destructor_workaround.a} {result_with_destructor_workaround.b} - with destructor - hacky fix");

var result_with_destructor = CreateNonPod(long.MaxValue);
Console.WriteLine($"Result {result_with_destructor.a} {result_with_destructor.b} - with destructor");

[SuppressUnmanagedCodeSecurity, DllImport("native-lib", EntryPoint = "_Z9CreatePODl", CallingConvention = CallingConvention.Cdecl)]
static extern S16 CreatePod(long b);

[SuppressUnmanagedCodeSecurity, DllImport("native-lib", EntryPoint = "_Z12CreateNonPodl", CallingConvention = CallingConvention.Cdecl)]
static extern S16_Plus1 CreateNonPod_HackyFix(long b);

[SuppressUnmanagedCodeSecurity, DllImport("native-lib", EntryPoint = "_Z12CreateNonPodl", CallingConvention = CallingConvention.Cdecl)]
static extern S16 CreateNonPod(long b);

[StructLayout(LayoutKind.Explicit, Size = 16)]
public partial struct S16
{
  [FieldOffset(0)]
  internal int a;
  [FieldOffset(8)]
  internal long b;
}

[StructLayout(LayoutKind.Explicit, Size = 16 + 1)]
public partial struct S16_Plus1
{
  [FieldOffset(0)]
  internal int a;
  [FieldOffset(8)]
  internal long b;
}
