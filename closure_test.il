.assembly extern System.Runtime
{
  .ver 4:2:2:0
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A ) // .?_....:
}
.assembly extern System.Console
{
  .ver 4:1:2:0
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A ) // .?_....:
}
.assembly 'closure_test'
{
  .custom instance void class [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::'.ctor'(int32) =  (01 00 08 00 00 00 00 00 ) // ........

  .custom instance void class [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::'.ctor'() =  (
		01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
		63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01       ) // ceptionThrows.

  .custom instance void class [mscorlib]System.Diagnostics.DebuggableAttribute::'.ctor'(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) =  (01 00 07 01 00 00 00 00 ) // ........

  .custom instance void class [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::'.ctor'(string) =  (
		01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
		65 72 73 69 6F 6E 3D 76 33 2E 31 01 00 54 0E 14   // ersion=v3.1..T..
		46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
		4E 61 6D 65 00                                  ) // Name.

  .custom instance void class [mscorlib]System.Reflection.AssemblyCompanyAttribute::'.ctor'(string) =  (
		01 00 0C 63 6C 6F 73 75 72 65 5F 74 65 73 74 00   // ...closure_test.
		00                                              ) // .

  .custom instance void class [mscorlib]System.Reflection.AssemblyConfigurationAttribute::'.ctor'(string) =  (01 00 05 44 65 62 75 67 00 00 ) // ...Debug..

  .custom instance void class [mscorlib]System.Reflection.AssemblyFileVersionAttribute::'.ctor'(string) =  (01 00 07 31 2E 30 2E 30 2E 30 00 00 ) // ...1.0.0.0..

  .custom instance void class [mscorlib]System.Reflection.AssemblyInformationalVersionAttribute::'.ctor'(string) =  (01 00 05 31 2E 30 2E 30 00 00 ) // ...1.0.0..

  .custom instance void class [mscorlib]System.Reflection.AssemblyProductAttribute::'.ctor'(string) =  (
		01 00 0C 63 6C 6F 73 75 72 65 5F 74 65 73 74 00   // ...closure_test.
		00                                              ) // .

  .custom instance void class [mscorlib]System.Reflection.AssemblyTitleAttribute::'.ctor'(string) =  (
		01 00 0C 63 6C 6F 73 75 72 65 5F 74 65 73 74 00   // ...closure_test.
		00                                              ) // .

  .hash algorithm 0x00008004
  .ver  1:0:0:0
}
.module closure_test.dll // GUID = {B1552B62-6BEA-4183-84FF-E0F59E193832}


.namespace closure_test
{
  .class public auto ansi beforefieldinit InnerClass
  	extends [System.Runtime]System.Object
  {
    .field  public static  int32 m_x

    // method line 1
    .method public hidebysig specialname rtspecialname 
           instance default void '.ctor' ()  cil managed 
    {
        // Method begins at RVA 0x2050
	// Code size 8 (0x8)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  call instance void object::'.ctor'()
	IL_0006:  nop 
	IL_0007:  ret 
    } // end of method InnerClass::.ctor

    // method line 2
    .method private static hidebysig specialname rtspecialname 
           default void '.cctor' ()  cil managed 
    {
        // Method begins at RVA 0x2059
	// Code size 8 (0x8)
	.maxstack 8
	IL_0000:  ldc.i4.s 0x64
	IL_0002:  stsfld int32 closure_test.InnerClass::m_x
	IL_0007:  ret 
    } // end of method InnerClass::.cctor

  .class nested public auto ansi beforefieldinit Inner
  	extends [System.Runtime]System.Object
  {
    .field  public  int32 m_x_ref

    // method line 7
    .method private hidebysig specialname rtspecialname 
           instance default void '.ctor' ()  cil managed 
    {
        // Method begins at RVA 0x20fe
	// Code size 20 (0x14)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  call instance void object::'.ctor'()
	IL_0006:  nop 
	IL_0007:  nop 
	IL_0008:  ldarg.0 
	IL_0009:  ldsfld int32 closure_test.InnerClass::m_x
	IL_000e:  stfld int32 closure_test.InnerClass/Inner::m_x_ref
	IL_0013:  ret 
    } // end of method Inner::.ctor

    // method line 8
    .method private hidebysig 
           instance default void '<interesting>AddOuterVal' ()  cil managed 
    {
        // Method begins at RVA 0x2113
	// Code size 14 (0xe)
	.maxstack 8
	IL_0000:  nop 
	IL_0001:  ldsfld int32 closure_test.InnerClass::m_x
	IL_0006:  ldc.i4.1 
	IL_0007:  add 
	IL_0008:  stsfld int32 closure_test.InnerClass::m_x
	IL_000d:  ret 
    } // end of method Inner::AddOuterVal

  } // end of class Inner

  } // end of class closure_test.InnerClass
}

.namespace closure_test
{
  .class private auto ansi beforefieldinit Program
  	extends [System.Runtime]System.Object
  {

    // method line 3
    .method private static hidebysig 
           default void Display<T> (!!T a)  cil managed 
    {
        // Method begins at RVA 0x2062
	// Code size 21 (0x15)
	.maxstack 8
	IL_0000:  nop 
	IL_0001:  ldarga.s 0
	IL_0003:  constrained. !!0
	IL_0009:  callvirt instance string object::ToString()
	IL_000e:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0013:  nop 
	IL_0014:  ret 
    } // end of method Program::Display

    // method line 4
    .method private static hidebysig 
           default void AQuestion ()  cil managed 
    {
        // Method begins at RVA 0x2078
	// Code size 102 (0x66)
	.maxstack 3
	.locals init (
		class closure_test.Program/'<>c__DisplayClass1_0'	V_0,
		class [mscorlib]System.Action	V_1,
		class [mscorlib]System.Action	V_2,
		int32	V_3)
	IL_0000:  newobj instance void class closure_test.Program/'<>c__DisplayClass1_0'::'.ctor'()
	IL_0005:  stloc.0 
	IL_0006:  nop 
	IL_0007:  ldloc.0 
	IL_0008:  ldc.i4 2015
	IL_000d:  stfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_0012:  ldloc.0 
	IL_0013:  ldfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_0018:  stloc.3 
	IL_0019:  ldloc.0 
	IL_001a:  ldloc.3 
	IL_001b:  ldc.i4.1 
	IL_001c:  add 
	IL_001d:  stfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_0022:  ldloc.0 
	IL_0023:  ldftn instance void class closure_test.Program/'<>c__DisplayClass1_0'::'<AQuestion>b__0'()
	IL_0029:  newobj instance void class [mscorlib]System.Action::'.ctor'(object, native int)
	IL_002e:  stloc.1 
	IL_002f:  ldloc.1 
	IL_0030:  callvirt instance void class [mscorlib]System.Action::Invoke()
	IL_0035:  nop 
	IL_0036:  ldloc.0 
	IL_0037:  ldftn instance void class closure_test.Program/'<>c__DisplayClass1_0'::'<AQuestion>b__1'()
	IL_003d:  newobj instance void class [mscorlib]System.Action::'.ctor'(object, native int)
	IL_0042:  stloc.2 
	IL_0043:  ldloc.2 
	IL_0044:  callvirt instance void class [mscorlib]System.Action::Invoke()
	IL_0049:  nop 
	IL_004a:  ldstr "i3="
	IL_004f:  ldloc.0 
	IL_0050:  ldflda int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_0055:  call instance string int32::ToString()
	IL_005a:  call string string::Concat(string, string)
	IL_005f:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0064:  nop 
	IL_0065:  ret 
    } // end of method Program::AQuestion

    // method line 5
    .method private static hidebysig 
           default void Main (string[] args)  cil managed 
    {
        // Method begins at RVA 0x20ea
	.entrypoint
	// Code size 10 (0xa)
	.maxstack 8
	IL_0000:  nop 
	IL_0001:  call void class closure_test.Program::AQuestion()
	IL_0006:  nop 
	IL_0007:  br.s IL_0009

	IL_0009:  ret 
    } // end of method Program::Main

    // method line 6
    .method public hidebysig specialname rtspecialname 
           instance default void '.ctor' ()  cil managed 
    {
        // Method begins at RVA 0x20f5
	// Code size 8 (0x8)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  call instance void object::'.ctor'()
	IL_0006:  nop 
	IL_0007:  ret 
    } // end of method Program::.ctor

  .class nested private auto ansi sealed beforefieldinit '<>c__DisplayClass1_0'
  	extends [System.Runtime]System.Object
  {
    .custom instance void class [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ....

    .field  public  int32 i

    // method line 9
    .method public hidebysig specialname rtspecialname 
           instance default void '.ctor' ()  cil managed 
    {
        // Method begins at RVA 0x2122
	// Code size 8 (0x8)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  call instance void object::'.ctor'()
	IL_0006:  nop 
	IL_0007:  ret 
    } // end of method <>c__DisplayClass1_0::.ctor

    // method line 10
    .method assembly hidebysig 
           instance default void '<AQuestion>b__0' ()  cil managed 
    {
        // Method begins at RVA 0x212b
	// Code size 43 (0x2b)
	.maxstack 8
	IL_0000:  nop 
	IL_0001:  ldarg.0 
	IL_0002:  ldarg.0 
	IL_0003:  ldfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_0008:  ldc.i4.5 
	IL_0009:  add 
	IL_000a:  stfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_000f:  ldstr "i1="
	IL_0014:  ldarg.0 
	IL_0015:  ldflda int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_001a:  call instance string int32::ToString()
	IL_001f:  call string string::Concat(string, string)
	IL_0024:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0029:  nop 
	IL_002a:  ret 
    } // end of method <>c__DisplayClass1_0::<AQuestion>b__0

    // method line 11
    .method assembly hidebysig 
           instance default void '<AQuestion>b__1' ()  cil managed 
    {
        // Method begins at RVA 0x2157
	// Code size 43 (0x2b)
	.maxstack 8
	IL_0000:  nop 
	IL_0001:  ldarg.0 
	IL_0002:  ldarg.0 
	IL_0003:  ldfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_0008:  ldc.i4.1 
	IL_0009:  sub 
	IL_000a:  stfld int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_000f:  ldstr "i2="
	IL_0014:  ldarg.0 
	IL_0015:  ldflda int32 closure_test.Program/'<>c__DisplayClass1_0'::i
	IL_001a:  call instance string int32::ToString()
	IL_001f:  call string string::Concat(string, string)
	IL_0024:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0029:  nop 
	IL_002a:  ret 
    } // end of method <>c__DisplayClass1_0::<AQuestion>b__1

  } // end of class <>c__DisplayClass1_0

  } // end of class closure_test.Program
}

