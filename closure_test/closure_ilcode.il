.method private static hidebysig
           default void AQuestion ()  cil managed
    {
        // Method begins at RVA 0x2050
	// Code size 86 (0x56)
	.maxstack 2
	.locals init (
		class closure_test.Program/'<>c__DisplayClass0_0'	V_0, // 匿名闭包类型的变量
		class [mscorlib]System.Action	V_1, 
		class [mscorlib]System.Action	V_2, // 两个Action对象
        int32	V_3) // 用于++的临时变量
    // 开始先创建闭包对象，该对象类型亦由CLR负责构建
	IL_0000:  newobj instance void class closure_test.Program/'<>c__DisplayClass0_0'::'.ctor'()
	IL_0005:  stloc.0
	IL_0006:  nop
    //! 初始化外部i...存储外部i到闭包的i，哦！这里根本没有一个局部变量，在代码里是局部变量的i实际上是在CLR给构造的闭包里面的字段i。
	IL_0007:  ldloc.0
	IL_0008:  ldc.i4 2015
	IL_000d:  stfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i //？ 这里存储的到底是指针还是？为什么i可以实现引用？内嵌类就可以？
    //! 调用V_0内部的i实现++
        IL_0012:  ldloc.0
        IL_0013:  ldfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i
        IL_0018:  stloc.3
        IL_0019:  ldloc.0
        IL_001a:  ldloc.3
        IL_001b:  ldc.i4.1
        IL_001c:  add
        IL_001d:  stfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i
    // 构造Action对象
	IL_0012:  ldloc.0
	IL_0013:  ldftn instance void class closure_test.Program/'<>c__DisplayClass0_0'::'<AQuestion>b__0'() // 将指向实现特定方法的本机代码的非托管指针（native int 类型）推送到计算堆栈上。
	IL_0019:  newobj instance void class [mscorlib]System.Action::'.ctor'(object, native int)
    // 存储构造的对象到V_1
	IL_001e:  stloc.1
	IL_001f:  ldloc.1
    // 调用Action中存储的函数
	IL_0020:  callvirt instance void class [mscorlib]System.Action::Invoke()
	IL_0025:  nop
    // 构建Action并存储到第二个Action变量，然后调用函数
	IL_0026:  ldloc.0
	IL_0027:  ldftn instance void class closure_test.Program/'<>c__DisplayClass0_0'::'<AQuestion>b__1'()
	IL_002d:  newobj instance void class [mscorlib]System.Action::'.ctor'(object, native int)
	IL_0032:  stloc.2
	IL_0033:  ldloc.2
	IL_0034:  callvirt instance void class [mscorlib]System.Action::Invoke()
	IL_0039:  nop
    // 
	IL_003a:  ldstr "i3="
	IL_003f:  ldloc.0
	IL_0040:  ldflda int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_0045:  call instance string int32::ToString()
	IL_004a:  call string string::Concat(string, string)
	IL_004f:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0054:  nop
	IL_0055:  ret
    } // end of method Program::AQuestion

    // 嵌套类的实现
    .class nested private auto ansi sealed beforefieldinit '<>c__DisplayClass0_0'
  	extends [System.Runtime]System.Object
  {
    .custom instance void class [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ....

    .field  public  int32 i

    // method line 4
    .method public hidebysig specialname rtspecialname
           instance default void '.ctor' ()  cil managed
    {
        // Method begins at RVA 0x20c6
	// Code size 8 (0x8)
	.maxstack 8
	IL_0000:  ldarg.0
	IL_0001:  call instance void object::'.ctor'()
	IL_0006:  nop
	IL_0007:  ret
    } // end of method <>c__DisplayClass0_0::.ctor

    // method line 5
    .method assembly hidebysig
           instance default void '<AQuestion>b__0' ()  cil managed
    {
        // Method begins at RVA 0x20cf
	// Code size 43 (0x2b)
	.maxstack 8
	IL_0000:  nop
	IL_0001:  ldarg.0
	IL_0002:  ldarg.0
	IL_0003:  ldfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_0008:  ldc.i4.5
	IL_0009:  add
	IL_000a:  stfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_000f:  ldstr "i1="
	IL_0014:  ldarg.0
	IL_0015:  ldflda int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_001a:  call instance string int32::ToString()
	IL_001f:  call string string::Concat(string, string)
	IL_0024:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0029:  nop
	IL_002a:  ret
    } // end of method <>c__DisplayClass0_0::<AQuestion>b__0

    // method line 6
    .method assembly hidebysig
           instance default void '<AQuestion>b__1' ()  cil managed
    {
        // Method begins at RVA 0x20fb
	// Code size 43 (0x2b)
	.maxstack 8
	IL_0000:  nop
	IL_0001:  ldarg.0
	IL_0002:  ldarg.0
	IL_0003:  ldfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_0008:  ldc.i4.1
	IL_0009:  sub
	IL_000a:  stfld int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_000f:  ldstr "i2="
	IL_0014:  ldarg.0
	IL_0015:  ldflda int32 closure_test.Program/'<>c__DisplayClass0_0'::i
	IL_001a:  call instance string int32::ToString()
	IL_001f:  call string string::Concat(string, string)
	IL_0024:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0029:  nop
	IL_002a:  ret
    } // end of method <>c__DisplayClass0_0::<AQuestion>b__1

  } // end of class <>c__DisplayClass0_0