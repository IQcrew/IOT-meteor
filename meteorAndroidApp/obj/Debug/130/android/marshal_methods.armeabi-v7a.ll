; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [176 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 42
	i32 33939330, ; 1: Microsoft.Threading.Tasks => 0x205df82 => 6
	i32 34715100, ; 2: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 60
	i32 39109920, ; 3: Newtonsoft.Json.dll => 0x254c520 => 10
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 51
	i32 117431740, ; 5: System.Runtime.InteropServices => 0x6ffddbc => 85
	i32 120558881, ; 6: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 51
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 29
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 52
	i32 185010651, ; 9: System.Net.Http.Primitives => 0xb0709db => 15
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 27
	i32 220171995, ; 11: System.Diagnostics.Debug => 0xd1f8edb => 82
	i32 230216969, ; 12: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 39
	i32 230752869, ; 13: Microsoft.CSharp.dll => 0xdc10265 => 83
	i32 231814094, ; 14: System.Globalization => 0xdd133ce => 68
	i32 280482487, ; 15: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 37
	i32 318968648, ; 16: Xamarin.AndroidX.Activity.dll => 0x13031348 => 20
	i32 321597661, ; 17: System.Numerics => 0x132b30dd => 16
	i32 342366114, ; 18: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 40
	i32 409659723, ; 19: meteorAndroidApp => 0x186ae94b => 0
	i32 442521989, ; 20: Xamarin.Essentials => 0x1a605985 => 58
	i32 442565967, ; 21: System.Collections => 0x1a61054f => 69
	i32 450948140, ; 22: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 36
	i32 459347974, ; 23: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 74
	i32 465846621, ; 24: mscorlib => 0x1bc4415d => 9
	i32 469710990, ; 25: System.dll => 0x1bff388e => 12
	i32 476646585, ; 26: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 37
	i32 486930444, ; 27: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 46
	i32 498788369, ; 28: System.ObjectModel => 0x1dbae811 => 64
	i32 545304856, ; 29: System.Runtime.Extensions => 0x2080b118 => 78
	i32 627609679, ; 30: Xamarin.AndroidX.CustomView => 0x2568904f => 33
	i32 643868501, ; 31: System.Net => 0x2660a755 => 1
	i32 663517072, ; 32: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 56
	i32 666292255, ; 33: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 24
	i32 690569205, ; 34: System.Xml.Linq.dll => 0x29293ff5 => 73
	i32 809851609, ; 35: System.Drawing.Common.dll => 0x30455ad9 => 62
	i32 843511501, ; 36: Xamarin.AndroidX.Print => 0x3246f6cd => 48
	i32 877678880, ; 37: System.Globalization.dll => 0x34505120 => 68
	i32 928116545, ; 38: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 60
	i32 955402788, ; 39: Newtonsoft.Json => 0x38f24a24 => 10
	i32 967690846, ; 40: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 40
	i32 975874589, ; 41: System.Xml.XDocument => 0x3a2aaa1d => 72
	i32 987214855, ; 42: System.Diagnostics.Tools => 0x3ad7b407 => 3
	i32 992768348, ; 43: System.Collections.dll => 0x3b2c715c => 69
	i32 1012816738, ; 44: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 50
	i32 1035644815, ; 45: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 23
	i32 1044663988, ; 46: System.Linq.Expressions.dll => 0x3e444eb4 => 65
	i32 1052210849, ; 47: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 43
	i32 1098259244, ; 48: System => 0x41761b2c => 12
	i32 1175144683, ; 49: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 54
	i32 1204270330, ; 50: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 24
	i32 1245772053, ; 51: FireSharp.dll => 0x4a40f915 => 4
	i32 1267360935, ; 52: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 55
	i32 1293217323, ; 53: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 35
	i32 1324164729, ; 54: System.Linq => 0x4eed2679 => 80
	i32 1364015309, ; 55: System.IO => 0x514d38cd => 67
	i32 1365406463, ; 56: System.ServiceModel.Internals.dll => 0x516272ff => 76
	i32 1376866003, ; 57: Xamarin.AndroidX.SavedState => 0x52114ed3 => 50
	i32 1406073936, ; 58: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 30
	i32 1453312822, ; 59: System.Diagnostics.Tools.dll => 0x569fcb36 => 3
	i32 1457743152, ; 60: System.Runtime.Extensions.dll => 0x56e36530 => 78
	i32 1469204771, ; 61: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 22
	i32 1543031311, ; 62: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 70
	i32 1550322496, ; 63: System.Reflection.Extensions.dll => 0x5c680b40 => 2
	i32 1582372066, ; 64: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 34
	i32 1592978981, ; 65: System.Runtime.Serialization.dll => 0x5ef2ee25 => 75
	i32 1622152042, ; 66: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 45
	i32 1622358360, ; 67: System.Dynamic.Runtime => 0x60b33958 => 63
	i32 1636350590, ; 68: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 32
	i32 1639515021, ; 69: System.Net.Http.dll => 0x61b9038d => 13
	i32 1639986890, ; 70: System.Text.RegularExpressions => 0x61c036ca => 70
	i32 1657153582, ; 71: System.Runtime => 0x62c6282e => 18
	i32 1658251792, ; 72: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 59
	i32 1677501392, ; 73: System.Net.Primitives.dll => 0x63fca3d0 => 86
	i32 1701541528, ; 74: System.Diagnostics.Debug.dll => 0x656b7698 => 82
	i32 1703690872, ; 75: Microsoft.Threading.Tasks.Extensions.dll => 0x658c4278 => 7
	i32 1726116996, ; 76: System.Reflection.dll => 0x66e27484 => 77
	i32 1729485958, ; 77: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 28
	i32 1765942094, ; 78: System.Reflection.Extensions => 0x6942234e => 2
	i32 1766324549, ; 79: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 52
	i32 1776026572, ; 80: System.Core.dll => 0x69dc03cc => 11
	i32 1788241197, ; 81: Xamarin.AndroidX.Fragment => 0x6a96652d => 36
	i32 1808609942, ; 82: Xamarin.AndroidX.Loader => 0x6bcd3296 => 45
	i32 1813201214, ; 83: Xamarin.Google.Android.Material => 0x6c13413e => 59
	i32 1824175904, ; 84: System.Text.Encoding.Extensions => 0x6cbab720 => 79
	i32 1858542181, ; 85: System.Linq.Expressions => 0x6ec71a65 => 65
	i32 1867746548, ; 86: Xamarin.Essentials.dll => 0x6f538cf4 => 58
	i32 1885316902, ; 87: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 25
	i32 1903513567, ; 88: meteorAndroidApp.dll => 0x71754fdf => 0
	i32 1919157823, ; 89: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 47
	i32 2004783961, ; 90: FireSharp => 0x777e9359 => 4
	i32 2019465201, ; 91: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 43
	i32 2055257422, ; 92: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 41
	i32 2079903147, ; 93: System.Runtime.dll => 0x7bf8cdab => 18
	i32 2090596640, ; 94: System.Numerics.Vectors => 0x7c9bf920 => 17
	i32 2097448633, ; 95: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 38
	i32 2193016926, ; 96: System.ObjectModel.dll => 0x82b6c85e => 64
	i32 2201231467, ; 97: System.Net.Http => 0x8334206b => 13
	i32 2217644978, ; 98: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 54
	i32 2244775296, ; 99: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 46
	i32 2256548716, ; 100: Xamarin.AndroidX.MultiDex => 0x8680336c => 47
	i32 2279755925, ; 101: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 49
	i32 2315684594, ; 102: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 21
	i32 2353062107, ; 103: System.Net.Primitives => 0x8c40e0db => 86
	i32 2368005991, ; 104: System.Xml.ReaderWriter.dll => 0x8d24e767 => 71
	i32 2454642406, ; 105: System.Text.Encoding.dll => 0x924edee6 => 66
	i32 2475788418, ; 106: Java.Interop.dll => 0x93918882 => 5
	i32 2505896520, ; 107: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 42
	i32 2562349572, ; 108: Microsoft.CSharp => 0x98ba5a04 => 83
	i32 2581819634, ; 109: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 55
	i32 2585220780, ; 110: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 79
	i32 2620871830, ; 111: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 32
	i32 2629600743, ; 112: System.Net.Http.Extensions.dll => 0x9cbc85e7 => 14
	i32 2664396074, ; 113: System.Xml.XDocument.dll => 0x9ecf752a => 72
	i32 2693849962, ; 114: System.IO.dll => 0xa090e36a => 67
	i32 2715334215, ; 115: System.Threading.Tasks.dll => 0xa1d8b647 => 61
	i32 2732626843, ; 116: Xamarin.AndroidX.Activity => 0xa2e0939b => 20
	i32 2737747696, ; 117: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 22
	i32 2778768386, ; 118: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 57
	i32 2810250172, ; 119: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 30
	i32 2819470561, ; 120: System.Xml.dll => 0xa80db4e1 => 19
	i32 2853208004, ; 121: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 57
	i32 2855708567, ; 122: Xamarin.AndroidX.Transition => 0xaa36a797 => 53
	i32 2887636118, ; 123: System.Net.dll => 0xac1dd496 => 1
	i32 2900621748, ; 124: System.Dynamic.Runtime.dll => 0xace3f9b4 => 63
	i32 2901442782, ; 125: System.Reflection => 0xacf080de => 77
	i32 2903344695, ; 126: System.ComponentModel.Composition => 0xad0d8637 => 87
	i32 2905242038, ; 127: mscorlib.dll => 0xad2a79b6 => 9
	i32 2919462931, ; 128: System.Numerics.Vectors.dll => 0xae037813 => 17
	i32 2978675010, ; 129: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 35
	i32 3024354802, ; 130: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 39
	i32 3075834255, ; 131: System.Threading.Tasks => 0xb755818f => 61
	i32 3111772706, ; 132: System.Runtime.Serialization => 0xb979e222 => 75
	i32 3202900353, ; 133: Microsoft.Threading.Tasks.Extensions => 0xbee86181 => 7
	i32 3211777861, ; 134: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 34
	i32 3220365878, ; 135: System.Threading => 0xbff2e236 => 81
	i32 3247949154, ; 136: Mono.Security => 0xc197c562 => 84
	i32 3258312781, ; 137: Xamarin.AndroidX.CardView => 0xc235e84d => 28
	i32 3267021929, ; 138: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 26
	i32 3299363146, ; 139: System.Text.Encoding => 0xc4a8494a => 66
	i32 3317135071, ; 140: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 33
	i32 3340431453, ; 141: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 25
	i32 3353484488, ; 142: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 38
	i32 3362522851, ; 143: Xamarin.AndroidX.Core => 0xc86c06e3 => 31
	i32 3366347497, ; 144: Java.Interop => 0xc8a662e9 => 5
	i32 3374999561, ; 145: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 49
	i32 3404865022, ; 146: System.ServiceModel.Internals => 0xcaf21dfe => 76
	i32 3429136800, ; 147: System.Xml => 0xcc6479a0 => 19
	i32 3476120550, ; 148: Mono.Android => 0xcf3163e6 => 8
	i32 3501239056, ; 149: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 26
	i32 3509114376, ; 150: System.Xml.Linq => 0xd128d608 => 73
	i32 3522916314, ; 151: System.Net.Http.Extensions => 0xd1fb6fda => 14
	i32 3567349600, ; 152: System.ComponentModel.Composition.dll => 0xd4a16f60 => 87
	i32 3608519521, ; 153: System.Linq.dll => 0xd715a361 => 80
	i32 3627220390, ; 154: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 48
	i32 3641597786, ; 155: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 41
	i32 3672681054, ; 156: Mono.Android.dll => 0xdae8aa5e => 8
	i32 3682565725, ; 157: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 27
	i32 3689375977, ; 158: System.Drawing.Common => 0xdbe768e9 => 62
	i32 3718780102, ; 159: Xamarin.AndroidX.Annotation => 0xdda814c6 => 21
	i32 3786282454, ; 160: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 29
	i32 3798658073, ; 161: System.Net.Http.Primitives.dll => 0xe26aec19 => 15
	i32 3829621856, ; 162: System.Numerics.dll => 0xe4436460 => 16
	i32 3849253459, ; 163: System.Runtime.InteropServices.dll => 0xe56ef253 => 85
	i32 3885922214, ; 164: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 53
	i32 3896760992, ; 165: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 31
	i32 3921031405, ; 166: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 56
	i32 3928044579, ; 167: System.Xml.ReaderWriter => 0xea213423 => 71
	i32 3955647286, ; 168: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 23
	i32 4073602200, ; 169: System.Threading.dll => 0xf2ce3c98 => 81
	i32 4105002889, ; 170: Mono.Security.dll => 0xf4ad5f89 => 84
	i32 4136602218, ; 171: Microsoft.Threading.Tasks.dll => 0xf68f8a6a => 6
	i32 4151237749, ; 172: System.Core => 0xf76edc75 => 11
	i32 4181436372, ; 173: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 74
	i32 4182413190, ; 174: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 44
	i32 4292120959 ; 175: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 44
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [176 x i32] [
	i32 42, i32 6, i32 60, i32 10, i32 51, i32 85, i32 51, i32 29, ; 0..7
	i32 52, i32 15, i32 27, i32 82, i32 39, i32 83, i32 68, i32 37, ; 8..15
	i32 20, i32 16, i32 40, i32 0, i32 58, i32 69, i32 36, i32 74, ; 16..23
	i32 9, i32 12, i32 37, i32 46, i32 64, i32 78, i32 33, i32 1, ; 24..31
	i32 56, i32 24, i32 73, i32 62, i32 48, i32 68, i32 60, i32 10, ; 32..39
	i32 40, i32 72, i32 3, i32 69, i32 50, i32 23, i32 65, i32 43, ; 40..47
	i32 12, i32 54, i32 24, i32 4, i32 55, i32 35, i32 80, i32 67, ; 48..55
	i32 76, i32 50, i32 30, i32 3, i32 78, i32 22, i32 70, i32 2, ; 56..63
	i32 34, i32 75, i32 45, i32 63, i32 32, i32 13, i32 70, i32 18, ; 64..71
	i32 59, i32 86, i32 82, i32 7, i32 77, i32 28, i32 2, i32 52, ; 72..79
	i32 11, i32 36, i32 45, i32 59, i32 79, i32 65, i32 58, i32 25, ; 80..87
	i32 0, i32 47, i32 4, i32 43, i32 41, i32 18, i32 17, i32 38, ; 88..95
	i32 64, i32 13, i32 54, i32 46, i32 47, i32 49, i32 21, i32 86, ; 96..103
	i32 71, i32 66, i32 5, i32 42, i32 83, i32 55, i32 79, i32 32, ; 104..111
	i32 14, i32 72, i32 67, i32 61, i32 20, i32 22, i32 57, i32 30, ; 112..119
	i32 19, i32 57, i32 53, i32 1, i32 63, i32 77, i32 87, i32 9, ; 120..127
	i32 17, i32 35, i32 39, i32 61, i32 75, i32 7, i32 34, i32 81, ; 128..135
	i32 84, i32 28, i32 26, i32 66, i32 33, i32 25, i32 38, i32 31, ; 136..143
	i32 5, i32 49, i32 76, i32 19, i32 8, i32 26, i32 73, i32 14, ; 144..151
	i32 87, i32 80, i32 48, i32 41, i32 8, i32 27, i32 62, i32 21, ; 152..159
	i32 29, i32 15, i32 16, i32 85, i32 53, i32 31, i32 56, i32 71, ; 160..167
	i32 23, i32 81, i32 84, i32 6, i32 11, i32 74, i32 44, i32 44 ; 176..175
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
