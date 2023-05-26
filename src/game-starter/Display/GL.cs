using System;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

#if !OGL_WRAPPER_API_BOTH && !OGL_WRAPPER_API_UNSAFE && !OGL_WRAPPER_API_SAFE
#error You must define one of OGL_WRAPPER_API_BOTH, OGL_WRAPPER_API_UNSAFE, or OGL_WRAPPER_API_SAFE
#endif

#if OGL_P_CORE

#if OGL_V_1_0 || OGL_V_1_1 || OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

using GLenum = System.UInt32;
using GLfloat = System.Single;
using GLint = System.Int32;
using GLsizei = System.Int32;
using GLbitfield = System.UInt32;
using GLdouble = System.Double;
using GLuint = System.UInt32;
using GLboolean = System.Boolean;
using GLubyte = System.Byte;
using System.Numerics;

#endif

#if OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

using GLsizeiptr = System.Int32;
using GLintptr = System.Int32;

#endif

#if OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

using GLshort = System.Int16;
using GLbyte = System.SByte;
using GLushort = System.UInt16;
using GLchar = System.Byte;

#endif

#if OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

#endif

#if OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

using GLuint64 = System.UInt64;
using GLint64 = System.Int64;

#endif

#endif

namespace GameStarter.Display; // TODO: Remove this later

/// <summary>
/// Bindings for OpenGL 4.6, both core and compatibility profiles.
/// Blazing fast, low level, direct access to the OpenGL API for all versions of OpenGL, using the new unmanaged delegates feature in C# 9.0, <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers" />.
/// Also includes a few overloads of many functions to make them a bit more C# friendly (e.g. passing arrays of bytes or floats instead of passing pointers to fixed memory locations). Significant effort has been made to make sure that the overloads are as efficient as possible, in terms of both performance and memory usage.
/// </summary>
[SuppressUnmanagedCodeSecurity]
public unsafe static class GL
{
    /// <summary>
    /// The null pointer, just like in C/C++.
    /// </summary>
    public static readonly void* NULL = (void*)0;

    /// <summary>
    /// Useful helper function for getting the major OpenGL version of the project as defined by the preprocessor.
    /// In cases where no version is defined, a compile time error will be thrown to prevent the project from compiling.
    /// This can be used as input to e.g. GLFW where you need to specify the major and minor version the OpenGL context that you want to create.
    /// </summary>
    public static int GetProjectOpenGLVersionMajor()
    {
        int major = -1;
#if OGL_V_4_6
        major = 4;
#elif OGL_V_4_5
        major = 4;
#elif OGL_V_4_4
        major = 4;
#elif OGL_V_4_3
        major = 4;
#elif OGL_V_4_2
        major = 4;
#elif OGL_V_4_1
        major = 4;
#elif OGL_V_4_0
        major = 4;
#elif OGL_V_3_3
        major = 3;
#elif OGL_V_3_2
        major = 3;
#elif OGL_V_3_1
        major = 3;
#elif OGL_V_3_0
        major = 3;
#elif OGL_V_2_1
        major = 2;
#elif OGL_V_2_0
        major = 2;
#elif OGL_V_1_5
        major = 1;
#elif OGL_V_1_4
        major = 1;
#elif OGL_V_1_3
        major = 1;
#elif OGL_V_1_2
        major = 1;
#elif OGL_V_1_1
        major = 1;
#elif OGL_V_1_0
        major = 1;
#else
#error "OpenGL version not defined"
#endif
        return major;
    }

    /// <summary>
    /// Useful helper function for getting the minor OpenGL version of the project as defined by the preprocessor.
    /// In cases where no version is defined, a compile time error will be thrown to prevent the project from compiling.
    /// This can be used as input to e.g. GLFW where you need to specify the major and minor version the OpenGL context that you want to create.
    /// </summary>
    public static int GetProjectOpenGLVersionMinor()
    {
        int minor = -1;
#if OGL_V_4_6
        minor = 6;
#elif OGL_V_4_5
        minor = 5;
#elif OGL_V_4_4
        minor = 4;
#elif OGL_V_4_3
        minor = 3;
#elif OGL_V_4_2
        minor = 2;
#elif OGL_V_4_1
        minor = 1;
#elif OGL_V_4_0
        minor = 0;
#elif OGL_V_3_3
        minor = 3;
#elif OGL_V_3_2
        minor = 2;
#elif OGL_V_3_1
        minor = 1;
#elif OGL_V_3_0
        minor = 0;
#elif OGL_V_2_1
        minor = 1;
#elif OGL_V_2_0
        minor = 0;
#elif OGL_V_1_5
        minor = 5;
#elif OGL_V_1_4
        minor = 4;
#elif OGL_V_1_3
        minor = 3;
#elif OGL_V_1_2
        minor = 2;
#elif OGL_V_1_1
        minor = 1;
#elif OGL_V_1_0
        minor = 0;
#else
#error "OpenGL version not defined"
#endif
        return minor;
    }

    /// <summary>
    /// Useful helper function for getting the OpenGL profile of the project as defined by the preprocessor.
    /// In cases where no profile is defined, a compile time error will be thrown to prevent the project from compiling.
    /// </summary>
    /// <returns>The string "CORE" or "COMPAT", allowing the developer to further convert this into a proper value for their context creation API.</returns>
    public static string GetProjectOpenGLProfile()
    {
        string profile = "";
#if OGL_P_CORE
        profile = "CORE";
#elif OGL_P_COMPAT
        profile = "COMPAT";
#error "COMPAT profile not supported yet"
#else
#error "OpenGL profile not defined"
#endif
        return profile;
    }

#if OGL_P_CORE

    /// <summary>
    /// Is used as the loading function for OpenGL functions. Typically comes from something like GLFW.
    /// </summary>
    /// <param name="funcName">The name of the function to load.</param>
    /// <returns>A pointer to the function.</returns>
    public delegate IntPtr GetProcAddressHandler(string funcName);

    // OpenGL 1.0

#if OGL_V_1_0 || OGL_V_1_1 || OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_DEPTH_BUFFER_BIT = 0x00000100;
    public const int GL_STENCIL_BUFFER_BIT = 0x00000400;
    public const int GL_COLOR_BUFFER_BIT = 0x00004000;
    public const int GL_FALSE = 0;
    public const int GL_TRUE = 1;
    public const int GL_POINTS = 0x0000;
    public const int GL_LINES = 0x0001;
    public const int GL_LINE_LOOP = 0x0002;
    public const int GL_LINE_STRIP = 0x0003;
    public const int GL_TRIANGLES = 0x0004;
    public const int GL_TRIANGLE_STRIP = 0x0005;
    public const int GL_TRIANGLE_FAN = 0x0006;
    public const int GL_QUADS = 0x0007;
    public const int GL_NEVER = 0x0200;
    public const int GL_LESS = 0x0201;
    public const int GL_EQUAL = 0x0202;
    public const int GL_LEQUAL = 0x0203;
    public const int GL_GREATER = 0x0204;
    public const int GL_NOTEQUAL = 0x0205;
    public const int GL_GEQUAL = 0x0206;
    public const int GL_ALWAYS = 0x0207;
    public const int GL_ZERO = 0;
    public const int GL_ONE = 1;
    public const int GL_SRC_COLOR = 0x0300;
    public const int GL_ONE_MINUS_SRC_COLOR = 0x0301;
    public const int GL_SRC_ALPHA = 0x0302;
    public const int GL_ONE_MINUS_SRC_ALPHA = 0x0303;
    public const int GL_DST_ALPHA = 0x0304;
    public const int GL_ONE_MINUS_DST_ALPHA = 0x0305;
    public const int GL_DST_COLOR = 0x0306;
    public const int GL_ONE_MINUS_DST_COLOR = 0x0307;
    public const int GL_SRC_ALPHA_SATURATE = 0x0308;
    public const int GL_NONE = 0;
    public const int GL_FRONT_LEFT = 0x0400;
    public const int GL_FRONT_RIGHT = 0x0401;
    public const int GL_BACK_LEFT = 0x0402;
    public const int GL_BACK_RIGHT = 0x0403;
    public const int GL_FRONT = 0x0404;
    public const int GL_BACK = 0x0405;
    public const int GL_LEFT = 0x0406;
    public const int GL_RIGHT = 0x0407;
    public const int GL_FRONT_AND_BACK = 0x0408;
    public const int GL_NO_ERROR = 0;
    public const int GL_INVALID_ENUM = 0x0500;
    public const int GL_INVALID_VALUE = 0x0501;
    public const int GL_INVALID_OPERATION = 0x0502;
    public const int GL_OUT_OF_MEMORY = 0x0505;
    public const int GL_CW = 0x0900;
    public const int GL_CCW = 0x0901;
    public const int GL_POINT_SIZE = 0x0B11;
    public const int GL_POINT_SIZE_RANGE = 0x0B12;
    public const int GL_POINT_SIZE_GRANULARITY = 0x0B13;
    public const int GL_LINE_SMOOTH = 0x0B20;
    public const int GL_LINE_WIDTH = 0x0B21;
    public const int GL_LINE_WIDTH_RANGE = 0x0B22;
    public const int GL_LINE_WIDTH_GRANULARITY = 0x0B23;
    public const int GL_POLYGON_MODE = 0x0B40;
    public const int GL_POLYGON_SMOOTH = 0x0B41;
    public const int GL_CULL_FACE = 0x0B44;
    public const int GL_CULL_FACE_MODE = 0x0B45;
    public const int GL_FRONT_FACE = 0x0B46;
    public const int GL_DEPTH_RANGE = 0x0B70;
    public const int GL_DEPTH_TEST = 0x0B71;
    public const int GL_DEPTH_WRITEMASK = 0x0B72;
    public const int GL_DEPTH_CLEAR_VALUE = 0x0B73;
    public const int GL_DEPTH_FUNC = 0x0B74;
    public const int GL_STENCIL_TEST = 0x0B90;
    public const int GL_STENCIL_CLEAR_VALUE = 0x0B91;
    public const int GL_STENCIL_FUNC = 0x0B92;
    public const int GL_STENCIL_VALUE_MASK = 0x0B93;
    public const int GL_STENCIL_FAIL = 0x0B94;
    public const int GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
    public const int GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
    public const int GL_STENCIL_REF = 0x0B97;
    public const int GL_STENCIL_WRITEMASK = 0x0B98;
    public const int GL_VIEWPORT = 0x0BA2;
    public const int GL_DITHER = 0x0BD0;
    public const int GL_BLEND_DST = 0x0BE0;
    public const int GL_BLEND_SRC = 0x0BE1;
    public const int GL_BLEND = 0x0BE2;
    public const int GL_LOGIC_OP_MODE = 0x0BF0;
    public const int GL_DRAW_BUFFER = 0x0C01;
    public const int GL_READ_BUFFER = 0x0C02;
    public const int GL_SCISSOR_BOX = 0x0C10;
    public const int GL_SCISSOR_TEST = 0x0C11;
    public const int GL_COLOR_CLEAR_VALUE = 0x0C22;
    public const int GL_COLOR_WRITEMASK = 0x0C23;
    public const int GL_DOUBLEBUFFER = 0x0C32;
    public const int GL_STEREO = 0x0C33;
    public const int GL_LINE_SMOOTH_HINT = 0x0C52;
    public const int GL_POLYGON_SMOOTH_HINT = 0x0C53;
    public const int GL_UNPACK_SWAP_BYTES = 0x0CF0;
    public const int GL_UNPACK_LSB_FIRST = 0x0CF1;
    public const int GL_UNPACK_ROW_LENGTH = 0x0CF2;
    public const int GL_UNPACK_SKIP_ROWS = 0x0CF3;
    public const int GL_UNPACK_SKIP_PIXELS = 0x0CF4;
    public const int GL_UNPACK_ALIGNMENT = 0x0CF5;
    public const int GL_PACK_SWAP_BYTES = 0x0D00;
    public const int GL_PACK_LSB_FIRST = 0x0D01;
    public const int GL_PACK_ROW_LENGTH = 0x0D02;
    public const int GL_PACK_SKIP_ROWS = 0x0D03;
    public const int GL_PACK_SKIP_PIXELS = 0x0D04;
    public const int GL_PACK_ALIGNMENT = 0x0D05;
    public const int GL_MAX_TEXTURE_SIZE = 0x0D33;
    public const int GL_MAX_VIEWPORT_DIMS = 0x0D3A;
    public const int GL_SUBPIXEL_BITS = 0x0D50;
    public const int GL_TEXTURE_1D = 0x0DE0;
    public const int GL_TEXTURE_2D = 0x0DE1;
    public const int GL_TEXTURE_WIDTH = 0x1000;
    public const int GL_TEXTURE_HEIGHT = 0x1001;
    public const int GL_TEXTURE_BORDER_COLOR = 0x1004;
    public const int GL_DONT_CARE = 0x1100;
    public const int GL_FASTEST = 0x1101;
    public const int GL_NICEST = 0x1102;
    public const int GL_BYTE = 0x1400;
    public const int GL_UNSIGNED_BYTE = 0x1401;
    public const int GL_SHORT = 0x1402;
    public const int GL_UNSIGNED_SHORT = 0x1403;
    public const int GL_INT = 0x1404;
    public const int GL_UNSIGNED_INT = 0x1405;
    public const int GL_FLOAT = 0x1406;
    public const int GL_STACK_OVERFLOW = 0x0503;
    public const int GL_STACK_UNDERFLOW = 0x0504;
    public const int GL_CLEAR = 0x1500;
    public const int GL_AND = 0x1501;
    public const int GL_AND_REVERSE = 0x1502;
    public const int GL_COPY = 0x1503;
    public const int GL_AND_INVERTED = 0x1504;
    public const int GL_NOOP = 0x1505;
    public const int GL_XOR = 0x1506;
    public const int GL_OR = 0x1507;
    public const int GL_NOR = 0x1508;
    public const int GL_EQUIV = 0x1509;
    public const int GL_INVERT = 0x150A;
    public const int GL_OR_REVERSE = 0x150B;
    public const int GL_COPY_INVERTED = 0x150C;
    public const int GL_OR_INVERTED = 0x150D;
    public const int GL_NAND = 0x150E;
    public const int GL_SET = 0x150F;
    public const int GL_TEXTURE = 0x1702;
    public const int GL_COLOR = 0x1800;
    public const int GL_DEPTH = 0x1801;
    public const int GL_STENCIL = 0x1802;
    public const int GL_STENCIL_INDEX = 0x1901;
    public const int GL_DEPTH_COMPONENT = 0x1902;
    public const int GL_RED = 0x1903;
    public const int GL_GREEN = 0x1904;
    public const int GL_BLUE = 0x1905;
    public const int GL_ALPHA = 0x1906;
    public const int GL_RGB = 0x1907;
    public const int GL_RGBA = 0x1908;
    public const int GL_POINT = 0x1B00;
    public const int GL_LINE = 0x1B01;
    public const int GL_FILL = 0x1B02;
    public const int GL_KEEP = 0x1E00;
    public const int GL_REPLACE = 0x1E01;
    public const int GL_INCR = 0x1E02;
    public const int GL_DECR = 0x1E03;
    public const int GL_VENDOR = 0x1F00;
    public const int GL_RENDERER = 0x1F01;
    public const int GL_VERSION = 0x1F02;
    public const int GL_EXTENSIONS = 0x1F03;
    public const int GL_NEAREST = 0x2600;
    public const int GL_LINEAR = 0x2601;
    public const int GL_NEAREST_MIPMAP_NEAREST = 0x2700;
    public const int GL_LINEAR_MIPMAP_NEAREST = 0x2701;
    public const int GL_NEAREST_MIPMAP_LINEAR = 0x2702;
    public const int GL_LINEAR_MIPMAP_LINEAR = 0x2703;
    public const int GL_TEXTURE_MAG_FILTER = 0x2800;
    public const int GL_TEXTURE_MIN_FILTER = 0x2801;
    public const int GL_TEXTURE_WRAP_S = 0x2802;
    public const int GL_TEXTURE_WRAP_T = 0x2803;
    public const int GL_REPEAT = 0x2901;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCULLFACEPROC(GLenum mode);
    private static PFNGLCULLFACEPROC _glCullFace;
    public static void glCullFace(GLenum mode) => _glCullFace(mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRONTFACEPROC(GLenum mode);
    private static PFNGLFRONTFACEPROC _glFrontFace;
    public static void glFrontFace(GLenum mode) => _glFrontFace(mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLHINTPROC(GLenum target, GLenum mode);
    private static PFNGLHINTPROC _glHint;
    public static void glHint(GLenum target, GLenum mode) => _glHint(target, mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLLINEWIDTHPROC(GLfloat width);
    private static PFNGLLINEWIDTHPROC _glLineWidth;
    public static void glLineWidth(GLfloat width) => _glLineWidth(width);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOINTSIZEPROC(GLfloat size);
    private static PFNGLPOINTSIZEPROC _glPointSize;
    public static void glPointSize(GLfloat size) => _glPointSize(size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOLYGONMODEPROC(GLenum face, GLenum mode);
    private static PFNGLPOLYGONMODEPROC _glPolygonMode;
    public static void glPolygonMode(GLenum face, GLenum mode) => _glPolygonMode(face, mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSCISSORPROC(GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLSCISSORPROC _glScissor;
    public static void glScissor(GLint x, GLint y, GLsizei width, GLsizei height) => _glScissor(x, y, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXPARAMETERFPROC(GLenum target, GLenum pname, GLfloat param);
    private static PFNGLTEXPARAMETERFPROC _glTexParameterf;
    public static void glTexParameterf(GLenum target, GLenum pname, GLfloat param) => _glTexParameterf(target, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXPARAMETERFVPROC(GLenum target, GLenum pname, GLfloat* @params);
    private static PFNGLTEXPARAMETERFVPROC _glTexParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexParameterfv(GLenum target, GLenum pname, GLfloat* @params) => _glTexParameterfv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexParameterfv(GLenum target, GLenum pname, GLfloat[] @params) { fixed (GLfloat* p = &@params[0]) _glTexParameterfv(target, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXPARAMETERIPROC(GLenum target, GLenum pname, GLint param);
    private static PFNGLTEXPARAMETERIPROC _glTexParameteri;
    public static void glTexParameteri(GLenum target, GLenum pname, GLint param) => _glTexParameteri(target, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXPARAMETERIVPROC(GLenum target, GLenum pname, GLint* @params);
    private static PFNGLTEXPARAMETERIVPROC _glTexParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexParameteriv(GLenum target, GLenum pname, GLint* @params) => _glTexParameteriv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexParameteriv(GLenum target, GLenum pname, GLint[] @params) { fixed (GLint* p = &@params[0]) _glTexParameteriv(target, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXIMAGE1DPROC(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXIMAGE1DPROC _glTexImage1D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLenum format, GLenum type, void* pixels) => _glTexImage1D(target, level, internalformat, width, border, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexImage1D<T>(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (void* p = &pixels[0]) _glTexImage1D(target, level, internalformat, width, border, format, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXIMAGE2DPROC(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXIMAGE2DPROC _glTexImage2D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, void* pixels) => _glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexImage2D<T>(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (void* p = &pixels[0]) _glTexImage2D(target, level, internalformat, width, height, border, format, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWBUFFERPROC(GLenum buf);
    private static PFNGLDRAWBUFFERPROC _glDrawBuffer;
    public static void glDrawBuffer(GLenum buf) => _glDrawBuffer(buf);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARPROC(GLbitfield mask);
    private static PFNGLCLEARPROC _glClear;
    public static void glClear(GLbitfield mask) => _glClear(mask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARCOLORPROC(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
    private static PFNGLCLEARCOLORPROC _glClearColor;
    public static void glClearColor(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha) => _glClearColor(red, green, blue, alpha);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARSTENCILPROC(GLint s);
    private static PFNGLCLEARSTENCILPROC _glClearStencil;
    public static void glClearStencil(GLint s) => _glClearStencil(s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARDEPTHPROC(GLdouble depth);
    private static PFNGLCLEARDEPTHPROC _glClearDepth;
    public static void glClearDepth(GLdouble depth) => _glClearDepth(depth);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSTENCILMASKPROC(GLuint mask);
    private static PFNGLSTENCILMASKPROC _glStencilMask;
    public static void glStencilMask(GLuint mask) => _glStencilMask(mask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOLORMASKPROC(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
    private static PFNGLCOLORMASKPROC _glColorMask;
    public static void glColorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha) => _glColorMask(red, green, blue, alpha);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEPTHMASKPROC(GLboolean flag);
    private static PFNGLDEPTHMASKPROC _glDepthMask;
    public static void glDepthMask(GLboolean flag) => _glDepthMask(flag);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDISABLEPROC(GLenum cap);
    private static PFNGLDISABLEPROC _glDisable;
    public static void glDisable(GLenum cap) => _glDisable(cap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENABLEPROC(GLenum cap);
    private static PFNGLENABLEPROC _glEnable;
    public static void glEnable(GLenum cap) => _glEnable(cap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFINISHPROC();
    private static PFNGLFINISHPROC _glFinish;
    public static void glFinish() => _glFinish();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFLUSHPROC();
    private static PFNGLFLUSHPROC _glFlush;
    public static void glFlush() => _glFlush();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDFUNCPROC(GLenum sfactor, GLenum dfactor);
    private static PFNGLBLENDFUNCPROC _glBlendFunc;
    public static void glBlendFunc(GLenum sfactor, GLenum dfactor) => _glBlendFunc(sfactor, dfactor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLLOGICOPPROC(GLenum opcode);
    private static PFNGLLOGICOPPROC _glLogicOp;
    public static void glLogicOp(GLenum opcode) => _glLogicOp(opcode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSTENCILFUNCPROC(GLenum func, GLint @ref, GLuint mask);
    private static PFNGLSTENCILFUNCPROC _glStencilFunc;
    public static void glStencilFunc(GLenum func, GLint @ref, GLuint mask) => _glStencilFunc(func, @ref, mask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSTENCILOPPROC(GLenum fail, GLenum zfail, GLenum zpass);
    private static PFNGLSTENCILOPPROC _glStencilOp;
    public static void glStencilOp(GLenum fail, GLenum zfail, GLenum zpass) => _glStencilOp(fail, zfail, zpass);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEPTHFUNCPROC(GLenum func);
    private static PFNGLDEPTHFUNCPROC _glDepthFunc;
    public static void glDepthFunc(GLenum func) => _glDepthFunc(func);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPIXELSTOREFPROC(GLenum pname, GLfloat param);
    private static PFNGLPIXELSTOREFPROC _glPixelStoref;
    public static void glPixelStoref(GLenum pname, GLfloat param) => _glPixelStoref(pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPIXELSTOREIPROC(GLenum pname, GLint param);
    private static PFNGLPIXELSTOREIPROC _glPixelStorei;
    public static void glPixelStorei(GLenum pname, GLint param) => _glPixelStorei(pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLREADBUFFERPROC(GLenum src);
    private static PFNGLREADBUFFERPROC _glReadBuffer;
    public static void glReadBuffer(GLenum src) => _glReadBuffer(src);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLREADPIXELSPROC(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, void* pixels);
    private static PFNGLREADPIXELSPROC _glReadPixels;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, void* pixels) => _glReadPixels(x, y, width, height, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glReadPixels<T>(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, ref T[] pixels) where T : unmanaged { fixed (void* p = &pixels[0]) _glReadPixels(x, y, width, height, format, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETBOOLEANVPROC(GLenum pname, GLboolean* data);
    private static PFNGLGETBOOLEANVPROC _glGetBooleanv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetBooleanv(GLenum pname, GLboolean* data) => _glGetBooleanv(pname, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetBooleanv(GLenum pname, ref GLboolean[] data) { fixed (GLboolean* p = &data[0]) _glGetBooleanv(pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETDOUBLEVPROC(GLenum pname, GLdouble* data);
    private static PFNGLGETDOUBLEVPROC _glGetDoublev;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetDoublev(GLenum pname, GLdouble* data) => _glGetDoublev(pname, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetDoublev(GLenum pname, ref GLdouble[] data) { fixed (GLdouble* p = &data[0]) _glGetDoublev(pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLenum PFNGLGETERRORPROC();
    private static PFNGLGETERRORPROC _glGetError;
    public static GLenum glGetError() => _glGetError();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETFLOATVPROC(GLenum pname, GLfloat* data);
    private static PFNGLGETFLOATVPROC _glGetFloatv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetFloatv(GLenum pname, GLfloat* data) => _glGetFloatv(pname, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetFloatv(GLenum pname, ref GLfloat[] data) { fixed (GLfloat* p = &data[0]) _glGetFloatv(pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETINTEGERVPROC(GLenum pname, GLint* data);
    private static PFNGLGETINTEGERVPROC _glGetIntegerv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetIntegerv(GLenum pname, GLint* data) => _glGetIntegerv(pname, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetIntegerv(GLenum pname, ref GLint[] data) { fixed (GLint* p = &data[0]) _glGetIntegerv(pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLubyte* PFNGLGETSTRINGPROC(GLenum name);
    private static PFNGLGETSTRINGPROC _glGetString;
#if OGL_WRAPPER_API_UNSAFE || OGL_WRAPPER_API_BOTH
    public static GLubyte* glGetString(GLenum name) => _glGetString(name);
#endif
#if OGL_WRAPPER_API_SAFE || OGL_WRAPPER_API_BOTH
    public static string glGetStringSafe(GLenum name)
    {
        GLubyte* p = _glGetString(name);
        if (p == null) return null;
        int i = 0;
        while (p[i] != 0) i++;
        return new string((sbyte*)p, 0, i, Encoding.UTF8);
    }
#endif


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXIMAGEPROC(GLenum target, GLint level, GLenum format, GLenum type, void* pixels);
    private static PFNGLGETTEXIMAGEPROC _glGetTexImage;
#if OGL_WRAPPER_API_UNSAFE || OGL_WRAPPER_API_BOTH
    public static void glGetTexImage(GLenum target, GLint level, GLenum format, GLenum type, void* pixels) => _glGetTexImage(target, level, format, type, pixels);
#endif
#if OGL_WRAPPER_API_SAFE || OGL_WRAPPER_API_BOTH
    public static void glGetTexImage<T>(GLenum target, GLint level, GLenum format, GLenum type, ref T[] pixels) where T : unmanaged { fixed (void* p = &pixels[0]) _glGetTexImage(target, level, format, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXPARAMETERFVPROC(GLenum target, GLenum pname, GLfloat* @params);
    private static PFNGLGETTEXPARAMETERFVPROC _glGetTexParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTexParameterfv(GLenum target, GLenum pname, GLfloat* @params) => _glGetTexParameterfv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTexParameterfv(GLenum target, GLenum pname, ref GLfloat[] @params) { fixed (GLfloat* p = &@params[0]) _glGetTexParameterfv(target, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXPARAMETERIVPROC(GLenum target, GLenum pname, GLint* @params);
    private static PFNGLGETTEXPARAMETERIVPROC _glGetTexParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTexParameteriv(GLenum target, GLenum pname, GLint* @params) => _glGetTexParameteriv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTexParameteriv(GLenum target, GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) _glGetTexParameteriv(target, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXLEVELPARAMETERFVPROC(GLenum target, GLint level, GLenum pname, GLfloat* @params);
    private static PFNGLGETTEXLEVELPARAMETERFVPROC _glGetTexLevelParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, GLfloat* @params) => _glGetTexLevelParameterfv(target, level, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, ref GLfloat[] @params) { fixed (GLfloat* p = &@params[0]) _glGetTexLevelParameterfv(target, level, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXLEVELPARAMETERIVPROC(GLenum target, GLint level, GLenum pname, GLint* @params);
    private static PFNGLGETTEXLEVELPARAMETERIVPROC _glGetTexLevelParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, GLint* @params) => _glGetTexLevelParameteriv(target, level, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) _glGetTexLevelParameteriv(target, level, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISENABLEDPROC(GLenum cap);
    private static PFNGLISENABLEDPROC _glIsEnabled;
    public static GLboolean glIsEnabled(GLenum cap) => _glIsEnabled(cap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEPTHRANGEPROC(GLdouble near, GLdouble far);
    private static PFNGLDEPTHRANGEPROC _glDepthRange;
    public static void glDepthRange(GLdouble near, GLdouble far) => _glDepthRange(near, far);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVIEWPORTPROC(GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLVIEWPORTPROC _glViewport;
    public static void glViewport(GLint x, GLint y, GLsizei width, GLsizei height) => _glViewport(x, y, width, height);

#endif

    // OpenGL 1.1

#if OGL_V_1_1 || OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_COLOR_LOGIC_OP = 0x0BF2;
    public const int GL_POLYGON_OFFSET_UNITS = 0x2A00;
    public const int GL_POLYGON_OFFSET_POINT = 0x2A01;
    public const int GL_POLYGON_OFFSET_LINE = 0x2A02;
    public const int GL_POLYGON_OFFSET_FILL = 0x8037;
    public const int GL_POLYGON_OFFSET_FACTOR = 0x8038;
    public const int GL_TEXTURE_BINDING_1D = 0x8068;
    public const int GL_TEXTURE_BINDING_2D = 0x8069;
    public const int GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
    public const int GL_TEXTURE_RED_SIZE = 0x805C;
    public const int GL_TEXTURE_GREEN_SIZE = 0x805D;
    public const int GL_TEXTURE_BLUE_SIZE = 0x805E;
    public const int GL_TEXTURE_ALPHA_SIZE = 0x805F;
    public const int GL_DOUBLE = 0x140A;
    public const int GL_PROXY_TEXTURE_1D = 0x8063;
    public const int GL_PROXY_TEXTURE_2D = 0x8064;
    public const int GL_R3_G3_B2 = 0x2A10;
    public const int GL_RGB4 = 0x804F;
    public const int GL_RGB5 = 0x8050;
    public const int GL_RGB8 = 0x8051;
    public const int GL_RGB10 = 0x8052;
    public const int GL_RGB12 = 0x8053;
    public const int GL_RGB16 = 0x8054;
    public const int GL_RGBA2 = 0x8055;
    public const int GL_RGBA4 = 0x8056;
    public const int GL_RGB5_A1 = 0x8057;
    public const int GL_RGBA8 = 0x8058;
    public const int GL_RGB10_A2 = 0x8059;
    public const int GL_RGBA12 = 0x805A;
    public const int GL_RGBA16 = 0x805B;
    public const int GL_VERTEX_ARRAY = 0x8074;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWARRAYSPROC(GLenum mode, GLint first, GLsizei count);
    private static PFNGLDRAWARRAYSPROC _glDrawArrays;
    public static void glDrawArrays(GLenum mode, GLint first, GLsizei count) => _glDrawArrays(mode, first, count);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSPROC(GLenum mode, GLsizei count, GLenum type, void* indices);
    private static PFNGLDRAWELEMENTSPROC _glDrawElements;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElements(GLenum mode, GLsizei count, GLenum type, void* indices) => _glDrawElements(mode, count, type, indices);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElements<T>(GLenum mode, GLsizei count, GLenum type, T[] indices) where T : unmanaged, IUnsignedNumber<T> { fixed (void* p = &indices[0]) _glDrawElements(mode, count, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPOINTERVPROC(GLenum pname, void** @params);
    private static PFNGLGETPOINTERVPROC _glGetPointerv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetPointerv(GLenum pname, void** @params) => _glGetPointerv(pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetPointerv(GLenum pname, ref IntPtr[] @params)
    {
        void* ptr = @params[0].ToPointer();
        void** p = &ptr;
        _glGetPointerv(pname, p);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOLYGONOFFSETPROC(GLfloat factor, GLfloat units);
    private static PFNGLPOLYGONOFFSETPROC _glPolygonOffset;
    public static void glPolygonOffset(GLfloat factor, GLfloat units) => _glPolygonOffset(factor, units);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXIMAGE1DPROC(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);
    private static PFNGLCOPYTEXIMAGE1DPROC _glCopyTexImage1D;
    public static void glCopyTexImage1D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border) => _glCopyTexImage1D(target, level, internalformat, x, y, width, border);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXIMAGE2DPROC(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);
    private static PFNGLCOPYTEXIMAGE2DPROC _glCopyTexImage2D;
    public static void glCopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border) => _glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXSUBIMAGE1DPROC(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
    private static PFNGLCOPYTEXSUBIMAGE1DPROC _glCopyTexSubImage1D;
    public static void glCopyTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width) => _glCopyTexSubImage1D(target, level, xoffset, x, y, width);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXSUBIMAGE2DPROC(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLCOPYTEXSUBIMAGE2DPROC _glCopyTexSubImage2D;
    public static void glCopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height) => _glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSUBIMAGE1DPROC(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXSUBIMAGE1DPROC _glTexSubImage1D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, void* pixels) => _glTexSubImage1D(target, level, xoffset, width, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexSubImage1D<T>(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (void* p = &pixels[0]) _glTexSubImage1D(target, level, xoffset, width, format, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSUBIMAGE2DPROC(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXSUBIMAGE2DPROC _glTexSubImage2D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, void* pixels) => _glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexSubImage2D<T>(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (void* p = &pixels[0]) _glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDTEXTUREPROC(GLenum target, GLuint texture);
    private static PFNGLBINDTEXTUREPROC _glBindTexture;
    public static void glBindTexture(GLenum target, GLuint texture) => _glBindTexture(target, texture);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETETEXTURESPROC(GLsizei n, GLuint* textures);
    private static PFNGLDELETETEXTURESPROC _glDeleteTextures;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteTextures(GLsizei n, GLuint* textures) => _glDeleteTextures(n, textures);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteTextures(params GLuint[] textures) { fixed (void* p = &textures[0]) _glDeleteTextures(textures.Length, (GLuint*)p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENTEXTURESPROC(GLsizei n, GLuint* textures);
    private static PFNGLGENTEXTURESPROC _glGenTextures;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenTextures(GLsizei n, GLuint* textures) => _glGenTextures(n, textures);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenTextures(GLsizei n) { GLuint[] textures = new GLuint[n]; fixed (void* p = &textures[0]) _glGenTextures(n, (GLuint*)p); return textures; }
    public static GLuint glGenTexture() => glGenTextures(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISTEXTUREPROC(GLuint texture);
    private static PFNGLISTEXTUREPROC _glIsTexture;
    public static GLboolean glIsTexture(GLuint texture) => _glIsTexture(texture);

#endif

    // OpenGL 1.2

#if OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_UNSIGNED_BYTE_3_3_2 = 0x8032;
    public const int GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
    public const int GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;
    public const int GL_UNSIGNED_INT_8_8_8_8 = 0x8035;
    public const int GL_UNSIGNED_INT_10_10_10_2 = 0x8036;
    public const int GL_TEXTURE_BINDING_3D = 0x806A;
    public const int GL_PACK_SKIP_IMAGES = 0x806B;
    public const int GL_PACK_IMAGE_HEIGHT = 0x806C;
    public const int GL_UNPACK_SKIP_IMAGES = 0x806D;
    public const int GL_UNPACK_IMAGE_HEIGHT = 0x806E;
    public const int GL_TEXTURE_3D = 0x806F;
    public const int GL_PROXY_TEXTURE_3D = 0x8070;
    public const int GL_TEXTURE_DEPTH = 0x8071;
    public const int GL_TEXTURE_WRAP_R = 0x8072;
    public const int GL_MAX_3D_TEXTURE_SIZE = 0x8073;
    public const int GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;
    public const int GL_UNSIGNED_SHORT_5_6_5 = 0x8363;
    public const int GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;
    public const int GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
    public const int GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
    public const int GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;
    public const int GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;
    public const int GL_BGR = 0x80E0;
    public const int GL_BGRA = 0x80E1;
    public const int GL_MAX_ELEMENTS_VERTICES = 0x80E8;
    public const int GL_MAX_ELEMENTS_INDICES = 0x80E9;
    public const int GL_CLAMP_TO_EDGE = 0x812F;
    public const int GL_TEXTURE_MIN_LOD = 0x813A;
    public const int GL_TEXTURE_MAX_LOD = 0x813B;
    public const int GL_TEXTURE_BASE_LEVEL = 0x813C;
    public const int GL_TEXTURE_MAX_LEVEL = 0x813D;
    public const int GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;
    public const int GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
    public const int GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
    public const int GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
    public const int GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWRANGEELEMENTSPROC(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, void* indices);
    private static PFNGLDRAWRANGEELEMENTSPROC _glDrawRangeElements;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawRangeElements(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, void* indices) => _glDrawRangeElements(mode, start, end, count, type, indices);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawRangeElements<T>(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, T[] indices) where T : unmanaged, IUnsignedNumber<T> { fixed (T* p_indices = &indices[0]) { _glDrawRangeElements(mode, start, end, count, type, p_indices); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXIMAGE3DPROC(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXIMAGE3DPROC _glTexImage3D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexImage3D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, void* pixels) => _glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexImage3D<T>(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (T* p_pixels = &pixels[0]) { _glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, p_pixels); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSUBIMAGE3DPROC(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXSUBIMAGE3DPROC _glTexSubImage3D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* pixels) => _glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexSubImage3D<T>(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (T* p_pixels = &pixels[0]) { _glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, p_pixels); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXSUBIMAGE3DPROC(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLCOPYTEXSUBIMAGE3DPROC _glCopyTexSubImage3D;
    public static void glCopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height) => _glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);

#endif

    // OpenGL 1.3

#if OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_TEXTURE0 = 0x84C0;
    public const int GL_TEXTURE1 = 0x84C1;
    public const int GL_TEXTURE2 = 0x84C2;
    public const int GL_TEXTURE3 = 0x84C3;
    public const int GL_TEXTURE4 = 0x84C4;
    public const int GL_TEXTURE5 = 0x84C5;
    public const int GL_TEXTURE6 = 0x84C6;
    public const int GL_TEXTURE7 = 0x84C7;
    public const int GL_TEXTURE8 = 0x84C8;
    public const int GL_TEXTURE9 = 0x84C9;
    public const int GL_TEXTURE10 = 0x84CA;
    public const int GL_TEXTURE11 = 0x84CB;
    public const int GL_TEXTURE12 = 0x84CC;
    public const int GL_TEXTURE13 = 0x84CD;
    public const int GL_TEXTURE14 = 0x84CE;
    public const int GL_TEXTURE15 = 0x84CF;
    public const int GL_TEXTURE16 = 0x84D0;
    public const int GL_TEXTURE17 = 0x84D1;
    public const int GL_TEXTURE18 = 0x84D2;
    public const int GL_TEXTURE19 = 0x84D3;
    public const int GL_TEXTURE20 = 0x84D4;
    public const int GL_TEXTURE21 = 0x84D5;
    public const int GL_TEXTURE22 = 0x84D6;
    public const int GL_TEXTURE23 = 0x84D7;
    public const int GL_TEXTURE24 = 0x84D8;
    public const int GL_TEXTURE25 = 0x84D9;
    public const int GL_TEXTURE26 = 0x84DA;
    public const int GL_TEXTURE27 = 0x84DB;
    public const int GL_TEXTURE28 = 0x84DC;
    public const int GL_TEXTURE29 = 0x84DD;
    public const int GL_TEXTURE30 = 0x84DE;
    public const int GL_TEXTURE31 = 0x84DF;
    public const int GL_ACTIVE_TEXTURE = 0x84E0;
    public const int GL_MULTISAMPLE = 0x809D;
    public const int GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
    public const int GL_SAMPLE_ALPHA_TO_ONE = 0x809F;
    public const int GL_SAMPLE_COVERAGE = 0x80A0;
    public const int GL_SAMPLE_BUFFERS = 0x80A8;
    public const int GL_SAMPLES = 0x80A9;
    public const int GL_SAMPLE_COVERAGE_VALUE = 0x80AA;
    public const int GL_SAMPLE_COVERAGE_INVERT = 0x80AB;
    public const int GL_TEXTURE_CUBE_MAP = 0x8513;
    public const int GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;
    public const int GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
    public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
    public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
    public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
    public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
    public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
    public const int GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;
    public const int GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
    public const int GL_COMPRESSED_RGB = 0x84ED;
    public const int GL_COMPRESSED_RGBA = 0x84EE;
    public const int GL_TEXTURE_COMPRESSION_HINT = 0x84EF;
    public const int GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
    public const int GL_TEXTURE_COMPRESSED = 0x86A1;
    public const int GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
    public const int GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;
    public const int GL_CLAMP_TO_BORDER = 0x812D;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLACTIVETEXTUREPROC(GLenum texture);
    private static PFNGLACTIVETEXTUREPROC _glActiveTexture;
    public static void glActiveTexture(GLenum texture) => _glActiveTexture(texture);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLECOVERAGEPROC(GLfloat value, GLboolean invert);
    private static PFNGLSAMPLECOVERAGEPROC _glSampleCoverage;
    public static void glSampleCoverage(GLfloat value, GLboolean invert) => _glSampleCoverage(value, invert);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXIMAGE3DPROC(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXIMAGE3DPROC _glCompressedTexImage3D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, void* data) => _glCompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, byte[] data) { fixed (byte* p = &data[0]) { _glCompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXIMAGE2DPROC(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXIMAGE2DPROC _glCompressedTexImage2D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, void* data) => _glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, byte[] data) { fixed (byte* p = &data[0]) { _glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXIMAGE1DPROC(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXIMAGE1DPROC _glCompressedTexImage1D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, void* data) => _glCompressedTexImage1D(target, level, internalformat, width, border, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, byte[] data) { fixed (byte* p = &data[0]) { _glCompressedTexImage1D(target, level, internalformat, width, border, imageSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC _glCompressedTexSubImage3D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, void* data) => _glCompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, byte[] data) { fixed (byte* p = &data[0]) { _glCompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC _glCompressedTexSubImage2D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, void* data) => _glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, byte[] data) { fixed (byte* p = &data[0]) { _glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC _glCompressedTexSubImage1D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, void* data) => _glCompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, byte[] data) { fixed (byte* p = &data[0]) { _glCompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETCOMPRESSEDTEXIMAGEPROC(GLenum target, GLint level, void* img);
    private static PFNGLGETCOMPRESSEDTEXIMAGEPROC _glGetCompressedTexImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetCompressedTexImage(GLenum target, GLint level, void* img) => _glGetCompressedTexImage(target, level, img);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetCompressedTexImage(GLenum target, GLint level, ref byte[] img) { fixed (byte* p = &img[0]) { _glGetCompressedTexImage(target, level, p); } }
#endif

#endif

    // OpenGL 1.4

#if OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_BLEND_DST_RGB = 0x80C8;
    public const int GL_BLEND_SRC_RGB = 0x80C9;
    public const int GL_BLEND_DST_ALPHA = 0x80CA;
    public const int GL_BLEND_SRC_ALPHA = 0x80CB;
    public const int GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
    public const int GL_DEPTH_COMPONENT16 = 0x81A5;
    public const int GL_DEPTH_COMPONENT24 = 0x81A6;
    public const int GL_DEPTH_COMPONENT32 = 0x81A7;
    public const int GL_MIRRORED_REPEAT = 0x8370;
    public const int GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
    public const int GL_TEXTURE_LOD_BIAS = 0x8501;
    public const int GL_INCR_WRAP = 0x8507;
    public const int GL_DECR_WRAP = 0x8508;
    public const int GL_TEXTURE_DEPTH_SIZE = 0x884A;
    public const int GL_TEXTURE_COMPARE_MODE = 0x884C;
    public const int GL_TEXTURE_COMPARE_FUNC = 0x884D;
    public const int GL_BLEND_COLOR = 0x8005;
    public const int GL_BLEND_EQUATION = 0x8009;
    public const int GL_CONSTANT_COLOR = 0x8001;
    public const int GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
    public const int GL_CONSTANT_ALPHA = 0x8003;
    public const int GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;
    public const int GL_FUNC_ADD = 0x8006;
    public const int GL_FUNC_REVERSE_SUBTRACT = 0x800B;
    public const int GL_FUNC_SUBTRACT = 0x800A;
    public const int GL_MIN = 0x8007;
    public const int GL_MAX = 0x8008;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDFUNCSEPARATEPROC(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);
    private static PFNGLBLENDFUNCSEPARATEPROC _glBlendFuncSeparate;
    public static void glBlendFuncSeparate(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha) => _glBlendFuncSeparate(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWARRAYSPROC(GLenum mode, GLint* first, GLsizei* count, GLsizei drawcount);
    private static PFNGLMULTIDRAWARRAYSPROC _glMultiDrawArrays;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawArrays(GLenum mode, GLint* first, GLsizei* count, GLsizei drawcount) => _glMultiDrawArrays(mode, first, count, drawcount);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawArrays(GLenum mode, GLint[] first, GLsizei[] count, GLsizei drawcount)
    {
        fixed (GLint* p1 = &first[0])
        fixed (GLsizei* p2 = &count[0])
        {
            _glMultiDrawArrays(mode, p1, p2, drawcount);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWELEMENTSPROC(GLenum mode, GLsizei* count, GLenum type, void** indices, GLsizei drawcount);
    private static PFNGLMULTIDRAWELEMENTSPROC _glMultiDrawElements;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawElements(GLenum mode, GLsizei* count, GLenum type, void** indices, GLsizei drawcount) => _glMultiDrawElements(mode, count, type, indices, drawcount);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawElements<T>(GLenum mode, GLsizei[] count, GLenum type, T[][] indices) where T : unmanaged, IUnsignedNumber<T>
    {
        void*[] indexPtrs = new void*[indices.Length];
        for (int i = 0; i < indices.Length; i++)
        {
            fixed (void* p = &indices[i][0])
            {
                indexPtrs[i] = p;
            }
        }

        fixed (GLsizei* c = &count[0])
        fixed (void** p = &indexPtrs[0])
        {
            _glMultiDrawElements(mode, c, type, p, count.Length);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOINTPARAMETERFPROC(GLenum pname, GLfloat param);
    private static PFNGLPOINTPARAMETERFPROC _glPointParameterf;
    public static void glPointParameterf(GLenum pname, GLfloat param) => _glPointParameterf(pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOINTPARAMETERFVPROC(GLenum pname, GLfloat* @params);
    private static PFNGLPOINTPARAMETERFVPROC _glPointParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glPointParameterfv(GLenum pname, GLfloat* @params) => _glPointParameterfv(pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glPointParameterfv(GLenum pname, ref GLfloat[] @params) { fixed (GLfloat* p = &@params[0]) { _glPointParameterfv(pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOINTPARAMETERIPROC(GLenum pname, GLint param);
    private static PFNGLPOINTPARAMETERIPROC _glPointParameteri;
    public static void glPointParameteri(GLenum pname, GLint param) => _glPointParameteri(pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOINTPARAMETERIVPROC(GLenum pname, GLint* @params);
    private static PFNGLPOINTPARAMETERIVPROC _glPointParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glPointParameteriv(GLenum pname, GLint* @params) => _glPointParameteriv(pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glPointParameteriv(GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) { _glPointParameteriv(pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDCOLORPROC(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
    private static PFNGLBLENDCOLORPROC _glBlendColor;
    public static void glBlendColor(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha) => _glBlendColor(red, green, blue, alpha);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDEQUATIONPROC(GLenum mode);
    private static PFNGLBLENDEQUATIONPROC _glBlendEquation;
    public static void glBlendEquation(GLenum mode) => _glBlendEquation(mode);

#endif

    // OpenGL 1.5

#if OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_BUFFER_SIZE = 0x8764;
    public const int GL_BUFFER_USAGE = 0x8765;
    public const int GL_QUERY_COUNTER_BITS = 0x8864;
    public const int GL_CURRENT_QUERY = 0x8865;
    public const int GL_QUERY_RESULT = 0x8866;
    public const int GL_QUERY_RESULT_AVAILABLE = 0x8867;
    public const int GL_ARRAY_BUFFER = 0x8892;
    public const int GL_ELEMENT_ARRAY_BUFFER = 0x8893;
    public const int GL_ARRAY_BUFFER_BINDING = 0x8894;
    public const int GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
    public const int GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
    public const int GL_READ_ONLY = 0x88B8;
    public const int GL_WRITE_ONLY = 0x88B9;
    public const int GL_READ_WRITE = 0x88BA;
    public const int GL_BUFFER_ACCESS = 0x88BB;
    public const int GL_BUFFER_MAPPED = 0x88BC;
    public const int GL_BUFFER_MAP_POINTER = 0x88BD;
    public const int GL_STREAM_DRAW = 0x88E0;
    public const int GL_STREAM_READ = 0x88E1;
    public const int GL_STREAM_COPY = 0x88E2;
    public const int GL_STATIC_DRAW = 0x88E4;
    public const int GL_STATIC_READ = 0x88E5;
    public const int GL_STATIC_COPY = 0x88E6;
    public const int GL_DYNAMIC_DRAW = 0x88E8;
    public const int GL_DYNAMIC_READ = 0x88E9;
    public const int GL_DYNAMIC_COPY = 0x88EA;
    public const int GL_SAMPLES_PASSED = 0x8914;
    public const int GL_SRC1_ALPHA = 0x8589;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENQUERIESPROC(GLsizei n, GLuint* ids);
    private static PFNGLGENQUERIESPROC _glGenQueries;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenQueries(GLsizei n, GLuint* ids) => _glGenQueries(n, ids);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenQueries(GLsizei n) { GLuint[] ret = new GLuint[n]; fixed (GLuint* p = &ret[0]) { _glGenQueries(n, p); } return ret; }
    public static GLuint glGenQuery() => glGenQueries(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETEQUERIESPROC(GLsizei n, GLuint* ids);
    private static PFNGLDELETEQUERIESPROC _glDeleteQueries;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteQueries(GLsizei n, GLuint* ids) => _glDeleteQueries(n, ids);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteQueries(params GLuint[] ids) { fixed (GLuint* p = &ids[0]) { _glDeleteQueries(ids.Length, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISQUERYPROC(GLuint id);
    private static PFNGLISQUERYPROC _glIsQuery;
    public static GLboolean glIsQuery(GLuint id) => _glIsQuery(id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBEGINQUERYPROC(GLenum target, GLuint id);
    private static PFNGLBEGINQUERYPROC _glBeginQuery;
    public static void glBeginQuery(GLenum target, GLuint id) => _glBeginQuery(target, id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENDQUERYPROC(GLenum target);
    private static PFNGLENDQUERYPROC _glEndQuery;
    public static void glEndQuery(GLenum target) => _glEndQuery(target);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYIVPROC(GLenum target, GLenum pname, GLint* @params);
    private static PFNGLGETQUERYIVPROC _glGetQueryiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetQueryiv(GLenum target, GLenum pname, GLint* @params) => _glGetQueryiv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetQueryiv(GLenum target, GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) { _glGetQueryiv(target, pname, (GLint*)p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYOBJECTIVPROC(GLuint id, GLenum pname, GLint* @params);
    private static PFNGLGETQUERYOBJECTIVPROC _glGetQueryObjectiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetQueryObjectiv(GLuint id, GLenum pname, GLint* @params) => _glGetQueryObjectiv(id, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetQueryObjectiv(GLuint id, GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) { _glGetQueryObjectiv(id, pname, (GLint*)p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYOBJECTUIVPROC(GLuint id, GLenum pname, GLuint* @params);
    private static PFNGLGETQUERYOBJECTUIVPROC _glGetQueryObjectuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetQueryObjectuiv(GLuint id, GLenum pname, GLuint* @params) => _glGetQueryObjectuiv(id, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetQueryObjectuiv(GLuint id, GLenum pname, ref GLuint[] @params) { fixed (GLuint* p = &@params[0]) { _glGetQueryObjectuiv(id, pname, (GLuint*)p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDBUFFERPROC(GLenum target, GLuint buffer);
    private static PFNGLBINDBUFFERPROC _glBindBuffer;
    public static void glBindBuffer(GLenum target, GLuint buffer) => _glBindBuffer(target, buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETEBUFFERSPROC(GLsizei n, GLuint* buffers);
    private static PFNGLDELETEBUFFERSPROC _glDeleteBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteBuffers(GLsizei n, GLuint* buffers) => _glDeleteBuffers(n, buffers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteBuffers(params GLuint[] buffers) { fixed (GLuint* p = &buffers[0]) { _glDeleteBuffers(buffers.Length, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENBUFFERSPROC(GLsizei n, GLuint* buffers);
    private static PFNGLGENBUFFERSPROC _glGenBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenBuffers(GLsizei n, GLuint* buffers) => _glGenBuffers(n, buffers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenBuffers(GLsizei n) { GLuint[] ret = new GLuint[n]; fixed (GLuint* p = &ret[0]) { _glGenBuffers(n, p); } return ret; }
    public static GLuint glGenBuffer() => glGenBuffers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISBUFFERPROC(GLuint buffer);
    private static PFNGLISBUFFERPROC _glIsBuffer;
    public static GLboolean glIsBuffer(GLuint buffer) => _glIsBuffer(buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBUFFERDATAPROC(GLenum target, GLsizeiptr size, void* data, GLenum usage);
    private static PFNGLBUFFERDATAPROC _glBufferData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBufferData(GLenum target, GLsizeiptr size, void* data, GLenum usage) => _glBufferData(target, size, data, usage);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBufferData<T>(GLenum target, T[] data, GLenum usage) where T : unmanaged { fixed (T* p = &data[0]) { _glBufferData(target, sizeof(T) * data.Length, p, usage); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBUFFERSUBDATAPROC(GLenum target, GLintptr offset, GLsizeiptr size, void* data);
    private static PFNGLBUFFERSUBDATAPROC _glBufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, void* data) => _glBufferSubData(target, offset, size, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBufferSubData<T>(GLenum target, GLintptr offset, T[] data) where T : unmanaged { fixed (T* p = &data[0]) { _glBufferSubData(target, offset, sizeof(T) * data.Length, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETBUFFERSUBDATAPROC(GLenum target, GLintptr offset, GLsizeiptr size, void* data);
    private static PFNGLGETBUFFERSUBDATAPROC _glGetBufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, void* data) => _glGetBufferSubData(target, offset, size, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetBufferSubData<T>(GLenum target, GLintptr offset, GLsizei count, ref T[] data) where T : unmanaged { fixed (T* p = &data[0]) { _glGetBufferSubData(target, offset, sizeof(T) * count, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void* PFNGLMAPBUFFERPROC(GLenum target, GLenum access);
    private static PFNGLMAPBUFFERPROC _glMapBuffer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void* glMapBuffer(GLenum target, GLenum access) => _glMapBuffer(target, access);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static System.Span<T> glMapBuffer<T>(GLenum target, GLenum access) where T : unmanaged
    {
        GLint size;
        _glGetBufferParameteriv(target, GL_BUFFER_SIZE, &size);

        void* ret = _glMapBuffer(target, access);
        return new System.Span<T>(ret, size / sizeof(T));
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLUNMAPBUFFERPROC(GLenum target);
    private static PFNGLUNMAPBUFFERPROC _glUnmapBuffer;
    public static GLboolean glUnmapBuffer(GLenum target) => _glUnmapBuffer(target);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETBUFFERPARAMETERIVPROC(GLenum target, GLenum pname, GLint* @params);
    private static PFNGLGETBUFFERPARAMETERIVPROC _glGetBufferParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetBufferParameteriv(GLenum target, GLenum pname, GLint* @params) => _glGetBufferParameteriv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetBufferParameteriv(GLenum target, GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) { _glGetBufferParameteriv(target, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETBUFFERPOINTERVPROC(GLenum target, GLenum pname, void** @params);
    private static PFNGLGETBUFFERPOINTERVPROC _glGetBufferPointerv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetBufferPointerv(GLenum target, GLenum pname, void** @params) => _glGetBufferPointerv(target, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetBufferPointerv(GLenum target, GLenum pname, ref IntPtr[] @params) { fixed (IntPtr* p = &@params[0]) { _glGetBufferPointerv(target, pname, (void**)p); } }
#endif

#endif

    // OpenGL 2.0

#if OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_BLEND_EQUATION_RGB = 0x8009;
    public const int GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
    public const int GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
    public const int GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
    public const int GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
    public const int GL_CURRENT_VERTEX_ATTRIB = 0x8626;
    public const int GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;
    public const int GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
    public const int GL_STENCIL_BACK_FUNC = 0x8800;
    public const int GL_STENCIL_BACK_FAIL = 0x8801;
    public const int GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
    public const int GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
    public const int GL_MAX_DRAW_BUFFERS = 0x8824;
    public const int GL_DRAW_BUFFER0 = 0x8825;
    public const int GL_DRAW_BUFFER1 = 0x8826;
    public const int GL_DRAW_BUFFER2 = 0x8827;
    public const int GL_DRAW_BUFFER3 = 0x8828;
    public const int GL_DRAW_BUFFER4 = 0x8829;
    public const int GL_DRAW_BUFFER5 = 0x882A;
    public const int GL_DRAW_BUFFER6 = 0x882B;
    public const int GL_DRAW_BUFFER7 = 0x882C;
    public const int GL_DRAW_BUFFER8 = 0x882D;
    public const int GL_DRAW_BUFFER9 = 0x882E;
    public const int GL_DRAW_BUFFER10 = 0x882F;
    public const int GL_DRAW_BUFFER11 = 0x8830;
    public const int GL_DRAW_BUFFER12 = 0x8831;
    public const int GL_DRAW_BUFFER13 = 0x8832;
    public const int GL_DRAW_BUFFER14 = 0x8833;
    public const int GL_DRAW_BUFFER15 = 0x8834;
    public const int GL_BLEND_EQUATION_ALPHA = 0x883D;
    public const int GL_MAX_VERTEX_ATTRIBS = 0x8869;
    public const int GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
    public const int GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
    public const int GL_FRAGMENT_SHADER = 0x8B30;
    public const int GL_VERTEX_SHADER = 0x8B31;
    public const int GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
    public const int GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
    public const int GL_MAX_VARYING_FLOATS = 0x8B4B;
    public const int GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
    public const int GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
    public const int GL_SHADER_TYPE = 0x8B4F;
    public const int GL_FLOAT_VEC2 = 0x8B50;
    public const int GL_FLOAT_VEC3 = 0x8B51;
    public const int GL_FLOAT_VEC4 = 0x8B52;
    public const int GL_INT_VEC2 = 0x8B53;
    public const int GL_INT_VEC3 = 0x8B54;
    public const int GL_INT_VEC4 = 0x8B55;
    public const int GL_BOOL = 0x8B56;
    public const int GL_BOOL_VEC2 = 0x8B57;
    public const int GL_BOOL_VEC3 = 0x8B58;
    public const int GL_BOOL_VEC4 = 0x8B59;
    public const int GL_FLOAT_MAT2 = 0x8B5A;
    public const int GL_FLOAT_MAT3 = 0x8B5B;
    public const int GL_FLOAT_MAT4 = 0x8B5C;
    public const int GL_SAMPLER_1D = 0x8B5D;
    public const int GL_SAMPLER_2D = 0x8B5E;
    public const int GL_SAMPLER_3D = 0x8B5F;
    public const int GL_SAMPLER_CUBE = 0x8B60;
    public const int GL_SAMPLER_1D_SHADOW = 0x8B61;
    public const int GL_SAMPLER_2D_SHADOW = 0x8B62;
    public const int GL_DELETE_STATUS = 0x8B80;
    public const int GL_COMPILE_STATUS = 0x8B81;
    public const int GL_LINK_STATUS = 0x8B82;
    public const int GL_VALIDATE_STATUS = 0x8B83;
    public const int GL_INFO_LOG_LENGTH = 0x8B84;
    public const int GL_ATTACHED_SHADERS = 0x8B85;
    public const int GL_ACTIVE_UNIFORMS = 0x8B86;
    public const int GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
    public const int GL_SHADER_SOURCE_LENGTH = 0x8B88;
    public const int GL_ACTIVE_ATTRIBUTES = 0x8B89;
    public const int GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
    public const int GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
    public const int GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
    public const int GL_CURRENT_PROGRAM = 0x8B8D;
    public const int GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
    public const int GL_LOWER_LEFT = 0x8CA1;
    public const int GL_UPPER_LEFT = 0x8CA2;
    public const int GL_STENCIL_BACK_REF = 0x8CA3;
    public const int GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;
    public const int GL_STENCIL_BACK_WRITEMASK = 0x8CA5;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDEQUATIONSEPARATEPROC(GLenum modeRGB, GLenum modeAlpha);
    private static PFNGLBLENDEQUATIONSEPARATEPROC _glBlendEquationSeparate;
    public static void glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha) => _glBlendEquationSeparate(modeRGB, modeAlpha);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWBUFFERSPROC(GLsizei n, GLenum* bufs);
    private static PFNGLDRAWBUFFERSPROC _glDrawBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawBuffers(GLsizei n, GLenum* bufs) => _glDrawBuffers(n, bufs);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawBuffers(GLsizei n, GLenum[] bufs) { fixed (GLenum* pbufs = &bufs[0]) { _glDrawBuffers(n, pbufs); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSTENCILOPSEPARATEPROC(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);
    private static PFNGLSTENCILOPSEPARATEPROC _glStencilOpSeparate;
    public static void glStencilOpSeparate(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass) => _glStencilOpSeparate(face, sfail, dpfail, dppass);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSTENCILFUNCSEPARATEPROC(GLenum face, GLenum func, GLint @ref, GLuint mask);
    private static PFNGLSTENCILFUNCSEPARATEPROC _glStencilFuncSeparate;
    public static void glStencilFuncSeparate(GLenum face, GLenum func, GLint @ref, GLuint mask) => _glStencilFuncSeparate(face, func, @ref, mask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSTENCILMASKSEPARATEPROC(GLenum face, GLuint mask);
    private static PFNGLSTENCILMASKSEPARATEPROC _glStencilMaskSeparate;
    public static void glStencilMaskSeparate(GLenum face, GLuint mask) => _glStencilMaskSeparate(face, mask);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLATTACHSHADERPROC(GLuint program, GLuint shader);
    private static PFNGLATTACHSHADERPROC _glAttachShader;
    public static void glAttachShader(GLuint program, GLuint shader) => _glAttachShader(program, shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDATTRIBLOCATIONPROC(GLuint program, GLuint index, GLchar* name);
    private static PFNGLBINDATTRIBLOCATIONPROC _glBindAttribLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindAttribLocation(GLuint program, GLuint index, GLchar* name) => _glBindAttribLocation(program, index, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindAttribLocation(GLuint program, GLuint index, string name)
    {
        var utf8 = Encoding.UTF8.GetBytes(name);
        fixed (byte* putf8 = &utf8[0])
        {
            _glBindAttribLocation(program, index, (GLchar*)putf8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPILESHADERPROC(GLuint shader);
    private static PFNGLCOMPILESHADERPROC _glCompileShader;
    public static void glCompileShader(GLuint shader) => _glCompileShader(shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLCREATEPROGRAMPROC();
    private static PFNGLCREATEPROGRAMPROC _glCreateProgram;
    public static GLuint glCreateProgram() => _glCreateProgram();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLCREATESHADERPROC(GLenum type);
    private static PFNGLCREATESHADERPROC _glCreateShader;
    public static GLuint glCreateShader(GLenum type) => _glCreateShader(type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETEPROGRAMPROC(GLuint program);
    private static PFNGLDELETEPROGRAMPROC _glDeleteProgram;
    public static void glDeleteProgram(GLuint program) => _glDeleteProgram(program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETESHADERPROC(GLuint shader);
    private static PFNGLDELETESHADERPROC _glDeleteShader;
    public static void glDeleteShader(GLuint shader) => _glDeleteShader(shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDETACHSHADERPROC(GLuint program, GLuint shader);
    private static PFNGLDETACHSHADERPROC _glDetachShader;
    public static void glDetachShader(GLuint program, GLuint shader) => _glDetachShader(program, shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDISABLEVERTEXATTRIBARRAYPROC(GLuint index);
    private static PFNGLDISABLEVERTEXATTRIBARRAYPROC _glDisableVertexAttribArray;
    public static void glDisableVertexAttribArray(GLuint index) => _glDisableVertexAttribArray(index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENABLEVERTEXATTRIBARRAYPROC(GLuint index);
    private static PFNGLENABLEVERTEXATTRIBARRAYPROC _glEnableVertexAttribArray;
    public static void glEnableVertexAttribArray(GLuint index) => _glEnableVertexAttribArray(index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEATTRIBPROC(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLint* size, GLenum* type, GLchar* name);
    private static PFNGLGETACTIVEATTRIBPROC _glGetActiveAttrib;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLint* size, GLenum* type, GLchar* name) => _glGetActiveAttrib(program, index, bufSize, length, size, type, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, out GLint size, out GLenum type)
    {
        GLchar* name = stackalloc GLchar[bufSize];
        GLsizei len;
        fixed (GLenum* ptype = &type)
        fixed (GLint* psize = &size)
        {
            _glGetActiveAttrib(program, index, bufSize, &len, psize, ptype, name);
        }

        return new string((sbyte*)name, 0, len, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEUNIFORMPROC(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLint* size, GLenum* type, GLchar* name);
    private static PFNGLGETACTIVEUNIFORMPROC _glGetActiveUniform;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLint* size, GLenum* type, GLchar* name) => _glGetActiveUniform(program, index, bufSize, length, size, type, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    /// <summary>
    /// Intentionally left out *length since it can be calculated from the length of the returned string instead. The C# way.
    /// </summary>
    public static string glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, out GLint size, out GLenum type)
    {
        GLchar* name = stackalloc GLchar[bufSize];
        GLsizei len;
        fixed (GLenum* ptype = &type)
        fixed (GLint* psize = &size)
        {
            _glGetActiveUniform(program, index, bufSize, &len, psize, ptype, name);
        }

        return new string((sbyte*)name, 0, len, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETATTACHEDSHADERSPROC(GLuint program, GLsizei maxCount, GLsizei* count, GLuint* shaders);
    private static PFNGLGETATTACHEDSHADERSPROC _glGetAttachedShaders;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetAttachedShaders(GLuint program, GLsizei maxCount, GLsizei* count, GLuint* shaders) => _glGetAttachedShaders(program, maxCount, count, shaders);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGetAttachedShaders(GLuint program, GLsizei maxCount)
    {
        GLuint[] shaders = new GLuint[maxCount];
        GLsizei count;
        fixed (GLuint* pshaders = &shaders[0])
        {
            _glGetAttachedShaders(program, maxCount, &count, pshaders);
        }

        Array.Resize(ref shaders, count);
        return shaders;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETATTRIBLOCATIONPROC(GLuint program, GLchar* name);
    private static PFNGLGETATTRIBLOCATIONPROC _glGetAttribLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetAttribLocation(GLuint program, GLchar* name) => _glGetAttribLocation(program, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetAttribLocation(GLuint program, string name)
    {
        fixed (GLchar* pname = Encoding.UTF8.GetBytes(name))
        {
            return _glGetAttribLocation(program, pname);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMIVPROC(GLuint program, GLenum pname, GLint* @params);
    private static PFNGLGETPROGRAMIVPROC _glGetProgramiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramiv(GLuint program, GLenum pname, GLint* @params) => _glGetProgramiv(program, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetProgramiv(GLuint program, GLenum pname, ref GLint[] @params) { fixed (GLint* pparams = &@params[0]) { _glGetProgramiv(program, pname, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMINFOLOGPROC(GLuint program, GLsizei bufSize, GLsizei* length, GLchar* infoLog);
    private static PFNGLGETPROGRAMINFOLOGPROC _glGetProgramInfoLog;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramInfoLog(GLuint program, GLsizei bufSize, GLsizei* length, GLchar* infoLog) => _glGetProgramInfoLog(program, bufSize, length, infoLog);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetProgramInfoLog(GLuint program, GLsizei bufSize)
    {
        GLchar* infoLog = stackalloc GLchar[bufSize];
        GLsizei len;
        _glGetProgramInfoLog(program, bufSize, &len, infoLog);
        return new string((sbyte*)infoLog, 0, len, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSHADERIVPROC(GLuint shader, GLenum pname, GLint* @params);
    private static PFNGLGETSHADERIVPROC _glGetShaderiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetShaderiv(GLuint shader, GLenum pname, GLint* @params) => _glGetShaderiv(shader, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetShaderiv(GLuint shader, GLenum pname, ref GLint[] @params) { fixed (GLint* pparams = &@params[0]) { _glGetShaderiv(shader, pname, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSHADERINFOLOGPROC(GLuint shader, GLsizei bufSize, GLsizei* length, GLchar* infoLog);
    private static PFNGLGETSHADERINFOLOGPROC _glGetShaderInfoLog;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, GLsizei* length, GLchar* infoLog) => _glGetShaderInfoLog(shader, bufSize, length, infoLog);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetShaderInfoLog(GLuint shader, GLsizei bufSize)
    {
        GLchar* infoLog = stackalloc GLchar[bufSize];
        GLsizei len;
        _glGetShaderInfoLog(shader, bufSize, &len, infoLog);
        return new string((sbyte*)infoLog, 0, len, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSHADERSOURCEPROC(GLuint shader, GLsizei bufSize, GLsizei* length, GLchar* source);
    private static PFNGLGETSHADERSOURCEPROC _glGetShaderSource;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetShaderSource(GLuint shader, GLsizei bufSize, GLsizei* length, GLchar* source) => _glGetShaderSource(shader, bufSize, length, source);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetShaderSource(GLuint shader, GLsizei bufSize = 4096)
    {
        GLchar* source = stackalloc GLchar[bufSize];
        GLsizei len;
        _glGetShaderSource(shader, bufSize, &len, source);
        return new string((sbyte*)source, 0, len, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETUNIFORMLOCATIONPROC(GLuint program, GLchar* name);
    private static PFNGLGETUNIFORMLOCATIONPROC _glGetUniformLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetUniformLocation(GLuint program, GLchar* name) => _glGetUniformLocation(program, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetUniformLocation(GLuint program, string name)
    {
        fixed (byte* pname = Encoding.UTF8.GetBytes(name))
        {
            return _glGetUniformLocation(program, (GLchar*)pname);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETUNIFORMFVPROC(GLuint program, GLint location, GLfloat* @params);
    private static PFNGLGETUNIFORMFVPROC _glGetUniformfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetUniformfv(GLuint program, GLint location, GLfloat* @params) => _glGetUniformfv(program, location, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetUniformfv(GLuint program, GLint location, ref GLfloat[] @params) { fixed (GLfloat* pparams = &@params[0]) { _glGetUniformfv(program, location, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETUNIFORMIVPROC(GLuint program, GLint location, GLint* @params);
    private static PFNGLGETUNIFORMIVPROC _glGetUniformiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetUniformiv(GLuint program, GLint location, GLint* @params) => _glGetUniformiv(program, location, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetUniformiv(GLuint program, GLint location, ref GLint[] @params) { fixed (GLint* pparams = &@params[0]) { _glGetUniformiv(program, location, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBDVPROC(GLuint index, GLenum pname, GLdouble* @params);
    private static PFNGLGETVERTEXATTRIBDVPROC _glGetVertexAttribdv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribdv(GLuint index, GLenum pname, GLdouble* @params) => _glGetVertexAttribdv(index, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribdv(GLuint index, GLenum pname, ref GLdouble[] @params) { fixed (GLdouble* pparams = &@params[0]) { _glGetVertexAttribdv(index, pname, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBFVPROC(GLuint index, GLenum pname, GLfloat* @params);
    private static PFNGLGETVERTEXATTRIBFVPROC _glGetVertexAttribfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribfv(GLuint index, GLenum pname, GLfloat* @params) => _glGetVertexAttribfv(index, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribfv(GLuint index, GLenum pname, ref GLfloat[] @params) { fixed (GLfloat* pparams = &@params[0]) { _glGetVertexAttribfv(index, pname, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBIVPROC(GLuint index, GLenum pname, GLint* @params);
    private static PFNGLGETVERTEXATTRIBIVPROC _glGetVertexAttribiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribiv(GLuint index, GLenum pname, GLint* @params) => _glGetVertexAttribiv(index, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribiv(GLuint index, GLenum pname, ref GLint[] @params) { fixed (GLint* pparams = &@params[0]) { _glGetVertexAttribiv(index, pname, pparams); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBPOINTERVPROC(GLuint index, GLenum pname, void** pointer);
    private static PFNGLGETVERTEXATTRIBPOINTERVPROC _glGetVertexAttribPointerv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribPointerv(GLuint index, GLenum pname, void** pointer) => _glGetVertexAttribPointerv(index, pname, pointer);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribPointerv(GLuint index, GLenum pname, ref uint[] pointer)
    {
        void*[] ptr = new void*[pointer.Length];
        fixed (void** p = &ptr[0])
            _glGetVertexAttribPointerv(index, pname, p);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISPROGRAMPROC(GLuint program);
    private static PFNGLISPROGRAMPROC _glIsProgram;
    public static GLboolean glIsProgram(GLuint program) => _glIsProgram(program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISSHADERPROC(GLuint shader);
    private static PFNGLISSHADERPROC _glIsShader;
    public static GLboolean glIsShader(GLuint shader) => _glIsShader(shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLLINKPROGRAMPROC(GLuint program);
    private static PFNGLLINKPROGRAMPROC _glLinkProgram;
    public static void glLinkProgram(GLuint program) => _glLinkProgram(program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSHADERSOURCEPROC(GLuint shader, GLsizei count, GLchar** @string, GLint* length);
    private static PFNGLSHADERSOURCEPROC _glShaderSource;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glShaderSource(GLuint shader, GLsizei count, GLchar** @string, GLint* length) => _glShaderSource(shader, count, @string, length);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glShaderSource(GLuint shader, params string[] @string)
    {
        int count = @string.Length;
        GLchar[][] strings = new GLchar[count][];
        GLint[] lengths = new GLint[count];

        for (int i = 0; i < count; i++)
        {
            strings[i] = Encoding.UTF8.GetBytes(@string[i]);
            lengths[i] = @string[i].Length;
        }

        GLchar** pstring = stackalloc GLchar*[count];
        GLint* length = stackalloc GLint[count];
        for (int i = 0; i < count; i++)
        {
            fixed (GLchar* p = &strings[i][0])
            {
                pstring[i] = p;
            }
            length[i] = lengths[i];
        }
        _glShaderSource(shader, count, pstring, length);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUSEPROGRAMPROC(GLuint program);
    private static PFNGLUSEPROGRAMPROC _glUseProgram;
    public static void glUseProgram(GLuint program) => _glUseProgram(program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1FPROC(GLint location, GLfloat v0);
    private static PFNGLUNIFORM1FPROC _glUniform1f;
    public static void glUniform1f(GLint location, GLfloat v0) => _glUniform1f(location, v0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2FPROC(GLint location, GLfloat v0, GLfloat v1);
    private static PFNGLUNIFORM2FPROC _glUniform2f;
    public static void glUniform2f(GLint location, GLfloat v0, GLfloat v1) => _glUniform2f(location, v0, v1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3FPROC(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
    private static PFNGLUNIFORM3FPROC _glUniform3f;
    public static void glUniform3f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2) => _glUniform3f(location, v0, v1, v2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4FPROC(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
    private static PFNGLUNIFORM4FPROC _glUniform4f;
    public static void glUniform4f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3) => _glUniform4f(location, v0, v1, v2, v3);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1IPROC(GLint location, GLint v0);
    private static PFNGLUNIFORM1IPROC _glUniform1i;
    public static void glUniform1i(GLint location, GLint v0) => _glUniform1i(location, v0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2IPROC(GLint location, GLint v0, GLint v1);
    private static PFNGLUNIFORM2IPROC _glUniform2i;
    public static void glUniform2i(GLint location, GLint v0, GLint v1) => _glUniform2i(location, v0, v1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3IPROC(GLint location, GLint v0, GLint v1, GLint v2);
    private static PFNGLUNIFORM3IPROC _glUniform3i;
    public static void glUniform3i(GLint location, GLint v0, GLint v1, GLint v2) => _glUniform3i(location, v0, v1, v2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4IPROC(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
    private static PFNGLUNIFORM4IPROC _glUniform4i;
    public static void glUniform4i(GLint location, GLint v0, GLint v1, GLint v2, GLint v3) => _glUniform4i(location, v0, v1, v2, v3);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1FVPROC(GLint location, GLsizei count, GLfloat* value);
    private static PFNGLUNIFORM1FVPROC _glUniform1fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform1fv(GLint location, GLsizei count, GLfloat* value) => _glUniform1fv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform1fv(GLint location, GLsizei count, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniform1fv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2FVPROC(GLint location, GLsizei count, GLfloat* value);
    private static PFNGLUNIFORM2FVPROC _glUniform2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform2fv(GLint location, GLsizei count, GLfloat* value) => _glUniform2fv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform2fv(GLint location, GLsizei count, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniform2fv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3FVPROC(GLint location, GLsizei count, GLfloat* value);
    private static PFNGLUNIFORM3FVPROC _glUniform3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform3fv(GLint location, GLsizei count, GLfloat* value) => _glUniform3fv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform3fv(GLint location, GLsizei count, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniform3fv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4FVPROC(GLint location, GLsizei count, GLfloat* value);
    private static PFNGLUNIFORM4FVPROC _glUniform4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform4fv(GLint location, GLsizei count, GLfloat* value) => _glUniform4fv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform4fv(GLint location, GLsizei count, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniform4fv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1IVPROC(GLint location, GLsizei count, GLint* value);
    private static PFNGLUNIFORM1IVPROC _glUniform1iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform1iv(GLint location, GLsizei count, GLint* value) => _glUniform1iv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform1iv(GLint location, GLsizei count, params GLint[] value) { fixed (GLint* p = &value[0]) _glUniform1iv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2IVPROC(GLint location, GLsizei count, GLint* value);
    private static PFNGLUNIFORM2IVPROC _glUniform2iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform2iv(GLint location, GLsizei count, GLint* value) => _glUniform2iv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform2iv(GLint location, GLsizei count, params GLint[] value) { fixed (GLint* p = &value[0]) _glUniform2iv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3IVPROC(GLint location, GLsizei count, GLint* value);
    private static PFNGLUNIFORM3IVPROC _glUniform3iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform3iv(GLint location, GLsizei count, GLint* value) => _glUniform3iv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform3iv(GLint location, GLsizei count, params GLint[] value) { fixed (GLint* p = &value[0]) _glUniform3iv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4IVPROC(GLint location, GLsizei count, GLint* value);
    private static PFNGLUNIFORM4IVPROC _glUniform4iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform4iv(GLint location, GLsizei count, GLint* value) => _glUniform4iv(location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform4iv(GLint location, GLsizei count, params GLint[] value) { fixed (GLint* p = &value[0]) _glUniform4iv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX2FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX2FVPROC _glUniformMatrix2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix2fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix2fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX3FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX3FVPROC _glUniformMatrix3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix3fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix3fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX4FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX4FVPROC _glUniformMatrix4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix4fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix4fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLVALIDATEPROGRAMPROC(GLuint program);
    private static PFNGLVALIDATEPROGRAMPROC _glValidateProgram;
    public static GLboolean glValidateProgram(GLuint program) => _glValidateProgram(program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB1DPROC(GLuint index, GLdouble x);
    private static PFNGLVERTEXATTRIB1DPROC _glVertexAttrib1d;
    public static void glVertexAttrib1d(GLuint index, GLdouble x) => _glVertexAttrib1d(index, x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB1DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIB1DVPROC _glVertexAttrib1dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib1dv(GLuint index, GLdouble* v) => _glVertexAttrib1dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib1dv(GLuint index, params GLdouble[] v) { fixed (GLdouble* p = &v[0]) _glVertexAttrib1dv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB1FPROC(GLuint index, GLfloat x);
    private static PFNGLVERTEXATTRIB1FPROC _glVertexAttrib1f;
    public static void glVertexAttrib1f(GLuint index, GLfloat x) => _glVertexAttrib1f(index, x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB1FVPROC(GLuint index, GLfloat* v);
    private static PFNGLVERTEXATTRIB1FVPROC _glVertexAttrib1fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib1fv(GLuint index, GLfloat* v) => _glVertexAttrib1fv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib1fv(GLuint index, params GLfloat[] v) { fixed (GLfloat* p = &v[0]) _glVertexAttrib1fv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB1SPROC(GLuint index, GLshort x);
    private static PFNGLVERTEXATTRIB1SPROC _glVertexAttrib1s;
    public static void glVertexAttrib1s(GLuint index, GLshort x) => _glVertexAttrib1s(index, x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB1SVPROC(GLuint index, GLshort* v);
    private static PFNGLVERTEXATTRIB1SVPROC _glVertexAttrib1sv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib1sv(GLuint index, GLshort* v) => _glVertexAttrib1sv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib1sv(GLuint index, params GLshort[] v) { fixed (GLshort* p = &v[0]) _glVertexAttrib1sv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB2DPROC(GLuint index, GLdouble x, GLdouble y);
    private static PFNGLVERTEXATTRIB2DPROC _glVertexAttrib2d;
    public static void glVertexAttrib2d(GLuint index, GLdouble x, GLdouble y) => _glVertexAttrib2d(index, x, y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB2DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIB2DVPROC _glVertexAttrib2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib2dv(GLuint index, GLdouble* v) => _glVertexAttrib2dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib2dv(GLuint index, params GLdouble[] v) { fixed (GLdouble* p = &v[0]) _glVertexAttrib2dv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB2FPROC(GLuint index, GLfloat x, GLfloat y);
    private static PFNGLVERTEXATTRIB2FPROC _glVertexAttrib2f;
    public static void glVertexAttrib2f(GLuint index, GLfloat x, GLfloat y) => _glVertexAttrib2f(index, x, y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB2FVPROC(GLuint index, GLfloat* v);
    private static PFNGLVERTEXATTRIB2FVPROC _glVertexAttrib2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib2fv(GLuint index, GLfloat* v) => _glVertexAttrib2fv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib2fv(GLuint index, params GLfloat[] v) { fixed (GLfloat* p = &v[0]) _glVertexAttrib2fv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB2SPROC(GLuint index, GLshort x, GLshort y);
    private static PFNGLVERTEXATTRIB2SPROC _glVertexAttrib2s;
    public static void glVertexAttrib2s(GLuint index, GLshort x, GLshort y) => _glVertexAttrib2s(index, x, y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB2SVPROC(GLuint index, GLshort* v);
    private static PFNGLVERTEXATTRIB2SVPROC _glVertexAttrib2sv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib2sv(GLuint index, GLshort* v) => _glVertexAttrib2sv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib2sv(GLuint index, params GLshort[] v) { fixed (GLshort* p = &v[0]) _glVertexAttrib2sv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB3DPROC(GLuint index, GLdouble x, GLdouble y, GLdouble z);
    private static PFNGLVERTEXATTRIB3DPROC _glVertexAttrib3d;
    public static void glVertexAttrib3d(GLuint index, GLdouble x, GLdouble y, GLdouble z) => _glVertexAttrib3d(index, x, y, z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB3DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIB3DVPROC _glVertexAttrib3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib3dv(GLuint index, GLdouble* v) => _glVertexAttrib3dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib3dv(GLuint index, params GLdouble[] v) { fixed (GLdouble* p = &v[0]) _glVertexAttrib3dv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB3FPROC(GLuint index, GLfloat x, GLfloat y, GLfloat z);
    private static PFNGLVERTEXATTRIB3FPROC _glVertexAttrib3f;
    public static void glVertexAttrib3f(GLuint index, GLfloat x, GLfloat y, GLfloat z) => _glVertexAttrib3f(index, x, y, z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB3FVPROC(GLuint index, GLfloat* v);
    private static PFNGLVERTEXATTRIB3FVPROC _glVertexAttrib3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib3fv(GLuint index, GLfloat* v) => _glVertexAttrib3fv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib3fv(GLuint index, params GLfloat[] v) { fixed (GLfloat* p = &v[0]) _glVertexAttrib3fv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB3SPROC(GLuint index, GLshort x, GLshort y, GLshort z);
    private static PFNGLVERTEXATTRIB3SPROC _glVertexAttrib3s;
    public static void glVertexAttrib3s(GLuint index, GLshort x, GLshort y, GLshort z) => _glVertexAttrib3s(index, x, y, z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB3SVPROC(GLuint index, GLshort* v);
    private static PFNGLVERTEXATTRIB3SVPROC _glVertexAttrib3sv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib3sv(GLuint index, GLshort* v) => _glVertexAttrib3sv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib3sv(GLuint index, params GLshort[] v) { fixed (GLshort* p = &v[0]) _glVertexAttrib3sv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NBVPROC(GLuint index, GLbyte* v);
    private static PFNGLVERTEXATTRIB4NBVPROC _glVertexAttrib4Nbv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4Nbv(GLuint index, GLbyte* v) => _glVertexAttrib4Nbv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4Nbv(GLuint index, params GLbyte[] v) { fixed (GLbyte* p = &v[0]) _glVertexAttrib4Nbv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NIVPROC(GLuint index, GLint* v);
    private static PFNGLVERTEXATTRIB4NIVPROC _glVertexAttrib4Niv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4Niv(GLuint index, GLint* v) => _glVertexAttrib4Niv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4Niv(GLuint index, params GLint[] v) { fixed (GLint* p = &v[0]) _glVertexAttrib4Niv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NSVPROC(GLuint index, GLshort* v);
    private static PFNGLVERTEXATTRIB4NSVPROC _glVertexAttrib4Nsv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4Nsv(GLuint index, GLshort* v) => _glVertexAttrib4Nsv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4Nsv(GLuint index, params GLshort[] v) { fixed (GLshort* p = &v[0]) _glVertexAttrib4Nsv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NUBPROC(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);
    private static PFNGLVERTEXATTRIB4NUBPROC _glVertexAttrib4Nub;
    public static void glVertexAttrib4Nub(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w) => _glVertexAttrib4Nub(index, x, y, z, w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NUBVPROC(GLuint index, GLubyte* v);
    private static PFNGLVERTEXATTRIB4NUBVPROC _glVertexAttrib4Nubv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4Nubv(GLuint index, GLubyte* v) => _glVertexAttrib4Nubv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4Nubv(GLuint index, params GLubyte[] v) { fixed (GLubyte* p = &v[0]) _glVertexAttrib4Nubv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NUIVPROC(GLuint index, GLuint* v);
    private static PFNGLVERTEXATTRIB4NUIVPROC _glVertexAttrib4Nuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4Nuiv(GLuint index, GLuint* v) => _glVertexAttrib4Nuiv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4Nuiv(GLuint index, params GLuint[] v) { fixed (GLuint* p = &v[0]) _glVertexAttrib4Nuiv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4NUSVPROC(GLuint index, GLushort* v);
    private static PFNGLVERTEXATTRIB4NUSVPROC _glVertexAttrib4Nusv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4Nusv(GLuint index, GLushort* v) => _glVertexAttrib4Nusv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4Nusv(GLuint index, params GLushort[] v) { fixed (GLushort* p = &v[0]) _glVertexAttrib4Nusv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4BVPROC(GLuint index, GLbyte* v);
    private static PFNGLVERTEXATTRIB4BVPROC _glVertexAttrib4bv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4bv(GLuint index, GLbyte* v) => _glVertexAttrib4bv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4bv(GLuint index, params GLbyte[] v) { fixed (GLbyte* p = &v[0]) _glVertexAttrib4bv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4DPROC(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
    private static PFNGLVERTEXATTRIB4DPROC _glVertexAttrib4d;
    public static void glVertexAttrib4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w) => _glVertexAttrib4d(index, x, y, z, w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIB4DVPROC _glVertexAttrib4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4dv(GLuint index, GLdouble* v) => _glVertexAttrib4dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4dv(GLuint index, params GLdouble[] v) { fixed (GLdouble* p = &v[0]) _glVertexAttrib4dv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4FPROC(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
    private static PFNGLVERTEXATTRIB4FPROC _glVertexAttrib4f;
    public static void glVertexAttrib4f(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w) => _glVertexAttrib4f(index, x, y, z, w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4FVPROC(GLuint index, GLfloat* v);
    private static PFNGLVERTEXATTRIB4FVPROC _glVertexAttrib4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4fv(GLuint index, GLfloat* v) => _glVertexAttrib4fv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4fv(GLuint index, params GLfloat[] v) { fixed (GLfloat* p = &v[0]) _glVertexAttrib4fv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4IVPROC(GLuint index, GLint* v);
    private static PFNGLVERTEXATTRIB4IVPROC _glVertexAttrib4iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4iv(GLuint index, GLint* v) => _glVertexAttrib4iv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4iv(GLuint index, params GLint[] v) { fixed (GLint* p = &v[0]) _glVertexAttrib4iv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4SPROC(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);
    private static PFNGLVERTEXATTRIB4SPROC _glVertexAttrib4s;
    public static void glVertexAttrib4s(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w) => _glVertexAttrib4s(index, x, y, z, w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4SVPROC(GLuint index, GLshort* v);
    private static PFNGLVERTEXATTRIB4SVPROC _glVertexAttrib4sv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4sv(GLuint index, GLshort* v) => _glVertexAttrib4sv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4sv(GLuint index, params GLshort[] v) { fixed (GLshort* p = &v[0]) _glVertexAttrib4sv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4UBVPROC(GLuint index, GLubyte* v);
    private static PFNGLVERTEXATTRIB4UBVPROC _glVertexAttrib4ubv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4ubv(GLuint index, GLubyte* v) => _glVertexAttrib4ubv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4ubv(GLuint index, params GLubyte[] v) { fixed (GLubyte* p = &v[0]) _glVertexAttrib4ubv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4UIVPROC(GLuint index, GLuint* v);
    private static PFNGLVERTEXATTRIB4UIVPROC _glVertexAttrib4uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4uiv(GLuint index, GLuint* v) => _glVertexAttrib4uiv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4uiv(GLuint index, params GLuint[] v) { fixed (GLuint* p = &v[0]) _glVertexAttrib4uiv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIB4USVPROC(GLuint index, GLushort* v);
    private static PFNGLVERTEXATTRIB4USVPROC _glVertexAttrib4usv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttrib4usv(GLuint index, GLushort* v) => _glVertexAttrib4usv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttrib4usv(GLuint index, params GLushort[] v) { fixed (GLushort* p = &v[0]) _glVertexAttrib4usv(index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBPOINTERPROC(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, void* pointer);
    private static PFNGLVERTEXATTRIBPOINTERPROC _glVertexAttribPointer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, void* pointer) => _glVertexAttribPointer(index, size, type, normalized, stride, pointer);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, uint pointer) => _glVertexAttribPointer(index, size, type, normalized, stride, (void*)pointer);
#endif

#endif

    // OpenGL 2.1

#if OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_PIXEL_PACK_BUFFER = 0x88EB;
    public const int GL_PIXEL_UNPACK_BUFFER = 0x88EC;
    public const int GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED;
    public const int GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
    public const int GL_FLOAT_MAT2x3 = 0x8B65;
    public const int GL_FLOAT_MAT2x4 = 0x8B66;
    public const int GL_FLOAT_MAT3x2 = 0x8B67;
    public const int GL_FLOAT_MAT3x4 = 0x8B68;
    public const int GL_FLOAT_MAT4x2 = 0x8B69;
    public const int GL_FLOAT_MAT4x3 = 0x8B6A;
    public const int GL_SRGB = 0x8C40;
    public const int GL_SRGB8 = 0x8C41;
    public const int GL_SRGB_ALPHA = 0x8C42;
    public const int GL_SRGB8_ALPHA8 = 0x8C43;
    public const int GL_COMPRESSED_SRGB = 0x8C48;
    public const int GL_COMPRESSED_SRGB_ALPHA = 0x8C49;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX2X3FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX2X3FVPROC _glUniformMatrix2x3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix2x3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix2x3fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix2x3fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix2x3fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX3X2FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX3X2FVPROC _glUniformMatrix3x2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix3x2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix3x2fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix3x2fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix3x2fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX2X4FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX2X4FVPROC _glUniformMatrix2x4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix2x4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix2x4fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix2x4fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix2x4fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX4X2FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX4X2FVPROC _glUniformMatrix4x2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix4x2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix4x2fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix4x2fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix4x2fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX3X4FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX3X4FVPROC _glUniformMatrix3x4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix3x4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix3x4fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix3x4fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix3x4fv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX4X3FVPROC(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLUNIFORMMATRIX4X3FVPROC _glUniformMatrix4x3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix4x3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glUniformMatrix4x3fv(location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix4x3fv(GLint location, GLsizei count, GLboolean transpose, params GLfloat[] value) { fixed (GLfloat* p = &value[0]) _glUniformMatrix4x3fv(location, count, transpose, p); }
#endif

#endif

    // OpenGL 3.0

#if OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_COMPARE_REF_TO_TEXTURE = 0x884E;
    public const int GL_CLIP_DISTANCE0 = 0x3000;
    public const int GL_CLIP_DISTANCE1 = 0x3001;
    public const int GL_CLIP_DISTANCE2 = 0x3002;
    public const int GL_CLIP_DISTANCE3 = 0x3003;
    public const int GL_CLIP_DISTANCE4 = 0x3004;
    public const int GL_CLIP_DISTANCE5 = 0x3005;
    public const int GL_CLIP_DISTANCE6 = 0x3006;
    public const int GL_CLIP_DISTANCE7 = 0x3007;
    public const int GL_MAX_CLIP_DISTANCES = 0x0D32;
    public const int GL_MAJOR_VERSION = 0x821B;
    public const int GL_MINOR_VERSION = 0x821C;
    public const int GL_NUM_EXTENSIONS = 0x821D;
    public const int GL_CONTEXT_FLAGS = 0x821E;
    public const int GL_COMPRESSED_RED = 0x8225;
    public const int GL_COMPRESSED_RG = 0x8226;
    public const int GL_CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = 0x0001;
    public const int GL_RGBA32F = 0x8814;
    public const int GL_RGB32F = 0x8815;
    public const int GL_RGBA16F = 0x881A;
    public const int GL_RGB16F = 0x881B;
    public const int GL_VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
    public const int GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
    public const int GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
    public const int GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
    public const int GL_CLAMP_READ_COLOR = 0x891C;
    public const int GL_FIXED_ONLY = 0x891D;
    public const int GL_MAX_VARYING_COMPONENTS = 0x8B4B;
    public const int GL_TEXTURE_1D_ARRAY = 0x8C18;
    public const int GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19;
    public const int GL_TEXTURE_2D_ARRAY = 0x8C1A;
    public const int GL_PROXY_TEXTURE_2D_ARRAY = 0x8C1B;
    public const int GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C;
    public const int GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
    public const int GL_R11F_G11F_B10F = 0x8C3A;
    public const int GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
    public const int GL_RGB9_E5 = 0x8C3D;
    public const int GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
    public const int GL_TEXTURE_SHARED_SIZE = 0x8C3F;
    public const int GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
    public const int GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
    public const int GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
    public const int GL_PRIMITIVES_GENERATED = 0x8C87;
    public const int GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
    public const int GL_RASTERIZER_DISCARD = 0x8C89;
    public const int GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
    public const int GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
    public const int GL_INTERLEAVED_ATTRIBS = 0x8C8C;
    public const int GL_SEPARATE_ATTRIBS = 0x8C8D;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
    public const int GL_RGBA32UI = 0x8D70;
    public const int GL_RGB32UI = 0x8D71;
    public const int GL_RGBA16UI = 0x8D76;
    public const int GL_RGB16UI = 0x8D77;
    public const int GL_RGBA8UI = 0x8D7C;
    public const int GL_RGB8UI = 0x8D7D;
    public const int GL_RGBA32I = 0x8D82;
    public const int GL_RGB32I = 0x8D83;
    public const int GL_RGBA16I = 0x8D88;
    public const int GL_RGB16I = 0x8D89;
    public const int GL_RGBA8I = 0x8D8E;
    public const int GL_RGB8I = 0x8D8F;
    public const int GL_RED_INTEGER = 0x8D94;
    public const int GL_GREEN_INTEGER = 0x8D95;
    public const int GL_BLUE_INTEGER = 0x8D96;
    public const int GL_RGB_INTEGER = 0x8D98;
    public const int GL_RGBA_INTEGER = 0x8D99;
    public const int GL_BGR_INTEGER = 0x8D9A;
    public const int GL_BGRA_INTEGER = 0x8D9B;
    public const int GL_SAMPLER_1D_ARRAY = 0x8DC0;
    public const int GL_SAMPLER_2D_ARRAY = 0x8DC1;
    public const int GL_SAMPLER_1D_ARRAY_SHADOW = 0x8DC3;
    public const int GL_SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
    public const int GL_SAMPLER_CUBE_SHADOW = 0x8DC5;
    public const int GL_UNSIGNED_INT_VEC2 = 0x8DC6;
    public const int GL_UNSIGNED_INT_VEC3 = 0x8DC7;
    public const int GL_UNSIGNED_INT_VEC4 = 0x8DC8;
    public const int GL_INT_SAMPLER_1D = 0x8DC9;
    public const int GL_INT_SAMPLER_2D = 0x8DCA;
    public const int GL_INT_SAMPLER_3D = 0x8DCB;
    public const int GL_INT_SAMPLER_CUBE = 0x8DCC;
    public const int GL_INT_SAMPLER_1D_ARRAY = 0x8DCE;
    public const int GL_INT_SAMPLER_2D_ARRAY = 0x8DCF;
    public const int GL_UNSIGNED_INT_SAMPLER_1D = 0x8DD1;
    public const int GL_UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
    public const int GL_UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
    public const int GL_UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
    public const int GL_UNSIGNED_INT_SAMPLER_1D_ARRAY = 0x8DD6;
    public const int GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
    public const int GL_QUERY_WAIT = 0x8E13;
    public const int GL_QUERY_NO_WAIT = 0x8E14;
    public const int GL_QUERY_BY_REGION_WAIT = 0x8E15;
    public const int GL_QUERY_BY_REGION_NO_WAIT = 0x8E16;
    public const int GL_BUFFER_ACCESS_FLAGS = 0x911F;
    public const int GL_BUFFER_MAP_LENGTH = 0x9120;
    public const int GL_BUFFER_MAP_OFFSET = 0x9121;
    public const int GL_DEPTH_COMPONENT32F = 0x8CAC;
    public const int GL_DEPTH32F_STENCIL8 = 0x8CAD;
    public const int GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
    public const int GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506;
    public const int GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
    public const int GL_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
    public const int GL_FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
    public const int GL_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
    public const int GL_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
    public const int GL_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
    public const int GL_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
    public const int GL_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
    public const int GL_FRAMEBUFFER_DEFAULT = 0x8218;
    public const int GL_FRAMEBUFFER_UNDEFINED = 0x8219;
    public const int GL_DEPTH_STENCIL_ATTACHMENT = 0x821A;
    public const int GL_MAX_RENDERBUFFER_SIZE = 0x84E8;
    public const int GL_DEPTH_STENCIL = 0x84F9;
    public const int GL_UNSIGNED_INT_24_8 = 0x84FA;
    public const int GL_DEPTH24_STENCIL8 = 0x88F0;
    public const int GL_TEXTURE_STENCIL_SIZE = 0x88F1;
    public const int GL_TEXTURE_RED_TYPE = 0x8C10;
    public const int GL_TEXTURE_GREEN_TYPE = 0x8C11;
    public const int GL_TEXTURE_BLUE_TYPE = 0x8C12;
    public const int GL_TEXTURE_ALPHA_TYPE = 0x8C13;
    public const int GL_TEXTURE_DEPTH_TYPE = 0x8C16;
    public const int GL_UNSIGNED_NORMALIZED = 0x8C17;
    public const int GL_FRAMEBUFFER_BINDING = 0x8CA6;
    public const int GL_DRAW_FRAMEBUFFER_BINDING = 0x8CA6;
    public const int GL_RENDERBUFFER_BINDING = 0x8CA7;
    public const int GL_READ_FRAMEBUFFER = 0x8CA8;
    public const int GL_DRAW_FRAMEBUFFER = 0x8CA9;
    public const int GL_READ_FRAMEBUFFER_BINDING = 0x8CAA;
    public const int GL_RENDERBUFFER_SAMPLES = 0x8CAB;
    public const int GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
    public const int GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
    public const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
    public const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;
    public const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
    public const int GL_FRAMEBUFFER_COMPLETE = 0x8CD5;
    public const int GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
    public const int GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
    public const int GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB;
    public const int GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC;
    public const int GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD;
    public const int GL_MAX_COLOR_ATTACHMENTS = 0x8CDF;
    public const int GL_COLOR_ATTACHMENT0 = 0x8CE0;
    public const int GL_COLOR_ATTACHMENT1 = 0x8CE1;
    public const int GL_COLOR_ATTACHMENT2 = 0x8CE2;
    public const int GL_COLOR_ATTACHMENT3 = 0x8CE3;
    public const int GL_COLOR_ATTACHMENT4 = 0x8CE4;
    public const int GL_COLOR_ATTACHMENT5 = 0x8CE5;
    public const int GL_COLOR_ATTACHMENT6 = 0x8CE6;
    public const int GL_COLOR_ATTACHMENT7 = 0x8CE7;
    public const int GL_COLOR_ATTACHMENT8 = 0x8CE8;
    public const int GL_COLOR_ATTACHMENT9 = 0x8CE9;
    public const int GL_COLOR_ATTACHMENT10 = 0x8CEA;
    public const int GL_COLOR_ATTACHMENT11 = 0x8CEB;
    public const int GL_COLOR_ATTACHMENT12 = 0x8CEC;
    public const int GL_COLOR_ATTACHMENT13 = 0x8CED;
    public const int GL_COLOR_ATTACHMENT14 = 0x8CEE;
    public const int GL_COLOR_ATTACHMENT15 = 0x8CEF;
    public const int GL_COLOR_ATTACHMENT16 = 0x8CF0;
    public const int GL_COLOR_ATTACHMENT17 = 0x8CF1;
    public const int GL_COLOR_ATTACHMENT18 = 0x8CF2;
    public const int GL_COLOR_ATTACHMENT19 = 0x8CF3;
    public const int GL_COLOR_ATTACHMENT20 = 0x8CF4;
    public const int GL_COLOR_ATTACHMENT21 = 0x8CF5;
    public const int GL_COLOR_ATTACHMENT22 = 0x8CF6;
    public const int GL_COLOR_ATTACHMENT23 = 0x8CF7;
    public const int GL_COLOR_ATTACHMENT24 = 0x8CF8;
    public const int GL_COLOR_ATTACHMENT25 = 0x8CF9;
    public const int GL_COLOR_ATTACHMENT26 = 0x8CFA;
    public const int GL_COLOR_ATTACHMENT27 = 0x8CFB;
    public const int GL_COLOR_ATTACHMENT28 = 0x8CFC;
    public const int GL_COLOR_ATTACHMENT29 = 0x8CFD;
    public const int GL_COLOR_ATTACHMENT30 = 0x8CFE;
    public const int GL_COLOR_ATTACHMENT31 = 0x8CFF;
    public const int GL_DEPTH_ATTACHMENT = 0x8D00;
    public const int GL_STENCIL_ATTACHMENT = 0x8D20;
    public const int GL_FRAMEBUFFER = 0x8D40;
    public const int GL_RENDERBUFFER = 0x8D41;
    public const int GL_RENDERBUFFER_WIDTH = 0x8D42;
    public const int GL_RENDERBUFFER_HEIGHT = 0x8D43;
    public const int GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
    public const int GL_STENCIL_INDEX1 = 0x8D46;
    public const int GL_STENCIL_INDEX4 = 0x8D47;
    public const int GL_STENCIL_INDEX8 = 0x8D48;
    public const int GL_STENCIL_INDEX16 = 0x8D49;
    public const int GL_RENDERBUFFER_RED_SIZE = 0x8D50;
    public const int GL_RENDERBUFFER_GREEN_SIZE = 0x8D51;
    public const int GL_RENDERBUFFER_BLUE_SIZE = 0x8D52;
    public const int GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53;
    public const int GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54;
    public const int GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55;
    public const int GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
    public const int GL_MAX_SAMPLES = 0x8D57;
    public const int GL_FRAMEBUFFER_SRGB = 0x8DB9;
    public const int GL_HALF_FLOAT = 0x140B;
    public const int GL_MAP_READ_BIT = 0x0001;
    public const int GL_MAP_WRITE_BIT = 0x0002;
    public const int GL_MAP_INVALIDATE_RANGE_BIT = 0x0004;
    public const int GL_MAP_INVALIDATE_BUFFER_BIT = 0x0008;
    public const int GL_MAP_FLUSH_EXPLICIT_BIT = 0x0010;
    public const int GL_MAP_UNSYNCHRONIZED_BIT = 0x0020;
    public const int GL_COMPRESSED_RED_RGTC1 = 0x8DBB;
    public const int GL_COMPRESSED_SIGNED_RED_RGTC1 = 0x8DBC;
    public const int GL_COMPRESSED_RG_RGTC2 = 0x8DBD;
    public const int GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE;
    public const int GL_RG = 0x8227;
    public const int GL_RG_INTEGER = 0x8228;
    public const int GL_R8 = 0x8229;
    public const int GL_R16 = 0x822A;
    public const int GL_RG8 = 0x822B;
    public const int GL_RG16 = 0x822C;
    public const int GL_R16F = 0x822D;
    public const int GL_R32F = 0x822E;
    public const int GL_RG16F = 0x822F;
    public const int GL_RG32F = 0x8230;
    public const int GL_R8I = 0x8231;
    public const int GL_R8UI = 0x8232;
    public const int GL_R16I = 0x8233;
    public const int GL_R16UI = 0x8234;
    public const int GL_R32I = 0x8235;
    public const int GL_R32UI = 0x8236;
    public const int GL_RG8I = 0x8237;
    public const int GL_RG8UI = 0x8238;
    public const int GL_RG16I = 0x8239;
    public const int GL_RG16UI = 0x823A;
    public const int GL_RG32I = 0x823B;
    public const int GL_RG32UI = 0x823C;
    public const int GL_VERTEX_ARRAY_BINDING = 0x85B5;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOLORMASKIPROC(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a);
    private static PFNGLCOLORMASKIPROC _glColorMaski;
    public static void glColorMaski(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a) { _glColorMaski(index, r, g, b, a); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETBOOLEANI_VPROC(GLenum target, GLuint index, GLboolean* data);
    private static PFNGLGETBOOLEANI_VPROC _glGetBooleani_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetBooleani_v(GLenum target, GLuint index, GLboolean* data) { _glGetBooleani_v(target, index, data); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetBooleani_v(GLenum target, GLuint index, ref GLboolean[] data) { fixed (GLboolean* p = &data[0]) _glGetBooleani_v(target, index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETINTEGERI_VPROC(GLenum target, GLuint index, GLint* data);
    private static PFNGLGETINTEGERI_VPROC _glGetIntegeri_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetIntegeri_v(GLenum target, GLuint index, GLint* data) { _glGetIntegeri_v(target, index, data); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetIntegeri_v(GLenum target, GLuint index, ref GLint[] data) { fixed (GLint* p = &data[0]) _glGetIntegeri_v(target, index, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENABLEIPROC(GLenum target, GLuint index);
    private static PFNGLENABLEIPROC _glEnablei;
    public static void glEnablei(GLenum target, GLuint index) { _glEnablei(target, index); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDISABLEIPROC(GLenum target, GLuint index);
    private static PFNGLDISABLEIPROC _glDisablei;
    public static void glDisablei(GLenum target, GLuint index) { _glDisablei(target, index); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISENABLEDIPROC(GLenum target, GLuint index);
    private static PFNGLISENABLEDIPROC _glIsEnabledi;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBEGINTRANSFORMFEEDBACKPROC(GLenum primitiveMode);
    private static PFNGLBEGINTRANSFORMFEEDBACKPROC _glBeginTransformFeedback;
    public static void glBeginTransformFeedback(GLenum primitiveMode) { _glBeginTransformFeedback(primitiveMode); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENDTRANSFORMFEEDBACKPROC();
    private static PFNGLENDTRANSFORMFEEDBACKPROC _glEndTransformFeedback;
    public static void glEndTransformFeedback() { _glEndTransformFeedback(); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDBUFFERRANGEPROC(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);
    private static PFNGLBINDBUFFERRANGEPROC _glBindBufferRange;
    public static void glBindBufferRange(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size) { _glBindBufferRange(target, index, buffer, offset, size); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDBUFFERBASEPROC(GLenum target, GLuint index, GLuint buffer);
    private static PFNGLBINDBUFFERBASEPROC _glBindBufferBase;
    public static void glBindBufferBase(GLenum target, GLuint index, GLuint buffer) { _glBindBufferBase(target, index, buffer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTRANSFORMFEEDBACKVARYINGSPROC(GLuint program, GLsizei count, GLchar** varyings, GLenum bufferMode);
    private static PFNGLTRANSFORMFEEDBACKVARYINGSPROC _glTransformFeedbackVaryings;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTransformFeedbackVaryings(GLuint program, GLsizei count, GLchar** varyings, GLenum bufferMode) { _glTransformFeedbackVaryings(program, count, varyings, bufferMode); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTransformFeedbackVaryings(GLuint program, string[] varyings, GLenum bufferMode)
    {
        GLchar[][] varyingsBytes = new GLchar[varyings.Length][];
        for (int i = 0; i < varyings.Length; i++)
        {
            varyingsBytes[i] = Encoding.UTF8.GetBytes(varyings[i]);
        }
        GLchar*[] varyingsPtrs = new GLchar*[varyings.Length];
        for (int i = 0; i < varyings.Length; i++)
        {
            fixed (GLchar* p = &varyingsBytes[i][0])
            {
                varyingsPtrs[i] = p;
            }
        }
        fixed (GLchar** p = &varyingsPtrs[0])
        {
            _glTransformFeedbackVaryings(program, varyings.Length, p, bufferMode);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTRANSFORMFEEDBACKVARYINGPROC(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLsizei* size, GLenum* type, GLchar* name);
    private static PFNGLGETTRANSFORMFEEDBACKVARYINGPROC _glGetTransformFeedbackVarying;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTransformFeedbackVarying(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLsizei* size, GLenum* type, GLchar* name) { _glGetTransformFeedbackVarying(program, index, bufSize, length, size, type, name); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetTransformFeedbackVarying(GLuint program, GLuint index, GLsizei bufSize, out GLsizei size, out GLenum type)
    {
        GLchar[] name = new GLchar[bufSize];
        GLsizei length;
        fixed (GLsizei* pSize = &size)
        fixed (GLenum* pType = &type)
        fixed (GLchar* p = &name[0])
        {
            _glGetTransformFeedbackVarying(program, index, bufSize, &length, pSize, pType, p);
            return new string((sbyte*)p, 0, length, Encoding.UTF8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLAMPCOLORPROC(GLenum target, GLenum clamp);
    private static PFNGLCLAMPCOLORPROC _glClampColor;
    public static void glClampColor(GLenum target, GLenum clamp) { _glClampColor(target, clamp); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBEGINCONDITIONALRENDERPROC(GLuint id, GLenum mode);
    private static PFNGLBEGINCONDITIONALRENDERPROC _glBeginConditionalRender;
    public static void glBeginConditionalRender(GLuint id, GLenum mode) { _glBeginConditionalRender(id, mode); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENDCONDITIONALRENDERPROC();
    private static PFNGLENDCONDITIONALRENDERPROC _glEndConditionalRender;
    public static void glEndConditionalRender() { _glEndConditionalRender(); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBIPOINTERPROC(GLuint index, GLint size, GLenum type, GLsizei stride, void* pointer);
    private static PFNGLVERTEXATTRIBIPOINTERPROC _glVertexAttribIPointer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribIPointer(GLuint index, GLint size, GLenum type, GLsizei stride, void* pointer) { _glVertexAttribIPointer(index, size, type, stride, pointer); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribIPointer(GLuint index, GLint size, GLenum type, GLsizei stride, uint pointer) { _glVertexAttribIPointer(index, size, type, stride, (void*)pointer); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBIIVPROC(GLuint index, GLenum pname, GLint* parameters);
    private static PFNGLGETVERTEXATTRIBIIVPROC _glGetVertexAttribIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribIiv(GLuint index, GLenum pname, GLint* parameters) { _glGetVertexAttribIiv(index, pname, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribIiv(GLuint index, GLenum pname, ref GLint[] parameters) { fixed (GLint* p = &parameters[0]) { _glGetVertexAttribIiv(index, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBIUIVPROC(GLuint index, GLenum pname, GLuint* parameters);
    private static PFNGLGETVERTEXATTRIBIUIVPROC _glGetVertexAttribIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribIuiv(GLuint index, GLenum pname, GLuint* parameters) { _glGetVertexAttribIuiv(index, pname, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribIuiv(GLuint index, GLenum pname, ref GLuint[] parameters) { fixed (GLuint* p = &parameters[0]) { _glGetVertexAttribIuiv(index, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI1IPROC(GLuint index, GLint x);
    private static PFNGLVERTEXATTRIBI1IPROC _glVertexAttribI1i;
    public static void glVertexAttribI1i(GLuint index, GLint x) { _glVertexAttribI1i(index, x); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI2IPROC(GLuint index, GLint x, GLint y);
    private static PFNGLVERTEXATTRIBI2IPROC _glVertexAttribI2i;
    public static void glVertexAttribI2i(GLuint index, GLint x, GLint y) { _glVertexAttribI2i(index, x, y); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI3IPROC(GLuint index, GLint x, GLint y, GLint z);
    private static PFNGLVERTEXATTRIBI3IPROC _glVertexAttribI3i;
    public static void glVertexAttribI3i(GLuint index, GLint x, GLint y, GLint z) { _glVertexAttribI3i(index, x, y, z); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4IPROC(GLuint index, GLint x, GLint y, GLint z, GLint w);
    private static PFNGLVERTEXATTRIBI4IPROC _glVertexAttribI4i;
    public static void glVertexAttribI4i(GLuint index, GLint x, GLint y, GLint z, GLint w) { _glVertexAttribI4i(index, x, y, z, w); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI1UIPROC(GLuint index, GLuint x);
    private static PFNGLVERTEXATTRIBI1UIPROC _glVertexAttribI1ui;
    public static void glVertexAttribI1ui(GLuint index, GLuint x) { _glVertexAttribI1ui(index, x); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI2UIPROC(GLuint index, GLuint x, GLuint y);
    private static PFNGLVERTEXATTRIBI2UIPROC _glVertexAttribI2ui;
    public static void glVertexAttribI2ui(GLuint index, GLuint x, GLuint y) { _glVertexAttribI2ui(index, x, y); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI3UIPROC(GLuint index, GLuint x, GLuint y, GLuint z);
    private static PFNGLVERTEXATTRIBI3UIPROC _glVertexAttribI3ui;
    public static void glVertexAttribI3ui(GLuint index, GLuint x, GLuint y, GLuint z) { _glVertexAttribI3ui(index, x, y, z); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4UIPROC(GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);
    private static PFNGLVERTEXATTRIBI4UIPROC _glVertexAttribI4ui;
    public static void glVertexAttribI4ui(GLuint index, GLuint x, GLuint y, GLuint z, GLuint w) { _glVertexAttribI4ui(index, x, y, z, w); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI1IVPROC(GLuint index, GLint* v);
    private static PFNGLVERTEXATTRIBI1IVPROC _glVertexAttribI1iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI1iv(GLuint index, GLint* v) { _glVertexAttribI1iv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI1iv(GLuint index, GLint[] v) { fixed (GLint* p = &v[0]) { _glVertexAttribI1iv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI2IVPROC(GLuint index, GLint* v);
    private static PFNGLVERTEXATTRIBI2IVPROC _glVertexAttribI2iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI2iv(GLuint index, GLint* v) { _glVertexAttribI2iv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI2iv(GLuint index, GLint[] v) { fixed (GLint* p = &v[0]) { _glVertexAttribI2iv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI3IVPROC(GLuint index, GLint* v);
    private static PFNGLVERTEXATTRIBI3IVPROC _glVertexAttribI3iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI3iv(GLuint index, GLint* v) { _glVertexAttribI3iv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI3iv(GLuint index, GLint[] v) { fixed (GLint* p = &v[0]) { _glVertexAttribI3iv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4IVPROC(GLuint index, GLint* v);
    private static PFNGLVERTEXATTRIBI4IVPROC _glVertexAttribI4iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI4iv(GLuint index, GLint* v) { _glVertexAttribI4iv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI4iv(GLuint index, GLint[] v) { fixed (GLint* p = &v[0]) { _glVertexAttribI4iv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI1UIVPROC(GLuint index, GLuint* v);
    private static PFNGLVERTEXATTRIBI1UIVPROC _glVertexAttribI1uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI1uiv(GLuint index, GLuint* v) { _glVertexAttribI1uiv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI1uiv(GLuint index, GLuint[] v) { fixed (GLuint* p = &v[0]) { _glVertexAttribI1uiv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI2UIVPROC(GLuint index, GLuint* v);
    private static PFNGLVERTEXATTRIBI2UIVPROC _glVertexAttribI2uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI2uiv(GLuint index, GLuint* v) { _glVertexAttribI2uiv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI2uiv(GLuint index, GLuint[] v) { fixed (GLuint* p = &v[0]) { _glVertexAttribI2uiv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI3UIVPROC(GLuint index, GLuint* v);
    private static PFNGLVERTEXATTRIBI3UIVPROC _glVertexAttribI3uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI3uiv(GLuint index, GLuint* v) { _glVertexAttribI3uiv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI3uiv(GLuint index, GLuint[] v) { fixed (GLuint* p = &v[0]) { _glVertexAttribI3uiv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4UIVPROC(GLuint index, GLuint* v);
    private static PFNGLVERTEXATTRIBI4UIVPROC _glVertexAttribI4uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI4uiv(GLuint index, GLuint* v) { _glVertexAttribI4uiv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI4uiv(GLuint index, GLuint[] v) { fixed (GLuint* p = &v[0]) { _glVertexAttribI4uiv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4BVPROC(GLuint index, GLbyte* v);
    private static PFNGLVERTEXATTRIBI4BVPROC _glVertexAttribI4bv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI4bv(GLuint index, GLbyte* v) { _glVertexAttribI4bv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI4bv(GLuint index, GLbyte[] v) { fixed (GLbyte* p = &v[0]) { _glVertexAttribI4bv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4SVPROC(GLuint index, GLshort* v);
    private static PFNGLVERTEXATTRIBI4SVPROC _glVertexAttribI4sv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI4sv(GLuint index, GLshort* v) { _glVertexAttribI4sv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI4sv(GLuint index, GLshort[] v) { fixed (GLshort* p = &v[0]) { _glVertexAttribI4sv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4UBVPROC(GLuint index, GLubyte* v);
    private static PFNGLVERTEXATTRIBI4UBVPROC _glVertexAttribI4ubv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI4ubv(GLuint index, GLubyte* v) { _glVertexAttribI4ubv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI4ubv(GLuint index, GLubyte[] v) { fixed (GLubyte* p = &v[0]) { _glVertexAttribI4ubv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBI4USVPROC(GLuint index, GLushort* v);
    private static PFNGLVERTEXATTRIBI4USVPROC _glVertexAttribI4usv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribI4usv(GLuint index, GLushort* v) { _glVertexAttribI4usv(index, v); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribI4usv(GLuint index, GLushort[] v) { fixed (GLushort* p = &v[0]) { _glVertexAttribI4usv(index, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETUNIFORMUIVPROC(GLuint program, GLint location, GLuint* @params);
    private static PFNGLGETUNIFORMUIVPROC _glGetUniformuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetUniformuiv(GLuint program, GLint location, GLuint* @params) { _glGetUniformuiv(program, location, @params); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetUniformuiv(GLuint program, GLint location, ref GLuint[] @params) { fixed (GLuint* p = &@params[0]) { _glGetUniformuiv(program, location, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDFRAGDATALOCATIONPROC(GLuint program, GLuint color, GLchar* name);
    private static PFNGLBINDFRAGDATALOCATIONPROC _glBindFragDataLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindFragDataLocation(GLuint program, GLuint color, GLchar* name) { _glBindFragDataLocation(program, color, name); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindFragDataLocation(GLuint program, GLuint color, string name) { GLchar[] narr = Encoding.UTF8.GetBytes(name); fixed (GLchar* p = &narr[0]) { _glBindFragDataLocation(program, color, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETFRAGDATALOCATIONPROC(GLuint program, GLchar* name);
    private static PFNGLGETFRAGDATALOCATIONPROC _glGetFragDataLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetFragDataLocation(GLuint program, GLchar* name) { return _glGetFragDataLocation(program, name); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetFragDataLocation(GLuint program, string name) { GLchar[] narr = Encoding.UTF8.GetBytes(name); fixed (GLchar* p = &narr[0]) { return _glGetFragDataLocation(program, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1UIPROC(GLint location, GLuint v0);
    private static PFNGLUNIFORM1UIPROC _glUniform1ui;
    public static void glUniform1ui(GLint location, GLuint v0) { _glUniform1ui(location, v0); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2UIPROC(GLint location, GLuint v0, GLuint v1);
    private static PFNGLUNIFORM2UIPROC _glUniform2ui;
    public static void glUniform2ui(GLint location, GLuint v0, GLuint v1) { _glUniform2ui(location, v0, v1); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3UIPROC(GLint location, GLuint v0, GLuint v1, GLuint v2);
    private static PFNGLUNIFORM3UIPROC _glUniform3ui;
    public static void glUniform3ui(GLint location, GLuint v0, GLuint v1, GLuint v2) { _glUniform3ui(location, v0, v1, v2); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4UIPROC(GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);
    private static PFNGLUNIFORM4UIPROC _glUniform4ui;
    public static void glUniform4ui(GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3) { _glUniform4ui(location, v0, v1, v2, v3); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1UIVPROC(GLint location, GLsizei count, GLuint* value);
    private static PFNGLUNIFORM1UIVPROC _glUniform1uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform1uiv(GLint location, GLsizei count, GLuint* value) { _glUniform1uiv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform1uiv(GLint location, GLsizei count, GLuint[] value) { fixed (GLuint* p = &value[0]) { _glUniform1uiv(location, count, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2UIVPROC(GLint location, GLsizei count, GLuint* value);
    private static PFNGLUNIFORM2UIVPROC _glUniform2uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform2uiv(GLint location, GLsizei count, GLuint* value) { _glUniform2uiv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform2uiv(GLint location, GLsizei count, GLuint[] value) { fixed (GLuint* p = &value[0]) { _glUniform2uiv(location, count, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3UIVPROC(GLint location, GLsizei count, GLuint* value);
    private static PFNGLUNIFORM3UIVPROC _glUniform3uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform3uiv(GLint location, GLsizei count, GLuint* value) { _glUniform3uiv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform3uiv(GLint location, GLsizei count, GLuint[] value) { fixed (GLuint* p = &value[0]) { _glUniform3uiv(location, count, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4UIVPROC(GLint location, GLsizei count, GLuint* value);
    private static PFNGLUNIFORM4UIVPROC _glUniform4uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform4uiv(GLint location, GLsizei count, GLuint* value) { _glUniform4uiv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform4uiv(GLint location, GLsizei count, GLuint[] value) { fixed (GLuint* p = &value[0]) { _glUniform4uiv(location, count, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXPARAMETERIIVPROC(GLenum target, GLenum pname, GLint* param);
    private static PFNGLTEXPARAMETERIIVPROC _glTexParameterIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexParameterIiv(GLenum target, GLenum pname, GLint* param) { _glTexParameterIiv(target, pname, param); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexParameterIiv(GLenum target, GLenum pname, GLint[] param) { fixed (GLint* p = &param[0]) { _glTexParameterIiv(target, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXPARAMETERIUIVPROC(GLenum target, GLenum pname, GLuint* param);
    private static PFNGLTEXPARAMETERIUIVPROC _glTexParameterIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTexParameterIuiv(GLenum target, GLenum pname, GLuint* param) { _glTexParameterIuiv(target, pname, param); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTexParameterIuiv(GLenum target, GLenum pname, GLuint[] param) { fixed (GLuint* p = &param[0]) { _glTexParameterIuiv(target, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXPARAMETERIIVPROC(GLenum target, GLenum pname, GLint* parameters);
    private static PFNGLGETTEXPARAMETERIIVPROC _glGetTexParameterIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTexParameterIiv(GLenum target, GLenum pname, GLint* parameters) { _glGetTexParameterIiv(target, pname, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTexParameterIiv(GLenum target, GLenum pname, ref GLint[] parameters) { fixed (GLint* p = &parameters[0]) { _glGetTexParameterIiv(target, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXPARAMETERIUIVPROC(GLenum target, GLenum pname, GLuint* parameters);
    private static PFNGLGETTEXPARAMETERIUIVPROC _glGetTexParameterIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTexParameterIuiv(GLenum target, GLenum pname, GLuint* parameters) { _glGetTexParameterIuiv(target, pname, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTexParameterIuiv(GLenum target, GLenum pname, ref GLuint[] parameters) { fixed (GLuint* p = &parameters[0]) { _glGetTexParameterIuiv(target, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARBUFFERIVPROC(GLenum buffer, GLint drawbuffer, GLint* value);
    private static PFNGLCLEARBUFFERIVPROC _glClearBufferiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearBufferiv(GLenum buffer, GLint drawbuffer, GLint* value) { _glClearBufferiv(buffer, drawbuffer, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearBufferiv(GLenum buffer, GLint drawbuffer, GLint[] value) { fixed (GLint* p = &value[0]) { _glClearBufferiv(buffer, drawbuffer, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARBUFFERUIVPROC(GLenum buffer, GLint drawbuffer, GLuint* value);
    private static PFNGLCLEARBUFFERUIVPROC _glClearBufferuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearBufferuiv(GLenum buffer, GLint drawbuffer, GLuint* value) { _glClearBufferuiv(buffer, drawbuffer, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearBufferuiv(GLenum buffer, GLint drawbuffer, GLuint[] value) { fixed (GLuint* p = &value[0]) { _glClearBufferuiv(buffer, drawbuffer, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARBUFFERFVPROC(GLenum buffer, GLint drawbuffer, GLfloat* value);
    private static PFNGLCLEARBUFFERFVPROC _glClearBufferfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearBufferfv(GLenum buffer, GLint drawbuffer, GLfloat* value) { _glClearBufferfv(buffer, drawbuffer, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearBufferfv(GLenum buffer, GLint drawbuffer, GLfloat[] value) { fixed (GLfloat* p = &value[0]) { _glClearBufferfv(buffer, drawbuffer, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARBUFFERFIPROC(GLenum buffer, GLint drawbuffer, GLfloat depth, GLint stencil);
    private static PFNGLCLEARBUFFERFIPROC _glClearBufferfi;
    public static void glClearBufferfi(GLenum buffer, GLint drawbuffer, GLfloat depth, GLint stencil) { _glClearBufferfi(buffer, drawbuffer, depth, stencil); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLubyte* PFNGLGETSTRINGIPROC(GLenum name, GLuint index);
    private static PFNGLGETSTRINGIPROC _glGetStringi;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLubyte* glGetStringi(GLenum name, GLuint index) { return _glGetStringi(name, index); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetStringiSafe(GLenum name, GLuint index)
    {
        GLubyte* ptr = _glGetStringi(name, index);
        if (ptr == null) return null;
        int i = 0; while (ptr[i] != 0) i++;
        return new string((sbyte*)ptr, 0, i, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISRENDERBUFFERPROC(GLuint renderbuffer);
    private static PFNGLISRENDERBUFFERPROC _glIsRenderbuffer;
    public static GLboolean glIsRenderbuffer(GLuint renderbuffer) { return _glIsRenderbuffer(renderbuffer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDRENDERBUFFERPROC(GLenum target, GLuint renderbuffer);
    private static PFNGLBINDRENDERBUFFERPROC _glBindRenderbuffer;
    public static void glBindRenderbuffer(GLenum target, GLuint renderbuffer) { _glBindRenderbuffer(target, renderbuffer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETERENDERBUFFERSPROC(GLsizei n, GLuint* renderbuffers);
    private static PFNGLDELETERENDERBUFFERSPROC _glDeleteRenderbuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteRenderbuffers(GLsizei n, GLuint* renderbuffers) { _glDeleteRenderbuffers(n, renderbuffers); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteRenderbuffers(params GLuint[] renderbuffers) { fixed (GLuint* p = &renderbuffers[0]) { _glDeleteRenderbuffers(renderbuffers.Length, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENRENDERBUFFERSPROC(GLsizei n, GLuint* renderbuffers);
    private static PFNGLGENRENDERBUFFERSPROC _glGenRenderbuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenRenderbuffers(GLsizei n, GLuint* renderbuffers) { _glGenRenderbuffers(n, renderbuffers); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenRenderbuffers(GLsizei n) { GLuint[] renderbuffers = new GLuint[n]; fixed (GLuint* p = &renderbuffers[0]) { _glGenRenderbuffers(n, p); } return renderbuffers; }
    public static GLuint glGenRenderbuffer() => glGenRenderbuffers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLRENDERBUFFERSTORAGEPROC(GLenum target, GLenum internalformat, GLsizei width, GLsizei height);
    private static PFNGLRENDERBUFFERSTORAGEPROC _glRenderbufferStorage;
    public static void glRenderbufferStorage(GLenum target, GLenum internalformat, GLsizei width, GLsizei height) { _glRenderbufferStorage(target, internalformat, width, height); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETRENDERBUFFERPARAMETERIVPROC(GLenum target, GLenum pname, GLint* parameters);
    private static PFNGLGETRENDERBUFFERPARAMETERIVPROC _glGetRenderbufferParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetRenderbufferParameteriv(GLenum target, GLenum pname, GLint* parameters) { _glGetRenderbufferParameteriv(target, pname, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetRenderbufferParameteriv(GLenum target, GLenum pname, ref GLsizei[] parameters) { fixed (GLsizei* p = &parameters[0]) { _glGetRenderbufferParameteriv(target, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISFRAMEBUFFERPROC(GLuint framebuffer);
    private static PFNGLISFRAMEBUFFERPROC _glIsFramebuffer;
    public static GLboolean glIsFramebuffer(GLuint framebuffer) { return _glIsFramebuffer(framebuffer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDFRAMEBUFFERPROC(GLenum target, GLuint framebuffer);
    private static PFNGLBINDFRAMEBUFFERPROC _glBindFramebuffer;
    public static void glBindFramebuffer(GLenum target, GLuint framebuffer) { _glBindFramebuffer(target, framebuffer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETEFRAMEBUFFERSPROC(GLsizei n, GLuint* framebuffers);
    private static PFNGLDELETEFRAMEBUFFERSPROC _glDeleteFramebuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteFramebuffers(GLsizei n, GLuint* framebuffers) { _glDeleteFramebuffers(n, framebuffers); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteFramebuffers(params GLuint[] framebuffers) { fixed (GLuint* p = &framebuffers[0]) { _glDeleteFramebuffers(framebuffers.Length, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENFRAMEBUFFERSPROC(GLsizei n, GLuint* framebuffers);
    private static PFNGLGENFRAMEBUFFERSPROC _glGenFramebuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenFramebuffers(GLsizei n, GLuint* framebuffers) { _glGenFramebuffers(n, framebuffers); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenFramebuffers(GLsizei n) { GLuint[] framebuffers = new GLuint[n]; fixed (GLuint* p = &framebuffers[0]) { _glGenFramebuffers(n, p); } return framebuffers; }
    public static GLuint glGenFramebuffer() => glGenFramebuffers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLenum PFNGLCHECKFRAMEBUFFERSTATUSPROC(GLenum target);
    private static PFNGLCHECKFRAMEBUFFERSTATUSPROC _glCheckFramebufferStatus;
    public static GLenum glCheckFramebufferStatus(GLenum target) { return _glCheckFramebufferStatus(target); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERTEXTURE1DPROC(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);
    private static PFNGLFRAMEBUFFERTEXTURE1DPROC _glFramebufferTexture1D;
    public static void glFramebufferTexture1D(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level) { _glFramebufferTexture1D(target, attachment, textarget, texture, level); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERTEXTURE2DPROC(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);
    private static PFNGLFRAMEBUFFERTEXTURE2DPROC _glFramebufferTexture2D;
    public static void glFramebufferTexture2D(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level) { _glFramebufferTexture2D(target, attachment, textarget, texture, level); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERTEXTURE3DPROC(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);
    private static PFNGLFRAMEBUFFERTEXTURE3DPROC _glFramebufferTexture3D;
    public static void glFramebufferTexture3D(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset) { _glFramebufferTexture3D(target, attachment, textarget, texture, level, zoffset); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERRENDERBUFFERPROC(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);
    private static PFNGLFRAMEBUFFERRENDERBUFFERPROC _glFramebufferRenderbuffer;
    public static void glFramebufferRenderbuffer(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer) { _glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC(GLenum target, GLenum attachment, GLenum pname, GLint* parameters);
    private static PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC _glGetFramebufferAttachmentParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetFramebufferAttachmentParameteriv(GLenum target, GLenum attachment, GLenum pname, GLint* parameters) { _glGetFramebufferAttachmentParameteriv(target, attachment, pname, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetFramebufferAttachmentParameteriv(GLenum target, GLenum attachment, GLenum pname, ref GLint[] parameters) { fixed (GLint* p = &parameters[0]) { _glGetFramebufferAttachmentParameteriv(target, attachment, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENERATEMIPMAPPROC(GLenum target);
    private static PFNGLGENERATEMIPMAPPROC _glGenerateMipmap;
    public static void glGenerateMipmap(GLenum target) { _glGenerateMipmap(target); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLITFRAMEBUFFERPROC(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);
    private static PFNGLBLITFRAMEBUFFERPROC _glBlitFramebuffer;
    public static void glBlitFramebuffer(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter) { _glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);
    private static PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC _glRenderbufferStorageMultisample;
    public static void glRenderbufferStorageMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height) { _glRenderbufferStorageMultisample(target, samples, internalformat, width, height); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERTEXTURELAYERPROC(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer);
    private static PFNGLFRAMEBUFFERTEXTURELAYERPROC _glFramebufferTextureLayer;
    public static void glFramebufferTextureLayer(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer) { _glFramebufferTextureLayer(target, attachment, texture, level, layer); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void* PFNGLMAPBUFFERRANGEPROC(GLenum target, GLintptr offset, GLsizeiptr length, GLbitfield access);
    private static PFNGLMAPBUFFERRANGEPROC _glMapBufferRange;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void* glMapBufferRange(GLenum target, GLintptr offset, GLsizeiptr length, GLbitfield access) { return _glMapBufferRange(target, offset, length, access); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static System.Span<T> glMapBufferRange<T>(GLenum target, GLintptr offset, GLsizeiptr length, GLbitfield access) where T : unmanaged
    {
        void* ret = _glMapBufferRange(target, offset, length, access);
        return new System.Span<T>(ret, (int)length);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFLUSHMAPPEDBUFFERRANGEPROC(GLenum target, GLintptr offset, GLsizeiptr length);
    private static PFNGLFLUSHMAPPEDBUFFERRANGEPROC _glFlushMappedBufferRange;
    public static void glFlushMappedBufferRange(GLenum target, GLintptr offset, GLsizeiptr length) { _glFlushMappedBufferRange(target, offset, length); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDVERTEXARRAYPROC(GLuint array);
    private static PFNGLBINDVERTEXARRAYPROC _glBindVertexArray;
    public static void glBindVertexArray(GLuint array) { _glBindVertexArray(array); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETEVERTEXARRAYSPROC(GLsizei n, GLuint* arrays);
    private static PFNGLDELETEVERTEXARRAYSPROC _glDeleteVertexArrays;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteVertexArrays(GLsizei n, GLuint* arrays) { _glDeleteVertexArrays(n, arrays); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteVertexArrays(params GLuint[] arrays) { fixed (GLuint* p = &arrays[0]) { _glDeleteVertexArrays((GLsizei)arrays.Length, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENVERTEXARRAYSPROC(GLsizei n, GLuint* arrays);
    private static PFNGLGENVERTEXARRAYSPROC _glGenVertexArrays;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenVertexArrays(GLsizei n, GLuint* arrays) { _glGenVertexArrays(n, arrays); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenVertexArrays(GLsizei n) { GLuint[] arrays = new GLuint[n]; fixed (GLuint* p = &arrays[0]) { _glGenVertexArrays(n, p); } return arrays; }
    public static GLuint glGenVertexArray() { GLuint array = 0; _glGenVertexArrays(1, &array); return array; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISVERTEXARRAYPROC(GLuint array);
    private static PFNGLISVERTEXARRAYPROC _glIsVertexArray;
    public static GLboolean glIsVertexArray(GLuint array) { return _glIsVertexArray(array); }

#endif

    // OpenGL 3.1

#if OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_SAMPLER_2D_RECT = 0x8B63;
    public const int GL_SAMPLER_2D_RECT_SHADOW = 0x8B64;
    public const int GL_SAMPLER_BUFFER = 0x8DC2;
    public const int GL_INT_SAMPLER_2D_RECT = 0x8DCD;
    public const int GL_INT_SAMPLER_BUFFER = 0x8DD0;
    public const int GL_UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5;
    public const int GL_UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8;
    public const int GL_TEXTURE_BUFFER = 0x8C2A;
    public const int GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B;
    public const int GL_TEXTURE_BINDING_BUFFER = 0x8C2C;
    public const int GL_TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D;
    public const int GL_TEXTURE_RECTANGLE = 0x84F5;
    public const int GL_TEXTURE_BINDING_RECTANGLE = 0x84F6;
    public const int GL_PROXY_TEXTURE_RECTANGLE = 0x84F7;
    public const int GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8;
    public const int GL_R8_SNORM = 0x8F94;
    public const int GL_RG8_SNORM = 0x8F95;
    public const int GL_RGB8_SNORM = 0x8F96;
    public const int GL_RGBA8_SNORM = 0x8F97;
    public const int GL_R16_SNORM = 0x8F98;
    public const int GL_RG16_SNORM = 0x8F99;
    public const int GL_RGB16_SNORM = 0x8F9A;
    public const int GL_RGBA16_SNORM = 0x8F9B;
    public const int GL_SIGNED_NORMALIZED = 0x8F9C;
    public const int GL_PRIMITIVE_RESTART = 0x8F9D;
    public const int GL_PRIMITIVE_RESTART_INDEX = 0x8F9E;
    public const int GL_COPY_READ_BUFFER = 0x8F36;
    public const int GL_COPY_WRITE_BUFFER = 0x8F37;
    public const int GL_UNIFORM_BUFFER = 0x8A11;
    public const int GL_UNIFORM_BUFFER_BINDING = 0x8A28;
    public const int GL_UNIFORM_BUFFER_START = 0x8A29;
    public const int GL_UNIFORM_BUFFER_SIZE = 0x8A2A;
    public const int GL_MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
    public const int GL_MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C;
    public const int GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;
    public const int GL_MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
    public const int GL_MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
    public const int GL_MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
    public const int GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
    public const int GL_MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32;
    public const int GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
    public const int GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
    public const int GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
    public const int GL_ACTIVE_UNIFORM_BLOCKS = 0x8A36;
    public const int GL_UNIFORM_TYPE = 0x8A37;
    public const int GL_UNIFORM_SIZE = 0x8A38;
    public const int GL_UNIFORM_NAME_LENGTH = 0x8A39;
    public const int GL_UNIFORM_BLOCK_INDEX = 0x8A3A;
    public const int GL_UNIFORM_OFFSET = 0x8A3B;
    public const int GL_UNIFORM_ARRAY_STRIDE = 0x8A3C;
    public const int GL_UNIFORM_MATRIX_STRIDE = 0x8A3D;
    public const int GL_UNIFORM_IS_ROW_MAJOR = 0x8A3E;
    public const int GL_UNIFORM_BLOCK_BINDING = 0x8A3F;
    public const int GL_UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
    public const int GL_UNIFORM_BLOCK_NAME_LENGTH = 0x8A41;
    public const int GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
    public const int GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
    public const int GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
    public const int GL_UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = 0x8A45;
    public const int GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;
    public const int GL_INVALID_INDEX = unchecked((int)0xFFFFFFFFu); // TODO: Is this right?

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWARRAYSINSTANCEDPROC(GLenum mode, GLint first, GLsizei count, GLsizei instancecount);
    private static PFNGLDRAWARRAYSINSTANCEDPROC _glDrawArraysInstanced;
    public static void glDrawArraysInstanced(GLenum mode, GLint first, GLsizei count, GLsizei instancecount) => _glDrawArraysInstanced(mode, first, count, instancecount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSINSTANCEDPROC(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount);
    private static PFNGLDRAWELEMENTSINSTANCEDPROC _glDrawElementsInstanced;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElementsInstanced(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount) => _glDrawElementsInstanced(mode, count, type, indices, instancecount);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElementsInstanced<T>(GLenum mode, GLsizei count, GLenum type, T[] indices, GLsizei instancecount) where T : unmanaged, IUnsignedNumber<T> { fixed (T* p = &indices[0]) _glDrawElementsInstanced(mode, count, type, p, instancecount); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXBUFFERPROC(GLenum target, GLenum internalformat, GLuint buffer);
    private static PFNGLTEXBUFFERPROC _glTexBuffer;
    public static void glTexBuffer(GLenum target, GLenum internalformat, GLuint buffer) => _glTexBuffer(target, internalformat, buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPRIMITIVERESTARTINDEXPROC(GLuint index);
    private static PFNGLPRIMITIVERESTARTINDEXPROC _glPrimitiveRestartIndex;
    public static void glPrimitiveRestartIndex(GLuint index) => _glPrimitiveRestartIndex(index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYBUFFERSUBDATAPROC(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);
    private static PFNGLCOPYBUFFERSUBDATAPROC _glCopyBufferSubData;
    public static void glCopyBufferSubData(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size) => _glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETUNIFORMINDICESPROC(GLuint program, GLsizei uniformCount, GLchar** uniformNames, GLuint* uniformIndices);
    private static PFNGLGETUNIFORMINDICESPROC _glGetUniformIndices;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetUniformIndices(GLuint program, GLsizei uniformCount, GLchar** uniformNames, GLuint* uniformIndices) => _glGetUniformIndices(program, uniformCount, uniformNames, uniformIndices);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGetUniformIndices(GLuint program, params string[] uniformNames)
    {
        int uniformCount = uniformNames.Length;
        GLchar[][] uniformNamesPtrs = new GLchar[uniformCount][];

        for (int i = 0; i < uniformCount; i++)
        {
            uniformNamesPtrs[i] = Encoding.UTF8.GetBytes(uniformNames[i]);
        }

        GLchar** pUniformNames = stackalloc GLchar*[uniformCount];
        for (int i = 0; i < uniformCount; i++)
        {
            fixed (GLchar* p = &uniformNamesPtrs[i][0])
            {
                pUniformNames[i] = p;
            }
        }

        GLuint[] uniformIndices = new GLuint[uniformCount];
        fixed (GLuint* p = &uniformIndices[0])
        {
            _glGetUniformIndices(program, uniformCount, pUniformNames, p);
        }
        return uniformIndices;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEUNIFORMSIVPROC(GLuint program, GLsizei uniformCount, GLuint* uniformIndices, GLenum pname, GLint* parameters);
    private static PFNGLGETACTIVEUNIFORMSIVPROC _glGetActiveUniformsiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveUniformsiv(GLuint program, GLsizei uniformCount, GLuint* uniformIndices, GLenum pname, GLint* parameters) => _glGetActiveUniformsiv(program, uniformCount, uniformIndices, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint[] glGetActiveUniformsiv(GLuint program, GLenum pname, params GLuint[] uniformIndices)
    {
        int uniformCount = uniformIndices.Length;
        GLint[] parameters = new GLint[uniformCount];
        fixed (GLuint* p = &uniformIndices[0])
        fixed (GLint* pParameters = &parameters[0])
        {
            _glGetActiveUniformsiv(program, uniformCount, p, pname, pParameters);
        }
        return parameters;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEUNIFORMNAMEPROC(GLuint program, GLuint uniformIndex, GLsizei bufSize, GLsizei* length, GLchar* uniformName);
    private static PFNGLGETACTIVEUNIFORMNAMEPROC _glGetActiveUniformName;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveUniformName(GLuint program, GLuint uniformIndex, GLsizei bufSize, GLsizei* length, GLchar* uniformName) => _glGetActiveUniformName(program, uniformIndex, bufSize, length, uniformName);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetActiveUniformName(GLuint program, GLuint uniformIndex, GLsizei bufSize)
    {
        GLchar* uniformName = stackalloc GLchar[bufSize];
        GLsizei length;
        _glGetActiveUniformName(program, uniformIndex, bufSize, &length, uniformName);
        return new string((sbyte*)uniformName, 0, length, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLGETUNIFORMBLOCKINDEXPROC(GLuint program, GLchar* uniformBlockName);
    private static PFNGLGETUNIFORMBLOCKINDEXPROC _glGetUniformBlockIndex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLuint glGetUniformBlockIndex(GLuint program, GLchar* uniformBlockName) => _glGetUniformBlockIndex(program, uniformBlockName);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint glGetUniformBlockIndex(GLuint program, string uniformBlockName)
    {
        byte[] uniformBlockNameBytes = Encoding.UTF8.GetBytes(uniformBlockName);
        fixed (GLchar* p = &uniformBlockNameBytes[0])
        {
            return _glGetUniformBlockIndex(program, p);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEUNIFORMBLOCKIVPROC(GLuint program, GLuint uniformBlockIndex, GLenum pname, GLint* parameters);
    private static PFNGLGETACTIVEUNIFORMBLOCKIVPROC _glGetActiveUniformBlockiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveUniformBlockiv(GLuint program, GLuint uniformBlockIndex, GLenum pname, GLint* parameters) => _glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetActiveUniformBlockiv(GLuint program, GLuint uniformBlockIndex, GLenum pname, ref GLint[] parameters) { fixed (GLint* p = &parameters[0]) { _glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC(GLuint program, GLuint uniformBlockIndex, GLsizei bufSize, GLsizei* length, GLchar* uniformBlockName);
    private static PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC _glGetActiveUniformBlockName;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveUniformBlockName(GLuint program, GLuint uniformBlockIndex, GLsizei bufSize, GLsizei* length, GLchar* uniformBlockName) => _glGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetActiveUniformBlockName(GLuint program, GLuint uniformBlockIndex, GLsizei bufSize)
    {
        GLchar* uniformBlockName = stackalloc GLchar[bufSize];
        GLsizei length;
        _glGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, &length, uniformBlockName);
        return new string((sbyte*)uniformBlockName, 0, length, Encoding.UTF8);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMBLOCKBINDINGPROC(GLuint program, GLuint uniformBlockIndex, GLuint uniformBlockBinding);
    private static PFNGLUNIFORMBLOCKBINDINGPROC _glUniformBlockBinding;
    public static void glUniformBlockBinding(GLuint program, GLuint uniformBlockIndex, GLuint uniformBlockBinding) => _glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);

#endif

    // OpenGL 3.2

#if OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_CONTEXT_CORE_PROFILE_BIT = 0x00000001;
    public const int GL_CONTEXT_COMPATIBILITY_PROFILE_BIT = 0x00000002;
    public const int GL_LINES_ADJACENCY = 0x000A;
    public const int GL_LINE_STRIP_ADJACENCY = 0x000B;
    public const int GL_TRIANGLES_ADJACENCY = 0x000C;
    public const int GL_TRIANGLE_STRIP_ADJACENCY = 0x000D;
    public const int GL_PROGRAM_POINT_SIZE = 0x8642;
    public const int GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29;
    public const int GL_FRAMEBUFFER_ATTACHMENT_LAYERED = 0x8DA7;
    public const int GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8;
    public const int GL_GEOMETRY_SHADER = 0x8DD9;
    public const int GL_GEOMETRY_VERTICES_OUT = 0x8916;
    public const int GL_GEOMETRY_INPUT_TYPE = 0x8917;
    public const int GL_GEOMETRY_OUTPUT_TYPE = 0x8918;
    public const int GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF;
    public const int GL_MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0;
    public const int GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1;
    public const int GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
    public const int GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123;
    public const int GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124;
    public const int GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
    public const int GL_CONTEXT_PROFILE_MASK = 0x9126;
    public const int GL_DEPTH_CLAMP = 0x864F;
    public const int GL_QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = 0x8E4C;
    public const int GL_FIRST_VERTEX_CONVENTION = 0x8E4D;
    public const int GL_LAST_VERTEX_CONVENTION = 0x8E4E;
    public const int GL_PROVOKING_VERTEX = 0x8E4F;
    public const int GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F;
    public const int GL_MAX_SERVER_WAIT_TIMEOUT = 0x9111;
    public const int GL_OBJECT_TYPE = 0x9112;
    public const int GL_SYNC_CONDITION = 0x9113;
    public const int GL_SYNC_STATUS = 0x9114;
    public const int GL_SYNC_FLAGS = 0x9115;
    public const int GL_SYNC_FENCE = 0x9116;
    public const int GL_SYNC_GPU_COMMANDS_COMPLETE = 0x9117;
    public const int GL_UNSIGNALED = 0x9118;
    public const int GL_SIGNALED = 0x9119;
    public const int GL_ALREADY_SIGNALED = 0x911A;
    public const int GL_TIMEOUT_EXPIRED = 0x911B;
    public const int GL_CONDITION_SATISFIED = 0x911C;
    public const int GL_WAIT_FAILED = 0x911D;
    public const ulong GL_TIMEOUT_IGNORED = 0xFFFFFFFFFFFFFFFFul; // TODO: Should be int?
    public const int GL_SYNC_FLUSH_COMMANDS_BIT = 0x00000001;
    public const int GL_SAMPLE_POSITION = 0x8E50;
    public const int GL_SAMPLE_MASK = 0x8E51;
    public const int GL_SAMPLE_MASK_VALUE = 0x8E52;
    public const int GL_MAX_SAMPLE_MASK_WORDS = 0x8E59;
    public const int GL_TEXTURE_2D_MULTISAMPLE = 0x9100;
    public const int GL_PROXY_TEXTURE_2D_MULTISAMPLE = 0x9101;
    public const int GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102;
    public const int GL_PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9103;
    public const int GL_TEXTURE_BINDING_2D_MULTISAMPLE = 0x9104;
    public const int GL_TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = 0x9105;
    public const int GL_TEXTURE_SAMPLES = 0x9106;
    public const int GL_TEXTURE_FIXED_SAMPLE_LOCATIONS = 0x9107;
    public const int GL_SAMPLER_2D_MULTISAMPLE = 0x9108;
    public const int GL_INT_SAMPLER_2D_MULTISAMPLE = 0x9109;
    public const int GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = 0x910A;
    public const int GL_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910B;
    public const int GL_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910C;
    public const int GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910D;
    public const int GL_MAX_COLOR_TEXTURE_SAMPLES = 0x910E;
    public const int GL_MAX_DEPTH_TEXTURE_SAMPLES = 0x910F;
    public const int GL_MAX_INTEGER_SAMPLES = 0x9110;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSBASEVERTEXPROC(GLenum mode, GLsizei count, GLenum type, void* indices, GLint basevertex);
    private static PFNGLDRAWELEMENTSBASEVERTEXPROC _glDrawElementsBaseVertex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElementsBaseVertex(GLenum mode, GLsizei count, GLenum type, void* indices, GLint basevertex) => _glDrawElementsBaseVertex(mode, count, type, indices, basevertex);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElementsBaseVertex<T>(GLenum mode, GLsizei count, GLenum type, T[] indices, GLint basevertex) where T : unmanaged, IUnsignedNumber<T> { fixed (void* p = &indices[0]) _glDrawElementsBaseVertex(mode, count, type, p, basevertex); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, void* indices, GLint basevertex);
    private static PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC _glDrawRangeElementsBaseVertex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawRangeElementsBaseVertex(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, void* indices, GLint basevertex) => _glDrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawRangeElementsBaseVertex<T>(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, T[] indices, GLint basevertex) where T : unmanaged, IUnsignedNumber<T> { fixed (void* p = &indices[0]) _glDrawRangeElementsBaseVertex(mode, start, end, count, type, p, basevertex); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount, GLint basevertex);
    private static PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC _glDrawElementsInstancedBaseVertex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElementsInstancedBaseVertex(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount, GLint basevertex) => _glDrawElementsInstancedBaseVertex(mode, count, type, indices, instancecount, basevertex);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElementsInstancedBaseVertex<T>(GLenum mode, GLsizei count, GLenum type, T[] indices, GLsizei instancecount, GLint basevertex) where T : unmanaged, IUnsignedNumber<T> { fixed (void* p = &indices[0]) _glDrawElementsInstancedBaseVertex(mode, count, type, p, instancecount, basevertex); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC(GLenum mode, GLsizei* count, GLenum type, void** indices, GLsizei drawcount, GLint* basevertex);
    private static PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC _glMultiDrawElementsBaseVertex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawElementsBaseVertex(GLenum mode, GLsizei* count, GLenum type, void** indices, GLsizei drawcount, GLint* basevertex) => _glMultiDrawElementsBaseVertex(mode, count, type, indices, drawcount, basevertex);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawElementsBaseVertex<T>(GLenum mode, GLenum type, T[][] indices, GLint[] basevertex) where T : unmanaged, IUnsignedNumber<T>
    {
        if (indices.Length != basevertex.Length) throw new ArgumentException("indices and basevertex must have the same length");

        GLsizei[] counts = new GLsizei[indices.Length];
        T*[] indexPtrs = new T*[indices.Length];
        for (int i = 0; i < indices.Length; i++)
        {
            counts[i] = (GLsizei)indices[i].Length;
            fixed (T* p = &indices[i][0]) indexPtrs[i] = p;
        }
        fixed (GLsizei* cp = &counts[0])
        fixed (GLint* bvp = &basevertex[0])
        fixed (T** ip = &indexPtrs[0])
        {
            _glMultiDrawElementsBaseVertex(mode, cp, type, (void**)ip, indices.Length, bvp);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROVOKINGVERTEXPROC(GLenum mode);
    private static PFNGLPROVOKINGVERTEXPROC _glProvokingVertex;
    public static void glProvokingVertex(GLenum mode) => _glProvokingVertex(mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void* PFNGLFENCESYNCPROC(GLenum condition, GLbitfield flags);
    private static PFNGLFENCESYNCPROC _glFenceSync;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void* glFenceSync(GLenum condition, GLbitfield flags) => _glFenceSync(condition, flags);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static IntPtr glFenceSyncSafe(GLenum condition, GLbitfield flags) => new IntPtr(_glFenceSync(condition, flags));
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISSYNCPROC(void* sync);
    private static PFNGLISSYNCPROC _glIsSync;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLboolean glIsSync(void* sync) => _glIsSync(sync);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLboolean glIsSyncSafe(IntPtr sync) => _glIsSync(sync.ToPointer());
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETESYNCPROC(void* sync);
    private static PFNGLDELETESYNCPROC _glDeleteSync;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteSync(void* sync) => _glDeleteSync(sync);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteSyncSafe(IntPtr sync) => _glDeleteSync(sync.ToPointer());
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLenum PFNGLCLIENTWAITSYNCPROC(void* sync, GLbitfield flags, GLuint64 timeout);
    private static PFNGLCLIENTWAITSYNCPROC _glClientWaitSync;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLenum glClientWaitSync(void* sync, GLbitfield flags, GLuint64 timeout) => _glClientWaitSync(sync, flags, timeout);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLenum glClientWaitSyncSafe(IntPtr sync, GLbitfield flags, GLuint64 timeout) => _glClientWaitSync(sync.ToPointer(), flags, timeout);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLWAITSYNCPROC(void* sync, GLbitfield flags, GLuint64 timeout);
    private static PFNGLWAITSYNCPROC _glWaitSync;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glWaitSync(void* sync, GLbitfield flags, GLuint64 timeout) => _glWaitSync(sync, flags, timeout);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glWaitSyncSafe(IntPtr sync, GLbitfield flags, GLuint64 timeout) => _glWaitSync(sync.ToPointer(), flags, timeout);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETINTEGER64VPROC(GLenum pname, GLint64* data);
    private static PFNGLGETINTEGER64VPROC _glGetInteger64v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetInteger64v(GLenum pname, GLint64* data) => _glGetInteger64v(pname, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetInteger64vSafe(GLenum pname, ref GLint64[] data) { fixed (GLint64* dp = &data[0]) _glGetInteger64v(pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSYNCIVPROC(void* sync, GLenum pname, GLsizei bufSize, GLsizei* length, GLint* values);
    private static PFNGLGETSYNCIVPROC _glGetSynciv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetSynciv(void* sync, GLenum pname, GLsizei bufSize, GLsizei* length, GLint* values) => _glGetSynciv(sync, pname, bufSize, length, values);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint[] glGetSynciv(IntPtr sync, GLenum pname, GLsizei bufSize)
    {
        GLint[] ret = new GLint[bufSize];
        fixed (GLint* dp = &ret[0])
        {
            GLsizei len;
            _glGetSynciv(sync.ToPointer(), pname, bufSize, &len, dp);
            Array.Resize(ref ret, len);
        }
        return ret;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETINTEGER64I_VPROC(GLenum target, GLuint index, GLint64* data);
    private static PFNGLGETINTEGER64I_VPROC _glGetInteger64i_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetInteger64i_v(GLenum target, GLuint index, GLint64* data) => _glGetInteger64i_v(target, index, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetInteger64i_vSafe(GLenum target, GLuint index, ref GLint64[] data) { fixed (GLint64* dp = &data[0]) _glGetInteger64i_v(target, index, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETBUFFERPARAMETERI64VPROC(GLenum target, GLenum pname, GLint64* parameters);
    private static PFNGLGETBUFFERPARAMETERI64VPROC _glGetBufferParameteri64v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetBufferParameteri64v(GLenum target, GLenum pname, GLint64* parameters) => _glGetBufferParameteri64v(target, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetBufferParameteri64vSafe(GLenum target, GLenum pname, ref GLint64[] parameters) { fixed (GLint64* dp = &parameters[0]) _glGetBufferParameteri64v(target, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERTEXTUREPROC(GLenum target, GLenum attachment, GLuint texture, GLint level);
    private static PFNGLFRAMEBUFFERTEXTUREPROC _glFramebufferTexture;
    public static void glFramebufferTexture(GLenum target, GLenum attachment, GLuint texture, GLint level) => _glFramebufferTexture(target, attachment, texture, level);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXIMAGE2DMULTISAMPLEPROC(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);
    private static PFNGLTEXIMAGE2DMULTISAMPLEPROC _glTexImage2DMultisample;
    public static void glTexImage2DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations) => _glTexImage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXIMAGE3DMULTISAMPLEPROC(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);
    private static PFNGLTEXIMAGE3DMULTISAMPLEPROC _glTexImage3DMultisample;
    public static void glTexImage3DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations) => _glTexImage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETMULTISAMPLEFVPROC(GLenum pname, GLuint index, GLfloat* val);
    private static PFNGLGETMULTISAMPLEFVPROC _glGetMultisamplefv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetMultisamplefv(GLenum pname, GLuint index, GLfloat* val) => _glGetMultisamplefv(pname, index, val);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetMultisamplefvSafe(GLenum pname, GLuint index, ref GLfloat[] val) { fixed (GLfloat* dp = &val[0]) _glGetMultisamplefv(pname, index, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLEMASKIPROC(GLuint maskNumber, GLbitfield mask);
    private static PFNGLSAMPLEMASKIPROC _glSampleMaski;
    public static void glSampleMaski(GLuint maskNumber, GLbitfield mask) => _glSampleMaski(maskNumber, mask);

#endif

    // OpenGL 3.3

#if OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;
    public const int GL_SRC1_COLOR = 0x88F9;
    public const int GL_ONE_MINUS_SRC1_COLOR = 0x88FA;
    public const int GL_ONE_MINUS_SRC1_ALPHA = 0x88FB;
    public const int GL_MAX_DUAL_SOURCE_DRAW_BUFFERS = 0x88FC;
    public const int GL_ANY_SAMPLES_PASSED = 0x8C2F;
    public const int GL_SAMPLER_BINDING = 0x8919;
    public const int GL_RGB10_A2UI = 0x906F;
    public const int GL_TEXTURE_SWIZZLE_R = 0x8E42;
    public const int GL_TEXTURE_SWIZZLE_G = 0x8E43;
    public const int GL_TEXTURE_SWIZZLE_B = 0x8E44;
    public const int GL_TEXTURE_SWIZZLE_A = 0x8E45;
    public const int GL_TEXTURE_SWIZZLE_RGBA = 0x8E46;
    public const int GL_TIME_ELAPSED = 0x88BF;
    public const int GL_TIMESTAMP = 0x8E28;
    public const int GL_INT_2_10_10_10_REV = 0x8D9F;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDFRAGDATALOCATIONINDEXEDPROC(GLuint program, GLuint colorNumber, GLuint index, GLchar* name);
    private static PFNGLBINDFRAGDATALOCATIONINDEXEDPROC _glBindFragDataLocationIndexed;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindFragDataLocationIndexed(GLuint program, GLuint colorNumber, GLuint index, GLchar* name) => _glBindFragDataLocationIndexed(program, colorNumber, index, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindFragDataLocationIndexed(GLuint program, GLuint colorNumber, GLuint index, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p = &nameBytes[0])
            _glBindFragDataLocationIndexed(program, colorNumber, index, p);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETFRAGDATAINDEXPROC(GLuint program, GLchar* name);
    private static PFNGLGETFRAGDATAINDEXPROC _glGetFragDataIndex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetFragDataIndex(GLuint program, GLchar* name) => _glGetFragDataIndex(program, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetFragDataIndex(GLuint program, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p = &nameBytes[0])
            return _glGetFragDataIndex(program, p);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENSAMPLERSPROC(GLsizei count, GLuint* samplers);
    private static PFNGLGENSAMPLERSPROC _glGenSamplers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenSamplers(GLsizei count, GLuint* samplers) => _glGenSamplers(count, samplers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenSamplers(GLsizei count) { GLuint[] result = new GLuint[count]; fixed (GLuint* dp = &result[0]) _glGenSamplers(count, dp); return result; }
    public static GLuint glGenSampler() => glGenSamplers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETESAMPLERSPROC(GLsizei count, GLuint* samplers);
    private static PFNGLDELETESAMPLERSPROC _glDeleteSamplers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteSamplers(GLsizei count, GLuint* samplers) => _glDeleteSamplers(count, samplers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteSamplers(params GLuint[] samplers) { fixed (GLuint* dp = &samplers[0]) _glDeleteSamplers(samplers.Length, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISSAMPLERPROC(GLuint sampler);
    private static PFNGLISSAMPLERPROC _glIsSampler;
    public static GLboolean glIsSampler(GLuint sampler) => _glIsSampler(sampler);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDSAMPLERPROC(GLuint unit, GLuint sampler);
    private static PFNGLBINDSAMPLERPROC _glBindSampler;
    public static void glBindSampler(GLuint unit, GLuint sampler) => _glBindSampler(unit, sampler);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLERPARAMETERIPROC(GLuint sampler, GLenum pname, GLint param);
    private static PFNGLSAMPLERPARAMETERIPROC _glSamplerParameteri;
    public static void glSamplerParameteri(GLuint sampler, GLenum pname, GLint param) => _glSamplerParameteri(sampler, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLERPARAMETERIVPROC(GLuint sampler, GLenum pname, GLint* param);
    private static PFNGLSAMPLERPARAMETERIVPROC _glSamplerParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glSamplerParameteriv(GLuint sampler, GLenum pname, GLint* param) => _glSamplerParameteriv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glSamplerParameteriv(GLuint sampler, GLenum pname, GLint[] param) { fixed (GLint* dp = &param[0]) _glSamplerParameteriv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLERPARAMETERFPROC(GLuint sampler, GLenum pname, GLfloat param);
    private static PFNGLSAMPLERPARAMETERFPROC _glSamplerParameterf;
    public static void glSamplerParameterf(GLuint sampler, GLenum pname, GLfloat param) => _glSamplerParameterf(sampler, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLERPARAMETERFVPROC(GLuint sampler, GLenum pname, GLfloat* param);
    private static PFNGLSAMPLERPARAMETERFVPROC _glSamplerParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glSamplerParameterfv(GLuint sampler, GLenum pname, GLfloat* param) => _glSamplerParameterfv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glSamplerParameterfv(GLuint sampler, GLenum pname, GLfloat[] param) { fixed (GLfloat* dp = &param[0]) _glSamplerParameterfv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLERPARAMETERIIVPROC(GLuint sampler, GLenum pname, GLint* param);
    private static PFNGLSAMPLERPARAMETERIIVPROC _glSamplerParameterIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glSamplerParameterIiv(GLuint sampler, GLenum pname, GLint* param) => _glSamplerParameterIiv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glSamplerParameterIiv(GLuint sampler, GLenum pname, GLint[] param) { fixed (GLint* dp = &param[0]) _glSamplerParameterIiv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSAMPLERPARAMETERIUIVPROC(GLuint sampler, GLenum pname, GLuint* param);
    private static PFNGLSAMPLERPARAMETERIUIVPROC _glSamplerParameterIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glSamplerParameterIuiv(GLuint sampler, GLenum pname, GLuint* param) => _glSamplerParameterIuiv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glSamplerParameterIuiv(GLuint sampler, GLenum pname, GLuint[] param) { fixed (GLuint* dp = &param[0]) _glSamplerParameterIuiv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSAMPLERPARAMETERIVPROC(GLuint sampler, GLenum pname, GLint* param);
    private static PFNGLGETSAMPLERPARAMETERIVPROC _glGetSamplerParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetSamplerParameteriv(GLuint sampler, GLenum pname, GLint* param) => _glGetSamplerParameteriv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetSamplerParameteriv(GLuint sampler, GLenum pname, ref GLint[] param) { fixed (GLint* dp = &param[0]) _glGetSamplerParameteriv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSAMPLERPARAMETERIIVPROC(GLuint sampler, GLenum pname, GLint* param);
    private static PFNGLGETSAMPLERPARAMETERIIVPROC _glGetSamplerParameterIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetSamplerParameterIiv(GLuint sampler, GLenum pname, GLint* param) => _glGetSamplerParameterIiv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetSamplerParameterIiv(GLuint sampler, GLenum pname, ref GLint[] param) { fixed (GLint* dp = &param[0]) _glGetSamplerParameterIiv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSAMPLERPARAMETERFVPROC(GLuint sampler, GLenum pname, GLfloat* param);
    private static PFNGLGETSAMPLERPARAMETERFVPROC _glGetSamplerParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetSamplerParameterfv(GLuint sampler, GLenum pname, GLfloat* param) => _glGetSamplerParameterfv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetSamplerParameterfv(GLuint sampler, GLenum pname, ref GLfloat[] param) { fixed (GLfloat* dp = &param[0]) _glGetSamplerParameterfv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSAMPLERPARAMETERIUIVPROC(GLuint sampler, GLenum pname, GLuint* param);
    private static PFNGLGETSAMPLERPARAMETERIUIVPROC _glGetSamplerParameterIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetSamplerParameterIuiv(GLuint sampler, GLenum pname, GLuint* param) => _glGetSamplerParameterIuiv(sampler, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetSamplerParameterIuiv(GLuint sampler, GLenum pname, ref GLuint[] param) { fixed (GLuint* dp = &param[0]) _glGetSamplerParameterIuiv(sampler, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLQUERYCOUNTERPROC(GLuint id, GLenum target);
    private static PFNGLQUERYCOUNTERPROC _glQueryCounter;
    public static void glQueryCounter(GLuint id, GLenum target) => _glQueryCounter(id, target);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYOBJECTI64VPROC(GLuint id, GLenum pname, GLint64* param);
    private static PFNGLGETQUERYOBJECTI64VPROC _glGetQueryObjecti64v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetQueryObjecti64v(GLuint id, GLenum pname, GLint64* param) => _glGetQueryObjecti64v(id, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetQueryObjecti64v(GLuint id, GLenum pname, ref GLint64[] param) { fixed (GLint64* dp = &param[0]) _glGetQueryObjecti64v(id, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYOBJECTUI64VPROC(GLuint id, GLenum pname, GLuint64* param);
    private static PFNGLGETQUERYOBJECTUI64VPROC _glGetQueryObjectui64v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetQueryObjectui64v(GLuint id, GLenum pname, GLuint64* param) => _glGetQueryObjectui64v(id, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetQueryObjectui64v(GLuint id, GLenum pname, ref GLuint64[] param) { fixed (GLuint64* dp = &param[0]) _glGetQueryObjectui64v(id, pname, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBDIVISORPROC(GLuint index, GLuint divisor);
    private static PFNGLVERTEXATTRIBDIVISORPROC _glVertexAttribDivisor;
    public static void glVertexAttribDivisor(GLuint index, GLuint divisor) => _glVertexAttribDivisor(index, divisor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP1UIPROC(GLuint index, GLenum type, GLboolean normalized, GLuint value);
    private static PFNGLVERTEXATTRIBP1UIPROC _glVertexAttribP1ui;
    public static void glVertexAttribP1ui(GLuint index, GLenum type, GLboolean normalized, GLuint value) => _glVertexAttribP1ui(index, type, normalized, value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP1UIVPROC(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
    private static PFNGLVERTEXATTRIBP1UIVPROC _glVertexAttribP1uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribP1uiv(GLuint index, GLenum type, GLboolean normalized, GLuint* value) => _glVertexAttribP1uiv(index, type, normalized, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribP1uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value) { fixed (GLuint* dp = &value[0]) _glVertexAttribP1uiv(index, type, normalized, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP2UIPROC(GLuint index, GLenum type, GLboolean normalized, GLuint value);
    private static PFNGLVERTEXATTRIBP2UIPROC _glVertexAttribP2ui;
    public static void glVertexAttribP2ui(GLuint index, GLenum type, GLboolean normalized, GLuint value) => _glVertexAttribP2ui(index, type, normalized, value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP2UIVPROC(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
    private static PFNGLVERTEXATTRIBP2UIVPROC _glVertexAttribP2uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribP2uiv(GLuint index, GLenum type, GLboolean normalized, GLuint* value) => _glVertexAttribP2uiv(index, type, normalized, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribP2uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value) { fixed (GLuint* dp = &value[0]) _glVertexAttribP2uiv(index, type, normalized, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP3UIPROC(GLuint index, GLenum type, GLboolean normalized, GLuint value);
    private static PFNGLVERTEXATTRIBP3UIPROC _glVertexAttribP3ui;
    public static void glVertexAttribP3ui(GLuint index, GLenum type, GLboolean normalized, GLuint value) => _glVertexAttribP3ui(index, type, normalized, value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP3UIVPROC(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
    private static PFNGLVERTEXATTRIBP3UIVPROC _glVertexAttribP3uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribP3uiv(GLuint index, GLenum type, GLboolean normalized, GLuint* value) => _glVertexAttribP3uiv(index, type, normalized, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribP3uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value) { fixed (GLuint* dp = &value[0]) _glVertexAttribP3uiv(index, type, normalized, dp); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP4UIPROC(GLuint index, GLenum type, GLboolean normalized, GLuint value);
    private static PFNGLVERTEXATTRIBP4UIPROC _glVertexAttribP4ui;
    public static void glVertexAttribP4ui(GLuint index, GLenum type, GLboolean normalized, GLuint value) => _glVertexAttribP4ui(index, type, normalized, value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBP4UIVPROC(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
    private static PFNGLVERTEXATTRIBP4UIVPROC _glVertexAttribP4uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribP4uiv(GLuint index, GLenum type, GLboolean normalized, GLuint* value) => _glVertexAttribP4uiv(index, type, normalized, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribP4uiv(GLuint index, GLenum type, GLboolean normalized, GLuint[] value) { fixed (GLuint* dp = &value[0]) _glVertexAttribP4uiv(index, type, normalized, dp); }
#endif

#endif

    // OpenGL 4.0

#if OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_SAMPLE_SHADING = 0x8C36;
    public const int GL_MIN_SAMPLE_SHADING_VALUE = 0x8C37;
    public const int GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5E;
    public const int GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5F;
    public const int GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009;
    public const int GL_TEXTURE_BINDING_CUBE_MAP_ARRAY = 0x900A;
    public const int GL_PROXY_TEXTURE_CUBE_MAP_ARRAY = 0x900B;
    public const int GL_SAMPLER_CUBE_MAP_ARRAY = 0x900C;
    public const int GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW = 0x900D;
    public const int GL_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900E;
    public const int GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900F;
    public const int GL_DRAW_INDIRECT_BUFFER = 0x8F3F;
    public const int GL_DRAW_INDIRECT_BUFFER_BINDING = 0x8F43;
    public const int GL_GEOMETRY_SHADER_INVOCATIONS = 0x887F;
    public const int GL_MAX_GEOMETRY_SHADER_INVOCATIONS = 0x8E5A;
    public const int GL_MIN_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5B;
    public const int GL_MAX_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5C;
    public const int GL_FRAGMENT_INTERPOLATION_OFFSET_BITS = 0x8E5D;
    public const int GL_MAX_VERTEX_STREAMS = 0x8E71;
    public const int GL_DOUBLE_VEC2 = 0x8FFC;
    public const int GL_DOUBLE_VEC3 = 0x8FFD;
    public const int GL_DOUBLE_VEC4 = 0x8FFE;
    public const int GL_DOUBLE_MAT2 = 0x8F46;
    public const int GL_DOUBLE_MAT3 = 0x8F47;
    public const int GL_DOUBLE_MAT4 = 0x8F48;
    public const int GL_DOUBLE_MAT2x3 = 0x8F49;
    public const int GL_DOUBLE_MAT2x4 = 0x8F4A;
    public const int GL_DOUBLE_MAT3x2 = 0x8F4B;
    public const int GL_DOUBLE_MAT3x4 = 0x8F4C;
    public const int GL_DOUBLE_MAT4x2 = 0x8F4D;
    public const int GL_DOUBLE_MAT4x3 = 0x8F4E;
    public const int GL_ACTIVE_SUBROUTINES = 0x8DE5;
    public const int GL_ACTIVE_SUBROUTINE_UNIFORMS = 0x8DE6;
    public const int GL_ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS = 0x8E47;
    public const int GL_ACTIVE_SUBROUTINE_MAX_LENGTH = 0x8E48;
    public const int GL_ACTIVE_SUBROUTINE_UNIFORM_MAX_LENGTH = 0x8E49;
    public const int GL_MAX_SUBROUTINES = 0x8DE7;
    public const int GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS = 0x8DE8;
    public const int GL_NUM_COMPATIBLE_SUBROUTINES = 0x8E4A;
    public const int GL_COMPATIBLE_SUBROUTINES = 0x8E4B;
    public const int GL_PATCHES = 0x000E;
    public const int GL_PATCH_VERTICES = 0x8E72;
    public const int GL_PATCH_DEFAULT_INNER_LEVEL = 0x8E73;
    public const int GL_PATCH_DEFAULT_OUTER_LEVEL = 0x8E74;
    public const int GL_TESS_CONTROL_OUTPUT_VERTICES = 0x8E75;
    public const int GL_TESS_GEN_MODE = 0x8E76;
    public const int GL_TESS_GEN_SPACING = 0x8E77;
    public const int GL_TESS_GEN_VERTEX_ORDER = 0x8E78;
    public const int GL_TESS_GEN_POINT_MODE = 0x8E79;
    public const int GL_ISOLINES = 0x8E7A;
    public const int GL_FRACTIONAL_ODD = 0x8E7B;
    public const int GL_FRACTIONAL_EVEN = 0x8E7C;
    public const int GL_MAX_PATCH_VERTICES = 0x8E7D;
    public const int GL_MAX_TESS_GEN_LEVEL = 0x8E7E;
    public const int GL_MAX_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E7F;
    public const int GL_MAX_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E80;
    public const int GL_MAX_TESS_CONTROL_TEXTURE_IMAGE_UNITS = 0x8E81;
    public const int GL_MAX_TESS_EVALUATION_TEXTURE_IMAGE_UNITS = 0x8E82;
    public const int GL_MAX_TESS_CONTROL_OUTPUT_COMPONENTS = 0x8E83;
    public const int GL_MAX_TESS_PATCH_COMPONENTS = 0x8E84;
    public const int GL_MAX_TESS_CONTROL_TOTAL_OUTPUT_COMPONENTS = 0x8E85;
    public const int GL_MAX_TESS_EVALUATION_OUTPUT_COMPONENTS = 0x8E86;
    public const int GL_MAX_TESS_CONTROL_UNIFORM_BLOCKS = 0x8E89;
    public const int GL_MAX_TESS_EVALUATION_UNIFORM_BLOCKS = 0x8E8A;
    public const int GL_MAX_TESS_CONTROL_INPUT_COMPONENTS = 0x886C;
    public const int GL_MAX_TESS_EVALUATION_INPUT_COMPONENTS = 0x886D;
    public const int GL_MAX_COMBINED_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E1E;
    public const int GL_MAX_COMBINED_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E1F;
    public const int GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_CONTROL_SHADER = 0x84F0;
    public const int GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x84F1;
    public const int GL_TESS_EVALUATION_SHADER = 0x8E87;
    public const int GL_TESS_CONTROL_SHADER = 0x8E88;
    public const int GL_TRANSFORM_FEEDBACK = 0x8E22;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED = 0x8E23;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE = 0x8E24;
    public const int GL_TRANSFORM_FEEDBACK_BINDING = 0x8E25;
    public const int GL_MAX_TRANSFORM_FEEDBACK_BUFFERS = 0x8E70;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMINSAMPLESHADINGPROC(GLfloat value);
    private static PFNGLMINSAMPLESHADINGPROC _glMinSampleShading;
    public static void glMinSampleShading(GLfloat value) { _glMinSampleShading(value); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDEQUATIONIPROC(GLuint buf, GLenum mode);
    private static PFNGLBLENDEQUATIONIPROC _glBlendEquationi;
    public static void glBlendEquationi(GLuint buf, GLenum mode) { _glBlendEquationi(buf, mode); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDEQUATIONSEPARATEIPROC(GLuint buf, GLenum modeRGB, GLenum modeAlpha);
    private static PFNGLBLENDEQUATIONSEPARATEIPROC _glBlendEquationSeparatei;
    public static void glBlendEquationSeparatei(GLuint buf, GLenum modeRGB, GLenum modeAlpha) { _glBlendEquationSeparatei(buf, modeRGB, modeAlpha); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDFUNCIPROC(GLuint buf, GLenum src, GLenum dst);
    private static PFNGLBLENDFUNCIPROC _glBlendFunci;
    public static void glBlendFunci(GLuint buf, GLenum src, GLenum dst) { _glBlendFunci(buf, src, dst); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLENDFUNCSEPARATEIPROC(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);
    private static PFNGLBLENDFUNCSEPARATEIPROC _glBlendFuncSeparatei;
    public static void glBlendFuncSeparatei(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha) { _glBlendFuncSeparatei(buf, srcRGB, dstRGB, srcAlpha, dstAlpha); }

#if OGL_V_4_0 || OGL_V_4_1 
    public struct DrawArraysIndirectCommand
    {
        public GLuint count;
        public GLuint primCount;
        public GLuint first;
        public GLuint reservedMustBeZero;
    }
#endif
#if OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
    public struct DrawArraysIndirectCommand
    {
        public GLuint count;
        public GLuint instanceCount;
        public GLuint first;
        public GLuint baseInstance;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWARRAYSINDIRECTPROC(GLenum mode, void* indirect);
    private static PFNGLDRAWARRAYSINDIRECTPROC _glDrawArraysIndirect;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawArraysIndirect(GLenum mode, void* indirect) { _glDrawArraysIndirect(mode, indirect); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawArraysIndirect(GLenum mode, DrawArraysIndirectCommand indirect) { _glDrawArraysIndirect(mode, &indirect); }
#endif

#if (OGL_V_4_0 || OGL_V_4_1) && (OGL_WRAPPER_API_SAFE || OGL_WRAPPER_API_BOTH) 
    public struct DrawElementsIndirectCommand
    {
        public GLuint count;
        public GLuint primCount;
        public GLuint firstIndex;
        public GLuint baseVertex;
        public GLuint reservedMustBeZero;
    }
#endif
#if (OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6) && (OGL_WRAPPER_API_SAFE || OGL_WRAPPER_API_BOTH)  
    public struct DrawElementsIndirectCommand
    {
        public GLuint count;
        public GLuint primCount;
        public GLuint firstIndex;
        public GLuint baseVertex;
        public GLuint baseInstance;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSINDIRECTPROC(GLenum mode, GLenum type, void* indirect);
    private static PFNGLDRAWELEMENTSINDIRECTPROC _glDrawElementsIndirect;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElementsIndirect(GLenum mode, GLenum type, void* indirect) { _glDrawElementsIndirect(mode, type, indirect); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElementsIndirect(GLenum mode, GLenum type, DrawElementsIndirectCommand indirect) { _glDrawElementsIndirect(mode, type, &indirect); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1DPROC(GLint location, GLdouble x);
    private static PFNGLUNIFORM1DPROC _glUniform1d;
    public static void glUniform1d(GLint location, GLdouble x) { _glUniform1d(location, x); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2DPROC(GLint location, GLdouble x, GLdouble y);
    private static PFNGLUNIFORM2DPROC _glUniform2d;
    public static void glUniform2d(GLint location, GLdouble x, GLdouble y) { _glUniform2d(location, x, y); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3DPROC(GLint location, GLdouble x, GLdouble y, GLdouble z);
    private static PFNGLUNIFORM3DPROC _glUniform3d;
    public static void glUniform3d(GLint location, GLdouble x, GLdouble y, GLdouble z) { _glUniform3d(location, x, y, z); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4DPROC(GLint location, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
    private static PFNGLUNIFORM4DPROC _glUniform4d;
    public static void glUniform4d(GLint location, GLdouble x, GLdouble y, GLdouble z, GLdouble w) { _glUniform4d(location, x, y, z, w); }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM1DVPROC(GLint location, GLsizei count, GLdouble* value);
    private static PFNGLUNIFORM1DVPROC _glUniform1dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform1dv(GLint location, GLsizei count, GLdouble* value) { _glUniform1dv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform1dv(GLint location, GLsizei count, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniform1dv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM2DVPROC(GLint location, GLsizei count, GLdouble* value);
    private static PFNGLUNIFORM2DVPROC _glUniform2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform2dv(GLint location, GLsizei count, GLdouble* value) { _glUniform2dv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform2dv(GLint location, GLsizei count, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniform2dv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM3DVPROC(GLint location, GLsizei count, GLdouble* value);
    private static PFNGLUNIFORM3DVPROC _glUniform3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform3dv(GLint location, GLsizei count, GLdouble* value) { _glUniform3dv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform3dv(GLint location, GLsizei count, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniform3dv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORM4DVPROC(GLint location, GLsizei count, GLdouble* value);
    private static PFNGLUNIFORM4DVPROC _glUniform4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniform4dv(GLint location, GLsizei count, GLdouble* value) { _glUniform4dv(location, count, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniform4dv(GLint location, GLsizei count, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniform4dv(location, count, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX2DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX2DVPROC _glUniformMatrix2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix2dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix2dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX3DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX3DVPROC _glUniformMatrix3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix3dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix3dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX4DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX4DVPROC _glUniformMatrix4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix4dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix4dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX2X3DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX2X3DVPROC _glUniformMatrix2x3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix2x3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix2x3dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix2x3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix2x3dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX2X4DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX2X4DVPROC _glUniformMatrix2x4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix2x4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix2x4dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix2x4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix2x4dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX3X2DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX3X2DVPROC _glUniformMatrix3x2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix3x2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix3x2dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix3x2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix3x2dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX3X4DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX3X4DVPROC _glUniformMatrix3x4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix3x4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix3x4dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix3x4dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix3x4dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX4X2DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX4X2DVPROC _glUniformMatrix4x2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix4x2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix4x2dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix4x2dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix4x2dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMMATRIX4X3DVPROC(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLUNIFORMMATRIX4X3DVPROC _glUniformMatrix4x3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformMatrix4x3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble* value) { _glUniformMatrix4x3dv(location, count, transpose, value); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformMatrix4x3dv(GLint location, GLsizei count, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* p = &value[0]) _glUniformMatrix4x3dv(location, count, transpose, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETUNIFORMDVPROC(GLuint program, GLint location, GLdouble* parameters);
    private static PFNGLGETUNIFORMDVPROC _glGetUniformdv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetUniformdv(GLuint program, GLint location, GLdouble* parameters) { _glGetUniformdv(program, location, parameters); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetUniformdv(GLuint program, GLint location, GLdouble[] parameters) { fixed (GLdouble* p = &parameters[0]) _glGetUniformdv(program, location, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETSUBROUTINEUNIFORMLOCATIONPROC(GLuint program, GLenum shadertype, GLchar* name);
    private static PFNGLGETSUBROUTINEUNIFORMLOCATIONPROC _glGetSubroutineUniformLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetSubroutineUniformLocation(GLuint program, GLenum shadertype, GLchar* name) { return _glGetSubroutineUniformLocation(program, shadertype, name); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetSubroutineUniformLocation(GLuint program, GLenum shadertype, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p = &nameBytes[0])
        {
            return _glGetSubroutineUniformLocation(program, shadertype, p);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLGETSUBROUTINEINDEXPROC(GLuint program, GLenum shadertype, GLchar* name);
    private static PFNGLGETSUBROUTINEINDEXPROC _glGetSubroutineIndex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLuint glGetSubroutineIndex(GLuint program, GLenum shadertype, GLchar* name) { return _glGetSubroutineIndex(program, shadertype, name); }
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint glGetSubroutineIndex(GLuint program, GLenum shadertype, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p = &nameBytes[0])
        {
            return _glGetSubroutineIndex(program, shadertype, p);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVESUBROUTINEUNIFORMIVPROC(GLuint program, GLenum shadertype, GLuint index, GLenum pname, GLint* values);
    private static PFNGLGETACTIVESUBROUTINEUNIFORMIVPROC _glGetActiveSubroutineUniformiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveSubroutineUniformiv(GLuint program, GLenum shadertype, GLuint index, GLenum pname, GLint* values) => _glGetActiveSubroutineUniformiv(program, shadertype, index, pname, values);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetActiveSubroutineUniformiv(GLuint program, GLenum shadertype, GLuint index, GLenum pname, ref GLint[] values) { fixed (GLint* p = &values[0]) _glGetActiveSubroutineUniformiv(program, shadertype, index, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVESUBROUTINEUNIFORMNAMEPROC(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize, GLsizei* length, GLchar* name);
    private static PFNGLGETACTIVESUBROUTINEUNIFORMNAMEPROC _glGetActiveSubroutineUniformName;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveSubroutineUniformName(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize, GLsizei* length, GLchar* name) => _glGetActiveSubroutineUniformName(program, shadertype, index, bufsize, length, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetActiveSubroutineUniformName(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize)
    {
        GLchar[] name = new GLchar[bufsize];
        GLsizei length;
        fixed (GLchar* p = &name[0])
        {
            _glGetActiveSubroutineUniformName(program, shadertype, index, bufsize, &length, p);
            return new string((sbyte*)p, 0, length, Encoding.UTF8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVESUBROUTINENAMEPROC(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize, GLsizei* length, GLchar* name);
    private static PFNGLGETACTIVESUBROUTINENAMEPROC _glGetActiveSubroutineName;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveSubroutineName(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize, GLsizei* length, GLchar* name) => _glGetActiveSubroutineName(program, shadertype, index, bufsize, length, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetActiveSubroutineName(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize)
    {
        GLchar[] name = new GLchar[bufsize];
        GLsizei length;
        fixed (GLchar* p = &name[0])
        {
            _glGetActiveSubroutineName(program, shadertype, index, bufsize, &length, p);
            return new string((sbyte*)p, 0, length, Encoding.UTF8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUNIFORMSUBROUTINESUIVPROC(GLenum shadertype, GLsizei count, GLuint* indices);
    private static PFNGLUNIFORMSUBROUTINESUIVPROC _glUniformSubroutinesuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glUniformSubroutinesuiv(GLenum shadertype, GLsizei count, GLuint* indices) => _glUniformSubroutinesuiv(shadertype, count, indices);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glUniformSubroutinesuiv(GLenum shadertype, GLuint[] indices) { fixed (GLuint* p = &indices[0]) _glUniformSubroutinesuiv(shadertype, indices.Length, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETUNIFORMSUBROUTINEUIVPROC(GLenum shadertype, GLint location, GLuint* @params);
    private static PFNGLGETUNIFORMSUBROUTINEUIVPROC _glGetUniformSubroutineuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetUniformSubroutineuiv(GLenum shadertype, GLint location, GLuint* @params) => _glGetUniformSubroutineuiv(shadertype, location, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetUniformSubroutineuiv(GLenum shadertype, GLint location, ref GLuint[] @params) { fixed (GLuint* p = &@params[0]) _glGetUniformSubroutineuiv(shadertype, location, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMSTAGEIVPROC(GLuint program, GLenum shadertype, GLenum pname, GLint* values);
    private static PFNGLGETPROGRAMSTAGEIVPROC _glGetProgramStageiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramStageiv(GLuint program, GLenum shadertype, GLenum pname, GLint* values) => _glGetProgramStageiv(program, shadertype, pname, values);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetProgramStageiv(GLuint program, GLenum shadertype, GLenum pname, ref GLint[] values) { fixed (GLint* p = &values[0]) _glGetProgramStageiv(program, shadertype, pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPATCHPARAMETERIPROC(GLenum pname, GLint value);
    private static PFNGLPATCHPARAMETERIPROC _glPatchParameteri;
    public static void glPatchParameteri(GLenum pname, GLint value) => _glPatchParameteri(pname, value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPATCHPARAMETERFVPROC(GLenum pname, GLfloat* values);
    private static PFNGLPATCHPARAMETERFVPROC _glPatchParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glPatchParameterfv(GLenum pname, GLfloat* values) => _glPatchParameterfv(pname, values);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glPatchParameterfv(GLenum pname, GLfloat[] values) { fixed (GLfloat* p = &values[0]) _glPatchParameterfv(pname, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDTRANSFORMFEEDBACKPROC(GLenum target, GLuint id);
    private static PFNGLBINDTRANSFORMFEEDBACKPROC _glBindTransformFeedback;
    public static void glBindTransformFeedback(GLenum target, GLuint id) => _glBindTransformFeedback(target, id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETETRANSFORMFEEDBACKSPROC(GLsizei n, GLuint* ids);
    private static PFNGLDELETETRANSFORMFEEDBACKSPROC _glDeleteTransformFeedbacks;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteTransformFeedbacks(GLsizei n, GLuint* ids) => _glDeleteTransformFeedbacks(n, ids);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteTransformFeedbacks(params GLuint[] ids) { fixed (GLuint* p = &ids[0]) _glDeleteTransformFeedbacks(ids.Length, p); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENTRANSFORMFEEDBACKSPROC(GLsizei n, GLuint* ids);
    private static PFNGLGENTRANSFORMFEEDBACKSPROC _glGenTransformFeedbacks;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenTransformFeedbacks(GLsizei n, GLuint* ids) => _glGenTransformFeedbacks(n, ids);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenTransformFeedbacks(GLsizei n) { var r = new GLuint[n]; fixed (GLuint* p = &r[0]) _glGenTransformFeedbacks(n, p); return r; }
    public static GLuint glGenTransformFeedback() => glGenTransformFeedbacks(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISTRANSFORMFEEDBACKPROC(GLuint id);
    private static PFNGLISTRANSFORMFEEDBACKPROC _glIsTransformFeedback;
    public static GLboolean glIsTransformFeedback(GLuint id) => _glIsTransformFeedback(id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPAUSETRANSFORMFEEDBACKPROC();
    private static PFNGLPAUSETRANSFORMFEEDBACKPROC _glPauseTransformFeedback;
    public static void glPauseTransformFeedback() => _glPauseTransformFeedback();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLRESUMETRANSFORMFEEDBACKPROC();
    private static PFNGLRESUMETRANSFORMFEEDBACKPROC _glResumeTransformFeedback;
    public static void glResumeTransformFeedback() => _glResumeTransformFeedback();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKPROC(GLenum mode, GLuint id);
    private static PFNGLDRAWTRANSFORMFEEDBACKPROC _glDrawTransformFeedback;
    public static void glDrawTransformFeedback(GLenum mode, GLuint id) => _glDrawTransformFeedback(mode, id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKSTREAMPROC(GLenum mode, GLuint id, GLuint stream);
    private static PFNGLDRAWTRANSFORMFEEDBACKSTREAMPROC _glDrawTransformFeedbackStream;
    public static void glDrawTransformFeedbackStream(GLenum mode, GLuint id, GLuint stream) => _glDrawTransformFeedbackStream(mode, id, stream);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBEGINQUERYINDEXEDPROC(GLenum target, GLuint index, GLuint id);
    private static PFNGLBEGINQUERYINDEXEDPROC _glBeginQueryIndexed;
    public static void glBeginQueryIndexed(GLenum target, GLuint index, GLuint id) => _glBeginQueryIndexed(target, index, id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENDQUERYINDEXEDPROC(GLenum target, GLuint index);
    private static PFNGLENDQUERYINDEXEDPROC _glEndQueryIndexed;
    public static void glEndQueryIndexed(GLenum target, GLuint index) => _glEndQueryIndexed(target, index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYINDEXEDIVPROC(GLenum target, GLuint index, GLenum pname, GLint* parameters);
    private static PFNGLGETQUERYINDEXEDIVPROC _glGetQueryIndexediv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetQueryIndexediv(GLenum target, GLuint index, GLenum pname, GLint* parameters) => _glGetQueryIndexediv(target, index, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetQueryIndexediv(GLenum target, GLuint index, GLenum pname, ref GLint[] parameters) { fixed (GLint* p = &parameters[0]) _glGetQueryIndexediv(target, index, pname, p); }
#endif

#endif

    // OpenGL 4.1

#if OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_FIXED = 0x140C;
    public const int GL_IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A;
    public const int GL_IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B;
    public const int GL_LOW_FLOAT = 0x8DF0;
    public const int GL_MEDIUM_FLOAT = 0x8DF1;
    public const int GL_HIGH_FLOAT = 0x8DF2;
    public const int GL_LOW_INT = 0x8DF3;
    public const int GL_MEDIUM_INT = 0x8DF4;
    public const int GL_HIGH_INT = 0x8DF5;
    public const int GL_SHADER_COMPILER = 0x8DFA;
    public const int GL_SHADER_BINARY_FORMATS = 0x8DF8;
    public const int GL_NUM_SHADER_BINARY_FORMATS = 0x8DF9;
    public const int GL_MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;
    public const int GL_MAX_VARYING_VECTORS = 0x8DFC;
    public const int GL_MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;
    public const int GL_RGB565 = 0x8D62;
    public const int GL_PROGRAM_BINARY_RETRIEVABLE_HINT = 0x8257;
    public const int GL_PROGRAM_BINARY_LENGTH = 0x8741;
    public const int GL_NUM_PROGRAM_BINARY_FORMATS = 0x87FE;
    public const int GL_PROGRAM_BINARY_FORMATS = 0x87FF;
    public const int GL_VERTEX_SHADER_BIT = 0x00000001;
    public const int GL_FRAGMENT_SHADER_BIT = 0x00000002;
    public const int GL_GEOMETRY_SHADER_BIT = 0x00000004;
    public const int GL_TESS_CONTROL_SHADER_BIT = 0x00000008;
    public const int GL_TESS_EVALUATION_SHADER_BIT = 0x00000010;
    public const int GL_ALL_SHADER_BITS = unchecked((int)0xFFFFFFFF);
    public const int GL_PROGRAM_SEPARABLE = 0x8258;
    public const int GL_ACTIVE_PROGRAM = 0x8259;
    public const int GL_PROGRAM_PIPELINE_BINDING = 0x825A;
    public const int GL_MAX_VIEWPORTS = 0x825B;
    public const int GL_VIEWPORT_SUBPIXEL_BITS = 0x825C;
    public const int GL_VIEWPORT_BOUNDS_RANGE = 0x825D;
    public const int GL_LAYER_PROVOKING_VERTEX = 0x825E;
    public const int GL_VIEWPORT_INDEX_PROVOKING_VERTEX = 0x825F;
    public const int GL_UNDEFINED_VERTEX = 0x8260;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLRELEASESHADERCOMPILERPROC();
    private static PFNGLRELEASESHADERCOMPILERPROC _glReleaseShaderCompiler;
    public static void glReleaseShaderCompiler() => _glReleaseShaderCompiler();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSHADERBINARYPROC(GLsizei count, GLuint* shaders, GLenum binaryformat, void* binary, GLsizei length);
    private static PFNGLSHADERBINARYPROC _glShaderBinary;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glShaderBinary(GLsizei count, GLuint* shaders, GLenum binaryformat, void* binary, GLsizei length) => _glShaderBinary(count, shaders, binaryformat, binary, length);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glShaderBinary(GLuint[] shaders, GLenum binaryFormat, byte[] binary)
    {
        GLsizei count = shaders.Length;
        fixed (GLuint* pShaders = &shaders[0])
        fixed (byte* pBinary = &binary[0])
        {
            _glShaderBinary(count, pShaders, binaryFormat, pBinary, binary.Length);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETSHADERPRECISIONFORMATPROC(GLenum shadertype, GLenum precisiontype, GLint* range, GLint* precision);
    private static PFNGLGETSHADERPRECISIONFORMATPROC _glGetShaderPrecisionFormat;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetShaderPrecisionFormat(GLenum shaderType, GLenum precisionType, GLint* range, GLint* precision) => _glGetShaderPrecisionFormat(shaderType, precisionType, range, precision);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetShaderPrecisionFormat(GLenum shaderType, GLenum precisionType, ref GLint[] range, ref GLint precision)
    {
        range = new GLint[2];
        fixed (GLint* pRange = &range[0])
        fixed (GLint* pPrecision = &precision)
        {
            _glGetShaderPrecisionFormat(shaderType, precisionType, pRange, pPrecision);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEPTHRANGEFPROC(GLfloat n, GLfloat f);
    private static PFNGLDEPTHRANGEFPROC _glDepthRangef;
    public static void glDepthRangef(GLfloat n, GLfloat f) => _glDepthRangef(n, f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARDEPTHFPROC(GLfloat d);
    private static PFNGLCLEARDEPTHFPROC _glClearDepthf;
    public static void glClearDepthf(GLfloat d) => _glClearDepthf(d);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMBINARYPROC(GLuint program, GLsizei bufSize, GLsizei* length, GLenum* binaryFormat, void* binary);
    private static PFNGLGETPROGRAMBINARYPROC _glGetProgramBinary;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramBinary(GLuint program, GLsizei bufSize, GLsizei* length, GLenum* binaryFormat, void* binary) => _glGetProgramBinary(program, bufSize, length, binaryFormat, binary);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glGetProgramBinary(GLuint program, GLsizei bufSize, out GLenum binaryFormat)
    {
        byte[] binary = new byte[bufSize];
        GLsizei length;
        fixed (byte* pBinary = &binary[0])
        fixed (GLenum* pBinaryFormat = &binaryFormat)
        {
            _glGetProgramBinary(program, bufSize, &length, pBinaryFormat, pBinary);
        }
        Array.Resize(ref binary, length);
        return binary;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMBINARYPROC(GLuint program, GLenum binaryFormat, void* binary, GLsizei length);
    private static PFNGLPROGRAMBINARYPROC _glProgramBinary;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramBinary(GLuint program, GLenum binaryFormat, void* binary, GLsizei length) => _glProgramBinary(program, binaryFormat, binary, length);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramBinary(GLuint program, GLenum binaryFormat, byte[] binary)
    {
        fixed (byte* pBinary = &binary[0])
        {
            _glProgramBinary(program, binaryFormat, pBinary, binary.Length);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMPARAMETERIPROC(GLuint program, GLenum pname, GLint value);
    private static PFNGLPROGRAMPARAMETERIPROC _glProgramParameteri;
    public static void glProgramParameteri(GLuint program, GLenum pname, GLint value) => _glProgramParameteri(program, pname, value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLUSEPROGRAMSTAGESPROC(GLuint pipeline, GLbitfield stages, GLuint program);
    private static PFNGLUSEPROGRAMSTAGESPROC _glUseProgramStages;
    public static void glUseProgramStages(GLuint pipeline, GLbitfield stages, GLuint program) => _glUseProgramStages(pipeline, stages, program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLACTIVESHADERPROGRAMPROC(GLuint pipeline, GLuint program);
    private static PFNGLACTIVESHADERPROGRAMPROC _glActiveShaderProgram;
    public static void glActiveShaderProgram(GLuint pipeline, GLuint program) => _glActiveShaderProgram(pipeline, program);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLCREATESHADERPROGRAMVPROC(GLenum type, GLsizei count, GLchar** strings);
    private static PFNGLCREATESHADERPROGRAMVPROC _glCreateShaderProgramv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLuint glCreateShaderProgramv(GLenum type, GLsizei count, GLchar** strings) => _glCreateShaderProgramv(type, count, strings);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint glCreateShaderProgramv(GLenum type, string[] strings)
    {
        // https://stackoverflow.com/questions/27777226/how-to-use-glcreateshaderprogram

        GLchar[][] stringsBytes = new GLchar[strings.Length][];
        for (int i = 0; i < strings.Length; i++)
        {
            stringsBytes[i] = Encoding.UTF8.GetBytes(strings[i]);
        }

        GLchar*[] stringsPtrs = new GLchar*[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            fixed (GLchar* pString = &stringsBytes[i][0])
            {
                stringsPtrs[i] = pString;
            }
        }

        fixed (GLchar** pStrings = &stringsPtrs[0])
        {
            return _glCreateShaderProgramv(type, strings.Length, pStrings);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDPROGRAMPIPELINEPROC(GLuint pipeline);
    private static PFNGLBINDPROGRAMPIPELINEPROC _glBindProgramPipeline;
    public static void glBindProgramPipeline(GLuint pipeline) => _glBindProgramPipeline(pipeline);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDELETEPROGRAMPIPELINESPROC(GLsizei n, GLuint* pipelines);
    private static PFNGLDELETEPROGRAMPIPELINESPROC _glDeleteProgramPipelines;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDeleteProgramPipelines(GLsizei n, GLuint* pipelines) => _glDeleteProgramPipelines(n, pipelines);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDeleteProgramPipelines(params GLuint[] pipelines) { fixed (GLuint* pPipelines = &pipelines[0]) { _glDeleteProgramPipelines(pipelines.Length, pPipelines); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENPROGRAMPIPELINESPROC(GLsizei n, GLuint* pipelines);
    private static PFNGLGENPROGRAMPIPELINESPROC _glGenProgramPipelines;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGenProgramPipelines(GLsizei n, GLuint* pipelines) => _glGenProgramPipelines(n, pipelines);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glGenProgramPipelines(GLsizei n) { GLuint[] pipelines = new GLuint[n]; fixed (GLuint* pPipelines = &pipelines[0]) { _glGenProgramPipelines(n, pPipelines); } return pipelines; }
    public static GLuint glGenProgramPipeline() => glGenProgramPipelines(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLISPROGRAMPIPELINEPROC(GLuint pipeline);
    private static PFNGLISPROGRAMPIPELINEPROC _glIsProgramPipeline;
    public static GLboolean glIsProgramPipeline(GLuint pipeline) => _glIsProgramPipeline(pipeline);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMPIPELINEIVPROC(GLuint pipeline, GLenum pname, GLint* param);
    private static PFNGLGETPROGRAMPIPELINEIVPROC _glGetProgramPipelineiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramPipelineiv(GLuint pipeline, GLenum pname, GLint* param) => _glGetProgramPipelineiv(pipeline, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetProgramPipelineiv(GLuint pipeline, GLenum pname, ref GLint[] param) { fixed (GLint* pParam = &param[0]) { _glGetProgramPipelineiv(pipeline, pname, pParam); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1IPROC(GLuint program, GLint location, GLint v0);
    private static PFNGLPROGRAMUNIFORM1IPROC _glProgramUniform1i;
    public static void glProgramUniform1i(GLuint program, GLint location, GLint v0) => _glProgramUniform1i(program, location, v0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1IVPROC(GLuint program, GLint location, GLsizei count, GLint* value);
    private static PFNGLPROGRAMUNIFORM1IVPROC _glProgramUniform1iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform1iv(GLuint program, GLint location, GLsizei count, GLint* value) => _glProgramUniform1iv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform1iv(GLuint program, GLint location, GLint[] value) { fixed (GLint* pValue = &value[0]) { _glProgramUniform1iv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1FPROC(GLuint program, GLint location, GLfloat v0);
    private static PFNGLPROGRAMUNIFORM1FPROC _glProgramUniform1f;
    public static void glProgramUniform1f(GLuint program, GLint location, GLfloat v0) => _glProgramUniform1f(program, location, v0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1FVPROC(GLuint program, GLint location, GLsizei count, GLfloat* value);
    private static PFNGLPROGRAMUNIFORM1FVPROC _glProgramUniform1fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform1fv(GLuint program, GLint location, GLsizei count, GLfloat* value) => _glProgramUniform1fv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform1fv(GLuint program, GLint location, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniform1fv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1DPROC(GLuint program, GLint location, GLdouble v0);
    private static PFNGLPROGRAMUNIFORM1DPROC _glProgramUniform1d;
    public static void glProgramUniform1d(GLuint program, GLint location, GLdouble v0) => _glProgramUniform1d(program, location, v0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1DVPROC(GLuint program, GLint location, GLsizei count, GLdouble* value);
    private static PFNGLPROGRAMUNIFORM1DVPROC _glProgramUniform1dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform1dv(GLuint program, GLint location, GLsizei count, GLdouble* value) => _glProgramUniform1dv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform1dv(GLuint program, GLint location, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniform1dv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1UIPROC(GLuint program, GLint location, GLuint v0);
    private static PFNGLPROGRAMUNIFORM1UIPROC _glProgramUniform1ui;
    public static void glProgramUniform1ui(GLuint program, GLint location, GLuint v0) => _glProgramUniform1ui(program, location, v0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM1UIVPROC(GLuint program, GLint location, GLsizei count, GLuint* value);
    private static PFNGLPROGRAMUNIFORM1UIVPROC _glProgramUniform1uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform1uiv(GLuint program, GLint location, GLsizei count, GLuint* value) => _glProgramUniform1uiv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform1uiv(GLuint program, GLint location, GLuint[] value) { fixed (GLuint* pValue = &value[0]) { _glProgramUniform1uiv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2IPROC(GLuint program, GLint location, GLint v0, GLint v1);
    private static PFNGLPROGRAMUNIFORM2IPROC _glProgramUniform2i;
    public static void glProgramUniform2i(GLuint program, GLint location, GLint v0, GLint v1) => _glProgramUniform2i(program, location, v0, v1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2IVPROC(GLuint program, GLint location, GLsizei count, GLint* value);
    private static PFNGLPROGRAMUNIFORM2IVPROC _glProgramUniform2iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform2iv(GLuint program, GLint location, GLsizei count, GLint* value) => _glProgramUniform2iv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform2iv(GLuint program, GLint location, GLint[] value) { fixed (GLint* pValue = &value[0]) { _glProgramUniform2iv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2FPROC(GLuint program, GLint location, GLfloat v0, GLfloat v1);
    private static PFNGLPROGRAMUNIFORM2FPROC _glProgramUniform2f;
    public static void glProgramUniform2f(GLuint program, GLint location, GLfloat v0, GLfloat v1) => _glProgramUniform2f(program, location, v0, v1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2FVPROC(GLuint program, GLint location, GLsizei count, GLfloat* value);
    private static PFNGLPROGRAMUNIFORM2FVPROC _glProgramUniform2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform2fv(GLuint program, GLint location, GLsizei count, GLfloat* value) => _glProgramUniform2fv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform2fv(GLuint program, GLint location, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniform2fv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2DPROC(GLuint program, GLint location, GLdouble v0, GLdouble v1);
    private static PFNGLPROGRAMUNIFORM2DPROC _glProgramUniform2d;
    public static void glProgramUniform2d(GLuint program, GLint location, GLdouble v0, GLdouble v1) => _glProgramUniform2d(program, location, v0, v1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2DVPROC(GLuint program, GLint location, GLsizei count, GLdouble* value);
    private static PFNGLPROGRAMUNIFORM2DVPROC _glProgramUniform2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform2dv(GLuint program, GLint location, GLsizei count, GLdouble* value) => _glProgramUniform2dv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform2dv(GLuint program, GLint location, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniform2dv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2UIPROC(GLuint program, GLint location, GLuint v0, GLuint v1);
    private static PFNGLPROGRAMUNIFORM2UIPROC _glProgramUniform2ui;
    public static void glProgramUniform2ui(GLuint program, GLint location, GLuint v0, GLuint v1) => _glProgramUniform2ui(program, location, v0, v1);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM2UIVPROC(GLuint program, GLint location, GLsizei count, GLuint* value);
    private static PFNGLPROGRAMUNIFORM2UIVPROC _glProgramUniform2uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform2uiv(GLuint program, GLint location, GLsizei count, GLuint* value) => _glProgramUniform2uiv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform2uiv(GLuint program, GLint location, GLuint[] value) { fixed (GLuint* pValue = &value[0]) { _glProgramUniform2uiv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3IPROC(GLuint program, GLint location, GLint v0, GLint v1, GLint v2);
    private static PFNGLPROGRAMUNIFORM3IPROC _glProgramUniform3i;
    public static void glProgramUniform3i(GLuint program, GLint location, GLint v0, GLint v1, GLint v2) => _glProgramUniform3i(program, location, v0, v1, v2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3IVPROC(GLuint program, GLint location, GLsizei count, GLint* value);
    private static PFNGLPROGRAMUNIFORM3IVPROC _glProgramUniform3iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform3iv(GLuint program, GLint location, GLsizei count, GLint* value) => _glProgramUniform3iv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform3iv(GLuint program, GLint location, GLint[] value) { fixed (GLint* pValue = &value[0]) { _glProgramUniform3iv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3FPROC(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
    private static PFNGLPROGRAMUNIFORM3FPROC _glProgramUniform3f;
    public static void glProgramUniform3f(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2) => _glProgramUniform3f(program, location, v0, v1, v2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3FVPROC(GLuint program, GLint location, GLsizei count, GLfloat* value);
    private static PFNGLPROGRAMUNIFORM3FVPROC _glProgramUniform3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform3fv(GLuint program, GLint location, GLsizei count, GLfloat* value) => _glProgramUniform3fv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform3fv(GLuint program, GLint location, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniform3fv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3DPROC(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2);
    private static PFNGLPROGRAMUNIFORM3DPROC _glProgramUniform3d;
    public static void glProgramUniform3d(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2) => _glProgramUniform3d(program, location, v0, v1, v2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3DVPROC(GLuint program, GLint location, GLsizei count, GLdouble* value);
    private static PFNGLPROGRAMUNIFORM3DVPROC _glProgramUniform3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform3dv(GLuint program, GLint location, GLsizei count, GLdouble* value) => _glProgramUniform3dv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform3dv(GLuint program, GLint location, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniform3dv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3UIPROC(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2);
    private static PFNGLPROGRAMUNIFORM3UIPROC _glProgramUniform3ui;
    public static void glProgramUniform3ui(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2) => _glProgramUniform3ui(program, location, v0, v1, v2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM3UIVPROC(GLuint program, GLint location, GLsizei count, GLuint* value);
    private static PFNGLPROGRAMUNIFORM3UIVPROC _glProgramUniform3uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform3uiv(GLuint program, GLint location, GLsizei count, GLuint* value) => _glProgramUniform3uiv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform3uiv(GLuint program, GLint location, GLuint[] value) { fixed (GLuint* pValue = &value[0]) { _glProgramUniform3uiv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4IPROC(GLuint program, GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
    private static PFNGLPROGRAMUNIFORM4IPROC _glProgramUniform4i;
    public static void glProgramUniform4i(GLuint program, GLint location, GLint v0, GLint v1, GLint v2, GLint v3) => _glProgramUniform4i(program, location, v0, v1, v2, v3);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4IVPROC(GLuint program, GLint location, GLsizei count, GLint* value);
    private static PFNGLPROGRAMUNIFORM4IVPROC _glProgramUniform4iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform4iv(GLuint program, GLint location, GLsizei count, GLint* value) => _glProgramUniform4iv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform4iv(GLuint program, GLint location, GLint[] value) { fixed (GLint* pValue = &value[0]) { _glProgramUniform4iv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4FPROC(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
    private static PFNGLPROGRAMUNIFORM4FPROC _glProgramUniform4f;
    public static void glProgramUniform4f(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3) => _glProgramUniform4f(program, location, v0, v1, v2, v3);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4FVPROC(GLuint program, GLint location, GLsizei count, GLfloat* value);
    private static PFNGLPROGRAMUNIFORM4FVPROC _glProgramUniform4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform4fv(GLuint program, GLint location, GLsizei count, GLfloat* value) => _glProgramUniform4fv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform4fv(GLuint program, GLint location, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniform4fv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4DPROC(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2, GLdouble v3);
    private static PFNGLPROGRAMUNIFORM4DPROC _glProgramUniform4d;
    public static void glProgramUniform4d(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2, GLdouble v3) => _glProgramUniform4d(program, location, v0, v1, v2, v3);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4DVPROC(GLuint program, GLint location, GLsizei count, GLdouble* value);
    private static PFNGLPROGRAMUNIFORM4DVPROC _glProgramUniform4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform4dv(GLuint program, GLint location, GLsizei count, GLdouble* value) => _glProgramUniform4dv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform4dv(GLuint program, GLint location, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniform4dv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4UIPROC(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);
    private static PFNGLPROGRAMUNIFORM4UIPROC _glProgramUniform4ui;
    public static void glProgramUniform4ui(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3) => _glProgramUniform4ui(program, location, v0, v1, v2, v3);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORM4UIVPROC(GLuint program, GLint location, GLsizei count, GLuint* value);
    private static PFNGLPROGRAMUNIFORM4UIVPROC _glProgramUniform4uiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniform4uiv(GLuint program, GLint location, GLsizei count, GLuint* value) => _glProgramUniform4uiv(program, location, count, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniform4uiv(GLuint program, GLint location, GLuint[] value) { fixed (GLuint* pValue = &value[0]) { _glProgramUniform4uiv(program, location, value.Length, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX2FVPROC _glProgramUniformMatrix2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix2fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix2fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix2fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix2fv(program, location, value.Length / 4, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX3FVPROC _glProgramUniformMatrix3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix3fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix3fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix3fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix3fv(program, location, value.Length / 9, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX4FVPROC _glProgramUniformMatrix4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix4fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix4fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix4fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix4fv(program, location, value.Length / 16, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX2DVPROC _glProgramUniformMatrix2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix2dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix2dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix2dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix2dv(program, location, value.Length / 4, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX3DVPROC _glProgramUniformMatrix3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix3dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix3dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix3dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix3dv(program, location, value.Length / 9, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX4DVPROC _glProgramUniformMatrix4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix4dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix4dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix4dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix4dv(program, location, value.Length / 16, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X3FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX2X3FVPROC _glProgramUniformMatrix2x3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix2x3fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix2x3fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix2x3fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix2x3fv(program, location, value.Length / 6, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X2FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX3X2FVPROC _glProgramUniformMatrix3x2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix3x2fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix3x2fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix3x2fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix3x2fv(program, location, value.Length / 6, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X4FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX2X4FVPROC _glProgramUniformMatrix2x4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix2x4fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix2x4fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix2x4fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix2x4fv(program, location, value.Length / 8, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X2FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX4X2FVPROC _glProgramUniformMatrix4x2fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix4x2fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix4x2fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix4x2fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix4x2fv(program, location, value.Length / 8, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X4FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX3X4FVPROC _glProgramUniformMatrix3x4fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix3x4fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix3x4fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix3x4fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix3x4fv(program, location, value.Length / 12, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X3FVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
    private static PFNGLPROGRAMUNIFORMMATRIX4X3FVPROC _glProgramUniformMatrix4x3fv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix4x3fv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value) => _glProgramUniformMatrix4x3fv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix4x3fv(GLuint program, GLint location, GLboolean transpose, GLfloat[] value) { fixed (GLfloat* pValue = &value[0]) { _glProgramUniformMatrix4x3fv(program, location, value.Length / 12, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X3DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX2X3DVPROC _glProgramUniformMatrix2x3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix2x3dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix2x3dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix2x3dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix2x3dv(program, location, value.Length / 6, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X2DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX3X2DVPROC _glProgramUniformMatrix3x2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix3x2dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix3x2dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix3x2dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix3x2dv(program, location, value.Length / 6, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X4DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX2X4DVPROC _glProgramUniformMatrix2x4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix2x4dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix2x4dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix2x4dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix2x4dv(program, location, value.Length / 8, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X2DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX4X2DVPROC _glProgramUniformMatrix4x2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix4x2dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix4x2dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix4x2dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix4x2dv(program, location, value.Length / 8, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X4DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX3X4DVPROC _glProgramUniformMatrix3x4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix3x4dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix3x4dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix3x4dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix3x4dv(program, location, value.Length / 12, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X3DVPROC(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
    private static PFNGLPROGRAMUNIFORMMATRIX4X3DVPROC _glProgramUniformMatrix4x3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glProgramUniformMatrix4x3dv(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value) => _glProgramUniformMatrix4x3dv(program, location, count, transpose, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glProgramUniformMatrix4x3dv(GLuint program, GLint location, GLboolean transpose, GLdouble[] value) { fixed (GLdouble* pValue = &value[0]) { _glProgramUniformMatrix4x3dv(program, location, value.Length / 12, transpose, pValue); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVALIDATEPROGRAMPIPELINEPROC(GLuint pipeline);
    private static PFNGLVALIDATEPROGRAMPIPELINEPROC _glValidateProgramPipeline;
    public static void glValidateProgramPipeline(GLuint pipeline) => _glValidateProgramPipeline(pipeline);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMPIPELINEINFOLOGPROC(GLuint pipeline, GLsizei bufSize, GLsizei* length, GLchar* infoLog);
    private static PFNGLGETPROGRAMPIPELINEINFOLOGPROC _glGetProgramPipelineInfoLog;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramPipelineInfoLog(GLuint pipeline, GLsizei bufSize, GLsizei* length, GLchar* infoLog) => _glGetProgramPipelineInfoLog(pipeline, bufSize, length, infoLog);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetProgramPipelineInfoLog(GLuint pipeline, GLsizei bufSize)
    {
        GLchar[] infoLog = new GLchar[bufSize];
        GLsizei length;
        fixed (GLchar* pInfoLog = &infoLog[0])
        {
            _glGetProgramPipelineInfoLog(pipeline, bufSize, &length, pInfoLog);
            return new string((sbyte*)pInfoLog, 0, length, Encoding.UTF8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL1DPROC(GLuint index, GLdouble x);
    private static PFNGLVERTEXATTRIBL1DPROC _glVertexAttribL1d;
    public static void glVertexAttribL1d(GLuint index, GLdouble x) => _glVertexAttribL1d(index, x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL2DPROC(GLuint index, GLdouble x, GLdouble y);
    private static PFNGLVERTEXATTRIBL2DPROC _glVertexAttribL2d;
    public static void glVertexAttribL2d(GLuint index, GLdouble x, GLdouble y) => _glVertexAttribL2d(index, x, y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL3DPROC(GLuint index, GLdouble x, GLdouble y, GLdouble z);
    private static PFNGLVERTEXATTRIBL3DPROC _glVertexAttribL3d;
    public static void glVertexAttribL3d(GLuint index, GLdouble x, GLdouble y, GLdouble z) => _glVertexAttribL3d(index, x, y, z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL4DPROC(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
    private static PFNGLVERTEXATTRIBL4DPROC _glVertexAttribL4d;
    public static void glVertexAttribL4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w) => _glVertexAttribL4d(index, x, y, z, w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL1DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIBL1DVPROC _glVertexAttribL1dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribL1dv(GLuint index, GLdouble* v) => _glVertexAttribL1dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribL1dv(GLuint index, GLdouble[] v) { fixed (GLdouble* pV = &v[0]) { _glVertexAttribL1dv(index, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL2DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIBL2DVPROC _glVertexAttribL2dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribL2dv(GLuint index, GLdouble* v) => _glVertexAttribL2dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribL2dv(GLuint index, GLdouble[] v) { fixed (GLdouble* pV = &v[0]) { _glVertexAttribL2dv(index, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL3DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIBL3DVPROC _glVertexAttribL3dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribL3dv(GLuint index, GLdouble* v) => _glVertexAttribL3dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribL3dv(GLuint index, GLdouble[] v) { fixed (GLdouble* pV = &v[0]) { _glVertexAttribL3dv(index, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBL4DVPROC(GLuint index, GLdouble* v);
    private static PFNGLVERTEXATTRIBL4DVPROC _glVertexAttribL4dv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribL4dv(GLuint index, GLdouble* v) => _glVertexAttribL4dv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribL4dv(GLuint index, GLdouble[] v) { fixed (GLdouble* pV = &v[0]) { _glVertexAttribL4dv(index, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBLPOINTERPROC(GLuint index, GLint size, GLenum type, GLsizei stride, void* pointer);
    private static PFNGLVERTEXATTRIBLPOINTERPROC _glVertexAttribLPointer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexAttribLPointer(GLuint index, GLint size, GLenum type, GLsizei stride, void* pointer) => _glVertexAttribLPointer(index, size, type, stride, pointer);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexAttribLPointer(GLuint index, GLint size, GLenum type, GLsizei stride, GLsizei pointer) => _glVertexAttribLPointer(index, size, type, stride, (void*)pointer);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXATTRIBLDVPROC(GLuint index, GLenum pname, GLdouble* parameters);
    private static PFNGLGETVERTEXATTRIBLDVPROC _glGetVertexAttribLdv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexAttribLdv(GLuint index, GLenum pname, GLdouble* parameters) => _glGetVertexAttribLdv(index, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexAttribLdv(GLuint index, GLenum pname, ref GLdouble[] parameters) { fixed (GLdouble* pP = &parameters[0]) { _glGetVertexAttribLdv(index, pname, pP); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVIEWPORTARRAYVPROC(GLuint first, GLsizei count, GLfloat* v);
    private static PFNGLVIEWPORTARRAYVPROC _glViewportArrayv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glViewportArrayv(GLuint first, GLsizei count, GLfloat* v) => _glViewportArrayv(first, count, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glViewportArrayv(GLuint first, GLsizei count, GLfloat[] v) { fixed (GLfloat* pV = &v[0]) { _glViewportArrayv(first, count, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVIEWPORTINDEXEDFPROC(GLuint index, GLfloat x, GLfloat y, GLfloat w, GLfloat h);
    private static PFNGLVIEWPORTINDEXEDFPROC _glViewportIndexedf;
    public static void glViewportIndexedf(GLuint index, GLfloat x, GLfloat y, GLfloat w, GLfloat h) => _glViewportIndexedf(index, x, y, w, h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVIEWPORTINDEXEDFVPROC(GLuint index, GLfloat* v);
    private static PFNGLVIEWPORTINDEXEDFVPROC _glViewportIndexedfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glViewportIndexedfv(GLuint index, GLfloat* v) => _glViewportIndexedfv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glViewportIndexedfv(GLuint index, GLfloat[] v) { fixed (GLfloat* pV = &v[0]) { _glViewportIndexedfv(index, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSCISSORARRAYVPROC(GLuint first, GLsizei count, GLint* v);
    private static PFNGLSCISSORARRAYVPROC _glScissorArrayv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glScissorArrayv(GLuint first, GLsizei count, GLint* v) => _glScissorArrayv(first, count, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glScissorArrayv(GLuint first, GLsizei count, GLint[] v) { fixed (GLint* pV = &v[0]) { _glScissorArrayv(first, count, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSCISSORINDEXEDPROC(GLuint index, GLint left, GLint bottom, GLsizei width, GLsizei height);
    private static PFNGLSCISSORINDEXEDPROC _glScissorIndexed;
    public static void glScissorIndexed(GLuint index, GLint left, GLint bottom, GLsizei width, GLsizei height) => _glScissorIndexed(index, left, bottom, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSCISSORINDEXEDVPROC(GLuint index, GLint* v);
    private static PFNGLSCISSORINDEXEDVPROC _glScissorIndexedv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glScissorIndexedv(GLuint index, GLint* v) => _glScissorIndexedv(index, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glScissorIndexedv(GLuint index, GLint[] v) { fixed (GLint* pV = &v[0]) { _glScissorIndexedv(index, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEPTHRANGEARRAYVPROC(GLuint first, GLsizei count, GLdouble* v);
    private static PFNGLDEPTHRANGEARRAYVPROC _glDepthRangeArrayv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDepthRangeArrayv(GLuint first, GLsizei count, GLdouble* v) => _glDepthRangeArrayv(first, count, v);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDepthRangeArrayv(GLuint first, GLsizei count, GLdouble[] v) { fixed (GLdouble* pV = &v[0]) { _glDepthRangeArrayv(first, count, pV); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEPTHRANGEINDEXEDPROC(GLuint index, GLdouble n, GLdouble f);
    private static PFNGLDEPTHRANGEINDEXEDPROC _glDepthRangeIndexed;
    public static void glDepthRangeIndexed(GLuint index, GLdouble n, GLdouble f) => _glDepthRangeIndexed(index, n, f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETFLOATI_VPROC(GLenum target, GLuint index, GLfloat* data);
    private static PFNGLGETFLOATI_VPROC _glGetFloati_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetFloati_v(GLenum target, GLuint index, GLfloat* data) => _glGetFloati_v(target, index, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetFloati_v(GLenum target, GLuint index, ref GLfloat[] data) { fixed (GLfloat* pData = &data[0]) { _glGetFloati_v(target, index, pData); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETDOUBLEI_VPROC(GLenum target, GLuint index, GLdouble* data);
    private static PFNGLGETDOUBLEI_VPROC _glGetDoublei_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetDoublei_v(GLenum target, GLuint index, GLdouble* data) => _glGetDoublei_v(target, index, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetDoublei_v(GLenum target, GLuint index, ref GLdouble[] data) { fixed (GLdouble* pData = &data[0]) { _glGetDoublei_v(target, index, pData); } }
#endif

#endif

    // OpenGL 4.2

#if OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_COPY_READ_BUFFER_BINDING = 0x8F36;
    public const int GL_COPY_WRITE_BUFFER_BINDING = 0x8F37;
    public const int GL_TRANSFORM_FEEDBACK_ACTIVE = 0x8E24;
    public const int GL_TRANSFORM_FEEDBACK_PAUSED = 0x8E23;
    public const int GL_UNPACK_COMPRESSED_BLOCK_WIDTH = 0x9127;
    public const int GL_UNPACK_COMPRESSED_BLOCK_HEIGHT = 0x9128;
    public const int GL_UNPACK_COMPRESSED_BLOCK_DEPTH = 0x9129;
    public const int GL_UNPACK_COMPRESSED_BLOCK_SIZE = 0x912A;
    public const int GL_PACK_COMPRESSED_BLOCK_WIDTH = 0x912B;
    public const int GL_PACK_COMPRESSED_BLOCK_HEIGHT = 0x912C;
    public const int GL_PACK_COMPRESSED_BLOCK_DEPTH = 0x912D;
    public const int GL_PACK_COMPRESSED_BLOCK_SIZE = 0x912E;
    public const int GL_NUM_SAMPLE_COUNTS = 0x9380;
    public const int GL_MIN_MAP_BUFFER_ALIGNMENT = 0x90BC;
    public const int GL_ATOMIC_COUNTER_BUFFER = 0x92C0;
    public const int GL_ATOMIC_COUNTER_BUFFER_BINDING = 0x92C1;
    public const int GL_ATOMIC_COUNTER_BUFFER_START = 0x92C2;
    public const int GL_ATOMIC_COUNTER_BUFFER_SIZE = 0x92C3;
    public const int GL_ATOMIC_COUNTER_BUFFER_DATA_SIZE = 0x92C4;
    public const int GL_ATOMIC_COUNTER_BUFFER_ACTIVE_ATOMIC_COUNTERS = 0x92C5;
    public const int GL_ATOMIC_COUNTER_BUFFER_ACTIVE_ATOMIC_COUNTER_INDICES = 0x92C6;
    public const int GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_VERTEX_SHADER = 0x92C7;
    public const int GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_TESS_CONTROL_SHADER = 0x92C8;
    public const int GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x92C9;
    public const int GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_GEOMETRY_SHADER = 0x92CA;
    public const int GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_FRAGMENT_SHADER = 0x92CB;
    public const int GL_MAX_VERTEX_ATOMIC_COUNTER_BUFFERS = 0x92CC;
    public const int GL_MAX_TESS_CONTROL_ATOMIC_COUNTER_BUFFERS = 0x92CD;
    public const int GL_MAX_TESS_EVALUATION_ATOMIC_COUNTER_BUFFERS = 0x92CE;
    public const int GL_MAX_GEOMETRY_ATOMIC_COUNTER_BUFFERS = 0x92CF;
    public const int GL_MAX_FRAGMENT_ATOMIC_COUNTER_BUFFERS = 0x92D0;
    public const int GL_MAX_COMBINED_ATOMIC_COUNTER_BUFFERS = 0x92D1;
    public const int GL_MAX_VERTEX_ATOMIC_COUNTERS = 0x92D2;
    public const int GL_MAX_TESS_CONTROL_ATOMIC_COUNTERS = 0x92D3;
    public const int GL_MAX_TESS_EVALUATION_ATOMIC_COUNTERS = 0x92D4;
    public const int GL_MAX_GEOMETRY_ATOMIC_COUNTERS = 0x92D5;
    public const int GL_MAX_FRAGMENT_ATOMIC_COUNTERS = 0x92D6;
    public const int GL_MAX_COMBINED_ATOMIC_COUNTERS = 0x92D7;
    public const int GL_MAX_ATOMIC_COUNTER_BUFFER_SIZE = 0x92D8;
    public const int GL_MAX_ATOMIC_COUNTER_BUFFER_BINDINGS = 0x92DC;
    public const int GL_ACTIVE_ATOMIC_COUNTER_BUFFERS = 0x92D9;
    public const int GL_UNIFORM_ATOMIC_COUNTER_BUFFER_INDEX = 0x92DA;
    public const int GL_UNSIGNED_INT_ATOMIC_COUNTER = 0x92DB;
    public const int GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT = 0x00000001;
    public const int GL_ELEMENT_ARRAY_BARRIER_BIT = 0x00000002;
    public const int GL_UNIFORM_BARRIER_BIT = 0x00000004;
    public const int GL_TEXTURE_FETCH_BARRIER_BIT = 0x00000008;
    public const int GL_SHADER_IMAGE_ACCESS_BARRIER_BIT = 0x00000020;
    public const int GL_COMMAND_BARRIER_BIT = 0x00000040;
    public const int GL_PIXEL_BUFFER_BARRIER_BIT = 0x00000080;
    public const int GL_TEXTURE_UPDATE_BARRIER_BIT = 0x00000100;
    public const int GL_BUFFER_UPDATE_BARRIER_BIT = 0x00000200;
    public const int GL_FRAMEBUFFER_BARRIER_BIT = 0x00000400;
    public const int GL_TRANSFORM_FEEDBACK_BARRIER_BIT = 0x00000800;
    public const int GL_ATOMIC_COUNTER_BARRIER_BIT = 0x00001000;
    public const int GL_ALL_BARRIER_BITS = unchecked((int)0xFFFFFFFF);
    public const int GL_MAX_IMAGE_UNITS = 0x8F38;
    public const int GL_MAX_COMBINED_IMAGE_UNITS_AND_FRAGMENT_OUTPUTS = 0x8F39;
    public const int GL_IMAGE_BINDING_NAME = 0x8F3A;
    public const int GL_IMAGE_BINDING_LEVEL = 0x8F3B;
    public const int GL_IMAGE_BINDING_LAYERED = 0x8F3C;
    public const int GL_IMAGE_BINDING_LAYER = 0x8F3D;
    public const int GL_IMAGE_BINDING_ACCESS = 0x8F3E;
    public const int GL_IMAGE_1D = 0x904C;
    public const int GL_IMAGE_2D = 0x904D;
    public const int GL_IMAGE_3D = 0x904E;
    public const int GL_IMAGE_2D_RECT = 0x904F;
    public const int GL_IMAGE_CUBE = 0x9050;
    public const int GL_IMAGE_BUFFER = 0x9051;
    public const int GL_IMAGE_1D_ARRAY = 0x9052;
    public const int GL_IMAGE_2D_ARRAY = 0x9053;
    public const int GL_IMAGE_CUBE_MAP_ARRAY = 0x9054;
    public const int GL_IMAGE_2D_MULTISAMPLE = 0x9055;
    public const int GL_IMAGE_2D_MULTISAMPLE_ARRAY = 0x9056;
    public const int GL_INT_IMAGE_1D = 0x9057;
    public const int GL_INT_IMAGE_2D = 0x9058;
    public const int GL_INT_IMAGE_3D = 0x9059;
    public const int GL_INT_IMAGE_2D_RECT = 0x905A;
    public const int GL_INT_IMAGE_CUBE = 0x905B;
    public const int GL_INT_IMAGE_BUFFER = 0x905C;
    public const int GL_INT_IMAGE_1D_ARRAY = 0x905D;
    public const int GL_INT_IMAGE_2D_ARRAY = 0x905E;
    public const int GL_INT_IMAGE_CUBE_MAP_ARRAY = 0x905F;
    public const int GL_INT_IMAGE_2D_MULTISAMPLE = 0x9060;
    public const int GL_INT_IMAGE_2D_MULTISAMPLE_ARRAY = 0x9061;
    public const int GL_UNSIGNED_INT_IMAGE_1D = 0x9062;
    public const int GL_UNSIGNED_INT_IMAGE_2D = 0x9063;
    public const int GL_UNSIGNED_INT_IMAGE_3D = 0x9064;
    public const int GL_UNSIGNED_INT_IMAGE_2D_RECT = 0x9065;
    public const int GL_UNSIGNED_INT_IMAGE_CUBE = 0x9066;
    public const int GL_UNSIGNED_INT_IMAGE_BUFFER = 0x9067;
    public const int GL_UNSIGNED_INT_IMAGE_1D_ARRAY = 0x9068;
    public const int GL_UNSIGNED_INT_IMAGE_2D_ARRAY = 0x9069;
    public const int GL_UNSIGNED_INT_IMAGE_CUBE_MAP_ARRAY = 0x906A;
    public const int GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE = 0x906B;
    public const int GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE_ARRAY = 0x906C;
    public const int GL_MAX_IMAGE_SAMPLES = 0x906D;
    public const int GL_IMAGE_BINDING_FORMAT = 0x906E;
    public const int GL_IMAGE_FORMAT_COMPATIBILITY_TYPE = 0x90C7;
    public const int GL_IMAGE_FORMAT_COMPATIBILITY_BY_SIZE = 0x90C8;
    public const int GL_IMAGE_FORMAT_COMPATIBILITY_BY_CLASS = 0x90C9;
    public const int GL_MAX_VERTEX_IMAGE_UNIFORMS = 0x90CA;
    public const int GL_MAX_TESS_CONTROL_IMAGE_UNIFORMS = 0x90CB;
    public const int GL_MAX_TESS_EVALUATION_IMAGE_UNIFORMS = 0x90CC;
    public const int GL_MAX_GEOMETRY_IMAGE_UNIFORMS = 0x90CD;
    public const int GL_MAX_FRAGMENT_IMAGE_UNIFORMS = 0x90CE;
    public const int GL_MAX_COMBINED_IMAGE_UNIFORMS = 0x90CF;
    public const int GL_COMPRESSED_RGBA_BPTC_UNORM = 0x8E8C;
    public const int GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM = 0x8E8D;
    public const int GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT = 0x8E8E;
    public const int GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT = 0x8E8F;
    public const int GL_TEXTURE_IMMUTABLE_FORMAT = 0x912F;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWARRAYSINSTANCEDBASEINSTANCEPROC(GLenum mode, GLint first, GLsizei count, GLsizei instancecount, GLuint baseinstance);
    private static PFNGLDRAWARRAYSINSTANCEDBASEINSTANCEPROC _glDrawArraysInstancedBaseInstance;
    public static void glDrawArraysInstancedBaseInstance(GLenum mode, GLint first, GLsizei count, GLsizei instancecount, GLuint baseinstance) => _glDrawArraysInstancedBaseInstance(mode, first, count, instancecount, baseinstance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEINSTANCEPROC(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount, GLuint baseinstance);
    private static PFNGLDRAWELEMENTSINSTANCEDBASEINSTANCEPROC _glDrawElementsInstancedBaseInstance;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElementsInstancedBaseInstance(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount, GLuint baseinstance) => _glDrawElementsInstancedBaseInstance(mode, count, type, indices, instancecount, baseinstance);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElementsInstancedBaseInstance<T>(GLenum mode, GLsizei count, GLenum type, T[] indices, GLsizei instancecount, GLuint baseinstance) where T : unmanaged, IUnsignedNumber<T> { fixed (void* p = &indices[0]) { _glDrawElementsInstancedBaseInstance(mode, count, type, p, instancecount, baseinstance); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXBASEINSTANCEPROC(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount, GLint basevertex, GLuint baseinstance);
    private static PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXBASEINSTANCEPROC _glDrawElementsInstancedBaseVertexBaseInstance;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDrawElementsInstancedBaseVertexBaseInstance(GLenum mode, GLsizei count, GLenum type, void* indices, GLsizei instancecount, GLint basevertex, GLuint baseinstance) => _glDrawElementsInstancedBaseVertexBaseInstance(mode, count, type, indices, instancecount, basevertex, baseinstance);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDrawElementsInstancedBaseVertexBaseInstance<T>(GLenum mode, GLsizei count, GLenum type, T[] indices, GLsizei instancecount, GLint basevertex, GLuint baseinstance) where T : unmanaged, IUnsignedNumber<T> { fixed (void* p = &indices[0]) { _glDrawElementsInstancedBaseVertexBaseInstance(mode, count, type, p, instancecount, basevertex, baseinstance); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETINTERNALFORMATIVPROC(GLenum target, GLenum internalformat, GLenum pname, GLsizei bufSize, GLint* @params);
    private static PFNGLGETINTERNALFORMATIVPROC _glGetInternalformativ;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetInternalformativ(GLenum target, GLenum internalformat, GLenum pname, GLsizei bufSize, GLint* @params) => _glGetInternalformativ(target, internalformat, pname, bufSize, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetInternalformativ(GLenum target, GLenum internalformat, GLenum pname, GLsizei bufSize, ref GLint[] @params) { fixed (GLint* p = &@params[0]) { _glGetInternalformativ(target, internalformat, pname, bufSize, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETACTIVEATOMICCOUNTERBUFFERIVPROC(GLuint program, GLuint bufferIndex, GLenum pname, GLint* @params);
    private static PFNGLGETACTIVEATOMICCOUNTERBUFFERIVPROC _glGetActiveAtomicCounterBufferiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetActiveAtomicCounterBufferiv(GLuint program, GLuint bufferIndex, GLenum pname, GLint* @params) => _glGetActiveAtomicCounterBufferiv(program, bufferIndex, pname, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetActiveAtomicCounterBufferiv(GLuint program, GLuint bufferIndex, GLenum pname, ref GLint[] @params) { fixed (GLint* p = &@params[0]) { _glGetActiveAtomicCounterBufferiv(program, bufferIndex, pname, p); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDIMAGETEXTUREPROC(GLuint unit, GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum access, GLenum format);
    private static PFNGLBINDIMAGETEXTUREPROC _glBindImageTexture;
    public static void glBindImageTexture(GLuint unit, GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum access, GLenum format) => _glBindImageTexture(unit, texture, level, layered, layer, access, format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMEMORYBARRIERPROC(GLbitfield barriers);
    private static PFNGLMEMORYBARRIERPROC _glMemoryBarrier;
    public static void glMemoryBarrier(GLbitfield barriers) => _glMemoryBarrier(barriers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSTORAGE1DPROC(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width);
    private static PFNGLTEXSTORAGE1DPROC _glTexStorage1D;
    public static void glTexStorage1D(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width) => _glTexStorage1D(target, levels, internalformat, width);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSTORAGE2DPROC(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);
    private static PFNGLTEXSTORAGE2DPROC _glTexStorage2D;
    public static void glTexStorage2D(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height) => _glTexStorage2D(target, levels, internalformat, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSTORAGE3DPROC(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);
    private static PFNGLTEXSTORAGE3DPROC _glTexStorage3D;
    public static void glTexStorage3D(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth) => _glTexStorage3D(target, levels, internalformat, width, height, depth);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKINSTANCEDPROC(GLenum mode, GLuint id, GLsizei instancecount);
    private static PFNGLDRAWTRANSFORMFEEDBACKINSTANCEDPROC _glDrawTransformFeedbackInstanced;
    public static void glDrawTransformFeedbackInstanced(GLenum mode, GLuint id, GLsizei instancecount) => _glDrawTransformFeedbackInstanced(mode, id, instancecount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKSTREAMINSTANCEDPROC(GLenum mode, GLuint id, GLuint stream, GLsizei instancecount);
    private static PFNGLDRAWTRANSFORMFEEDBACKSTREAMINSTANCEDPROC _glDrawTransformFeedbackStreamInstanced;
    public static void glDrawTransformFeedbackStreamInstanced(GLenum mode, GLuint id, GLuint stream, GLsizei instancecount) => _glDrawTransformFeedbackStreamInstanced(mode, id, stream, instancecount);

#endif

    // OpenGL 4.3

#if OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_NUM_SHADING_LANGUAGE_VERSIONS = 0x82E9;
    public const int GL_VERTEX_ATTRIB_ARRAY_LONG = 0x874E;
    public const int GL_COMPRESSED_RGB8_ETC2 = 0x9274;
    public const int GL_COMPRESSED_SRGB8_ETC2 = 0x9275;
    public const int GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9276;
    public const int GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9277;
    public const int GL_COMPRESSED_RGBA8_ETC2_EAC = 0x9278;
    public const int GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9279;
    public const int GL_COMPRESSED_R11_EAC = 0x9270;
    public const int GL_COMPRESSED_SIGNED_R11_EAC = 0x9271;
    public const int GL_COMPRESSED_RG11_EAC = 0x9272;
    public const int GL_COMPRESSED_SIGNED_RG11_EAC = 0x9273;
    public const int GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69;
    public const int GL_ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;
    public const int GL_MAX_ELEMENT_INDEX = 0x8D6B;
    public const int GL_COMPUTE_SHADER = 0x91B9;
    public const int GL_MAX_COMPUTE_UNIFORM_BLOCKS = 0x91BB;
    public const int GL_MAX_COMPUTE_TEXTURE_IMAGE_UNITS = 0x91BC;
    public const int GL_MAX_COMPUTE_IMAGE_UNIFORMS = 0x91BD;
    public const int GL_MAX_COMPUTE_SHARED_MEMORY_SIZE = 0x8262;
    public const int GL_MAX_COMPUTE_UNIFORM_COMPONENTS = 0x8263;
    public const int GL_MAX_COMPUTE_ATOMIC_COUNTER_BUFFERS = 0x8264;
    public const int GL_MAX_COMPUTE_ATOMIC_COUNTERS = 0x8265;
    public const int GL_MAX_COMBINED_COMPUTE_UNIFORM_COMPONENTS = 0x8266;
    public const int GL_MAX_COMPUTE_WORK_GROUP_INVOCATIONS = 0x90EB;
    public const int GL_MAX_COMPUTE_WORK_GROUP_COUNT = 0x91BE;
    public const int GL_MAX_COMPUTE_WORK_GROUP_SIZE = 0x91BF;
    public const int GL_COMPUTE_WORK_GROUP_SIZE = 0x8267;
    public const int GL_UNIFORM_BLOCK_REFERENCED_BY_COMPUTE_SHADER = 0x90EC;
    public const int GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_COMPUTE_SHADER = 0x90ED;
    public const int GL_DISPATCH_INDIRECT_BUFFER = 0x90EE;
    public const int GL_DISPATCH_INDIRECT_BUFFER_BINDING = 0x90EF;
    public const int GL_COMPUTE_SHADER_BIT = 0x00000020;
    public const int GL_DEBUG_OUTPUT_SYNCHRONOUS = 0x8242;
    public const int GL_DEBUG_NEXT_LOGGED_MESSAGE_LENGTH = 0x8243;
    public const int GL_DEBUG_CALLBACK_FUNCTION = 0x8244;
    public const int GL_DEBUG_CALLBACK_USER_PARAM = 0x8245;
    public const int GL_DEBUG_SOURCE_API = 0x8246;
    public const int GL_DEBUG_SOURCE_WINDOW_SYSTEM = 0x8247;
    public const int GL_DEBUG_SOURCE_SHADER_COMPILER = 0x8248;
    public const int GL_DEBUG_SOURCE_THIRD_PARTY = 0x8249;
    public const int GL_DEBUG_SOURCE_APPLICATION = 0x824A;
    public const int GL_DEBUG_SOURCE_OTHER = 0x824B;
    public const int GL_DEBUG_TYPE_ERROR = 0x824C;
    public const int GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR = 0x824D;
    public const int GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR = 0x824E;
    public const int GL_DEBUG_TYPE_PORTABILITY = 0x824F;
    public const int GL_DEBUG_TYPE_PERFORMANCE = 0x8250;
    public const int GL_DEBUG_TYPE_OTHER = 0x8251;
    public const int GL_MAX_DEBUG_MESSAGE_LENGTH = 0x9143;
    public const int GL_MAX_DEBUG_LOGGED_MESSAGES = 0x9144;
    public const int GL_DEBUG_LOGGED_MESSAGES = 0x9145;
    public const int GL_DEBUG_SEVERITY_HIGH = 0x9146;
    public const int GL_DEBUG_SEVERITY_MEDIUM = 0x9147;
    public const int GL_DEBUG_SEVERITY_LOW = 0x9148;
    public const int GL_DEBUG_TYPE_MARKER = 0x8268;
    public const int GL_DEBUG_TYPE_PUSH_GROUP = 0x8269;
    public const int GL_DEBUG_TYPE_POP_GROUP = 0x826A;
    public const int GL_DEBUG_SEVERITY_NOTIFICATION = 0x826B;
    public const int GL_MAX_DEBUG_GROUP_STACK_DEPTH = 0x826C;
    public const int GL_DEBUG_GROUP_STACK_DEPTH = 0x826D;
    public const int GL_BUFFER = 0x82E0;
    public const int GL_SHADER = 0x82E1;
    public const int GL_PROGRAM = 0x82E2;
    public const int GL_QUERY = 0x82E3;
    public const int GL_PROGRAM_PIPELINE = 0x82E4;
    public const int GL_SAMPLER = 0x82E6;
    public const int GL_MAX_LABEL_LENGTH = 0x82E8;
    public const int GL_DEBUG_OUTPUT = 0x92E0;
    public const int GL_CONTEXT_FLAG_DEBUG_BIT = 0x00000002;
    public const int GL_MAX_UNIFORM_LOCATIONS = 0x826E;
    public const int GL_FRAMEBUFFER_DEFAULT_WIDTH = 0x9310;
    public const int GL_FRAMEBUFFER_DEFAULT_HEIGHT = 0x9311;
    public const int GL_FRAMEBUFFER_DEFAULT_LAYERS = 0x9312;
    public const int GL_FRAMEBUFFER_DEFAULT_SAMPLES = 0x9313;
    public const int GL_FRAMEBUFFER_DEFAULT_FIXED_SAMPLE_LOCATIONS = 0x9314;
    public const int GL_MAX_FRAMEBUFFER_WIDTH = 0x9315;
    public const int GL_MAX_FRAMEBUFFER_HEIGHT = 0x9316;
    public const int GL_MAX_FRAMEBUFFER_LAYERS = 0x9317;
    public const int GL_MAX_FRAMEBUFFER_SAMPLES = 0x9318;
    public const int GL_INTERNALFORMAT_SUPPORTED = 0x826F;
    public const int GL_INTERNALFORMAT_PREFERRED = 0x8270;
    public const int GL_INTERNALFORMAT_RED_SIZE = 0x8271;
    public const int GL_INTERNALFORMAT_GREEN_SIZE = 0x8272;
    public const int GL_INTERNALFORMAT_BLUE_SIZE = 0x8273;
    public const int GL_INTERNALFORMAT_ALPHA_SIZE = 0x8274;
    public const int GL_INTERNALFORMAT_DEPTH_SIZE = 0x8275;
    public const int GL_INTERNALFORMAT_STENCIL_SIZE = 0x8276;
    public const int GL_INTERNALFORMAT_SHARED_SIZE = 0x8277;
    public const int GL_INTERNALFORMAT_RED_TYPE = 0x8278;
    public const int GL_INTERNALFORMAT_GREEN_TYPE = 0x8279;
    public const int GL_INTERNALFORMAT_BLUE_TYPE = 0x827A;
    public const int GL_INTERNALFORMAT_ALPHA_TYPE = 0x827B;
    public const int GL_INTERNALFORMAT_DEPTH_TYPE = 0x827C;
    public const int GL_INTERNALFORMAT_STENCIL_TYPE = 0x827D;
    public const int GL_MAX_WIDTH = 0x827E;
    public const int GL_MAX_HEIGHT = 0x827F;
    public const int GL_MAX_DEPTH = 0x8280;
    public const int GL_MAX_LAYERS = 0x8281;
    public const int GL_MAX_COMBINED_DIMENSIONS = 0x8282;
    public const int GL_COLOR_COMPONENTS = 0x8283;
    public const int GL_DEPTH_COMPONENTS = 0x8284;
    public const int GL_STENCIL_COMPONENTS = 0x8285;
    public const int GL_COLOR_RENDERABLE = 0x8286;
    public const int GL_DEPTH_RENDERABLE = 0x8287;
    public const int GL_STENCIL_RENDERABLE = 0x8288;
    public const int GL_FRAMEBUFFER_RENDERABLE = 0x8289;
    public const int GL_FRAMEBUFFER_RENDERABLE_LAYERED = 0x828A;
    public const int GL_FRAMEBUFFER_BLEND = 0x828B;
    public const int GL_READ_PIXELS = 0x828C;
    public const int GL_READ_PIXELS_FORMAT = 0x828D;
    public const int GL_READ_PIXELS_TYPE = 0x828E;
    public const int GL_TEXTURE_IMAGE_FORMAT = 0x828F;
    public const int GL_TEXTURE_IMAGE_TYPE = 0x8290;
    public const int GL_GET_TEXTURE_IMAGE_FORMAT = 0x8291;
    public const int GL_GET_TEXTURE_IMAGE_TYPE = 0x8292;
    public const int GL_MIPMAP = 0x8293;
    public const int GL_MANUAL_GENERATE_MIPMAP = 0x8294;
    public const int GL_AUTO_GENERATE_MIPMAP = 0x8295;
    public const int GL_COLOR_ENCODING = 0x8296;
    public const int GL_SRGB_READ = 0x8297;
    public const int GL_SRGB_WRITE = 0x8298;
    public const int GL_FILTER = 0x829A;
    public const int GL_VERTEX_TEXTURE = 0x829B;
    public const int GL_TESS_CONTROL_TEXTURE = 0x829C;
    public const int GL_TESS_EVALUATION_TEXTURE = 0x829D;
    public const int GL_GEOMETRY_TEXTURE = 0x829E;
    public const int GL_FRAGMENT_TEXTURE = 0x829F;
    public const int GL_COMPUTE_TEXTURE = 0x82A0;
    public const int GL_TEXTURE_SHADOW = 0x82A1;
    public const int GL_TEXTURE_GATHER = 0x82A2;
    public const int GL_TEXTURE_GATHER_SHADOW = 0x82A3;
    public const int GL_SHADER_IMAGE_LOAD = 0x82A4;
    public const int GL_SHADER_IMAGE_STORE = 0x82A5;
    public const int GL_SHADER_IMAGE_ATOMIC = 0x82A6;
    public const int GL_IMAGE_TEXEL_SIZE = 0x82A7;
    public const int GL_IMAGE_COMPATIBILITY_CLASS = 0x82A8;
    public const int GL_IMAGE_PIXEL_FORMAT = 0x82A9;
    public const int GL_IMAGE_PIXEL_TYPE = 0x82AA;
    public const int GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_TEST = 0x82AC;
    public const int GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_TEST = 0x82AD;
    public const int GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_WRITE = 0x82AE;
    public const int GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_WRITE = 0x82AF;
    public const int GL_TEXTURE_COMPRESSED_BLOCK_WIDTH = 0x82B1;
    public const int GL_TEXTURE_COMPRESSED_BLOCK_HEIGHT = 0x82B2;
    public const int GL_TEXTURE_COMPRESSED_BLOCK_SIZE = 0x82B3;
    public const int GL_CLEAR_BUFFER = 0x82B4;
    public const int GL_TEXTURE_VIEW = 0x82B5;
    public const int GL_VIEW_COMPATIBILITY_CLASS = 0x82B6;
    public const int GL_FULL_SUPPORT = 0x82B7;
    public const int GL_CAVEAT_SUPPORT = 0x82B8;
    public const int GL_IMAGE_CLASS_4_X_32 = 0x82B9;
    public const int GL_IMAGE_CLASS_2_X_32 = 0x82BA;
    public const int GL_IMAGE_CLASS_1_X_32 = 0x82BB;
    public const int GL_IMAGE_CLASS_4_X_16 = 0x82BC;
    public const int GL_IMAGE_CLASS_2_X_16 = 0x82BD;
    public const int GL_IMAGE_CLASS_1_X_16 = 0x82BE;
    public const int GL_IMAGE_CLASS_4_X_8 = 0x82BF;
    public const int GL_IMAGE_CLASS_2_X_8 = 0x82C0;
    public const int GL_IMAGE_CLASS_1_X_8 = 0x82C1;
    public const int GL_IMAGE_CLASS_11_11_10 = 0x82C2;
    public const int GL_IMAGE_CLASS_10_10_10_2 = 0x82C3;
    public const int GL_VIEW_CLASS_128_BITS = 0x82C4;
    public const int GL_VIEW_CLASS_96_BITS = 0x82C5;
    public const int GL_VIEW_CLASS_64_BITS = 0x82C6;
    public const int GL_VIEW_CLASS_48_BITS = 0x82C7;
    public const int GL_VIEW_CLASS_32_BITS = 0x82C8;
    public const int GL_VIEW_CLASS_24_BITS = 0x82C9;
    public const int GL_VIEW_CLASS_16_BITS = 0x82CA;
    public const int GL_VIEW_CLASS_8_BITS = 0x82CB;
    public const int GL_VIEW_CLASS_S3TC_DXT1_RGB = 0x82CC;
    public const int GL_VIEW_CLASS_S3TC_DXT1_RGBA = 0x82CD;
    public const int GL_VIEW_CLASS_S3TC_DXT3_RGBA = 0x82CE;
    public const int GL_VIEW_CLASS_S3TC_DXT5_RGBA = 0x82CF;
    public const int GL_VIEW_CLASS_RGTC1_RED = 0x82D0;
    public const int GL_VIEW_CLASS_RGTC2_RG = 0x82D1;
    public const int GL_VIEW_CLASS_BPTC_UNORM = 0x82D2;
    public const int GL_VIEW_CLASS_BPTC_FLOAT = 0x82D3;
    public const int GL_UNIFORM = 0x92E1;
    public const int GL_UNIFORM_BLOCK = 0x92E2;
    public const int GL_PROGRAM_INPUT = 0x92E3;
    public const int GL_PROGRAM_OUTPUT = 0x92E4;
    public const int GL_BUFFER_VARIABLE = 0x92E5;
    public const int GL_SHADER_STORAGE_BLOCK = 0x92E6;
    public const int GL_VERTEX_SUBROUTINE = 0x92E8;
    public const int GL_TESS_CONTROL_SUBROUTINE = 0x92E9;
    public const int GL_TESS_EVALUATION_SUBROUTINE = 0x92EA;
    public const int GL_GEOMETRY_SUBROUTINE = 0x92EB;
    public const int GL_FRAGMENT_SUBROUTINE = 0x92EC;
    public const int GL_COMPUTE_SUBROUTINE = 0x92ED;
    public const int GL_VERTEX_SUBROUTINE_UNIFORM = 0x92EE;
    public const int GL_TESS_CONTROL_SUBROUTINE_UNIFORM = 0x92EF;
    public const int GL_TESS_EVALUATION_SUBROUTINE_UNIFORM = 0x92F0;
    public const int GL_GEOMETRY_SUBROUTINE_UNIFORM = 0x92F1;
    public const int GL_FRAGMENT_SUBROUTINE_UNIFORM = 0x92F2;
    public const int GL_COMPUTE_SUBROUTINE_UNIFORM = 0x92F3;
    public const int GL_TRANSFORM_FEEDBACK_VARYING = 0x92F4;
    public const int GL_ACTIVE_RESOURCES = 0x92F5;
    public const int GL_MAX_NAME_LENGTH = 0x92F6;
    public const int GL_MAX_NUM_ACTIVE_VARIABLES = 0x92F7;
    public const int GL_MAX_NUM_COMPATIBLE_SUBROUTINES = 0x92F8;
    public const int GL_NAME_LENGTH = 0x92F9;
    public const int GL_TYPE = 0x92FA;
    public const int GL_ARRAY_SIZE = 0x92FB;
    public const int GL_OFFSET = 0x92FC;
    public const int GL_BLOCK_INDEX = 0x92FD;
    public const int GL_ARRAY_STRIDE = 0x92FE;
    public const int GL_MATRIX_STRIDE = 0x92FF;
    public const int GL_IS_ROW_MAJOR = 0x9300;
    public const int GL_ATOMIC_COUNTER_BUFFER_INDEX = 0x9301;
    public const int GL_BUFFER_BINDING = 0x9302;
    public const int GL_BUFFER_DATA_SIZE = 0x9303;
    public const int GL_NUM_ACTIVE_VARIABLES = 0x9304;
    public const int GL_ACTIVE_VARIABLES = 0x9305;
    public const int GL_REFERENCED_BY_VERTEX_SHADER = 0x9306;
    public const int GL_REFERENCED_BY_TESS_CONTROL_SHADER = 0x9307;
    public const int GL_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x9308;
    public const int GL_REFERENCED_BY_GEOMETRY_SHADER = 0x9309;
    public const int GL_REFERENCED_BY_FRAGMENT_SHADER = 0x930A;
    public const int GL_REFERENCED_BY_COMPUTE_SHADER = 0x930B;
    public const int GL_TOP_LEVEL_ARRAY_SIZE = 0x930C;
    public const int GL_TOP_LEVEL_ARRAY_STRIDE = 0x930D;
    public const int GL_LOCATION = 0x930E;
    public const int GL_LOCATION_INDEX = 0x930F;
    public const int GL_IS_PER_PATCH = 0x92E7;
    public const int GL_SHADER_STORAGE_BUFFER = 0x90D2;
    public const int GL_SHADER_STORAGE_BUFFER_BINDING = 0x90D3;
    public const int GL_SHADER_STORAGE_BUFFER_START = 0x90D4;
    public const int GL_SHADER_STORAGE_BUFFER_SIZE = 0x90D5;
    public const int GL_MAX_VERTEX_SHADER_STORAGE_BLOCKS = 0x90D6;
    public const int GL_MAX_GEOMETRY_SHADER_STORAGE_BLOCKS = 0x90D7;
    public const int GL_MAX_TESS_CONTROL_SHADER_STORAGE_BLOCKS = 0x90D8;
    public const int GL_MAX_TESS_EVALUATION_SHADER_STORAGE_BLOCKS = 0x90D9;
    public const int GL_MAX_FRAGMENT_SHADER_STORAGE_BLOCKS = 0x90DA;
    public const int GL_MAX_COMPUTE_SHADER_STORAGE_BLOCKS = 0x90DB;
    public const int GL_MAX_COMBINED_SHADER_STORAGE_BLOCKS = 0x90DC;
    public const int GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS = 0x90DD;
    public const int GL_MAX_SHADER_STORAGE_BLOCK_SIZE = 0x90DE;
    public const int GL_SHADER_STORAGE_BUFFER_OFFSET_ALIGNMENT = 0x90DF;
    public const int GL_SHADER_STORAGE_BARRIER_BIT = 0x00002000;
    public const int GL_MAX_COMBINED_SHADER_OUTPUT_RESOURCES = 0x8F39;
    public const int GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA;
    public const int GL_TEXTURE_BUFFER_OFFSET = 0x919D;
    public const int GL_TEXTURE_BUFFER_SIZE = 0x919E;
    public const int GL_TEXTURE_BUFFER_OFFSET_ALIGNMENT = 0x919F;
    public const int GL_TEXTURE_VIEW_MIN_LEVEL = 0x82DB;
    public const int GL_TEXTURE_VIEW_NUM_LEVELS = 0x82DC;
    public const int GL_TEXTURE_VIEW_MIN_LAYER = 0x82DD;
    public const int GL_TEXTURE_VIEW_NUM_LAYERS = 0x82DE;
    public const int GL_TEXTURE_IMMUTABLE_LEVELS = 0x82DF;
    public const int GL_VERTEX_ATTRIB_BINDING = 0x82D4;
    public const int GL_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D5;
    public const int GL_VERTEX_BINDING_DIVISOR = 0x82D6;
    public const int GL_VERTEX_BINDING_OFFSET = 0x82D7;
    public const int GL_VERTEX_BINDING_STRIDE = 0x82D8;
    public const int GL_MAX_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D9;
    public const int GL_MAX_VERTEX_ATTRIB_BINDINGS = 0x82DA;
    public const int GL_VERTEX_BINDING_BUFFER = 0x8F4F;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARBUFFERDATAPROC(GLenum target, GLenum internalformat, GLenum format, GLenum type, void* data);
    private static PFNGLCLEARBUFFERDATAPROC _glClearBufferData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearBufferData(GLenum target, GLenum internalformat, GLenum format, GLenum type, void* data) => _glClearBufferData(target, internalformat, format, type, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearBufferData<T>(GLenum target, GLenum internalformat, GLenum format, GLenum type, T data) where T : unmanaged => _glClearBufferData(target, internalformat, format, type, &data);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARBUFFERSUBDATAPROC(GLenum target, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, void* data);
    private static PFNGLCLEARBUFFERSUBDATAPROC _glClearBufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearBufferSubData(GLenum target, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, void* data) => _glClearBufferSubData(target, internalformat, offset, size, format, type, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearBufferSubData<T>(GLenum target, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, T data) where T : unmanaged => _glClearBufferSubData(target, internalformat, offset, size, format, type, &data);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDISPATCHCOMPUTEPROC(GLuint num_groups_x, GLuint num_groups_y, GLuint num_groups_z);
    private static PFNGLDISPATCHCOMPUTEPROC _glDispatchCompute;
    public static void glDispatchCompute(GLuint num_groups_x, GLuint num_groups_y, GLuint num_groups_z) => _glDispatchCompute(num_groups_x, num_groups_y, num_groups_z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDISPATCHCOMPUTEINDIRECTPROC(void* indirect);
    private static PFNGLDISPATCHCOMPUTEINDIRECTPROC _glDispatchComputeIndirect;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDispatchComputeIndirect(void* indirect) => _glDispatchComputeIndirect(indirect);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public struct DispatchIndirectCommand
    {
        public uint num_groups_x;
        public uint num_groups_y;
        public uint num_groups_z;
    }
    public static void glDispatchComputeIndirect(DispatchIndirectCommand indirect) => _glDispatchComputeIndirect(&indirect);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYIMAGESUBDATAPROC(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth);
    private static PFNGLCOPYIMAGESUBDATAPROC _glCopyImageSubData;
    public static void glCopyImageSubData(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth) => _glCopyImageSubData(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFRAMEBUFFERPARAMETERIPROC(GLenum target, GLenum pname, GLint param);
    private static PFNGLFRAMEBUFFERPARAMETERIPROC _glFramebufferParameteri;
    public static void glFramebufferParameteri(GLenum target, GLenum pname, GLint param) => _glFramebufferParameteri(target, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETFRAMEBUFFERPARAMETERIVPROC(GLenum target, GLenum pname, GLint* parameters);
    private static PFNGLGETFRAMEBUFFERPARAMETERIVPROC _glGetFramebufferParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetFramebufferParameteriv(GLenum target, GLenum pname, GLint* parameters) => _glGetFramebufferParameteriv(target, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetFramebufferParameteriv(GLenum target, GLenum pname, ref GLint[] parameters) { fixed (GLint* p_parameters = &parameters[0]) _glGetFramebufferParameteriv(target, pname, p_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETINTERNALFORMATI64VPROC(GLenum target, GLenum internalformat, GLenum pname, GLsizei count, GLint64* @params);
    private static PFNGLGETINTERNALFORMATI64VPROC _glGetInternalformati64v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetInternalformati64v(GLenum target, GLenum internalformat, GLenum pname, GLsizei count, GLint64* @params) => _glGetInternalformati64v(target, internalformat, pname, count, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetInternalformati64v(GLenum target, GLenum internalformat, GLenum pname, GLsizei count, ref GLint64[] @params) { fixed (GLint64* p_params = &@params[0]) _glGetInternalformati64v(target, internalformat, pname, count, p_params); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATETEXSUBIMAGEPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth);
    private static PFNGLINVALIDATETEXSUBIMAGEPROC _glInvalidateTexSubImage;
    public static void glInvalidateTexSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth) => _glInvalidateTexSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATETEXIMAGEPROC(GLuint texture, GLint level);
    private static PFNGLINVALIDATETEXIMAGEPROC _glInvalidateTexImage;
    public static void glInvalidateTexImage(GLuint texture, GLint level) => _glInvalidateTexImage(texture, level);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATEBUFFERSUBDATAPROC(GLuint buffer, GLintptr offset, GLsizeiptr length);
    private static PFNGLINVALIDATEBUFFERSUBDATAPROC _glInvalidateBufferSubData;
    public static void glInvalidateBufferSubData(GLuint buffer, GLintptr offset, GLsizeiptr length) => _glInvalidateBufferSubData(buffer, offset, length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATEBUFFERDATAPROC(GLuint buffer);
    private static PFNGLINVALIDATEBUFFERDATAPROC _glInvalidateBufferData;
    public static void glInvalidateBufferData(GLuint buffer) => _glInvalidateBufferData(buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATEFRAMEBUFFERPROC(GLenum target, GLsizei numAttachments, GLenum* attachments);
    private static PFNGLINVALIDATEFRAMEBUFFERPROC _glInvalidateFramebuffer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glInvalidateFramebuffer(GLenum target, GLsizei numAttachments, GLenum* attachments) => _glInvalidateFramebuffer(target, numAttachments, attachments);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glInvalidateFramebuffer(GLenum target, GLsizei numAttachments, GLenum[] attachments) { fixed (GLenum* p_attachments = &attachments[0]) _glInvalidateFramebuffer(target, numAttachments, p_attachments); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATESUBFRAMEBUFFERPROC(GLenum target, GLsizei numAttachments, GLenum* attachments, GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLINVALIDATESUBFRAMEBUFFERPROC _glInvalidateSubFramebuffer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glInvalidateSubFramebuffer(GLenum target, GLsizei numAttachments, GLenum* attachments, GLint x, GLint y, GLsizei width, GLsizei height) => _glInvalidateSubFramebuffer(target, numAttachments, attachments, x, y, width, height);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glInvalidateSubFramebuffer(GLenum target, GLsizei numAttachments, GLenum[] attachments, GLint x, GLint y, GLsizei width, GLsizei height) { fixed (GLenum* p_attachments = &attachments[0]) _glInvalidateSubFramebuffer(target, numAttachments, p_attachments, x, y, width, height); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWARRAYSINDIRECTPROC(GLenum mode, void* indirect, GLsizei drawcount, GLsizei stride);
    private static PFNGLMULTIDRAWARRAYSINDIRECTPROC _glMultiDrawArraysIndirect;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawArraysIndirect(GLenum mode, void* indirect, GLsizei drawcount, GLsizei stride) => _glMultiDrawArraysIndirect(mode, indirect, drawcount, stride);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawArraysIndirect(GLenum mode, DrawArraysIndirectCommand indirect, GLsizei drawcount, GLsizei stride) => _glMultiDrawArraysIndirect(mode, (void*)&indirect, drawcount, stride);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWELEMENTSINDIRECTPROC(GLenum mode, GLenum type, void* indirect, GLsizei drawcount, GLsizei stride);
    private static PFNGLMULTIDRAWELEMENTSINDIRECTPROC _glMultiDrawElementsIndirect;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawElementsIndirect(GLenum mode, GLenum type, void* indirect, GLsizei drawcount, GLsizei stride) => _glMultiDrawElementsIndirect(mode, type, indirect, drawcount, stride);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawElementsIndirect(GLenum mode, GLenum type, DrawElementsIndirectCommand indirect, GLsizei drawcount, GLsizei stride) => _glMultiDrawElementsIndirect(mode, type, (void*)&indirect, drawcount, stride);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMINTERFACEIVPROC(GLuint program, GLenum programInterface, GLenum pname, GLint* parameters);
    private static PFNGLGETPROGRAMINTERFACEIVPROC _glGetProgramInterfaceiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramInterfaceiv(GLuint program, GLenum programInterface, GLenum pname, GLint* parameters) => _glGetProgramInterfaceiv(program, programInterface, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetProgramInterfaceiv(GLuint program, GLenum programInterface, GLenum pname, ref GLint[] parameters) { fixed (GLint* p_parameters = &parameters[0]) _glGetProgramInterfaceiv(program, programInterface, pname, p_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLGETPROGRAMRESOURCEINDEXPROC(GLuint program, GLenum programInterface, GLchar* name);
    private static PFNGLGETPROGRAMRESOURCEINDEXPROC _glGetProgramResourceIndex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLuint glGetProgramResourceIndex(GLuint program, GLenum programInterface, GLchar* name) => _glGetProgramResourceIndex(program, programInterface, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint glGetProgramResourceIndex(GLuint program, GLenum programInterface, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p_name = &nameBytes[0])
        {
            return _glGetProgramResourceIndex(program, programInterface, p_name);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMRESOURCENAMEPROC(GLuint program, GLenum programInterface, GLuint index, GLsizei bufSize, GLsizei* length, GLchar* name);
    private static PFNGLGETPROGRAMRESOURCENAMEPROC _glGetProgramResourceName;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramResourceName(GLuint program, GLenum programInterface, GLuint index, GLsizei bufSize, GLsizei* length, GLchar* name) => _glGetProgramResourceName(program, programInterface, index, bufSize, length, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetProgramResourceName(GLuint program, GLenum programInterface, GLuint index, GLsizei bufSize)
    {
        GLchar[] name = new GLchar[bufSize];
        GLsizei length;
        fixed (GLchar* p_name = &name[0])
        {
            _glGetProgramResourceName(program, programInterface, index, bufSize, &length, p_name);
            return new string((sbyte*)p_name, 0, length, Encoding.UTF8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETPROGRAMRESOURCEIVPROC(GLuint program, GLenum programInterface, GLuint index, GLsizei propCount, GLenum* props, GLsizei bufSize, GLsizei* length, GLint* @params);
    private static PFNGLGETPROGRAMRESOURCEIVPROC _glGetProgramResourceiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetProgramResourceiv(GLuint program, GLenum programInterface, GLuint index, GLsizei propCount, GLenum* props, GLsizei bufSize, GLsizei* length, GLint* @params) => _glGetProgramResourceiv(program, programInterface, index, propCount, props, bufSize, length, @params);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetProgramResourceiv(GLuint program, GLenum programInterface, GLuint index, GLenum[] props, GLsizei bufSize, ref GLint[] @params)
    {
        fixed (GLenum* p_props = &props[0])
        fixed (GLint* p_params = &@params[0])
        {
            GLsizei length;
            _glGetProgramResourceiv(program, programInterface, index, props.Length, p_props, bufSize, &length, p_params);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETPROGRAMRESOURCELOCATIONPROC(GLuint program, GLenum programInterface, GLchar* name);
    private static PFNGLGETPROGRAMRESOURCELOCATIONPROC _glGetProgramResourceLocation;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetProgramResourceLocation(GLuint program, GLenum programInterface, GLchar* name) => _glGetProgramResourceLocation(program, programInterface, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetProgramResourceLocation(GLuint program, GLenum programInterface, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p_name = &nameBytes[0])
        {
            return _glGetProgramResourceLocation(program, programInterface, p_name);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLint PFNGLGETPROGRAMRESOURCELOCATIONINDEXPROC(GLuint program, GLenum programInterface, GLchar* name);
    private static PFNGLGETPROGRAMRESOURCELOCATIONINDEXPROC _glGetProgramResourceLocationIndex;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLint glGetProgramResourceLocationIndex(GLuint program, GLenum programInterface, GLchar* name) => _glGetProgramResourceLocationIndex(program, programInterface, name);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLint glGetProgramResourceLocationIndex(GLuint program, GLenum programInterface, string name)
    {
        GLchar[] nameBytes = Encoding.UTF8.GetBytes(name);
        fixed (GLchar* p_name = &nameBytes[0])
        {
            return _glGetProgramResourceLocationIndex(program, programInterface, p_name);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSHADERSTORAGEBLOCKBINDINGPROC(GLuint program, GLuint storageBlockIndex, GLuint storageBlockBinding);
    private static PFNGLSHADERSTORAGEBLOCKBINDINGPROC _glShaderStorageBlockBinding;
    public static void glShaderStorageBlockBinding(GLuint program, GLuint storageBlockIndex, GLuint storageBlockBinding) => _glShaderStorageBlockBinding(program, storageBlockIndex, storageBlockBinding);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXBUFFERRANGEPROC(GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);
    private static PFNGLTEXBUFFERRANGEPROC _glTexBufferRange;
    public static void glTexBufferRange(GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size) => _glTexBufferRange(target, internalformat, buffer, offset, size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSTORAGE2DMULTISAMPLEPROC(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);
    private static PFNGLTEXSTORAGE2DMULTISAMPLEPROC _glTexStorage2DMultisample;
    public static void glTexStorage2DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations) => _glTexStorage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXSTORAGE3DMULTISAMPLEPROC(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);
    private static PFNGLTEXSTORAGE3DMULTISAMPLEPROC _glTexStorage3DMultisample;
    public static void glTexStorage3DMultisample(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations) => _glTexStorage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREVIEWPROC(GLuint texture, GLenum target, GLuint origtexture, GLenum internalformat, GLuint minlevel, GLuint numlevels, GLuint minlayer, GLuint numlayers);
    private static PFNGLTEXTUREVIEWPROC _glTextureView;
    public static void glTextureView(GLuint texture, GLenum target, GLuint origtexture, GLenum internalformat, GLuint minlevel, GLuint numlevels, GLuint minlayer, GLuint numlayers) => _glTextureView(texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDVERTEXBUFFERPROC(GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride);
    private static PFNGLBINDVERTEXBUFFERPROC _glBindVertexBuffer;
    public static void glBindVertexBuffer(GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride) => _glBindVertexBuffer(bindingindex, buffer, offset, stride);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBFORMATPROC(GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset);
    private static PFNGLVERTEXATTRIBFORMATPROC _glVertexAttribFormat;
    public static void glVertexAttribFormat(GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset) => _glVertexAttribFormat(attribindex, size, type, normalized, relativeoffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBIFORMATPROC(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);
    private static PFNGLVERTEXATTRIBIFORMATPROC _glVertexAttribIFormat;
    public static void glVertexAttribIFormat(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset) => _glVertexAttribIFormat(attribindex, size, type, relativeoffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBLFORMATPROC(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);
    private static PFNGLVERTEXATTRIBLFORMATPROC _glVertexAttribLFormat;
    public static void glVertexAttribLFormat(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset) => _glVertexAttribLFormat(attribindex, size, type, relativeoffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXATTRIBBINDINGPROC(GLuint attribindex, GLuint bindingindex);
    private static PFNGLVERTEXATTRIBBINDINGPROC _glVertexAttribBinding;
    public static void glVertexAttribBinding(GLuint attribindex, GLuint bindingindex) => _glVertexAttribBinding(attribindex, bindingindex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXBINDINGDIVISORPROC(GLuint bindingindex, GLuint divisor);
    private static PFNGLVERTEXBINDINGDIVISORPROC _glVertexBindingDivisor;
    public static void glVertexBindingDivisor(GLuint bindingindex, GLuint divisor) => _glVertexBindingDivisor(bindingindex, divisor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEBUGMESSAGECONTROLPROC(GLenum source, GLenum type, GLenum severity, GLsizei count, GLuint* ids, GLboolean enabled);
    private static PFNGLDEBUGMESSAGECONTROLPROC _glDebugMessageControl;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDebugMessageControl(GLenum source, GLenum type, GLenum severity, GLsizei count, GLuint* ids, GLboolean enabled) => _glDebugMessageControl(source, type, severity, count, ids, enabled);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDebugMessageControl(GLenum source, GLenum type, GLenum severity, GLuint[] ids, GLboolean enabled) { fixed (GLuint* p_ids = ids) { _glDebugMessageControl(source, type, severity, ids.Length, p_ids, enabled); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEBUGMESSAGEINSERTPROC(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, GLchar* buf);
    private static PFNGLDEBUGMESSAGEINSERTPROC _glDebugMessageInsert;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDebugMessageInsert(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, GLchar* buf) => _glDebugMessageInsert(source, type, id, severity, length, buf);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glDebugMessageInsert(GLenum source, GLenum type, GLuint id, GLenum severity, string buf)
    {
        GLchar[] bufBytes = Encoding.UTF8.GetBytes(buf);
        fixed (GLchar* p_bufBytes = bufBytes) { _glDebugMessageInsert(source, type, id, severity, bufBytes.Length, p_bufBytes); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void GLDEBUGPROC(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, GLchar* message, void* userParam);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDEBUGMESSAGECALLBACKPROC(GLDEBUGPROC callback, void* userParam);
    private static PFNGLDEBUGMESSAGECALLBACKPROC _glDebugMessageCallback;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glDebugMessageCallback(GLDEBUGPROC callback, void* userParam) => _glDebugMessageCallback(callback, userParam);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public delegate void GLDEBUGPROCSAFE(GLenum source, GLenum type, GLuint id, GLenum severity, string message, void* userParam);
    public static void glDebugMessageCallback(GLDEBUGPROCSAFE callback, void* userParam)
    {
        GLDEBUGPROC callbackUnsafe = (GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, GLchar* message, void* userParam) =>
        {
            string messageString = new string((sbyte*)message, 0, length, Encoding.UTF8);
            callback(source, type, id, severity, messageString, userParam);
        };
        _glDebugMessageCallback(callbackUnsafe, userParam);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLuint PFNGLGETDEBUGMESSAGELOGPROC(GLuint count, GLsizei bufsize, GLenum* sources, GLenum* types, GLuint* ids, GLenum* severities, GLsizei* lengths, GLchar* messageLog);
    private static PFNGLGETDEBUGMESSAGELOGPROC _glGetDebugMessageLog;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static GLuint glGetDebugMessageLog(GLuint count, GLsizei bufsize, GLenum* sources, GLenum* types, GLuint* ids, GLenum* severities, GLsizei* lengths, GLchar* messageLog) => _glGetDebugMessageLog(count, bufsize, sources, types, ids, severities, lengths, messageLog);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint glGetDebugMessageLog(GLuint count, GLsizei bufSize, out GLenum[] sources, out GLenum[] types, out GLuint[] ids, out GLenum[] severities, out string[] messageLog)
    {
        sources = new GLenum[count];
        types = new GLenum[count];
        ids = new GLuint[count];
        severities = new GLenum[count];

        GLchar[] messageLogBytes = new GLchar[bufSize];
        GLsizei[] lengths = new GLsizei[count];
        fixed (GLenum* p_sources = &sources[0])
        fixed (GLenum* p_types = &types[0])
        fixed (GLuint* p_ids = &ids[0])
        fixed (GLenum* p_severities = &severities[0])
        fixed (GLsizei* p_lengths = &lengths[0])
        fixed (GLchar* p_messageLogBytes = &messageLogBytes[0])
        {
            GLchar* pstart = p_messageLogBytes;
            GLuint ret = _glGetDebugMessageLog(count, bufSize, p_sources, p_types, p_ids, p_severities, p_lengths, p_messageLogBytes);
            messageLog = new string[count];
            for (int i = 0; i < count; i++)
            {
                messageLog[i] = new string((sbyte*)pstart, 0, lengths[i], Encoding.UTF8);
                pstart += lengths[i];
            }

            Array.Resize(ref sources, (int)ret);
            Array.Resize(ref types, (int)ret);
            Array.Resize(ref ids, (int)ret);
            Array.Resize(ref severities, (int)ret);
            Array.Resize(ref messageLog, (int)ret);

            return ret;
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPUSHDEBUGGROUPPROC(GLenum source, GLuint id, GLsizei length, GLchar* message);
    private static PFNGLPUSHDEBUGGROUPPROC _glPushDebugGroup;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glPushDebugGroup(GLenum source, GLuint id, GLsizei length, GLchar* message) => _glPushDebugGroup(source, id, length, message);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glPushDebugGroup(GLenum source, GLuint id, string message)
    {
        GLchar[] messageBytes = Encoding.UTF8.GetBytes(message);
        fixed (GLchar* p_messageBytes = messageBytes) { _glPushDebugGroup(source, id, messageBytes.Length, p_messageBytes); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOPDEBUGGROUPPROC();
    private static PFNGLPOPDEBUGGROUPPROC _glPopDebugGroup;
    public static void glPopDebugGroup() => _glPopDebugGroup();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLOBJECTLABELPROC(GLenum identifier, GLuint name, GLsizei length, GLchar* label);
    private static PFNGLOBJECTLABELPROC _glObjectLabel;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glObjectLabel(GLenum identifier, GLuint name, GLsizei length, GLchar* label) => _glObjectLabel(identifier, name, length, label);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glObjectLabel(GLenum identifier, GLuint name, string label)
    {
        GLchar[] labelBytes = Encoding.UTF8.GetBytes(label);
        fixed (GLchar* p_labelBytes = labelBytes) { _glObjectLabel(identifier, name, labelBytes.Length, p_labelBytes); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETOBJECTLABELPROC(GLenum identifier, GLuint name, GLsizei bufSize, GLsizei* length, GLchar* label);
    private static PFNGLGETOBJECTLABELPROC _glGetObjectLabel;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetObjectLabel(GLenum identifier, GLuint name, GLsizei bufSize, GLsizei* length, GLchar* label) => _glGetObjectLabel(identifier, name, bufSize, length, label);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetObjectLabel(GLenum identifier, GLuint name, GLsizei bufSize)
    {
        GLchar[] labelBytes = new GLchar[bufSize];
        GLsizei length;
        fixed (GLchar* p_labelBytes = labelBytes)
        {
            _glGetObjectLabel(identifier, name, bufSize, &length, p_labelBytes);
            return new string((sbyte*)p_labelBytes, 0, length, Encoding.UTF8);
        }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLOBJECTPTRLABELPROC(void* ptr, GLsizei length, GLchar* label);
    private static PFNGLOBJECTPTRLABELPROC _glObjectPtrLabel;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glObjectPtrLabel(void* ptr, GLsizei length, GLchar* label) => _glObjectPtrLabel(ptr, length, label);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glObjectPtrLabel(IntPtr ptr, string label)
    {
        GLchar[] labelBytes = Encoding.UTF8.GetBytes(label);
        fixed (GLchar* p_labelBytes = labelBytes) { _glObjectPtrLabel(ptr.ToPointer(), labelBytes.Length, p_labelBytes); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETOBJECTPTRLABELPROC(void* ptr, GLsizei bufSize, GLsizei* length, GLchar* label);
    private static PFNGLGETOBJECTPTRLABELPROC _glGetObjectPtrLabel;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetObjectPtrLabel(void* ptr, GLsizei bufSize, GLsizei* length, GLchar* label) => _glGetObjectPtrLabel(ptr, bufSize, length, label);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static string glGetObjectPtrLabel(IntPtr ptr, GLsizei bufSize)
    {
        GLchar[] labelBytes = new GLchar[bufSize];
        GLsizei length;
        fixed (GLchar* p_labelBytes = labelBytes)
        {
            _glGetObjectPtrLabel(ptr.ToPointer(), bufSize, &length, p_labelBytes);
            return new string((sbyte*)p_labelBytes, 0, length, Encoding.UTF8);
        }
    }
#endif

#endif

    // OpenGL 4.4

#if OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6

    public const int GL_MAX_VERTEX_ATTRIB_STRIDE = 0x82E5;
    public const int GL_PRIMITIVE_RESTART_FOR_PATCHES_SUPPORTED = 0x8221;
    public const int GL_TEXTURE_BUFFER_BINDING = 0x8C2A;
    public const int GL_MAP_PERSISTENT_BIT = 0x0040;
    public const int GL_MAP_COHERENT_BIT = 0x0080;
    public const int GL_DYNAMIC_STORAGE_BIT = 0x0100;
    public const int GL_CLIENT_STORAGE_BIT = 0x0200;
    public const int GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT = 0x00004000;
    public const int GL_BUFFER_IMMUTABLE_STORAGE = 0x821F;
    public const int GL_BUFFER_STORAGE_FLAGS = 0x8220;
    public const int GL_CLEAR_TEXTURE = 0x9365;
    public const int GL_LOCATION_COMPONENT = 0x934A;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_INDEX = 0x934B;
    public const int GL_TRANSFORM_FEEDBACK_BUFFER_STRIDE = 0x934C;
    public const int GL_QUERY_BUFFER = 0x9192;
    public const int GL_QUERY_BUFFER_BARRIER_BIT = 0x00008000;
    public const int GL_QUERY_BUFFER_BINDING = 0x9193;
    public const int GL_QUERY_RESULT_NO_WAIT = 0x9194;
    public const int GL_MIRROR_CLAMP_TO_EDGE = 0x8743;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBUFFERSTORAGEPROC(GLenum target, GLsizeiptr size, void* data, GLbitfield flags);
    private static PFNGLBUFFERSTORAGEPROC _glBufferStorage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBufferStorage(GLenum target, GLsizeiptr size, void* data, GLbitfield flags) => _glBufferStorage(target, size, data, flags);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBufferStorage<T>(GLenum target, T[] data, GLbitfield flags) where T : unmanaged { fixed (void* p_data = &data[0]) { _glBufferStorage(target, data.Length * sizeof(T), p_data, flags); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARTEXIMAGEPROC(GLuint texture, GLint level, GLenum format, GLenum type, void* data);
    private static PFNGLCLEARTEXIMAGEPROC _glClearTexImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearTexImage(GLuint texture, GLint level, GLenum format, GLenum type, void* data) => _glClearTexImage(texture, level, format, type, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearTexImage<T>(GLuint texture, GLint level, GLenum format, GLenum type, T data) where T : unmanaged { _glClearTexImage(texture, level, format, type, &data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARTEXSUBIMAGEPROC(GLuint texture, GLint level, GLint xOffset, GLint yOffset, GLint zOffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* data);
    private static PFNGLCLEARTEXSUBIMAGEPROC _glClearTexSubImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearTexSubImage(GLuint texture, GLint level, GLint xOffset, GLint yOffset, GLint zOffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* data) => _glClearTexSubImage(texture, level, xOffset, yOffset, zOffset, width, height, depth, format, type, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearTexSubImage<T>(GLuint texture, GLint level, GLint xOffset, GLint yOffset, GLint zOffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, T data) where T : unmanaged { _glClearTexSubImage(texture, level, xOffset, yOffset, zOffset, width, height, depth, format, type, &data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDBUFFERSBASEPROC(GLenum target, GLuint first, GLsizei count, GLuint* buffers);
    private static PFNGLBINDBUFFERSBASEPROC _glBindBuffersBase;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindBuffersBase(GLenum target, GLuint first, GLsizei count, GLuint* buffers) => _glBindBuffersBase(target, first, count, buffers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindBuffersBase(GLenum target, GLuint first, GLuint[] buffers) { fixed (GLuint* p_buffers = &buffers[0]) { _glBindBuffersBase(target, first, buffers.Length, p_buffers); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDBUFFERSRANGEPROC(GLenum target, GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizeiptr* sizes);
    private static PFNGLBINDBUFFERSRANGEPROC _glBindBuffersRange;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindBuffersRange(GLenum target, GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizeiptr* sizes) => _glBindBuffersRange(target, first, count, buffers, offsets, sizes);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindBuffersRange(GLenum target, GLuint first, GLuint[] buffers, GLintptr[] offsets, GLsizeiptr[] sizes) { fixed (GLuint* p_buffers = &buffers[0]) { fixed (GLintptr* p_offsets = &offsets[0]) { fixed (GLsizeiptr* p_sizes = &sizes[0]) { _glBindBuffersRange(target, first, buffers.Length, p_buffers, p_offsets, p_sizes); } } } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDTEXTURESPROC(GLuint first, GLsizei count, GLuint* textures);
    private static PFNGLBINDTEXTURESPROC _glBindTextures;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindTextures(GLuint first, GLsizei count, GLuint* textures) => _glBindTextures(first, count, textures);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindTextures(GLuint first, GLuint[] textures) { fixed (GLuint* p_textures = &textures[0]) { _glBindTextures(first, textures.Length, p_textures); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDSAMPLERSPROC(GLuint first, GLsizei count, GLuint* samplers);
    private static PFNGLBINDSAMPLERSPROC _glBindSamplers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindSamplers(GLuint first, GLsizei count, GLuint* samplers) => _glBindSamplers(first, count, samplers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindSamplers(GLuint first, GLuint[] samplers) { fixed (GLuint* p_samplers = &samplers[0]) { _glBindSamplers(first, samplers.Length, p_samplers); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDIMAGETEXTURESPROC(GLuint first, GLsizei count, GLuint* textures);
    private static PFNGLBINDIMAGETEXTURESPROC _glBindImageTextures;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindImageTextures(GLuint first, GLsizei count, GLuint* textures) => _glBindImageTextures(first, count, textures);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindImageTextures(GLuint first, GLuint[] textures) { fixed (GLuint* p_textures = &textures[0]) { _glBindImageTextures(first, textures.Length, p_textures); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDVERTEXBUFFERSPROC(GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizei* strides);
    private static PFNGLBINDVERTEXBUFFERSPROC _glBindVertexBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glBindVertexBuffers(GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizei* strides) => _glBindVertexBuffers(first, count, buffers, offsets, strides);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glBindVertexBuffers(GLuint first, GLuint[] buffers, GLintptr[] offsets, GLsizei[] strides) { fixed (GLuint* p_buffers = &buffers[0]) { fixed (GLintptr* p_offsets = &offsets[0]) { fixed (GLsizei* p_strides = &strides[0]) { _glBindVertexBuffers(first, buffers.Length, p_buffers, p_offsets, p_strides); } } } }
#endif

#endif

    // OpenGL 4.5

#if OGL_V_4_5 || OGL_V_4_6

    public const int GL_CONTEXT_LOST = 0x0507;
    public const int GL_NEGATIVE_ONE_TO_ONE = 0x935E;
    public const int GL_ZERO_TO_ONE = 0x935F;
    public const int GL_CLIP_ORIGIN = 0x935C;
    public const int GL_CLIP_DEPTH_MODE = 0x935D;
    public const int GL_QUERY_WAIT_INVERTED = 0x8E17;
    public const int GL_QUERY_NO_WAIT_INVERTED = 0x8E18;
    public const int GL_QUERY_BY_REGION_WAIT_INVERTED = 0x8E19;
    public const int GL_QUERY_BY_REGION_NO_WAIT_INVERTED = 0x8E1A;
    public const int GL_MAX_CULL_DISTANCES = 0x82F9;
    public const int GL_MAX_COMBINED_CLIP_AND_CULL_DISTANCES = 0x82FA;
    public const int GL_TEXTURE_TARGET = 0x1006;
    public const int GL_QUERY_TARGET = 0x82EA;
    public const int GL_GUILTY_CONTEXT_RESET = 0x8253;
    public const int GL_INNOCENT_CONTEXT_RESET = 0x8254;
    public const int GL_UNKNOWN_CONTEXT_RESET = 0x8255;
    public const int GL_RESET_NOTIFICATION_STRATEGY = 0x8256;
    public const int GL_LOSE_CONTEXT_ON_RESET = 0x8252;
    public const int GL_NO_RESET_NOTIFICATION = 0x8261;
    public const int GL_CONTEXT_FLAG_ROBUST_ACCESS_BIT = 0x00000004;
    public const int GL_CONTEXT_RELEASE_BEHAVIOR = 0x82FB;
    public const int GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH = 0x82FC;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLIPCONTROLPROC(GLenum origin, GLenum depth);
    private static PFNGLCLIPCONTROLPROC _glClipControl;
    public static void glClipControl(GLenum origin, GLenum depth) => _glClipControl(origin, depth);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATETRANSFORMFEEDBACKSPROC(GLsizei n, GLuint* ids);
    private static PFNGLCREATETRANSFORMFEEDBACKSPROC _glCreateTransformFeedbacks;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateTransformFeedbacks(GLsizei n, GLuint* ids) => _glCreateTransformFeedbacks(n, ids);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateTransformFeedbacks(GLsizei n) { GLuint[] ids = new GLuint[n]; fixed (GLuint* p_ids = &ids[0]) { _glCreateTransformFeedbacks(n, p_ids); } return ids; }
    public static GLuint glCreateTransformFeedbacks() => glCreateTransformFeedbacks(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTRANSFORMFEEDBACKBUFFERBASEPROC(GLuint xfb, GLuint index, GLuint buffer);
    private static PFNGLTRANSFORMFEEDBACKBUFFERBASEPROC _glTransformFeedbackBufferBase;
    public static void glTransformFeedbackBufferBase(GLuint xfb, GLuint index, GLuint buffer) => _glTransformFeedbackBufferBase(xfb, index, buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTRANSFORMFEEDBACKBUFFERRANGEPROC(GLuint xfb, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);
    private static PFNGLTRANSFORMFEEDBACKBUFFERRANGEPROC _glTransformFeedbackBufferRange;
    public static void glTransformFeedbackBufferRange(GLuint xfb, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size) => _glTransformFeedbackBufferRange(xfb, index, buffer, offset, size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTRANSFORMFEEDBACKIVPROC(GLuint xfb, GLenum pname, GLint* param);
    private static PFNGLGETTRANSFORMFEEDBACKIVPROC _glGetTransformFeedbackiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTransformFeedbackiv(GLuint xfb, GLenum pname, GLint* param) => _glGetTransformFeedbackiv(xfb, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTransformFeedbackiv(GLuint xfb, GLenum pname, ref GLint[] param) { fixed (GLint* p_param = &param[0]) { _glGetTransformFeedbackiv(xfb, pname, p_param); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTRANSFORMFEEDBACKI_VPROC(GLuint xfb, GLenum pname, GLuint index, GLint* param);
    private static PFNGLGETTRANSFORMFEEDBACKI_VPROC _glGetTransformFeedbacki_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTransformFeedbacki_v(GLuint xfb, GLenum pname, GLuint index, GLint* param) => _glGetTransformFeedbacki_v(xfb, pname, index, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTransformFeedbacki_v(GLuint xfb, GLenum pname, GLuint index, ref GLint[] param) { fixed (GLint* p_param = &param[0]) { _glGetTransformFeedbacki_v(xfb, pname, index, p_param); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTRANSFORMFEEDBACKI64_VPROC(GLuint xfb, GLenum pname, GLuint index, GLint64* param);
    private static PFNGLGETTRANSFORMFEEDBACKI64_VPROC _glGetTransformFeedbacki64_v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTransformFeedbacki64_v(GLuint xfb, GLenum pname, GLuint index, GLint64* param) => _glGetTransformFeedbacki64_v(xfb, pname, index, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTransformFeedbacki64_v(GLuint xfb, GLenum pname, GLuint index, ref GLint64[] param) { fixed (GLint64* p_param = &param[0]) { _glGetTransformFeedbacki64_v(xfb, pname, index, p_param); } }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATEBUFFERSPROC(GLsizei n, GLuint* buffers);
    private static PFNGLCREATEBUFFERSPROC _glCreateBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateBuffers(GLsizei n, GLuint* buffers) => _glCreateBuffers(n, buffers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateBuffers(GLsizei n) { GLuint[] buffers = new GLuint[n]; fixed (GLuint* p_buffers = &buffers[0]) { _glCreateBuffers(n, p_buffers); } return buffers; }
    public static GLuint glCreateBuffer() => glCreateBuffers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDBUFFERSTORAGEPROC(GLuint buffer, GLsizeiptr size, void* data, GLbitfield flags);
    private static PFNGLNAMEDBUFFERSTORAGEPROC _glNamedBufferStorage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glNamedBufferStorage(GLuint buffer, GLsizeiptr size, void* data, GLbitfield flags) => _glNamedBufferStorage(buffer, size, data, flags);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glNamedBufferStorage<T>(GLuint buffer, GLsizeiptr size, T[] data, GLbitfield flags) where T : unmanaged
    {
        fixed (T* p_data = &data[0]) { _glNamedBufferStorage(buffer, size, p_data, flags); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDBUFFERDATAPROC(GLuint buffer, GLsizeiptr size, void* data, GLenum usage);
    private static PFNGLNAMEDBUFFERDATAPROC _glNamedBufferData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glNamedBufferData(GLuint buffer, GLsizeiptr size, void* data, GLenum usage) => _glNamedBufferData(buffer, size, data, usage);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glNamedBufferData<T>(GLuint buffer, GLsizeiptr size, T[] data, GLenum usage) where T : unmanaged
    {
        fixed (T* p_data = &data[0]) { _glNamedBufferData(buffer, size, p_data, usage); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDBUFFERSUBDATAPROC(GLuint buffer, GLintptr offset, GLsizeiptr size, void* data);
    private static PFNGLNAMEDBUFFERSUBDATAPROC _glNamedBufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glNamedBufferSubData(GLuint buffer, GLintptr offset, GLsizeiptr size, void* data) => _glNamedBufferSubData(buffer, offset, size, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glNamedBufferSubData<T>(GLuint buffer, GLintptr offset, GLsizeiptr size, T[] data) where T : unmanaged
    {
        fixed (T* p_data = &data[0]) { _glNamedBufferSubData(buffer, offset, size, p_data); }
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYNAMEDBUFFERSUBDATAPROC(GLuint readBuffer, GLuint writeBuffer, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);
    private static PFNGLCOPYNAMEDBUFFERSUBDATAPROC _glCopyNamedBufferSubData;
    public static void glCopyNamedBufferSubData(GLuint readBuffer, GLuint writeBuffer, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size) => _glCopyNamedBufferSubData(readBuffer, writeBuffer, readOffset, writeOffset, size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARNAMEDBUFFERDATAPROC(GLuint buffer, GLenum internalformat, GLenum format, GLenum type, void* data);
    private static PFNGLCLEARNAMEDBUFFERDATAPROC _glClearNamedBufferData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearNamedBufferData(GLuint buffer, GLenum internalformat, GLenum format, GLenum type, void* data) => _glClearNamedBufferData(buffer, internalformat, format, type, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearNamedBufferData<T>(GLuint buffer, GLenum internalformat, GLenum format, GLenum type, T data) where T : unmanaged { _glClearNamedBufferData(buffer, internalformat, format, type, &data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARNAMEDBUFFERSUBDATAPROC(GLuint buffer, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, void* data);
    private static PFNGLCLEARNAMEDBUFFERSUBDATAPROC _glClearNamedBufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearNamedBufferSubData(GLuint buffer, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, void* data) => _glClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearNamedBufferSubData<T>(GLuint buffer, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, T data) where T : unmanaged { _glClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, &data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void* PFNGLMAPNAMEDBUFFERPROC(GLuint buffer, GLenum access);
    private static PFNGLMAPNAMEDBUFFERPROC _glMapNamedBuffer;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void* glMapNamedBuffer(GLuint buffer, GLenum access) => _glMapNamedBuffer(buffer, access);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static System.Span<T> glMapNamedBuffer<T>(GLuint buffer, GLenum access) where T : unmanaged
    {
        GLint* size = stackalloc GLint[1];
        _glGetNamedBufferParameteriv(buffer, GL_BUFFER_SIZE, size);
        void* ptr = _glMapNamedBuffer(buffer, access);
        return new System.Span<T>(ptr, *size / sizeof(T));
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void* PFNGLMAPNAMEDBUFFERRANGEPROC(GLuint buffer, GLintptr offset, GLsizeiptr length, GLbitfield access);
    private static PFNGLMAPNAMEDBUFFERRANGEPROC _glMapNamedBufferRange;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void* glMapNamedBufferRange(GLuint buffer, GLintptr offset, GLsizeiptr length, GLbitfield access) => _glMapNamedBufferRange(buffer, offset, length, access);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static System.Span<T> glMapNamedBufferRange<T>(GLuint buffer, GLintptr offset, GLsizeiptr length, GLbitfield access) where T : unmanaged
    {
        void* ptr = _glMapNamedBufferRange(buffer, offset, length, access);
        return new System.Span<T>(ptr, (int)length / sizeof(T));
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLboolean PFNGLUNMAPNAMEDBUFFERPROC(GLuint buffer);
    private static PFNGLUNMAPNAMEDBUFFERPROC _glUnmapNamedBuffer;
    public static GLboolean glUnmapNamedBuffer(GLuint buffer) => _glUnmapNamedBuffer(buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLFLUSHMAPPEDNAMEDBUFFERRANGEPROC(GLuint buffer, GLintptr offset, GLsizeiptr length);
    private static PFNGLFLUSHMAPPEDNAMEDBUFFERRANGEPROC _glFlushMappedNamedBufferRange;
    public static void glFlushMappedNamedBufferRange(GLuint buffer, GLintptr offset, GLsizeiptr length) => _glFlushMappedNamedBufferRange(buffer, offset, length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDBUFFERPARAMETERIVPROC(GLuint buffer, GLenum pname, GLint* parameters);
    private static PFNGLGETNAMEDBUFFERPARAMETERIVPROC _glGetNamedBufferParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedBufferParameteriv(GLuint buffer, GLenum pname, GLint* parameters) => _glGetNamedBufferParameteriv(buffer, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetNamedBufferParameteriv(GLuint buffer, GLenum pname, ref GLint[] parameters) { fixed (GLint* ptr_parameters = &parameters[0]) _glGetNamedBufferParameteriv(buffer, pname, ptr_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDBUFFERPARAMETERI64VPROC(GLuint buffer, GLenum pname, GLint64* parameters);
    private static PFNGLGETNAMEDBUFFERPARAMETERI64VPROC _glGetNamedBufferParameteri64v;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedBufferParameteri64v(GLuint buffer, GLenum pname, GLint64* parameters) => _glGetNamedBufferParameteri64v(buffer, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetNamedBufferParameteri64v(GLuint buffer, GLenum pname, ref GLint64[] parameters) { fixed (GLint64* ptr_parameters = &parameters[0]) _glGetNamedBufferParameteri64v(buffer, pname, ptr_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDBUFFERPOINTERVPROC(GLuint buffer, GLenum pname, void** parameters);
    private static PFNGLGETNAMEDBUFFERPOINTERVPROC _glGetNamedBufferPointerv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedBufferPointerv(GLuint buffer, GLenum pname, void** parameters) => _glGetNamedBufferPointerv(buffer, pname, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetNamedBufferPointerv(GLuint buffer, GLenum pname, ref IntPtr[] parameters)
    {
        void*[] ptr_parameters = new void*[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
            ptr_parameters[i] = (void*)parameters[i];
        fixed (void** ptr = &ptr_parameters[0])
            _glGetNamedBufferPointerv(buffer, pname, ptr);

        for (int i = 0; i < parameters.Length; i++)
            parameters[i] = (IntPtr)ptr_parameters[i];
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDBUFFERSUBDATAPROC(GLuint buffer, GLintptr offset, GLsizeiptr size, void* data);
    private static PFNGLGETNAMEDBUFFERSUBDATAPROC _glGetNamedBufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedBufferSubData(GLuint buffer, GLintptr offset, GLsizeiptr size, void* data) => _glGetNamedBufferSubData(buffer, offset, size, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static T[] glGetNamedBufferSubData<T>(GLuint buffer, GLintptr offset, GLsizeiptr size) where T : unmanaged
    {
        T[] data = new T[size / sizeof(T)];
        fixed (T* ptr_data = &data[0])
            _glGetNamedBufferSubData(buffer, offset, size, ptr_data);
        return data;
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATEFRAMEBUFFERSPROC(GLsizei n, GLuint* framebuffers);
    private static PFNGLCREATEFRAMEBUFFERSPROC _glCreateFramebuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateFramebuffers(GLsizei n, GLuint* framebuffers) => _glCreateFramebuffers(n, framebuffers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateFramebuffers(GLsizei n) { GLuint[] framebuffers = new GLuint[n]; fixed (GLuint* ptr_framebuffers = &framebuffers[0]) _glCreateFramebuffers(n, ptr_framebuffers); return framebuffers; }
    public static GLuint glCreateFramebuffer() => glCreateFramebuffers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERRENDERBUFFERPROC(GLuint framebuffer, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);
    private static PFNGLNAMEDFRAMEBUFFERRENDERBUFFERPROC _glNamedFramebufferRenderbuffer;
    public static void glNamedFramebufferRenderbuffer(GLuint framebuffer, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer) => _glNamedFramebufferRenderbuffer(framebuffer, attachment, renderbuffertarget, renderbuffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERPARAMETERIPROC(GLuint framebuffer, GLenum pname, GLint param);
    private static PFNGLNAMEDFRAMEBUFFERPARAMETERIPROC _glNamedFramebufferParameteri;
    public static void glNamedFramebufferParameteri(GLuint framebuffer, GLenum pname, GLint param) => _glNamedFramebufferParameteri(framebuffer, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTUREPROC(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level);
    private static PFNGLNAMEDFRAMEBUFFERTEXTUREPROC _glNamedFramebufferTexture;
    public static void glNamedFramebufferTexture(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level) => _glNamedFramebufferTexture(framebuffer, attachment, texture, level);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTURELAYERPROC(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level, GLint layer);
    private static PFNGLNAMEDFRAMEBUFFERTEXTURELAYERPROC _glNamedFramebufferTextureLayer;
    public static void glNamedFramebufferTextureLayer(GLuint framebuffer, GLenum attachment, GLuint texture, GLint level, GLint layer) => _glNamedFramebufferTextureLayer(framebuffer, attachment, texture, level, layer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERDRAWBUFFERPROC(GLuint framebuffer, GLenum buf);
    private static PFNGLNAMEDFRAMEBUFFERDRAWBUFFERPROC _glNamedFramebufferDrawBuffer;
    public static void glNamedFramebufferDrawBuffer(GLuint framebuffer, GLenum buf) => _glNamedFramebufferDrawBuffer(framebuffer, buf);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERDRAWBUFFERSPROC(GLuint framebuffer, GLsizei n, GLenum* bufs);
    private static PFNGLNAMEDFRAMEBUFFERDRAWBUFFERSPROC _glNamedFramebufferDrawBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glNamedFramebufferDrawBuffers(GLuint framebuffer, GLsizei n, GLenum* bufs) => _glNamedFramebufferDrawBuffers(framebuffer, n, bufs);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glNamedFramebufferDrawBuffers(GLuint framebuffer, GLenum[] bufs) { fixed (GLenum* ptr_bufs = &bufs[0]) _glNamedFramebufferDrawBuffers(framebuffer, bufs.Length, ptr_bufs); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDFRAMEBUFFERREADBUFFERPROC(GLuint framebuffer, GLenum src);
    private static PFNGLNAMEDFRAMEBUFFERREADBUFFERPROC _glNamedFramebufferReadBuffer;
    public static void glNamedFramebufferReadBuffer(GLuint framebuffer, GLenum src) => _glNamedFramebufferReadBuffer(framebuffer, src);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATENAMEDFRAMEBUFFERDATAPROC(GLuint framebuffer, GLsizei numAttachments, GLenum* attachments);
    private static PFNGLINVALIDATENAMEDFRAMEBUFFERDATAPROC _glInvalidateNamedFramebufferData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glInvalidateNamedFramebufferData(GLuint framebuffer, GLsizei numAttachments, GLenum* attachments) => _glInvalidateNamedFramebufferData(framebuffer, numAttachments, attachments);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glInvalidateNamedFramebufferData(GLuint framebuffer, GLenum[] attachments) { fixed (GLenum* ptr_attachments = &attachments[0]) _glInvalidateNamedFramebufferData(framebuffer, attachments.Length, ptr_attachments); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLINVALIDATENAMEDFRAMEBUFFERSUBDATAPROC(GLuint framebuffer, GLsizei numAttachments, GLenum* attachments, GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLINVALIDATENAMEDFRAMEBUFFERSUBDATAPROC _glInvalidateNamedFramebufferSubData;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glInvalidateNamedFramebufferSubData(GLuint framebuffer, GLsizei numAttachments, GLenum* attachments, GLint x, GLint y, GLsizei width, GLsizei height) => _glInvalidateNamedFramebufferSubData(framebuffer, numAttachments, attachments, x, y, width, height);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glInvalidateNamedFramebufferSubData(GLuint framebuffer, GLenum[] attachments, GLint x, GLint y, GLsizei width, GLsizei height) { fixed (GLenum* ptr_attachments = &attachments[0]) _glInvalidateNamedFramebufferSubData(framebuffer, attachments.Length, ptr_attachments, x, y, width, height); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARNAMEDFRAMEBUFFERIVPROC(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLint* value);
    private static PFNGLCLEARNAMEDFRAMEBUFFERIVPROC _glClearNamedFramebufferiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearNamedFramebufferiv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLint* value) => _glClearNamedFramebufferiv(framebuffer, buffer, drawbuffer, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearNamedFramebufferiv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLint[] value) { fixed (GLint* ptr_value = &value[0]) _glClearNamedFramebufferiv(framebuffer, buffer, drawbuffer, ptr_value); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARNAMEDFRAMEBUFFERUIVPROC(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLuint* value);
    private static PFNGLCLEARNAMEDFRAMEBUFFERUIVPROC _glClearNamedFramebufferuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearNamedFramebufferuiv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLuint* value) => _glClearNamedFramebufferuiv(framebuffer, buffer, drawbuffer, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearNamedFramebufferuiv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLuint[] value) { fixed (GLuint* ptr_value = &value[0]) _glClearNamedFramebufferuiv(framebuffer, buffer, drawbuffer, ptr_value); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARNAMEDFRAMEBUFFERFVPROC(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLfloat* value);
    private static PFNGLCLEARNAMEDFRAMEBUFFERFVPROC _glClearNamedFramebufferfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glClearNamedFramebufferfv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLfloat* value) => _glClearNamedFramebufferfv(framebuffer, buffer, drawbuffer, value);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glClearNamedFramebufferfv(GLuint framebuffer, GLenum buffer, GLint drawbuffer, GLfloat[] value) { fixed (GLfloat* ptr_value = &value[0]) _glClearNamedFramebufferfv(framebuffer, buffer, drawbuffer, ptr_value); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCLEARNAMEDFRAMEBUFFERFIPROC(GLuint framebuffer, GLenum buffer, GLfloat depth, GLint stencil);
    private static PFNGLCLEARNAMEDFRAMEBUFFERFIPROC _glClearNamedFramebufferfi;
    public static void glClearNamedFramebufferfi(GLuint framebuffer, GLenum buffer, GLfloat depth, GLint stencil) => _glClearNamedFramebufferfi(framebuffer, buffer, depth, stencil);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBLITNAMEDFRAMEBUFFERPROC(GLuint readFramebuffer, GLuint drawFramebuffer, GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);
    private static PFNGLBLITNAMEDFRAMEBUFFERPROC _glBlitNamedFramebuffer;
    public static void glBlitNamedFramebuffer(GLuint readFramebuffer, GLuint drawFramebuffer, GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter) => _glBlitNamedFramebuffer(readFramebuffer, drawFramebuffer, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLenum PFNGLCHECKNAMEDFRAMEBUFFERSTATUSPROC(GLuint framebuffer, GLenum target);
    private static PFNGLCHECKNAMEDFRAMEBUFFERSTATUSPROC _glCheckNamedFramebufferStatus;
    public static GLenum glCheckNamedFramebufferStatus(GLuint framebuffer, GLenum target) => _glCheckNamedFramebufferStatus(framebuffer, target);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDFRAMEBUFFERPARAMETERIVPROC(GLuint framebuffer, GLenum pname, GLint* param);
    private static PFNGLGETNAMEDFRAMEBUFFERPARAMETERIVPROC _glGetNamedFramebufferParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedFramebufferParameteriv(GLuint framebuffer, GLenum pname, GLint* param) => _glGetNamedFramebufferParameteriv(framebuffer, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetNamedFramebufferParameteriv(GLuint framebuffer, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetNamedFramebufferParameteriv(framebuffer, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDFRAMEBUFFERATTACHMENTPARAMETERIVPROC(GLuint framebuffer, GLenum attachment, GLenum pname, GLint* params_);
    private static PFNGLGETNAMEDFRAMEBUFFERATTACHMENTPARAMETERIVPROC _glGetNamedFramebufferAttachmentParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedFramebufferAttachmentParameteriv(GLuint framebuffer, GLenum attachment, GLenum pname, GLint* params_) => _glGetNamedFramebufferAttachmentParameteriv(framebuffer, attachment, pname, params_);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetNamedFramebufferAttachmentParameteriv(GLuint framebuffer, GLenum attachment, GLenum pname, ref GLint[] params_) { fixed (GLint* ptr_params_ = &params_[0]) _glGetNamedFramebufferAttachmentParameteriv(framebuffer, attachment, pname, ptr_params_); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATERENDERBUFFERSPROC(GLsizei n, GLuint* renderbuffers);
    private static PFNGLCREATERENDERBUFFERSPROC _glCreateRenderbuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateRenderbuffers(GLsizei n, GLuint* renderbuffers) => _glCreateRenderbuffers(n, renderbuffers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateRenderbuffers(GLsizei n) { GLuint[] renderbuffers = new GLuint[n]; fixed (GLuint* ptr_renderbuffers = &renderbuffers[0]) _glCreateRenderbuffers(n, ptr_renderbuffers); return renderbuffers; }
    public static GLuint glCreateRenderbuffer() => glCreateRenderbuffers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDRENDERBUFFERSTORAGEPROC(GLuint renderbuffer, GLenum internalformat, GLsizei width, GLsizei height);
    private static PFNGLNAMEDRENDERBUFFERSTORAGEPROC _glNamedRenderbufferStorage;
    public static void glNamedRenderbufferStorage(GLuint renderbuffer, GLenum internalformat, GLsizei width, GLsizei height) => _glNamedRenderbufferStorage(renderbuffer, internalformat, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLEPROC(GLuint renderbuffer, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);
    private static PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLEPROC _glNamedRenderbufferStorageMultisample;
    public static void glNamedRenderbufferStorageMultisample(GLuint renderbuffer, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height) => _glNamedRenderbufferStorageMultisample(renderbuffer, samples, internalformat, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNAMEDRENDERBUFFERPARAMETERIVPROC(GLuint renderbuffer, GLenum pname, GLint* param);
    private static PFNGLGETNAMEDRENDERBUFFERPARAMETERIVPROC _glGetNamedRenderbufferParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetNamedRenderbufferParameteriv(GLuint renderbuffer, GLenum pname, GLint* param) => _glGetNamedRenderbufferParameteriv(renderbuffer, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetNamedRenderbufferParameteriv(GLuint renderbuffer, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetNamedRenderbufferParameteriv(renderbuffer, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATETEXTURESPROC(GLenum target, GLsizei n, GLuint* textures);
    private static PFNGLCREATETEXTURESPROC _glCreateTextures;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateTextures(GLenum target, GLsizei n, GLuint* textures) => _glCreateTextures(target, n, textures);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateTextures(GLenum target, GLsizei n) { GLuint[] textures = new GLuint[n]; fixed (GLuint* ptr_textures = &textures[0]) _glCreateTextures(target, n, ptr_textures); return textures; }
    public static GLuint glCreateTexture(GLenum target) => glCreateTextures(target, 1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREBUFFERPROC(GLuint texture, GLenum internalformat, GLuint buffer);
    private static PFNGLTEXTUREBUFFERPROC _glTextureBuffer;
    public static void glTextureBuffer(GLuint texture, GLenum internalformat, GLuint buffer) => _glTextureBuffer(texture, internalformat, buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREBUFFERRANGEPROC(GLuint texture, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);
    private static PFNGLTEXTUREBUFFERRANGEPROC _glTextureBufferRange;
    public static void glTextureBufferRange(GLuint texture, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size) => _glTextureBufferRange(texture, internalformat, buffer, offset, size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESTORAGE1DPROC(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width);
    private static PFNGLTEXTURESTORAGE1DPROC _glTextureStorage1D;
    public static void glTextureStorage1D(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width) => _glTextureStorage1D(texture, levels, internalformat, width);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESTORAGE2DPROC(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);
    private static PFNGLTEXTURESTORAGE2DPROC _glTextureStorage2D;
    public static void glTextureStorage2D(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height) => _glTextureStorage2D(texture, levels, internalformat, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESTORAGE3DPROC(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);
    private static PFNGLTEXTURESTORAGE3DPROC _glTextureStorage3D;
    public static void glTextureStorage3D(GLuint texture, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth) => _glTextureStorage3D(texture, levels, internalformat, width, height, depth);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESTORAGE2DMULTISAMPLEPROC(GLuint texture, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);
    private static PFNGLTEXTURESTORAGE2DMULTISAMPLEPROC _glTextureStorage2DMultisample;
    public static void glTextureStorage2DMultisample(GLuint texture, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations) => _glTextureStorage2DMultisample(texture, samples, internalformat, width, height, fixedsamplelocations);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESTORAGE3DMULTISAMPLEPROC(GLuint texture, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);
    private static PFNGLTEXTURESTORAGE3DMULTISAMPLEPROC _glTextureStorage3DMultisample;
    public static void glTextureStorage3DMultisample(GLuint texture, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations) => _glTextureStorage3DMultisample(texture, samples, internalformat, width, height, depth, fixedsamplelocations);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESUBIMAGE1DPROC(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXTURESUBIMAGE1DPROC _glTextureSubImage1D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, void* pixels) => _glTextureSubImage1D(texture, level, xoffset, width, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureSubImage1D<T>(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (T* ptr_pixels = &pixels[0]) _glTextureSubImage1D(texture, level, xoffset, width, format, type, ptr_pixels); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESUBIMAGE2DPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXTURESUBIMAGE2DPROC _glTextureSubImage2D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, void* pixels) => _glTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureSubImage2D<T>(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (T* ptr_pixels = &pixels[0]) _glTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, ptr_pixels); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTURESUBIMAGE3DPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* pixels);
    private static PFNGLTEXTURESUBIMAGE3DPROC _glTextureSubImage3D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* pixels) => _glTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureSubImage3D<T>(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, T[] pixels) where T : unmanaged { fixed (T* ptr_pixels = &pixels[0]) _glTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr_pixels); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE1DPROC(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXTURESUBIMAGE1DPROC _glCompressedTextureSubImage1D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, void* data) => _glCompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, byte[] data) { fixed (byte* ptr_data = &data[0]) _glCompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, ptr_data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE2DPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXTURESUBIMAGE2DPROC _glCompressedTextureSubImage2D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, void* data) => _glCompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, byte[] data) { fixed (byte* ptr_data = &data[0]) _glCompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, ptr_data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE3DPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, void* data);
    private static PFNGLCOMPRESSEDTEXTURESUBIMAGE3DPROC _glCompressedTextureSubImage3D;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCompressedTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, void* data) => _glCompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glCompressedTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, byte[] data) { fixed (byte* ptr_data = &data[0]) _glCompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr_data); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXTURESUBIMAGE1DPROC(GLuint texture, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
    private static PFNGLCOPYTEXTURESUBIMAGE1DPROC _glCopyTextureSubImage1D;
    public static void glCopyTextureSubImage1D(GLuint texture, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width) => _glCopyTextureSubImage1D(texture, level, xoffset, x, y, width);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXTURESUBIMAGE2DPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLCOPYTEXTURESUBIMAGE2DPROC _glCopyTextureSubImage2D;
    public static void glCopyTextureSubImage2D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height) => _glCopyTextureSubImage2D(texture, level, xoffset, yoffset, x, y, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCOPYTEXTURESUBIMAGE3DPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
    private static PFNGLCOPYTEXTURESUBIMAGE3DPROC _glCopyTextureSubImage3D;
    public static void glCopyTextureSubImage3D(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height) => _glCopyTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, x, y, width, height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREPARAMETERFPROC(GLuint texture, GLenum pname, GLfloat param);
    private static PFNGLTEXTUREPARAMETERFPROC _glTextureParameterf;
    public static void glTextureParameterf(GLuint texture, GLenum pname, GLfloat param) => _glTextureParameterf(texture, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREPARAMETERFVPROC(GLuint texture, GLenum pname, GLfloat* param);
    private static PFNGLTEXTUREPARAMETERFVPROC _glTextureParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureParameterfv(GLuint texture, GLenum pname, GLfloat* param) => _glTextureParameterfv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureParameterfv(GLuint texture, GLenum pname, GLfloat[] param) { fixed (GLfloat* ptr_param = &param[0]) _glTextureParameterfv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREPARAMETERIPROC(GLuint texture, GLenum pname, GLint param);
    private static PFNGLTEXTUREPARAMETERIPROC _glTextureParameteri;
    public static void glTextureParameteri(GLuint texture, GLenum pname, GLint param) => _glTextureParameteri(texture, pname, param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREPARAMETERIIVPROC(GLuint texture, GLenum pname, GLint* param);
    private static PFNGLTEXTUREPARAMETERIIVPROC _glTextureParameterIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureParameterIiv(GLuint texture, GLenum pname, GLint* param) => _glTextureParameterIiv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureParameterIiv(GLuint texture, GLenum pname, GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glTextureParameterIiv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREPARAMETERIUIVPROC(GLuint texture, GLenum pname, GLuint* param);
    private static PFNGLTEXTUREPARAMETERIUIVPROC _glTextureParameterIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureParameterIuiv(GLuint texture, GLenum pname, GLuint* param) => _glTextureParameterIuiv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureParameterIuiv(GLuint texture, GLenum pname, GLuint[] param) { fixed (GLuint* ptr_param = &param[0]) _glTextureParameterIuiv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREPARAMETERIVPROC(GLuint texture, GLenum pname, GLint* param);
    private static PFNGLTEXTUREPARAMETERIVPROC _glTextureParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glTextureParameteriv(GLuint texture, GLenum pname, GLint* param) => _glTextureParameteriv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glTextureParameteriv(GLuint texture, GLenum pname, GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glTextureParameteriv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGENERATETEXTUREMIPMAPPROC(GLuint texture);
    private static PFNGLGENERATETEXTUREMIPMAPPROC _glGenerateTextureMipmap;
    public static void glGenerateTextureMipmap(GLuint texture) => _glGenerateTextureMipmap(texture);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLBINDTEXTUREUNITPROC(GLuint unit, GLuint texture);
    private static PFNGLBINDTEXTUREUNITPROC _glBindTextureUnit;
    public static void glBindTextureUnit(GLuint unit, GLuint texture) => _glBindTextureUnit(unit, texture);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTUREIMAGEPROC(GLuint texture, GLint level, GLenum format, GLenum type, GLsizei bufSize, void* pixels);
    private static PFNGLGETTEXTUREIMAGEPROC _glGetTextureImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureImage(GLuint texture, GLint level, GLenum format, GLenum type, GLsizei bufSize, void* pixels) => _glGetTextureImage(texture, level, format, type, bufSize, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static T[] glGetTextureImage<T>(GLuint texture, GLint level, GLenum format, GLenum type, GLsizei bufSize) where T : unmanaged { T[] pixels = new T[bufSize]; fixed (T* ptr_pixels = &pixels[0]) _glGetTextureImage(texture, level, format, type, bufSize, ptr_pixels); return pixels; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETCOMPRESSEDTEXTUREIMAGEPROC(GLuint texture, GLint level, GLsizei bufSize, void* pixels);
    private static PFNGLGETCOMPRESSEDTEXTUREIMAGEPROC _glGetCompressedTextureImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetCompressedTextureImage(GLuint texture, GLint level, GLsizei bufSize, void* pixels) => _glGetCompressedTextureImage(texture, level, bufSize, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glGetCompressedTextureImage(GLuint texture, GLint level, GLsizei bufSize) { byte[] pixels = new byte[bufSize]; fixed (byte* ptr_pixels = &pixels[0]) _glGetCompressedTextureImage(texture, level, bufSize, ptr_pixels); return pixels; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTURELEVELPARAMETERFVPROC(GLuint texture, GLint level, GLenum pname, GLfloat* param);
    private static PFNGLGETTEXTURELEVELPARAMETERFVPROC _glGetTextureLevelParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureLevelParameterfv(GLuint texture, GLint level, GLenum pname, GLfloat* param) => _glGetTextureLevelParameterfv(texture, level, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTextureLevelParameterfv(GLuint texture, GLint level, GLenum pname, ref GLfloat[] param) { fixed (GLfloat* ptr_param = &param[0]) _glGetTextureLevelParameterfv(texture, level, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTURELEVELPARAMETERIVPROC(GLuint texture, GLint level, GLenum pname, GLint* param);
    private static PFNGLGETTEXTURELEVELPARAMETERIVPROC _glGetTextureLevelParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureLevelParameteriv(GLuint texture, GLint level, GLenum pname, GLint* param) => _glGetTextureLevelParameteriv(texture, level, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTextureLevelParameteriv(GLuint texture, GLint level, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetTextureLevelParameteriv(texture, level, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTUREPARAMETERFVPROC(GLuint texture, GLenum pname, GLfloat* param);
    private static PFNGLGETTEXTUREPARAMETERFVPROC _glGetTextureParameterfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureParameterfv(GLuint texture, GLenum pname, GLfloat* param) => _glGetTextureParameterfv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTextureParameterfv(GLuint texture, GLenum pname, ref GLfloat[] param) { fixed (GLfloat* ptr_param = &param[0]) _glGetTextureParameterfv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTUREPARAMETERIIVPROC(GLuint texture, GLenum pname, GLint* param);
    private static PFNGLGETTEXTUREPARAMETERIIVPROC _glGetTextureParameterIiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureParameterIiv(GLuint texture, GLenum pname, GLint* param) => _glGetTextureParameterIiv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTextureParameterIiv(GLuint texture, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetTextureParameterIiv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTUREPARAMETERIUIVPROC(GLuint texture, GLenum pname, GLuint* param);
    private static PFNGLGETTEXTUREPARAMETERIUIVPROC _glGetTextureParameterIuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureParameterIuiv(GLuint texture, GLenum pname, GLuint* param) => _glGetTextureParameterIuiv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTextureParameterIuiv(GLuint texture, GLenum pname, ref GLuint[] param) { fixed (GLuint* ptr_param = &param[0]) _glGetTextureParameterIuiv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTUREPARAMETERIVPROC(GLuint texture, GLenum pname, GLint* param);
    private static PFNGLGETTEXTUREPARAMETERIVPROC _glGetTextureParameteriv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureParameteriv(GLuint texture, GLenum pname, GLint* param) => _glGetTextureParameteriv(texture, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetTextureParameteriv(GLuint texture, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetTextureParameteriv(texture, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATEVERTEXARRAYSPROC(GLsizei n, GLuint* arrays);
    private static PFNGLCREATEVERTEXARRAYSPROC _glCreateVertexArrays;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateVertexArrays(GLsizei n, GLuint* arrays) => _glCreateVertexArrays(n, arrays);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateVertexArrays(GLsizei n) { var arrays = new GLuint[n]; fixed (GLuint* ptr_arrays = &arrays[0]) _glCreateVertexArrays(n, ptr_arrays); return arrays; }
    public static GLuint glCreateVertexArray() => glCreateVertexArrays(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLDISABLEVERTEXARRAYATTRIBPROC(GLuint vaobj, GLuint index);
    private static PFNGLDISABLEVERTEXARRAYATTRIBPROC _glDisableVertexArrayAttrib;
    public static void glDisableVertexArrayAttrib(GLuint vaobj, GLuint index) => _glDisableVertexArrayAttrib(vaobj, index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLENABLEVERTEXARRAYATTRIBPROC(GLuint vaobj, GLuint index);
    private static PFNGLENABLEVERTEXARRAYATTRIBPROC _glEnableVertexArrayAttrib;
    public static void glEnableVertexArrayAttrib(GLuint vaobj, GLuint index) => _glEnableVertexArrayAttrib(vaobj, index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYELEMENTBUFFERPROC(GLuint vaobj, GLuint buffer);
    private static PFNGLVERTEXARRAYELEMENTBUFFERPROC _glVertexArrayElementBuffer;
    public static void glVertexArrayElementBuffer(GLuint vaobj, GLuint buffer) => _glVertexArrayElementBuffer(vaobj, buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYVERTEXBUFFERPROC(GLuint vaobj, GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride);
    private static PFNGLVERTEXARRAYVERTEXBUFFERPROC _glVertexArrayVertexBuffer;
    public static void glVertexArrayVertexBuffer(GLuint vaobj, GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride) => _glVertexArrayVertexBuffer(vaobj, bindingindex, buffer, offset, stride);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYVERTEXBUFFERSPROC(GLuint vaobj, GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizei* strides);
    private static PFNGLVERTEXARRAYVERTEXBUFFERSPROC _glVertexArrayVertexBuffers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glVertexArrayVertexBuffers(GLuint vaobj, GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizei* strides) => _glVertexArrayVertexBuffers(vaobj, first, count, buffers, offsets, strides);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glVertexArrayVertexBuffers(GLuint vaobj, GLuint first, GLuint[] buffers, GLintptr[] offsets, GLsizei[] strides) { fixed (GLuint* ptr_buffers = &buffers[0]) fixed (GLintptr* ptr_offsets = &offsets[0]) fixed (GLsizei* ptr_strides = &strides[0]) _glVertexArrayVertexBuffers(vaobj, first, (GLsizei)buffers.Length, ptr_buffers, ptr_offsets, ptr_strides); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYATTRIBBINDINGPROC(GLuint vaobj, GLuint attribindex, GLuint bindingindex);
    private static PFNGLVERTEXARRAYATTRIBBINDINGPROC _glVertexArrayAttribBinding;
    public static void glVertexArrayAttribBinding(GLuint vaobj, GLuint attribindex, GLuint bindingindex) => _glVertexArrayAttribBinding(vaobj, attribindex, bindingindex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYATTRIBFORMATPROC(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset);
    private static PFNGLVERTEXARRAYATTRIBFORMATPROC _glVertexArrayAttribFormat;
    public static void glVertexArrayAttribFormat(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset) => _glVertexArrayAttribFormat(vaobj, attribindex, size, type, normalized, relativeoffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYATTRIBIFORMATPROC(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);
    private static PFNGLVERTEXARRAYATTRIBIFORMATPROC _glVertexArrayAttribIFormat;
    public static void glVertexArrayAttribIFormat(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset) => _glVertexArrayAttribIFormat(vaobj, attribindex, size, type, relativeoffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYATTRIBLFORMATPROC(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);
    private static PFNGLVERTEXARRAYATTRIBLFORMATPROC _glVertexArrayAttribLFormat;
    public static void glVertexArrayAttribLFormat(GLuint vaobj, GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset) => _glVertexArrayAttribLFormat(vaobj, attribindex, size, type, relativeoffset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLVERTEXARRAYBINDINGDIVISORPROC(GLuint vaobj, GLuint bindingindex, GLuint divisor);
    private static PFNGLVERTEXARRAYBINDINGDIVISORPROC _glVertexArrayBindingDivisor;
    public static void glVertexArrayBindingDivisor(GLuint vaobj, GLuint bindingindex, GLuint divisor) => _glVertexArrayBindingDivisor(vaobj, bindingindex, divisor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXARRAYIVPROC(GLuint vaobj, GLenum pname, GLint* param);
    private static PFNGLGETVERTEXARRAYIVPROC _glGetVertexArrayiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexArrayiv(GLuint vaobj, GLenum pname, GLint* param) => _glGetVertexArrayiv(vaobj, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexArrayiv(GLuint vaobj, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetVertexArrayiv(vaobj, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXARRAYINDEXEDIVPROC(GLuint vaobj, GLuint index, GLenum pname, GLint* param);
    private static PFNGLGETVERTEXARRAYINDEXEDIVPROC _glGetVertexArrayIndexediv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexArrayIndexediv(GLuint vaobj, GLuint index, GLenum pname, GLint* param) => _glGetVertexArrayIndexediv(vaobj, index, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexArrayIndexediv(GLuint vaobj, GLuint index, GLenum pname, ref GLint[] param) { fixed (GLint* ptr_param = &param[0]) _glGetVertexArrayIndexediv(vaobj, index, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETVERTEXARRAYINDEXED64IVPROC(GLuint vaobj, GLuint index, GLenum pname, GLint64* param);
    private static PFNGLGETVERTEXARRAYINDEXED64IVPROC _glGetVertexArrayIndexed64iv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetVertexArrayIndexed64iv(GLuint vaobj, GLuint index, GLenum pname, GLint64* param) => _glGetVertexArrayIndexed64iv(vaobj, index, pname, param);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetVertexArrayIndexed64iv(GLuint vaobj, GLuint index, GLenum pname, ref GLint64[] param) { fixed (GLint64* ptr_param = &param[0]) _glGetVertexArrayIndexed64iv(vaobj, index, pname, ptr_param); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATESAMPLERSPROC(GLsizei n, GLuint* samplers);
    private static PFNGLCREATESAMPLERSPROC _glCreateSamplers;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateSamplers(GLsizei n, GLuint* samplers) => _glCreateSamplers(n, samplers);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateSamplers(GLsizei n) { GLuint[] samplers = new GLuint[n]; fixed (GLuint* ptr_samplers = &samplers[0]) _glCreateSamplers(n, ptr_samplers); return samplers; }
    public static GLuint glCreateSamplers() => glCreateSamplers(1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATEPROGRAMPIPELINESPROC(GLsizei n, GLuint* pipelines);
    private static PFNGLCREATEPROGRAMPIPELINESPROC _glCreateProgramPipelines;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateProgramPipelines(GLsizei n, GLuint* pipelines) => _glCreateProgramPipelines(n, pipelines);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateProgramPipelines(GLsizei n) { GLuint[] pipelines = new GLuint[n]; fixed (GLuint* ptr_pipelines = &pipelines[0]) _glCreateProgramPipelines(n, ptr_pipelines); return pipelines; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLCREATEQUERIESPROC(GLenum target, GLsizei n, GLuint* ids);
    private static PFNGLCREATEQUERIESPROC _glCreateQueries;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glCreateQueries(GLenum target, GLsizei n, GLuint* ids) => _glCreateQueries(target, n, ids);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static GLuint[] glCreateQueries(GLenum target, GLsizei n) { GLuint[] ids = new GLuint[n]; fixed (GLuint* ptr_ids = &ids[0]) _glCreateQueries(target, n, ptr_ids); return ids; }
    public static GLuint glCreateQuery(GLenum target) => glCreateQueries(target, 1)[0];
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYBUFFEROBJECTI64VPROC(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);
    private static PFNGLGETQUERYBUFFEROBJECTI64VPROC _glGetQueryBufferObjecti64v;
    public static void glGetQueryBufferObjecti64v(GLuint id, GLuint buffer, GLenum pname, GLintptr offset) => _glGetQueryBufferObjecti64v(id, buffer, pname, offset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYBUFFEROBJECTIVPROC(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);
    private static PFNGLGETQUERYBUFFEROBJECTIVPROC _glGetQueryBufferObjectiv;
    public static void glGetQueryBufferObjectiv(GLuint id, GLuint buffer, GLenum pname, GLintptr offset) => _glGetQueryBufferObjectiv(id, buffer, pname, offset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYBUFFEROBJECTUI64VPROC(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);
    private static PFNGLGETQUERYBUFFEROBJECTUI64VPROC _glGetQueryBufferObjectui64v;
    public static void glGetQueryBufferObjectui64v(GLuint id, GLuint buffer, GLenum pname, GLintptr offset) => _glGetQueryBufferObjectui64v(id, buffer, pname, offset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETQUERYBUFFEROBJECTUIVPROC(GLuint id, GLuint buffer, GLenum pname, GLintptr offset);
    private static PFNGLGETQUERYBUFFEROBJECTUIVPROC _glGetQueryBufferObjectuiv;
    public static void glGetQueryBufferObjectuiv(GLuint id, GLuint buffer, GLenum pname, GLintptr offset) => _glGetQueryBufferObjectuiv(id, buffer, pname, offset);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMEMORYBARRIERBYREGIONPROC(GLbitfield barriers);
    private static PFNGLMEMORYBARRIERBYREGIONPROC _glMemoryBarrierByRegion;
    public static void glMemoryBarrierByRegion(GLbitfield barriers) => _glMemoryBarrierByRegion(barriers);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETTEXTURESUBIMAGEPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLsizei bufSize, void* pixels);
    private static PFNGLGETTEXTURESUBIMAGEPROC _glGetTextureSubImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetTextureSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLsizei bufSize, void* pixels) => _glGetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glGetTextureSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLsizei bufSize) { byte[] pixels = new byte[bufSize]; fixed (void* ptr_pixels = &pixels[0]) _glGetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, ptr_pixels); return pixels; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETCOMPRESSEDTEXTURESUBIMAGEPROC(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLsizei bufSize, void* pixels);
    private static PFNGLGETCOMPRESSEDTEXTURESUBIMAGEPROC _glGetCompressedTextureSubImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetCompressedTextureSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLsizei bufSize, void* pixels) => _glGetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glGetCompressedTextureSubImage(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLsizei bufSize) { byte[] pixels = new byte[bufSize]; fixed (void* ptr_pixels = &pixels[0]) _glGetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, ptr_pixels); return pixels; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate GLenum PFNGLGETGRAPHICSRESETSTATUSPROC();
    private static PFNGLGETGRAPHICSRESETSTATUSPROC _glGetGraphicsResetStatus;
    public static GLenum glGetGraphicsResetStatus() => _glGetGraphicsResetStatus();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNCOMPRESSEDTEXIMAGEPROC(GLenum target, GLint lod, GLsizei bufSize, void* pixels);
    private static PFNGLGETNCOMPRESSEDTEXIMAGEPROC _glGetnCompressedTexImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetnCompressedTexImage(GLenum target, GLint lod, GLsizei bufSize, void* pixels) => _glGetnCompressedTexImage(target, lod, bufSize, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glGetnCompressedTexImage(GLenum target, GLint lod, GLsizei bufSize) { byte[] pixels = new byte[bufSize]; fixed (void* ptr_pixels = &pixels[0]) _glGetnCompressedTexImage(target, lod, bufSize, ptr_pixels); return pixels; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNTEXIMAGEPROC(GLenum target, GLint level, GLenum format, GLenum type, GLsizei bufSize, void* pixels);
    private static PFNGLGETNTEXIMAGEPROC _glGetnTexImage;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetnTexImage(GLenum target, GLint level, GLenum format, GLenum type, GLsizei bufSize, void* pixels) => _glGetnTexImage(target, level, format, type, bufSize, pixels);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glGetnTexImage(GLenum target, GLint level, GLenum format, GLenum type, GLsizei bufSize) { byte[] pixels = new byte[bufSize]; fixed (void* ptr_pixels = &pixels[0]) _glGetnTexImage(target, level, format, type, bufSize, ptr_pixels); return pixels; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNUNIFORMDVPROC(GLuint program, GLint location, GLsizei bufSize, GLdouble* parameters);
    private static PFNGLGETNUNIFORMDVPROC _glGetnUniformdv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetnUniformdv(GLuint program, GLint location, GLsizei bufSize, GLdouble* parameters) => _glGetnUniformdv(program, location, bufSize, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetnUniformdv(GLuint program, GLint location, GLsizei bufSize, ref GLdouble[] parameters) { fixed (void* ptr_parameters = &parameters[0]) _glGetnUniformdv(program, location, bufSize, (GLdouble*)ptr_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNUNIFORMFVPROC(GLuint program, GLint location, GLsizei bufSize, GLfloat* parameters);
    private static PFNGLGETNUNIFORMFVPROC _glGetnUniformfv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetnUniformfv(GLuint program, GLint location, GLsizei bufSize, GLfloat* parameters) => _glGetnUniformfv(program, location, bufSize, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetnUniformfv(GLuint program, GLint location, GLsizei bufSize, ref GLfloat[] parameters) { fixed (void* ptr_parameters = &parameters[0]) _glGetnUniformfv(program, location, bufSize, (GLfloat*)ptr_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNUNIFORMIVPROC(GLuint program, GLint location, GLsizei bufSize, GLint* parameters);
    private static PFNGLGETNUNIFORMIVPROC _glGetnUniformiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetnUniformiv(GLuint program, GLint location, GLsizei bufSize, GLint* parameters) => _glGetnUniformiv(program, location, bufSize, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetnUniformiv(GLuint program, GLint location, GLsizei bufSize, ref GLint[] parameters) { fixed (void* ptr_parameters = &parameters[0]) _glGetnUniformiv(program, location, bufSize, (GLint*)ptr_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLGETNUNIFORMUIVPROC(GLuint program, GLint location, GLsizei bufSize, GLuint* parameters);
    private static PFNGLGETNUNIFORMUIVPROC _glGetnUniformuiv;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glGetnUniformuiv(GLuint program, GLint location, GLsizei bufSize, GLuint* parameters) => _glGetnUniformuiv(program, location, bufSize, parameters);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glGetnUniformuiv(GLuint program, GLint location, GLsizei bufSize, ref GLuint[] parameters) { fixed (void* ptr_parameters = &parameters[0]) _glGetnUniformuiv(program, location, bufSize, (GLuint*)ptr_parameters); }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLREADNPIXELSPROC(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize, void* data);
    private static PFNGLREADNPIXELSPROC _glReadnPixels;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glReadnPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize, void* data) => _glReadnPixels(x, y, width, height, format, type, bufSize, data);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static byte[] glReadnPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLsizei bufSize) { byte[] data = new byte[bufSize]; fixed (void* ptr_data = &data[0]) _glReadnPixels(x, y, width, height, format, type, bufSize, ptr_data); return data; }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLTEXTUREBARRIERPROC();
    private static PFNGLTEXTUREBARRIERPROC _glTextureBarrier;
    public static void glTextureBarrier() => _glTextureBarrier();


#endif

    // OpenGL 4.6

#if OGL_V_4_6

    public const int GL_SHADER_BINARY_FORMAT_SPIR_V = 0x9551;
    public const int GL_SPIR_V_BINARY = 0x9552;
    public const int GL_PARAMETER_BUFFER = 0x80EE;
    public const int GL_PARAMETER_BUFFER_BINDING = 0x80EF;
    public const int GL_CONTEXT_FLAG_NO_ERROR_BIT = 0x00000008;
    public const int GL_VERTICES_SUBMITTED = 0x82EE;
    public const int GL_PRIMITIVES_SUBMITTED = 0x82EF;
    public const int GL_VERTEX_SHADER_INVOCATIONS = 0x82F0;
    public const int GL_TESS_CONTROL_SHADER_PATCHES = 0x82F1;
    public const int GL_TESS_EVALUATION_SHADER_INVOCATIONS = 0x82F2;
    public const int GL_GEOMETRY_SHADER_PRIMITIVES_EMITTED = 0x82F3;
    public const int GL_FRAGMENT_SHADER_INVOCATIONS = 0x82F4;
    public const int GL_COMPUTE_SHADER_INVOCATIONS = 0x82F5;
    public const int GL_CLIPPING_INPUT_PRIMITIVES = 0x82F6;
    public const int GL_CLIPPING_OUTPUT_PRIMITIVES = 0x82F7;
    public const int GL_POLYGON_OFFSET_CLAMP = 0x8E1B;
    public const int GL_SPIR_V_EXTENSIONS = 0x9553;
    public const int GL_NUM_SPIR_V_EXTENSIONS = 0x9554;
    public const int GL_TEXTURE_MAX_ANISOTROPY = 0x84FE;
    public const int GL_MAX_TEXTURE_MAX_ANISOTROPY = 0x84FF;
    public const int GL_TRANSFORM_FEEDBACK_OVERFLOW = 0x82EC;
    public const int GL_TRANSFORM_FEEDBACK_STREAM_OVERFLOW = 0x82ED;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLSPECIALIZESHADERPROC(GLuint shader, GLchar* pEntryPoint, GLuint numSpecializationConstants, GLuint* pConstantIndex, GLuint* pConstantValue);
    private static PFNGLSPECIALIZESHADERPROC _glSpecializeShader;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glSpecializeShader(GLuint shader, GLchar* pEntryPoint, GLuint numSpecializationConstants, GLuint* pConstantIndex, GLuint* pConstantValue) => _glSpecializeShader(shader, pEntryPoint, numSpecializationConstants, pConstantIndex, pConstantValue);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glSpecializeShader(GLuint shader, string pEntryPoint, GLuint numSpecializationConstants, GLuint[] pConstantIndex, GLuint[] pConstantValue)
    {
        GLchar[] pEntryPointBytes = Encoding.UTF8.GetBytes(pEntryPoint);
        fixed (GLchar* ptr_pEntryPoint = &pEntryPointBytes[0])
        fixed (GLuint* ptr_pConstantIndex = &pConstantIndex[0])
        fixed (GLuint* ptr_pConstantValue = &pConstantValue[0])
            _glSpecializeShader(shader, ptr_pEntryPoint, numSpecializationConstants, ptr_pConstantIndex, ptr_pConstantValue);
    }
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWARRAYSINDIRECTCOUNTPROC(GLenum mode, void* indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);
    private static PFNGLMULTIDRAWARRAYSINDIRECTCOUNTPROC _glMultiDrawArraysIndirectCount;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawArraysIndirectCount(GLenum mode, void* indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride) => _glMultiDrawArraysIndirectCount(mode, indirect, drawcount, maxdrawcount, stride);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawArraysIndirectCount(GLenum mode, DrawArraysIndirectCommand indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride) => _glMultiDrawArraysIndirectCount(mode, &indirect, drawcount, maxdrawcount, stride);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLMULTIDRAWELEMENTSINDIRECTCOUNTPROC(GLenum mode, GLenum type, void* indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride);
    private static PFNGLMULTIDRAWELEMENTSINDIRECTCOUNTPROC _glMultiDrawElementsIndirectCount;
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_UNSAFE
    public static void glMultiDrawElementsIndirectCount(GLenum mode, GLenum type, void* indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride) => _glMultiDrawElementsIndirectCount(mode, type, indirect, drawcount, maxdrawcount, stride);
#endif
#if OGL_WRAPPER_API_BOTH || OGL_WRAPPER_API_SAFE
    public static void glMultiDrawElementsIndirectCount(GLenum mode, GLenum type, DrawElementsIndirectCommand indirect, GLintptr drawcount, GLsizei maxdrawcount, GLsizei stride) => _glMultiDrawElementsIndirectCount(mode, type, &indirect, drawcount, maxdrawcount, stride);
#endif

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void PFNGLPOLYGONOFFSETCLAMPPROC(GLfloat factor, GLfloat units, GLfloat clamp);
    private static PFNGLPOLYGONOFFSETCLAMPPROC _glPolygonOffsetClamp;
    public static void glPolygonOffsetClamp(GLfloat factor, GLfloat units, GLfloat clamp) => _glPolygonOffsetClamp(factor, units, clamp);

#endif

    public unsafe static void Import(GetProcAddressHandler loader)
    {
#if OGL_V_1_0 || OGL_V_1_1 || OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glCullFace = Marshal.GetDelegateForFunctionPointer<PFNGLCULLFACEPROC>(loader.Invoke("glCullFace"));
        _glFrontFace = Marshal.GetDelegateForFunctionPointer<PFNGLFRONTFACEPROC>(loader.Invoke("glFrontFace"));
        _glHint = Marshal.GetDelegateForFunctionPointer<PFNGLHINTPROC>(loader.Invoke("glHint"));
        _glLineWidth = Marshal.GetDelegateForFunctionPointer<PFNGLLINEWIDTHPROC>(loader.Invoke("glLineWidth"));
        _glPointSize = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTSIZEPROC>(loader.Invoke("glPointSize"));
        _glPolygonMode = Marshal.GetDelegateForFunctionPointer<PFNGLPOLYGONMODEPROC>(loader.Invoke("glPolygonMode"));
        _glScissor = Marshal.GetDelegateForFunctionPointer<PFNGLSCISSORPROC>(loader.Invoke("glScissor"));
        _glTexParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERFPROC>(loader.Invoke("glTexParameterf"));
        _glTexParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERFVPROC>(loader.Invoke("glTexParameterfv"));
        _glTexParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIPROC>(loader.Invoke("glTexParameteri"));
        _glTexParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIVPROC>(loader.Invoke("glTexParameteriv"));
        _glTexImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE1DPROC>(loader.Invoke("glTexImage1D"));
        _glTexImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE2DPROC>(loader.Invoke("glTexImage2D"));
        _glDrawBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWBUFFERPROC>(loader.Invoke("glDrawBuffer"));
        _glClear = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARPROC>(loader.Invoke("glClear"));
        _glClearColor = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARCOLORPROC>(loader.Invoke("glClearColor"));
        _glClearStencil = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARSTENCILPROC>(loader.Invoke("glClearStencil"));
        _glClearDepth = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARDEPTHPROC>(loader.Invoke("glClearDepth"));
        _glStencilMask = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILMASKPROC>(loader.Invoke("glStencilMask"));
        _glColorMask = Marshal.GetDelegateForFunctionPointer<PFNGLCOLORMASKPROC>(loader.Invoke("glColorMask"));
        _glDepthMask = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHMASKPROC>(loader.Invoke("glDepthMask"));
        _glDisable = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEPROC>(loader.Invoke("glDisable"));
        _glEnable = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEPROC>(loader.Invoke("glEnable"));
        _glFinish = Marshal.GetDelegateForFunctionPointer<PFNGLFINISHPROC>(loader.Invoke("glFinish"));
        _glFlush = Marshal.GetDelegateForFunctionPointer<PFNGLFLUSHPROC>(loader.Invoke("glFlush"));
        _glBlendFunc = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDFUNCPROC>(loader.Invoke("glBlendFunc"));
        _glLogicOp = Marshal.GetDelegateForFunctionPointer<PFNGLLOGICOPPROC>(loader.Invoke("glLogicOp"));
        _glStencilFunc = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILFUNCPROC>(loader.Invoke("glStencilFunc"));
        _glStencilOp = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILOPPROC>(loader.Invoke("glStencilOp"));
        _glDepthFunc = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHFUNCPROC>(loader.Invoke("glDepthFunc"));
        _glPixelStoref = Marshal.GetDelegateForFunctionPointer<PFNGLPIXELSTOREFPROC>(loader.Invoke("glPixelStoref"));
        _glPixelStorei = Marshal.GetDelegateForFunctionPointer<PFNGLPIXELSTOREIPROC>(loader.Invoke("glPixelStorei"));
        _glReadBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLREADBUFFERPROC>(loader.Invoke("glReadBuffer"));
        _glReadPixels = Marshal.GetDelegateForFunctionPointer<PFNGLREADPIXELSPROC>(loader.Invoke("glReadPixels"));
        _glGetBooleanv = Marshal.GetDelegateForFunctionPointer<PFNGLGETBOOLEANVPROC>(loader.Invoke("glGetBooleanv"));
        _glGetDoublev = Marshal.GetDelegateForFunctionPointer<PFNGLGETDOUBLEVPROC>(loader.Invoke("glGetDoublev"));
        _glGetError = Marshal.GetDelegateForFunctionPointer<PFNGLGETERRORPROC>(loader.Invoke("glGetError"));
        _glGetFloatv = Marshal.GetDelegateForFunctionPointer<PFNGLGETFLOATVPROC>(loader.Invoke("glGetFloatv"));
        _glGetIntegerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGERVPROC>(loader.Invoke("glGetIntegerv"));
        _glGetString = Marshal.GetDelegateForFunctionPointer<PFNGLGETSTRINGPROC>(loader.Invoke("glGetString"));
        _glGetTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXIMAGEPROC>(loader.Invoke("glGetTexImage"));
        _glGetTexParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERFVPROC>(loader.Invoke("glGetTexParameterfv"));
        _glGetTexParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERIVPROC>(loader.Invoke("glGetTexParameteriv"));
        _glGetTexLevelParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXLEVELPARAMETERFVPROC>(loader.Invoke("glGetTexLevelParameterfv"));
        _glGetTexLevelParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXLEVELPARAMETERIVPROC>(loader.Invoke("glGetTexLevelParameteriv"));
        _glIsEnabled = Marshal.GetDelegateForFunctionPointer<PFNGLISENABLEDPROC>(loader.Invoke("glIsEnabled"));
        _glDepthRange = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHRANGEPROC>(loader.Invoke("glDepthRange"));
        _glViewport = Marshal.GetDelegateForFunctionPointer<PFNGLVIEWPORTPROC>(loader.Invoke("glViewport"));
#endif
#if OGL_V_1_1 || OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glDrawArrays = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWARRAYSPROC>(loader.Invoke("glDrawArrays"));
        _glDrawElements = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSPROC>(loader.Invoke("glDrawElements"));
        _glGetPointerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPOINTERVPROC>(loader.Invoke("glGetPointerv"));
        _glPolygonOffset = Marshal.GetDelegateForFunctionPointer<PFNGLPOLYGONOFFSETPROC>(loader.Invoke("glPolygonOffset"));
        _glCopyTexImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXIMAGE1DPROC>(loader.Invoke("glCopyTexImage1D"));
        _glCopyTexImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXIMAGE2DPROC>(loader.Invoke("glCopyTexImage2D"));
        _glCopyTexSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXSUBIMAGE1DPROC>(loader.Invoke("glCopyTexSubImage1D"));
        _glCopyTexSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXSUBIMAGE2DPROC>(loader.Invoke("glCopyTexSubImage2D"));
        _glTexSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSUBIMAGE1DPROC>(loader.Invoke("glTexSubImage1D"));
        _glTexSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSUBIMAGE2DPROC>(loader.Invoke("glTexSubImage2D"));
        _glBindTexture = Marshal.GetDelegateForFunctionPointer<PFNGLBINDTEXTUREPROC>(loader.Invoke("glBindTexture"));
        _glDeleteTextures = Marshal.GetDelegateForFunctionPointer<PFNGLDELETETEXTURESPROC>(loader.Invoke("glDeleteTextures"));
        _glGenTextures = Marshal.GetDelegateForFunctionPointer<PFNGLGENTEXTURESPROC>(loader.Invoke("glGenTextures"));
        _glIsTexture = Marshal.GetDelegateForFunctionPointer<PFNGLISTEXTUREPROC>(loader.Invoke("glIsTexture"));
#endif
#if OGL_V_1_2 || OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glDrawRangeElements = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWRANGEELEMENTSPROC>(loader.Invoke("glDrawRangeElements"));
        _glTexImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE3DPROC>(loader.Invoke("glTexImage3D"));
        _glTexSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSUBIMAGE3DPROC>(loader.Invoke("glTexSubImage3D"));
        _glCopyTexSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXSUBIMAGE3DPROC>(loader.Invoke("glCopyTexSubImage3D"));
#endif
#if OGL_V_1_3 || OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glActiveTexture = Marshal.GetDelegateForFunctionPointer<PFNGLACTIVETEXTUREPROC>(loader.Invoke("glActiveTexture"));
        _glSampleCoverage = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLECOVERAGEPROC>(loader.Invoke("glSampleCoverage"));
        _glCompressedTexImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXIMAGE3DPROC>(loader.Invoke("glCompressedTexImage3D"));
        _glCompressedTexImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXIMAGE2DPROC>(loader.Invoke("glCompressedTexImage2D"));
        _glCompressedTexImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXIMAGE1DPROC>(loader.Invoke("glCompressedTexImage1D"));
        _glCompressedTexSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC>(loader.Invoke("glCompressedTexSubImage3D"));
        _glCompressedTexSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC>(loader.Invoke("glCompressedTexSubImage2D"));
        _glCompressedTexSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC>(loader.Invoke("glCompressedTexSubImage1D"));
        _glGetCompressedTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETCOMPRESSEDTEXIMAGEPROC>(loader.Invoke("glGetCompressedTexImage"));
#endif
#if OGL_V_1_4 || OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glBlendFuncSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDFUNCSEPARATEPROC>(loader.Invoke("glBlendFuncSeparate"));
        _glMultiDrawArrays = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWARRAYSPROC>(loader.Invoke("glMultiDrawArrays"));
        _glMultiDrawElements = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWELEMENTSPROC>(loader.Invoke("glMultiDrawElements"));
        _glPointParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERFPROC>(loader.Invoke("glPointParameterf"));
        _glPointParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERFVPROC>(loader.Invoke("glPointParameterfv"));
        _glPointParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERIPROC>(loader.Invoke("glPointParameteri"));
        _glPointParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERIVPROC>(loader.Invoke("glPointParameteriv"));
        _glBlendColor = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDCOLORPROC>(loader.Invoke("glBlendColor"));
        _glBlendEquation = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDEQUATIONPROC>(loader.Invoke("glBlendEquation"));
#endif
#if OGL_V_1_5 || OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glGenQueries = Marshal.GetDelegateForFunctionPointer<PFNGLGENQUERIESPROC>(loader.Invoke("glGenQueries"));
        _glDeleteQueries = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEQUERIESPROC>(loader.Invoke("glDeleteQueries"));
        _glIsQuery = Marshal.GetDelegateForFunctionPointer<PFNGLISQUERYPROC>(loader.Invoke("glIsQuery"));
        _glBeginQuery = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINQUERYPROC>(loader.Invoke("glBeginQuery"));
        _glEndQuery = Marshal.GetDelegateForFunctionPointer<PFNGLENDQUERYPROC>(loader.Invoke("glEndQuery"));
        _glGetQueryiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYIVPROC>(loader.Invoke("glGetQueryiv"));
        _glGetQueryObjectiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTIVPROC>(loader.Invoke("glGetQueryObjectiv"));
        _glGetQueryObjectuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTUIVPROC>(loader.Invoke("glGetQueryObjectuiv"));
        _glBindBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERPROC>(loader.Invoke("glBindBuffer"));
        _glDeleteBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEBUFFERSPROC>(loader.Invoke("glDeleteBuffers"));
        _glGenBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLGENBUFFERSPROC>(loader.Invoke("glGenBuffers"));
        _glIsBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLISBUFFERPROC>(loader.Invoke("glIsBuffer"));
        _glBufferData = Marshal.GetDelegateForFunctionPointer<PFNGLBUFFERDATAPROC>(loader.Invoke("glBufferData"));
        _glBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLBUFFERSUBDATAPROC>(loader.Invoke("glBufferSubData"));
        _glGetBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERSUBDATAPROC>(loader.Invoke("glGetBufferSubData"));
        _glMapBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLMAPBUFFERPROC>(loader.Invoke("glMapBuffer"));
        _glUnmapBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLUNMAPBUFFERPROC>(loader.Invoke("glUnmapBuffer"));
        _glGetBufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERPARAMETERIVPROC>(loader.Invoke("glGetBufferParameteriv"));
        _glGetBufferPointerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERPOINTERVPROC>(loader.Invoke("glGetBufferPointerv"));
#endif
#if OGL_V_2_0 || OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glBlendEquationSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDEQUATIONSEPARATEPROC>(loader.Invoke("glBlendEquationSeparate"));
        _glDrawBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWBUFFERSPROC>(loader.Invoke("glDrawBuffers"));
        _glStencilOpSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILOPSEPARATEPROC>(loader.Invoke("glStencilOpSeparate"));
        _glStencilFuncSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILFUNCSEPARATEPROC>(loader.Invoke("glStencilFuncSeparate"));
        _glStencilMaskSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILMASKSEPARATEPROC>(loader.Invoke("glStencilMaskSeparate"));
        _glAttachShader = Marshal.GetDelegateForFunctionPointer<PFNGLATTACHSHADERPROC>(loader.Invoke("glAttachShader"));
        _glBindAttribLocation = Marshal.GetDelegateForFunctionPointer<PFNGLBINDATTRIBLOCATIONPROC>(loader.Invoke("glBindAttribLocation"));
        _glCompileShader = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPILESHADERPROC>(loader.Invoke("glCompileShader"));
        _glCreateProgram = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEPROGRAMPROC>(loader.Invoke("glCreateProgram"));
        _glCreateShader = Marshal.GetDelegateForFunctionPointer<PFNGLCREATESHADERPROC>(loader.Invoke("glCreateShader"));
        _glDeleteProgram = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEPROGRAMPROC>(loader.Invoke("glDeleteProgram"));
        _glDeleteShader = Marshal.GetDelegateForFunctionPointer<PFNGLDELETESHADERPROC>(loader.Invoke("glDeleteShader"));
        _glDetachShader = Marshal.GetDelegateForFunctionPointer<PFNGLDETACHSHADERPROC>(loader.Invoke("glDetachShader"));
        _glDisableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEVERTEXATTRIBARRAYPROC>(loader.Invoke("glDisableVertexAttribArray"));
        _glEnableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEVERTEXATTRIBARRAYPROC>(loader.Invoke("glEnableVertexAttribArray"));
        _glGetActiveAttrib = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEATTRIBPROC>(loader.Invoke("glGetActiveAttrib"));
        _glGetActiveUniform = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMPROC>(loader.Invoke("glGetActiveUniform"));
        _glGetAttachedShaders = Marshal.GetDelegateForFunctionPointer<PFNGLGETATTACHEDSHADERSPROC>(loader.Invoke("glGetAttachedShaders"));
        _glGetAttribLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETATTRIBLOCATIONPROC>(loader.Invoke("glGetAttribLocation"));
        _glGetProgramiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMIVPROC>(loader.Invoke("glGetProgramiv"));
        _glGetProgramInfoLog = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMINFOLOGPROC>(loader.Invoke("glGetProgramInfoLog"));
        _glGetShaderiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERIVPROC>(loader.Invoke("glGetShaderiv"));
        _glGetShaderInfoLog = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERINFOLOGPROC>(loader.Invoke("glGetShaderInfoLog"));
        _glGetShaderSource = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERSOURCEPROC>(loader.Invoke("glGetShaderSource"));
        _glGetUniformLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMLOCATIONPROC>(loader.Invoke("glGetUniformLocation"));
        _glGetUniformfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMFVPROC>(loader.Invoke("glGetUniformfv"));
        _glGetUniformiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMIVPROC>(loader.Invoke("glGetUniformiv"));
        _glGetVertexAttribdv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBDVPROC>(loader.Invoke("glGetVertexAttribdv"));
        _glGetVertexAttribfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBFVPROC>(loader.Invoke("glGetVertexAttribfv"));
        _glGetVertexAttribiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBIVPROC>(loader.Invoke("glGetVertexAttribiv"));
        _glGetVertexAttribPointerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBPOINTERVPROC>(loader.Invoke("glGetVertexAttribPointerv"));
        _glIsProgram = Marshal.GetDelegateForFunctionPointer<PFNGLISPROGRAMPROC>(loader.Invoke("glIsProgram"));
        _glIsShader = Marshal.GetDelegateForFunctionPointer<PFNGLISSHADERPROC>(loader.Invoke("glIsShader"));
        _glLinkProgram = Marshal.GetDelegateForFunctionPointer<PFNGLLINKPROGRAMPROC>(loader.Invoke("glLinkProgram"));
        _glShaderSource = Marshal.GetDelegateForFunctionPointer<PFNGLSHADERSOURCEPROC>(loader.Invoke("glShaderSource"));
        _glUseProgram = Marshal.GetDelegateForFunctionPointer<PFNGLUSEPROGRAMPROC>(loader.Invoke("glUseProgram"));
        _glUniform1f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1FPROC>(loader.Invoke("glUniform1f"));
        _glUniform2f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2FPROC>(loader.Invoke("glUniform2f"));
        _glUniform3f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3FPROC>(loader.Invoke("glUniform3f"));
        _glUniform4f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4FPROC>(loader.Invoke("glUniform4f"));
        _glUniform1i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1IPROC>(loader.Invoke("glUniform1i"));
        _glUniform2i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2IPROC>(loader.Invoke("glUniform2i"));
        _glUniform3i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3IPROC>(loader.Invoke("glUniform3i"));
        _glUniform4i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4IPROC>(loader.Invoke("glUniform4i"));
        _glUniform1fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1FVPROC>(loader.Invoke("glUniform1fv"));
        _glUniform2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2FVPROC>(loader.Invoke("glUniform2fv"));
        _glUniform3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3FVPROC>(loader.Invoke("glUniform3fv"));
        _glUniform4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4FVPROC>(loader.Invoke("glUniform4fv"));
        _glUniform1iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1IVPROC>(loader.Invoke("glUniform1iv"));
        _glUniform2iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2IVPROC>(loader.Invoke("glUniform2iv"));
        _glUniform3iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3IVPROC>(loader.Invoke("glUniform3iv"));
        _glUniform4iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4IVPROC>(loader.Invoke("glUniform4iv"));
        _glUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2FVPROC>(loader.Invoke("glUniformMatrix2fv"));
        _glUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3FVPROC>(loader.Invoke("glUniformMatrix3fv"));
        _glUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4FVPROC>(loader.Invoke("glUniformMatrix4fv"));
        _glValidateProgram = Marshal.GetDelegateForFunctionPointer<PFNGLVALIDATEPROGRAMPROC>(loader.Invoke("glValidateProgram"));
        _glVertexAttrib1d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1DPROC>(loader.Invoke("glVertexAttrib1d"));
        _glVertexAttrib1dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1DVPROC>(loader.Invoke("glVertexAttrib1dv"));
        _glVertexAttrib1f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1FPROC>(loader.Invoke("glVertexAttrib1f"));
        _glVertexAttrib1fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1FVPROC>(loader.Invoke("glVertexAttrib1fv"));
        _glVertexAttrib1s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1SPROC>(loader.Invoke("glVertexAttrib1s"));
        _glVertexAttrib1sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1SVPROC>(loader.Invoke("glVertexAttrib1sv"));
        _glVertexAttrib2d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2DPROC>(loader.Invoke("glVertexAttrib2d"));
        _glVertexAttrib2dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2DVPROC>(loader.Invoke("glVertexAttrib2dv"));
        _glVertexAttrib2f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2FPROC>(loader.Invoke("glVertexAttrib2f"));
        _glVertexAttrib2fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2FVPROC>(loader.Invoke("glVertexAttrib2fv"));
        _glVertexAttrib2s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2SPROC>(loader.Invoke("glVertexAttrib2s"));
        _glVertexAttrib2sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2SVPROC>(loader.Invoke("glVertexAttrib2sv"));
        _glVertexAttrib3d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3DPROC>(loader.Invoke("glVertexAttrib3d"));
        _glVertexAttrib3dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3DVPROC>(loader.Invoke("glVertexAttrib3dv"));
        _glVertexAttrib3f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3FPROC>(loader.Invoke("glVertexAttrib3f"));
        _glVertexAttrib3fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3FVPROC>(loader.Invoke("glVertexAttrib3fv"));
        _glVertexAttrib3s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3SPROC>(loader.Invoke("glVertexAttrib3s"));
        _glVertexAttrib3sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3SVPROC>(loader.Invoke("glVertexAttrib3sv"));
        _glVertexAttrib4Nbv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NBVPROC>(loader.Invoke("glVertexAttrib4Nbv"));
        _glVertexAttrib4Niv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NIVPROC>(loader.Invoke("glVertexAttrib4Niv"));
        _glVertexAttrib4Nsv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NSVPROC>(loader.Invoke("glVertexAttrib4Nsv"));
        _glVertexAttrib4Nub = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUBPROC>(loader.Invoke("glVertexAttrib4Nub"));
        _glVertexAttrib4Nubv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUBVPROC>(loader.Invoke("glVertexAttrib4Nubv"));
        _glVertexAttrib4Nuiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUIVPROC>(loader.Invoke("glVertexAttrib4Nuiv"));
        _glVertexAttrib4Nusv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUSVPROC>(loader.Invoke("glVertexAttrib4Nusv"));
        _glVertexAttrib4bv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4BVPROC>(loader.Invoke("glVertexAttrib4bv"));
        _glVertexAttrib4d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4DPROC>(loader.Invoke("glVertexAttrib4d"));
        _glVertexAttrib4dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4DVPROC>(loader.Invoke("glVertexAttrib4dv"));
        _glVertexAttrib4f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4FPROC>(loader.Invoke("glVertexAttrib4f"));
        _glVertexAttrib4fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4FVPROC>(loader.Invoke("glVertexAttrib4fv"));
        _glVertexAttrib4iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4IVPROC>(loader.Invoke("glVertexAttrib4iv"));
        _glVertexAttrib4s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4SPROC>(loader.Invoke("glVertexAttrib4s"));
        _glVertexAttrib4sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4SVPROC>(loader.Invoke("glVertexAttrib4sv"));
        _glVertexAttrib4ubv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4UBVPROC>(loader.Invoke("glVertexAttrib4ubv"));
        _glVertexAttrib4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4UIVPROC>(loader.Invoke("glVertexAttrib4uiv"));
        _glVertexAttrib4usv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4USVPROC>(loader.Invoke("glVertexAttrib4usv"));
        _glVertexAttribPointer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBPOINTERPROC>(loader.Invoke("glVertexAttribPointer"));
#endif
#if OGL_V_2_1 || OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2X3FVPROC>(loader.Invoke("glUniformMatrix2x3fv"));
        _glUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3X2FVPROC>(loader.Invoke("glUniformMatrix3x2fv"));
        _glUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2X4FVPROC>(loader.Invoke("glUniformMatrix2x4fv"));
        _glUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4X2FVPROC>(loader.Invoke("glUniformMatrix4x2fv"));
        _glUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3X4FVPROC>(loader.Invoke("glUniformMatrix3x4fv"));
        _glUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4X3FVPROC>(loader.Invoke("glUniformMatrix4x3fv"));
#endif
#if OGL_V_3_0 || OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glColorMaski = Marshal.GetDelegateForFunctionPointer<PFNGLCOLORMASKIPROC>(loader.Invoke("glColorMaski"));
        _glGetBooleani_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETBOOLEANI_VPROC>(loader.Invoke("glGetBooleani_v"));
        _glGetIntegeri_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGERI_VPROC>(loader.Invoke("glGetIntegeri_v"));
        _glEnablei = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEIPROC>(loader.Invoke("glEnablei"));
        _glDisablei = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEIPROC>(loader.Invoke("glDisablei"));
        _glIsEnabledi = Marshal.GetDelegateForFunctionPointer<PFNGLISENABLEDIPROC>(loader.Invoke("glIsEnabledi"));
        _glBeginTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINTRANSFORMFEEDBACKPROC>(loader.Invoke("glBeginTransformFeedback"));
        _glEndTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLENDTRANSFORMFEEDBACKPROC>(loader.Invoke("glEndTransformFeedback"));
        _glBindBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERRANGEPROC>(loader.Invoke("glBindBufferRange"));
        _glBindBufferBase = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERBASEPROC>(loader.Invoke("glBindBufferBase"));
        _glTransformFeedbackVaryings = Marshal.GetDelegateForFunctionPointer<PFNGLTRANSFORMFEEDBACKVARYINGSPROC>(loader.Invoke("glTransformFeedbackVaryings"));
        _glGetTransformFeedbackVarying = Marshal.GetDelegateForFunctionPointer<PFNGLGETTRANSFORMFEEDBACKVARYINGPROC>(loader.Invoke("glGetTransformFeedbackVarying"));
        _glClampColor = Marshal.GetDelegateForFunctionPointer<PFNGLCLAMPCOLORPROC>(loader.Invoke("glClampColor"));
        _glBeginConditionalRender = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINCONDITIONALRENDERPROC>(loader.Invoke("glBeginConditionalRender"));
        _glEndConditionalRender = Marshal.GetDelegateForFunctionPointer<PFNGLENDCONDITIONALRENDERPROC>(loader.Invoke("glEndConditionalRender"));
        _glVertexAttribIPointer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBIPOINTERPROC>(loader.Invoke("glVertexAttribIPointer"));
        _glGetVertexAttribIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBIIVPROC>(loader.Invoke("glGetVertexAttribIiv"));
        _glGetVertexAttribIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBIUIVPROC>(loader.Invoke("glGetVertexAttribIuiv"));
        _glVertexAttribI1i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1IPROC>(loader.Invoke("glVertexAttribI1i"));
        _glVertexAttribI2i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2IPROC>(loader.Invoke("glVertexAttribI2i"));
        _glVertexAttribI3i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3IPROC>(loader.Invoke("glVertexAttribI3i"));
        _glVertexAttribI4i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4IPROC>(loader.Invoke("glVertexAttribI4i"));
        _glVertexAttribI1ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1UIPROC>(loader.Invoke("glVertexAttribI1ui"));
        _glVertexAttribI2ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2UIPROC>(loader.Invoke("glVertexAttribI2ui"));
        _glVertexAttribI3ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3UIPROC>(loader.Invoke("glVertexAttribI3ui"));
        _glVertexAttribI4ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4UIPROC>(loader.Invoke("glVertexAttribI4ui"));
        _glVertexAttribI1iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1IVPROC>(loader.Invoke("glVertexAttribI1iv"));
        _glVertexAttribI2iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2IVPROC>(loader.Invoke("glVertexAttribI2iv"));
        _glVertexAttribI3iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3IVPROC>(loader.Invoke("glVertexAttribI3iv"));
        _glVertexAttribI4iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4IVPROC>(loader.Invoke("glVertexAttribI4iv"));
        _glVertexAttribI1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1UIVPROC>(loader.Invoke("glVertexAttribI1uiv"));
        _glVertexAttribI2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2UIVPROC>(loader.Invoke("glVertexAttribI2uiv"));
        _glVertexAttribI3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3UIVPROC>(loader.Invoke("glVertexAttribI3uiv"));
        _glVertexAttribI4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4UIVPROC>(loader.Invoke("glVertexAttribI4uiv"));
        _glVertexAttribI4bv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4BVPROC>(loader.Invoke("glVertexAttribI4bv"));
        _glVertexAttribI4sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4SVPROC>(loader.Invoke("glVertexAttribI4sv"));
        _glVertexAttribI4ubv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4UBVPROC>(loader.Invoke("glVertexAttribI4ubv"));
        _glVertexAttribI4usv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4USVPROC>(loader.Invoke("glVertexAttribI4usv"));
        _glGetUniformuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMUIVPROC>(loader.Invoke("glGetUniformuiv"));
        _glBindFragDataLocation = Marshal.GetDelegateForFunctionPointer<PFNGLBINDFRAGDATALOCATIONPROC>(loader.Invoke("glBindFragDataLocation"));
        _glGetFragDataLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAGDATALOCATIONPROC>(loader.Invoke("glGetFragDataLocation"));
        _glUniform1ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1UIPROC>(loader.Invoke("glUniform1ui"));
        _glUniform2ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2UIPROC>(loader.Invoke("glUniform2ui"));
        _glUniform3ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3UIPROC>(loader.Invoke("glUniform3ui"));
        _glUniform4ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4UIPROC>(loader.Invoke("glUniform4ui"));
        _glUniform1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1UIVPROC>(loader.Invoke("glUniform1uiv"));
        _glUniform2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2UIVPROC>(loader.Invoke("glUniform2uiv"));
        _glUniform3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3UIVPROC>(loader.Invoke("glUniform3uiv"));
        _glUniform4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4UIVPROC>(loader.Invoke("glUniform4uiv"));
        _glTexParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIIVPROC>(loader.Invoke("glTexParameterIiv"));
        _glTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIUIVPROC>(loader.Invoke("glTexParameterIuiv"));
        _glGetTexParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERIIVPROC>(loader.Invoke("glGetTexParameterIiv"));
        _glGetTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERIUIVPROC>(loader.Invoke("glGetTexParameterIuiv"));
        _glClearBufferiv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERIVPROC>(loader.Invoke("glClearBufferiv"));
        _glClearBufferuiv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERUIVPROC>(loader.Invoke("glClearBufferuiv"));
        _glClearBufferfv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERFVPROC>(loader.Invoke("glClearBufferfv"));
        _glClearBufferfi = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERFIPROC>(loader.Invoke("glClearBufferfi"));
        _glGetStringi = Marshal.GetDelegateForFunctionPointer<PFNGLGETSTRINGIPROC>(loader.Invoke("glGetStringi"));
        _glIsRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLISRENDERBUFFERPROC>(loader.Invoke("glIsRenderbuffer"));
        _glBindRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDRENDERBUFFERPROC>(loader.Invoke("glBindRenderbuffer"));
        _glDeleteRenderbuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETERENDERBUFFERSPROC>(loader.Invoke("glDeleteRenderbuffers"));
        _glGenRenderbuffers = Marshal.GetDelegateForFunctionPointer<PFNGLGENRENDERBUFFERSPROC>(loader.Invoke("glGenRenderbuffers"));
        _glRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<PFNGLRENDERBUFFERSTORAGEPROC>(loader.Invoke("glRenderbufferStorage"));
        _glGetRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETRENDERBUFFERPARAMETERIVPROC>(loader.Invoke("glGetRenderbufferParameteriv"));
        _glIsFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLISFRAMEBUFFERPROC>(loader.Invoke("glIsFramebuffer"));
        _glBindFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDFRAMEBUFFERPROC>(loader.Invoke("glBindFramebuffer"));
        _glDeleteFramebuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEFRAMEBUFFERSPROC>(loader.Invoke("glDeleteFramebuffers"));
        _glGenFramebuffers = Marshal.GetDelegateForFunctionPointer<PFNGLGENFRAMEBUFFERSPROC>(loader.Invoke("glGenFramebuffers"));
        _glCheckFramebufferStatus = Marshal.GetDelegateForFunctionPointer<PFNGLCHECKFRAMEBUFFERSTATUSPROC>(loader.Invoke("glCheckFramebufferStatus"));
        _glFramebufferTexture1D = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURE1DPROC>(loader.Invoke("glFramebufferTexture1D"));
        _glFramebufferTexture2D = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURE2DPROC>(loader.Invoke("glFramebufferTexture2D"));
        _glFramebufferTexture3D = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURE3DPROC>(loader.Invoke("glFramebufferTexture3D"));
        _glFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERRENDERBUFFERPROC>(loader.Invoke("glFramebufferRenderbuffer"));
        _glGetFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC>(loader.Invoke("glGetFramebufferAttachmentParameteriv"));
        _glGenerateMipmap = Marshal.GetDelegateForFunctionPointer<PFNGLGENERATEMIPMAPPROC>(loader.Invoke("glGenerateMipmap"));
        _glBlitFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBLITFRAMEBUFFERPROC>(loader.Invoke("glBlitFramebuffer"));
        _glRenderbufferStorageMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC>(loader.Invoke("glRenderbufferStorageMultisample"));
        _glFramebufferTextureLayer = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURELAYERPROC>(loader.Invoke("glFramebufferTextureLayer"));
        _glMapBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLMAPBUFFERRANGEPROC>(loader.Invoke("glMapBufferRange"));
        _glFlushMappedBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLFLUSHMAPPEDBUFFERRANGEPROC>(loader.Invoke("glFlushMappedBufferRange"));
        _glBindVertexArray = Marshal.GetDelegateForFunctionPointer<PFNGLBINDVERTEXARRAYPROC>(loader.Invoke("glBindVertexArray"));
        _glDeleteVertexArrays = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEVERTEXARRAYSPROC>(loader.Invoke("glDeleteVertexArrays"));
        _glGenVertexArrays = Marshal.GetDelegateForFunctionPointer<PFNGLGENVERTEXARRAYSPROC>(loader.Invoke("glGenVertexArrays"));
        _glIsVertexArray = Marshal.GetDelegateForFunctionPointer<PFNGLISVERTEXARRAYPROC>(loader.Invoke("glIsVertexArray"));
#endif
#if OGL_V_3_1 || OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glDrawArraysInstanced = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWARRAYSINSTANCEDPROC>(loader.Invoke("glDrawArraysInstanced"));
        _glDrawElementsInstanced = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINSTANCEDPROC>(loader.Invoke("glDrawElementsInstanced"));
        _glTexBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLTEXBUFFERPROC>(loader.Invoke("glTexBuffer"));
        _glPrimitiveRestartIndex = Marshal.GetDelegateForFunctionPointer<PFNGLPRIMITIVERESTARTINDEXPROC>(loader.Invoke("glPrimitiveRestartIndex"));
        _glCopyBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYBUFFERSUBDATAPROC>(loader.Invoke("glCopyBufferSubData"));
        _glGetUniformIndices = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMINDICESPROC>(loader.Invoke("glGetUniformIndices"));
        _glGetActiveUniformsiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMSIVPROC>(loader.Invoke("glGetActiveUniformsiv"));
        _glGetActiveUniformName = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMNAMEPROC>(loader.Invoke("glGetActiveUniformName"));
        _glGetUniformBlockIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMBLOCKINDEXPROC>(loader.Invoke("glGetUniformBlockIndex"));
        _glGetActiveUniformBlockiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMBLOCKIVPROC>(loader.Invoke("glGetActiveUniformBlockiv"));
        _glGetActiveUniformBlockName = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC>(loader.Invoke("glGetActiveUniformBlockName"));
        _glUniformBlockBinding = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMBLOCKBINDINGPROC>(loader.Invoke("glUniformBlockBinding"));
#endif
#if OGL_V_3_2 || OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSBASEVERTEXPROC>(loader.Invoke("glDrawElementsBaseVertex"));
        _glDrawRangeElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC>(loader.Invoke("glDrawRangeElementsBaseVertex"));
        _glDrawElementsInstancedBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC>(loader.Invoke("glDrawElementsInstancedBaseVertex"));
        _glMultiDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC>(loader.Invoke("glMultiDrawElementsBaseVertex"));
        _glProvokingVertex = Marshal.GetDelegateForFunctionPointer<PFNGLPROVOKINGVERTEXPROC>(loader.Invoke("glProvokingVertex"));
        _glFenceSync = Marshal.GetDelegateForFunctionPointer<PFNGLFENCESYNCPROC>(loader.Invoke("glFenceSync"));
        _glIsSync = Marshal.GetDelegateForFunctionPointer<PFNGLISSYNCPROC>(loader.Invoke("glIsSync"));
        _glDeleteSync = Marshal.GetDelegateForFunctionPointer<PFNGLDELETESYNCPROC>(loader.Invoke("glDeleteSync"));
        _glClientWaitSync = Marshal.GetDelegateForFunctionPointer<PFNGLCLIENTWAITSYNCPROC>(loader.Invoke("glClientWaitSync"));
        _glWaitSync = Marshal.GetDelegateForFunctionPointer<PFNGLWAITSYNCPROC>(loader.Invoke("glWaitSync"));
        _glGetInteger64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGER64VPROC>(loader.Invoke("glGetInteger64v"));
        _glGetSynciv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSYNCIVPROC>(loader.Invoke("glGetSynciv"));
        _glGetInteger64i_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGER64I_VPROC>(loader.Invoke("glGetInteger64i_v"));
        _glGetBufferParameteri64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERPARAMETERI64VPROC>(loader.Invoke("glGetBufferParameteri64v"));
        _glFramebufferTexture = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTUREPROC>(loader.Invoke("glFramebufferTexture"));
        _glTexImage2DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE2DMULTISAMPLEPROC>(loader.Invoke("glTexImage2DMultisample"));
        _glTexImage3DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE3DMULTISAMPLEPROC>(loader.Invoke("glTexImage3DMultisample"));
        _glGetMultisamplefv = Marshal.GetDelegateForFunctionPointer<PFNGLGETMULTISAMPLEFVPROC>(loader.Invoke("glGetMultisamplefv"));
        _glSampleMaski = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLEMASKIPROC>(loader.Invoke("glSampleMaski"));
#endif
#if OGL_V_3_3 || OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glBindFragDataLocationIndexed = Marshal.GetDelegateForFunctionPointer<PFNGLBINDFRAGDATALOCATIONINDEXEDPROC>(loader.Invoke("glBindFragDataLocationIndexed"));
        _glGetFragDataIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAGDATAINDEXPROC>(loader.Invoke("glGetFragDataIndex"));
        _glGenSamplers = Marshal.GetDelegateForFunctionPointer<PFNGLGENSAMPLERSPROC>(loader.Invoke("glGenSamplers"));
        _glDeleteSamplers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETESAMPLERSPROC>(loader.Invoke("glDeleteSamplers"));
        _glIsSampler = Marshal.GetDelegateForFunctionPointer<PFNGLISSAMPLERPROC>(loader.Invoke("glIsSampler"));
        _glBindSampler = Marshal.GetDelegateForFunctionPointer<PFNGLBINDSAMPLERPROC>(loader.Invoke("glBindSampler"));
        _glSamplerParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIPROC>(loader.Invoke("glSamplerParameteri"));
        _glSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIVPROC>(loader.Invoke("glSamplerParameteriv"));
        _glSamplerParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERFPROC>(loader.Invoke("glSamplerParameterf"));
        _glSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERFVPROC>(loader.Invoke("glSamplerParameterfv"));
        _glSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIIVPROC>(loader.Invoke("glSamplerParameterIiv"));
        _glSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIUIVPROC>(loader.Invoke("glSamplerParameterIuiv"));
        _glGetSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERIVPROC>(loader.Invoke("glGetSamplerParameteriv"));
        _glGetSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERIIVPROC>(loader.Invoke("glGetSamplerParameterIiv"));
        _glGetSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERFVPROC>(loader.Invoke("glGetSamplerParameterfv"));
        _glGetSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERIUIVPROC>(loader.Invoke("glGetSamplerParameterIuiv"));
        _glQueryCounter = Marshal.GetDelegateForFunctionPointer<PFNGLQUERYCOUNTERPROC>(loader.Invoke("glQueryCounter"));
        _glGetQueryObjecti64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTI64VPROC>(loader.Invoke("glGetQueryObjecti64v"));
        _glGetQueryObjectui64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTUI64VPROC>(loader.Invoke("glGetQueryObjectui64v"));
        _glVertexAttribDivisor = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBDIVISORPROC>(loader.Invoke("glVertexAttribDivisor"));
        _glVertexAttribP1ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP1UIPROC>(loader.Invoke("glVertexAttribP1ui"));
        _glVertexAttribP1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP1UIVPROC>(loader.Invoke("glVertexAttribP1uiv"));
        _glVertexAttribP2ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP2UIPROC>(loader.Invoke("glVertexAttribP2ui"));
        _glVertexAttribP2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP2UIVPROC>(loader.Invoke("glVertexAttribP2uiv"));
        _glVertexAttribP3ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP3UIPROC>(loader.Invoke("glVertexAttribP3ui"));
        _glVertexAttribP3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP3UIVPROC>(loader.Invoke("glVertexAttribP3uiv"));
        _glVertexAttribP4ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP4UIPROC>(loader.Invoke("glVertexAttribP4ui"));
        _glVertexAttribP4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP4UIVPROC>(loader.Invoke("glVertexAttribP4uiv"));
#endif
#if OGL_V_4_0 || OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glMinSampleShading = Marshal.GetDelegateForFunctionPointer<PFNGLMINSAMPLESHADINGPROC>(loader.Invoke("glMinSampleShading"));
        _glBlendEquationi = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDEQUATIONIPROC>(loader.Invoke("glBlendEquationi"));
        _glBlendEquationSeparatei = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDEQUATIONSEPARATEIPROC>(loader.Invoke("glBlendEquationSeparatei"));
        _glBlendFunci = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDFUNCIPROC>(loader.Invoke("glBlendFunci"));
        _glBlendFuncSeparatei = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDFUNCSEPARATEIPROC>(loader.Invoke("glBlendFuncSeparatei"));
        _glDrawArraysIndirect = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWARRAYSINDIRECTPROC>(loader.Invoke("glDrawArraysIndirect"));
        _glDrawElementsIndirect = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINDIRECTPROC>(loader.Invoke("glDrawElementsIndirect"));
        _glUniform1d = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1DPROC>(loader.Invoke("glUniform1d"));
        _glUniform2d = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2DPROC>(loader.Invoke("glUniform2d"));
        _glUniform3d = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3DPROC>(loader.Invoke("glUniform3d"));
        _glUniform4d = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4DPROC>(loader.Invoke("glUniform4d"));
        _glUniform1dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1DVPROC>(loader.Invoke("glUniform1dv"));
        _glUniform2dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2DVPROC>(loader.Invoke("glUniform2dv"));
        _glUniform3dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3DVPROC>(loader.Invoke("glUniform3dv"));
        _glUniform4dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4DVPROC>(loader.Invoke("glUniform4dv"));
        _glUniformMatrix2dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2DVPROC>(loader.Invoke("glUniformMatrix2dv"));
        _glUniformMatrix3dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3DVPROC>(loader.Invoke("glUniformMatrix3dv"));
        _glUniformMatrix4dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4DVPROC>(loader.Invoke("glUniformMatrix4dv"));
        _glUniformMatrix2x3dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2X3DVPROC>(loader.Invoke("glUniformMatrix2x3dv"));
        _glUniformMatrix2x4dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2X4DVPROC>(loader.Invoke("glUniformMatrix2x4dv"));
        _glUniformMatrix3x2dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3X2DVPROC>(loader.Invoke("glUniformMatrix3x2dv"));
        _glUniformMatrix3x4dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3X4DVPROC>(loader.Invoke("glUniformMatrix3x4dv"));
        _glUniformMatrix4x2dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4X2DVPROC>(loader.Invoke("glUniformMatrix4x2dv"));
        _glUniformMatrix4x3dv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4X3DVPROC>(loader.Invoke("glUniformMatrix4x3dv"));
        _glGetUniformdv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMDVPROC>(loader.Invoke("glGetUniformdv"));
        _glGetSubroutineUniformLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETSUBROUTINEUNIFORMLOCATIONPROC>(loader.Invoke("glGetSubroutineUniformLocation"));
        _glGetSubroutineIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETSUBROUTINEINDEXPROC>(loader.Invoke("glGetSubroutineIndex"));
        _glGetActiveSubroutineUniformiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVESUBROUTINEUNIFORMIVPROC>(loader.Invoke("glGetActiveSubroutineUniformiv"));
        _glGetActiveSubroutineUniformName = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVESUBROUTINEUNIFORMNAMEPROC>(loader.Invoke("glGetActiveSubroutineUniformName"));
        _glGetActiveSubroutineName = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVESUBROUTINENAMEPROC>(loader.Invoke("glGetActiveSubroutineName"));
        _glUniformSubroutinesuiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMSUBROUTINESUIVPROC>(loader.Invoke("glUniformSubroutinesuiv"));
        _glGetUniformSubroutineuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMSUBROUTINEUIVPROC>(loader.Invoke("glGetUniformSubroutineuiv"));
        _glGetProgramStageiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMSTAGEIVPROC>(loader.Invoke("glGetProgramStageiv"));
        _glPatchParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLPATCHPARAMETERIPROC>(loader.Invoke("glPatchParameteri"));
        _glPatchParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLPATCHPARAMETERFVPROC>(loader.Invoke("glPatchParameterfv"));
        _glBindTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLBINDTRANSFORMFEEDBACKPROC>(loader.Invoke("glBindTransformFeedback"));
        _glDeleteTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<PFNGLDELETETRANSFORMFEEDBACKSPROC>(loader.Invoke("glDeleteTransformFeedbacks"));
        _glGenTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<PFNGLGENTRANSFORMFEEDBACKSPROC>(loader.Invoke("glGenTransformFeedbacks"));
        _glIsTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLISTRANSFORMFEEDBACKPROC>(loader.Invoke("glIsTransformFeedback"));
        _glPauseTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLPAUSETRANSFORMFEEDBACKPROC>(loader.Invoke("glPauseTransformFeedback"));
        _glResumeTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLRESUMETRANSFORMFEEDBACKPROC>(loader.Invoke("glResumeTransformFeedback"));
        _glDrawTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWTRANSFORMFEEDBACKPROC>(loader.Invoke("glDrawTransformFeedback"));
        _glDrawTransformFeedbackStream = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWTRANSFORMFEEDBACKSTREAMPROC>(loader.Invoke("glDrawTransformFeedbackStream"));
        _glBeginQueryIndexed = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINQUERYINDEXEDPROC>(loader.Invoke("glBeginQueryIndexed"));
        _glEndQueryIndexed = Marshal.GetDelegateForFunctionPointer<PFNGLENDQUERYINDEXEDPROC>(loader.Invoke("glEndQueryIndexed"));
        _glGetQueryIndexediv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYINDEXEDIVPROC>(loader.Invoke("glGetQueryIndexediv"));
#endif
#if OGL_V_4_1 || OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glReleaseShaderCompiler = Marshal.GetDelegateForFunctionPointer<PFNGLRELEASESHADERCOMPILERPROC>(loader.Invoke("glReleaseShaderCompiler"));
        _glShaderBinary = Marshal.GetDelegateForFunctionPointer<PFNGLSHADERBINARYPROC>(loader.Invoke("glShaderBinary"));
        _glGetShaderPrecisionFormat = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERPRECISIONFORMATPROC>(loader.Invoke("glGetShaderPrecisionFormat"));
        _glDepthRangef = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHRANGEFPROC>(loader.Invoke("glDepthRangef"));
        _glClearDepthf = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARDEPTHFPROC>(loader.Invoke("glClearDepthf"));
        _glGetProgramBinary = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMBINARYPROC>(loader.Invoke("glGetProgramBinary"));
        _glProgramBinary = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMBINARYPROC>(loader.Invoke("glProgramBinary"));
        _glProgramParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMPARAMETERIPROC>(loader.Invoke("glProgramParameteri"));
        _glUseProgramStages = Marshal.GetDelegateForFunctionPointer<PFNGLUSEPROGRAMSTAGESPROC>(loader.Invoke("glUseProgramStages"));
        _glActiveShaderProgram = Marshal.GetDelegateForFunctionPointer<PFNGLACTIVESHADERPROGRAMPROC>(loader.Invoke("glActiveShaderProgram"));
        _glCreateShaderProgramv = Marshal.GetDelegateForFunctionPointer<PFNGLCREATESHADERPROGRAMVPROC>(loader.Invoke("glCreateShaderProgramv"));
        _glBindProgramPipeline = Marshal.GetDelegateForFunctionPointer<PFNGLBINDPROGRAMPIPELINEPROC>(loader.Invoke("glBindProgramPipeline"));
        _glDeleteProgramPipelines = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEPROGRAMPIPELINESPROC>(loader.Invoke("glDeleteProgramPipelines"));
        _glGenProgramPipelines = Marshal.GetDelegateForFunctionPointer<PFNGLGENPROGRAMPIPELINESPROC>(loader.Invoke("glGenProgramPipelines"));
        _glIsProgramPipeline = Marshal.GetDelegateForFunctionPointer<PFNGLISPROGRAMPIPELINEPROC>(loader.Invoke("glIsProgramPipeline"));
        _glGetProgramPipelineiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMPIPELINEIVPROC>(loader.Invoke("glGetProgramPipelineiv"));
        _glProgramUniform1i = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1IPROC>(loader.Invoke("glProgramUniform1i"));
        _glProgramUniform1iv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1IVPROC>(loader.Invoke("glProgramUniform1iv"));
        _glProgramUniform1f = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1FPROC>(loader.Invoke("glProgramUniform1f"));
        _glProgramUniform1fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1FVPROC>(loader.Invoke("glProgramUniform1fv"));
        _glProgramUniform1d = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1DPROC>(loader.Invoke("glProgramUniform1d"));
        _glProgramUniform1dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1DVPROC>(loader.Invoke("glProgramUniform1dv"));
        _glProgramUniform1ui = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1UIPROC>(loader.Invoke("glProgramUniform1ui"));
        _glProgramUniform1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM1UIVPROC>(loader.Invoke("glProgramUniform1uiv"));
        _glProgramUniform2i = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2IPROC>(loader.Invoke("glProgramUniform2i"));
        _glProgramUniform2iv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2IVPROC>(loader.Invoke("glProgramUniform2iv"));
        _glProgramUniform2f = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2FPROC>(loader.Invoke("glProgramUniform2f"));
        _glProgramUniform2fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2FVPROC>(loader.Invoke("glProgramUniform2fv"));
        _glProgramUniform2d = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2DPROC>(loader.Invoke("glProgramUniform2d"));
        _glProgramUniform2dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2DVPROC>(loader.Invoke("glProgramUniform2dv"));
        _glProgramUniform2ui = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2UIPROC>(loader.Invoke("glProgramUniform2ui"));
        _glProgramUniform2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM2UIVPROC>(loader.Invoke("glProgramUniform2uiv"));
        _glProgramUniform3i = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3IPROC>(loader.Invoke("glProgramUniform3i"));
        _glProgramUniform3iv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3IVPROC>(loader.Invoke("glProgramUniform3iv"));
        _glProgramUniform3f = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3FPROC>(loader.Invoke("glProgramUniform3f"));
        _glProgramUniform3fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3FVPROC>(loader.Invoke("glProgramUniform3fv"));
        _glProgramUniform3d = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3DPROC>(loader.Invoke("glProgramUniform3d"));
        _glProgramUniform3dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3DVPROC>(loader.Invoke("glProgramUniform3dv"));
        _glProgramUniform3ui = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3UIPROC>(loader.Invoke("glProgramUniform3ui"));
        _glProgramUniform3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM3UIVPROC>(loader.Invoke("glProgramUniform3uiv"));
        _glProgramUniform4i = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4IPROC>(loader.Invoke("glProgramUniform4i"));
        _glProgramUniform4iv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4IVPROC>(loader.Invoke("glProgramUniform4iv"));
        _glProgramUniform4f = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4FPROC>(loader.Invoke("glProgramUniform4f"));
        _glProgramUniform4fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4FVPROC>(loader.Invoke("glProgramUniform4fv"));
        _glProgramUniform4d = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4DPROC>(loader.Invoke("glProgramUniform4d"));
        _glProgramUniform4dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4DVPROC>(loader.Invoke("glProgramUniform4dv"));
        _glProgramUniform4ui = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4UIPROC>(loader.Invoke("glProgramUniform4ui"));
        _glProgramUniform4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORM4UIVPROC>(loader.Invoke("glProgramUniform4uiv"));
        _glProgramUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX2FVPROC>(loader.Invoke("glProgramUniformMatrix2fv"));
        _glProgramUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX3FVPROC>(loader.Invoke("glProgramUniformMatrix3fv"));
        _glProgramUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX4FVPROC>(loader.Invoke("glProgramUniformMatrix4fv"));
        _glProgramUniformMatrix2dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX2DVPROC>(loader.Invoke("glProgramUniformMatrix2dv"));
        _glProgramUniformMatrix3dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX3DVPROC>(loader.Invoke("glProgramUniformMatrix3dv"));
        _glProgramUniformMatrix4dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX4DVPROC>(loader.Invoke("glProgramUniformMatrix4dv"));
        _glProgramUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX2X3FVPROC>(loader.Invoke("glProgramUniformMatrix2x3fv"));
        _glProgramUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX3X2FVPROC>(loader.Invoke("glProgramUniformMatrix3x2fv"));
        _glProgramUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX2X4FVPROC>(loader.Invoke("glProgramUniformMatrix2x4fv"));
        _glProgramUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX4X2FVPROC>(loader.Invoke("glProgramUniformMatrix4x2fv"));
        _glProgramUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX3X4FVPROC>(loader.Invoke("glProgramUniformMatrix3x4fv"));
        _glProgramUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX4X3FVPROC>(loader.Invoke("glProgramUniformMatrix4x3fv"));
        _glProgramUniformMatrix2x3dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX2X3DVPROC>(loader.Invoke("glProgramUniformMatrix2x3dv"));
        _glProgramUniformMatrix3x2dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX3X2DVPROC>(loader.Invoke("glProgramUniformMatrix3x2dv"));
        _glProgramUniformMatrix2x4dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX2X4DVPROC>(loader.Invoke("glProgramUniformMatrix2x4dv"));
        _glProgramUniformMatrix4x2dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX4X2DVPROC>(loader.Invoke("glProgramUniformMatrix4x2dv"));
        _glProgramUniformMatrix3x4dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX3X4DVPROC>(loader.Invoke("glProgramUniformMatrix3x4dv"));
        _glProgramUniformMatrix4x3dv = Marshal.GetDelegateForFunctionPointer<PFNGLPROGRAMUNIFORMMATRIX4X3DVPROC>(loader.Invoke("glProgramUniformMatrix4x3dv"));
        _glValidateProgramPipeline = Marshal.GetDelegateForFunctionPointer<PFNGLVALIDATEPROGRAMPIPELINEPROC>(loader.Invoke("glValidateProgramPipeline"));
        _glGetProgramPipelineInfoLog = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMPIPELINEINFOLOGPROC>(loader.Invoke("glGetProgramPipelineInfoLog"));
        _glVertexAttribL1d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL1DPROC>(loader.Invoke("glVertexAttribL1d"));
        _glVertexAttribL2d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL2DPROC>(loader.Invoke("glVertexAttribL2d"));
        _glVertexAttribL3d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL3DPROC>(loader.Invoke("glVertexAttribL3d"));
        _glVertexAttribL4d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL4DPROC>(loader.Invoke("glVertexAttribL4d"));
        _glVertexAttribL1dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL1DVPROC>(loader.Invoke("glVertexAttribL1dv"));
        _glVertexAttribL2dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL2DVPROC>(loader.Invoke("glVertexAttribL2dv"));
        _glVertexAttribL3dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL3DVPROC>(loader.Invoke("glVertexAttribL3dv"));
        _glVertexAttribL4dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBL4DVPROC>(loader.Invoke("glVertexAttribL4dv"));
        _glVertexAttribLPointer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBLPOINTERPROC>(loader.Invoke("glVertexAttribLPointer"));
        _glGetVertexAttribLdv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBLDVPROC>(loader.Invoke("glGetVertexAttribLdv"));
        _glViewportArrayv = Marshal.GetDelegateForFunctionPointer<PFNGLVIEWPORTARRAYVPROC>(loader.Invoke("glViewportArrayv"));
        _glViewportIndexedf = Marshal.GetDelegateForFunctionPointer<PFNGLVIEWPORTINDEXEDFPROC>(loader.Invoke("glViewportIndexedf"));
        _glViewportIndexedfv = Marshal.GetDelegateForFunctionPointer<PFNGLVIEWPORTINDEXEDFVPROC>(loader.Invoke("glViewportIndexedfv"));
        _glScissorArrayv = Marshal.GetDelegateForFunctionPointer<PFNGLSCISSORARRAYVPROC>(loader.Invoke("glScissorArrayv"));
        _glScissorIndexed = Marshal.GetDelegateForFunctionPointer<PFNGLSCISSORINDEXEDPROC>(loader.Invoke("glScissorIndexed"));
        _glScissorIndexedv = Marshal.GetDelegateForFunctionPointer<PFNGLSCISSORINDEXEDVPROC>(loader.Invoke("glScissorIndexedv"));
        _glDepthRangeArrayv = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHRANGEARRAYVPROC>(loader.Invoke("glDepthRangeArrayv"));
        _glDepthRangeIndexed = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHRANGEINDEXEDPROC>(loader.Invoke("glDepthRangeIndexed"));
        _glGetFloati_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETFLOATI_VPROC>(loader.Invoke("glGetFloati_v"));
        _glGetDoublei_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETDOUBLEI_VPROC>(loader.Invoke("glGetDoublei_v"));
#endif
#if OGL_V_4_2 || OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glDrawArraysInstancedBaseInstance = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWARRAYSINSTANCEDBASEINSTANCEPROC>(loader.Invoke("glDrawArraysInstancedBaseInstance"));
        _glDrawElementsInstancedBaseInstance = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINSTANCEDBASEINSTANCEPROC>(loader.Invoke("glDrawElementsInstancedBaseInstance"));
        _glDrawElementsInstancedBaseVertexBaseInstance = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXBASEINSTANCEPROC>(loader.Invoke("glDrawElementsInstancedBaseVertexBaseInstance"));
        _glGetInternalformativ = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTERNALFORMATIVPROC>(loader.Invoke("glGetInternalformativ"));
        _glGetActiveAtomicCounterBufferiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEATOMICCOUNTERBUFFERIVPROC>(loader.Invoke("glGetActiveAtomicCounterBufferiv"));
        _glBindImageTexture = Marshal.GetDelegateForFunctionPointer<PFNGLBINDIMAGETEXTUREPROC>(loader.Invoke("glBindImageTexture"));
        _glMemoryBarrier = Marshal.GetDelegateForFunctionPointer<PFNGLMEMORYBARRIERPROC>(loader.Invoke("glMemoryBarrier"));
        _glTexStorage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSTORAGE1DPROC>(loader.Invoke("glTexStorage1D"));
        _glTexStorage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSTORAGE2DPROC>(loader.Invoke("glTexStorage2D"));
        _glTexStorage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSTORAGE3DPROC>(loader.Invoke("glTexStorage3D"));
        _glDrawTransformFeedbackInstanced = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWTRANSFORMFEEDBACKINSTANCEDPROC>(loader.Invoke("glDrawTransformFeedbackInstanced"));
        _glDrawTransformFeedbackStreamInstanced = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWTRANSFORMFEEDBACKSTREAMINSTANCEDPROC>(loader.Invoke("glDrawTransformFeedbackStreamInstanced"));
#endif
#if OGL_V_4_3 || OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glClearBufferData = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERDATAPROC>(loader.Invoke("glClearBufferData"));
        _glClearBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERSUBDATAPROC>(loader.Invoke("glClearBufferSubData"));
        _glDispatchCompute = Marshal.GetDelegateForFunctionPointer<PFNGLDISPATCHCOMPUTEPROC>(loader.Invoke("glDispatchCompute"));
        _glDispatchComputeIndirect = Marshal.GetDelegateForFunctionPointer<PFNGLDISPATCHCOMPUTEINDIRECTPROC>(loader.Invoke("glDispatchComputeIndirect"));
        _glCopyImageSubData = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYIMAGESUBDATAPROC>(loader.Invoke("glCopyImageSubData"));
        _glFramebufferParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERPARAMETERIPROC>(loader.Invoke("glFramebufferParameteri"));
        _glGetFramebufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAMEBUFFERPARAMETERIVPROC>(loader.Invoke("glGetFramebufferParameteriv"));
        _glGetInternalformati64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTERNALFORMATI64VPROC>(loader.Invoke("glGetInternalformati64v"));
        _glInvalidateTexSubImage = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATETEXSUBIMAGEPROC>(loader.Invoke("glInvalidateTexSubImage"));
        _glInvalidateTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATETEXIMAGEPROC>(loader.Invoke("glInvalidateTexImage"));
        _glInvalidateBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATEBUFFERSUBDATAPROC>(loader.Invoke("glInvalidateBufferSubData"));
        _glInvalidateBufferData = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATEBUFFERDATAPROC>(loader.Invoke("glInvalidateBufferData"));
        _glInvalidateFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATEFRAMEBUFFERPROC>(loader.Invoke("glInvalidateFramebuffer"));
        _glInvalidateSubFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATESUBFRAMEBUFFERPROC>(loader.Invoke("glInvalidateSubFramebuffer"));
        _glMultiDrawArraysIndirect = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWARRAYSINDIRECTPROC>(loader.Invoke("glMultiDrawArraysIndirect"));
        _glMultiDrawElementsIndirect = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWELEMENTSINDIRECTPROC>(loader.Invoke("glMultiDrawElementsIndirect"));
        _glGetProgramInterfaceiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMINTERFACEIVPROC>(loader.Invoke("glGetProgramInterfaceiv"));
        _glGetProgramResourceIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMRESOURCEINDEXPROC>(loader.Invoke("glGetProgramResourceIndex"));
        _glGetProgramResourceName = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMRESOURCENAMEPROC>(loader.Invoke("glGetProgramResourceName"));
        _glGetProgramResourceiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMRESOURCEIVPROC>(loader.Invoke("glGetProgramResourceiv"));
        _glGetProgramResourceLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMRESOURCELOCATIONPROC>(loader.Invoke("glGetProgramResourceLocation"));
        _glGetProgramResourceLocationIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMRESOURCELOCATIONINDEXPROC>(loader.Invoke("glGetProgramResourceLocationIndex"));
        _glShaderStorageBlockBinding = Marshal.GetDelegateForFunctionPointer<PFNGLSHADERSTORAGEBLOCKBINDINGPROC>(loader.Invoke("glShaderStorageBlockBinding"));
        _glTexBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLTEXBUFFERRANGEPROC>(loader.Invoke("glTexBufferRange"));
        _glTexStorage2DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSTORAGE2DMULTISAMPLEPROC>(loader.Invoke("glTexStorage2DMultisample"));
        _glTexStorage3DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSTORAGE3DMULTISAMPLEPROC>(loader.Invoke("glTexStorage3DMultisample"));
        _glTextureView = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREVIEWPROC>(loader.Invoke("glTextureView"));
        _glBindVertexBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDVERTEXBUFFERPROC>(loader.Invoke("glBindVertexBuffer"));
        _glVertexAttribFormat = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBFORMATPROC>(loader.Invoke("glVertexAttribFormat"));
        _glVertexAttribIFormat = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBIFORMATPROC>(loader.Invoke("glVertexAttribIFormat"));
        _glVertexAttribLFormat = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBLFORMATPROC>(loader.Invoke("glVertexAttribLFormat"));
        _glVertexAttribBinding = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBBINDINGPROC>(loader.Invoke("glVertexAttribBinding"));
        _glVertexBindingDivisor = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXBINDINGDIVISORPROC>(loader.Invoke("glVertexBindingDivisor"));
        _glDebugMessageControl = Marshal.GetDelegateForFunctionPointer<PFNGLDEBUGMESSAGECONTROLPROC>(loader.Invoke("glDebugMessageControl"));
        _glDebugMessageInsert = Marshal.GetDelegateForFunctionPointer<PFNGLDEBUGMESSAGEINSERTPROC>(loader.Invoke("glDebugMessageInsert"));
        _glDebugMessageCallback = Marshal.GetDelegateForFunctionPointer<PFNGLDEBUGMESSAGECALLBACKPROC>(loader.Invoke("glDebugMessageCallback"));
        _glGetDebugMessageLog = Marshal.GetDelegateForFunctionPointer<PFNGLGETDEBUGMESSAGELOGPROC>(loader.Invoke("glGetDebugMessageLog"));
        _glPushDebugGroup = Marshal.GetDelegateForFunctionPointer<PFNGLPUSHDEBUGGROUPPROC>(loader.Invoke("glPushDebugGroup"));
        _glPopDebugGroup = Marshal.GetDelegateForFunctionPointer<PFNGLPOPDEBUGGROUPPROC>(loader.Invoke("glPopDebugGroup"));
        _glObjectLabel = Marshal.GetDelegateForFunctionPointer<PFNGLOBJECTLABELPROC>(loader.Invoke("glObjectLabel"));
        _glGetObjectLabel = Marshal.GetDelegateForFunctionPointer<PFNGLGETOBJECTLABELPROC>(loader.Invoke("glGetObjectLabel"));
        _glObjectPtrLabel = Marshal.GetDelegateForFunctionPointer<PFNGLOBJECTPTRLABELPROC>(loader.Invoke("glObjectPtrLabel"));
        _glGetObjectPtrLabel = Marshal.GetDelegateForFunctionPointer<PFNGLGETOBJECTPTRLABELPROC>(loader.Invoke("glGetObjectPtrLabel"));
#endif
#if OGL_V_4_4 || OGL_V_4_5 || OGL_V_4_6
        _glBufferStorage = Marshal.GetDelegateForFunctionPointer<PFNGLBUFFERSTORAGEPROC>(loader.Invoke("glBufferStorage"));
        _glClearTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARTEXIMAGEPROC>(loader.Invoke("glClearTexImage"));
        _glClearTexSubImage = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARTEXSUBIMAGEPROC>(loader.Invoke("glClearTexSubImage"));
        _glBindBuffersBase = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERSBASEPROC>(loader.Invoke("glBindBuffersBase"));
        _glBindBuffersRange = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERSRANGEPROC>(loader.Invoke("glBindBuffersRange"));
        _glBindTextures = Marshal.GetDelegateForFunctionPointer<PFNGLBINDTEXTURESPROC>(loader.Invoke("glBindTextures"));
        _glBindSamplers = Marshal.GetDelegateForFunctionPointer<PFNGLBINDSAMPLERSPROC>(loader.Invoke("glBindSamplers"));
        _glBindImageTextures = Marshal.GetDelegateForFunctionPointer<PFNGLBINDIMAGETEXTURESPROC>(loader.Invoke("glBindImageTextures"));
        _glBindVertexBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLBINDVERTEXBUFFERSPROC>(loader.Invoke("glBindVertexBuffers"));
#endif
#if OGL_V_4_5 || OGL_V_4_6
        _glClipControl = Marshal.GetDelegateForFunctionPointer<PFNGLCLIPCONTROLPROC>(loader.Invoke("glClipControl"));
        _glCreateTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<PFNGLCREATETRANSFORMFEEDBACKSPROC>(loader.Invoke("glCreateTransformFeedbacks"));
        _glTransformFeedbackBufferBase = Marshal.GetDelegateForFunctionPointer<PFNGLTRANSFORMFEEDBACKBUFFERBASEPROC>(loader.Invoke("glTransformFeedbackBufferBase"));
        _glTransformFeedbackBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLTRANSFORMFEEDBACKBUFFERRANGEPROC>(loader.Invoke("glTransformFeedbackBufferRange"));
        _glGetTransformFeedbackiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTRANSFORMFEEDBACKIVPROC>(loader.Invoke("glGetTransformFeedbackiv"));
        _glGetTransformFeedbacki_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETTRANSFORMFEEDBACKI_VPROC>(loader.Invoke("glGetTransformFeedbacki_v"));
        _glGetTransformFeedbacki64_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETTRANSFORMFEEDBACKI64_VPROC>(loader.Invoke("glGetTransformFeedbacki64_v"));
        _glCreateBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEBUFFERSPROC>(loader.Invoke("glCreateBuffers"));
        _glNamedBufferStorage = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDBUFFERSTORAGEPROC>(loader.Invoke("glNamedBufferStorage"));
        _glNamedBufferData = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDBUFFERDATAPROC>(loader.Invoke("glNamedBufferData"));
        _glNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDBUFFERSUBDATAPROC>(loader.Invoke("glNamedBufferSubData"));
        _glCopyNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYNAMEDBUFFERSUBDATAPROC>(loader.Invoke("glCopyNamedBufferSubData"));
        _glClearNamedBufferData = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARNAMEDBUFFERDATAPROC>(loader.Invoke("glClearNamedBufferData"));
        _glClearNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARNAMEDBUFFERSUBDATAPROC>(loader.Invoke("glClearNamedBufferSubData"));
        _glMapNamedBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLMAPNAMEDBUFFERPROC>(loader.Invoke("glMapNamedBuffer"));
        _glMapNamedBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLMAPNAMEDBUFFERRANGEPROC>(loader.Invoke("glMapNamedBufferRange"));
        _glUnmapNamedBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLUNMAPNAMEDBUFFERPROC>(loader.Invoke("glUnmapNamedBuffer"));
        _glFlushMappedNamedBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLFLUSHMAPPEDNAMEDBUFFERRANGEPROC>(loader.Invoke("glFlushMappedNamedBufferRange"));
        _glGetNamedBufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDBUFFERPARAMETERIVPROC>(loader.Invoke("glGetNamedBufferParameteriv"));
        _glGetNamedBufferParameteri64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDBUFFERPARAMETERI64VPROC>(loader.Invoke("glGetNamedBufferParameteri64v"));
        _glGetNamedBufferPointerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDBUFFERPOINTERVPROC>(loader.Invoke("glGetNamedBufferPointerv"));
        _glGetNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDBUFFERSUBDATAPROC>(loader.Invoke("glGetNamedBufferSubData"));
        _glCreateFramebuffers = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEFRAMEBUFFERSPROC>(loader.Invoke("glCreateFramebuffers"));
        _glNamedFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERRENDERBUFFERPROC>(loader.Invoke("glNamedFramebufferRenderbuffer"));
        _glNamedFramebufferParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERPARAMETERIPROC>(loader.Invoke("glNamedFramebufferParameteri"));
        _glNamedFramebufferTexture = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERTEXTUREPROC>(loader.Invoke("glNamedFramebufferTexture"));
        _glNamedFramebufferTextureLayer = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERTEXTURELAYERPROC>(loader.Invoke("glNamedFramebufferTextureLayer"));
        _glNamedFramebufferDrawBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERDRAWBUFFERPROC>(loader.Invoke("glNamedFramebufferDrawBuffer"));
        _glNamedFramebufferDrawBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERDRAWBUFFERSPROC>(loader.Invoke("glNamedFramebufferDrawBuffers"));
        _glNamedFramebufferReadBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDFRAMEBUFFERREADBUFFERPROC>(loader.Invoke("glNamedFramebufferReadBuffer"));
        _glInvalidateNamedFramebufferData = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATENAMEDFRAMEBUFFERDATAPROC>(loader.Invoke("glInvalidateNamedFramebufferData"));
        _glInvalidateNamedFramebufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLINVALIDATENAMEDFRAMEBUFFERSUBDATAPROC>(loader.Invoke("glInvalidateNamedFramebufferSubData"));
        _glClearNamedFramebufferiv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARNAMEDFRAMEBUFFERIVPROC>(loader.Invoke("glClearNamedFramebufferiv"));
        _glClearNamedFramebufferuiv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARNAMEDFRAMEBUFFERUIVPROC>(loader.Invoke("glClearNamedFramebufferuiv"));
        _glClearNamedFramebufferfv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARNAMEDFRAMEBUFFERFVPROC>(loader.Invoke("glClearNamedFramebufferfv"));
        _glClearNamedFramebufferfi = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARNAMEDFRAMEBUFFERFIPROC>(loader.Invoke("glClearNamedFramebufferfi"));
        _glBlitNamedFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBLITNAMEDFRAMEBUFFERPROC>(loader.Invoke("glBlitNamedFramebuffer"));
        _glCheckNamedFramebufferStatus = Marshal.GetDelegateForFunctionPointer<PFNGLCHECKNAMEDFRAMEBUFFERSTATUSPROC>(loader.Invoke("glCheckNamedFramebufferStatus"));
        _glGetNamedFramebufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDFRAMEBUFFERPARAMETERIVPROC>(loader.Invoke("glGetNamedFramebufferParameteriv"));
        _glGetNamedFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDFRAMEBUFFERATTACHMENTPARAMETERIVPROC>(loader.Invoke("glGetNamedFramebufferAttachmentParameteriv"));
        _glCreateRenderbuffers = Marshal.GetDelegateForFunctionPointer<PFNGLCREATERENDERBUFFERSPROC>(loader.Invoke("glCreateRenderbuffers"));
        _glNamedRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDRENDERBUFFERSTORAGEPROC>(loader.Invoke("glNamedRenderbufferStorage"));
        _glNamedRenderbufferStorageMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLEPROC>(loader.Invoke("glNamedRenderbufferStorageMultisample"));
        _glGetNamedRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNAMEDRENDERBUFFERPARAMETERIVPROC>(loader.Invoke("glGetNamedRenderbufferParameteriv"));
        _glCreateTextures = Marshal.GetDelegateForFunctionPointer<PFNGLCREATETEXTURESPROC>(loader.Invoke("glCreateTextures"));
        _glTextureBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREBUFFERPROC>(loader.Invoke("glTextureBuffer"));
        _glTextureBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREBUFFERRANGEPROC>(loader.Invoke("glTextureBufferRange"));
        _glTextureStorage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESTORAGE1DPROC>(loader.Invoke("glTextureStorage1D"));
        _glTextureStorage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESTORAGE2DPROC>(loader.Invoke("glTextureStorage2D"));
        _glTextureStorage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESTORAGE3DPROC>(loader.Invoke("glTextureStorage3D"));
        _glTextureStorage2DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESTORAGE2DMULTISAMPLEPROC>(loader.Invoke("glTextureStorage2DMultisample"));
        _glTextureStorage3DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESTORAGE3DMULTISAMPLEPROC>(loader.Invoke("glTextureStorage3DMultisample"));
        _glTextureSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESUBIMAGE1DPROC>(loader.Invoke("glTextureSubImage1D"));
        _glTextureSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESUBIMAGE2DPROC>(loader.Invoke("glTextureSubImage2D"));
        _glTextureSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTURESUBIMAGE3DPROC>(loader.Invoke("glTextureSubImage3D"));
        _glCompressedTextureSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXTURESUBIMAGE1DPROC>(loader.Invoke("glCompressedTextureSubImage1D"));
        _glCompressedTextureSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXTURESUBIMAGE2DPROC>(loader.Invoke("glCompressedTextureSubImage2D"));
        _glCompressedTextureSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXTURESUBIMAGE3DPROC>(loader.Invoke("glCompressedTextureSubImage3D"));
        _glCopyTextureSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXTURESUBIMAGE1DPROC>(loader.Invoke("glCopyTextureSubImage1D"));
        _glCopyTextureSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXTURESUBIMAGE2DPROC>(loader.Invoke("glCopyTextureSubImage2D"));
        _glCopyTextureSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXTURESUBIMAGE3DPROC>(loader.Invoke("glCopyTextureSubImage3D"));
        _glTextureParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREPARAMETERFPROC>(loader.Invoke("glTextureParameterf"));
        _glTextureParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREPARAMETERFVPROC>(loader.Invoke("glTextureParameterfv"));
        _glTextureParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREPARAMETERIPROC>(loader.Invoke("glTextureParameteri"));
        _glTextureParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREPARAMETERIIVPROC>(loader.Invoke("glTextureParameterIiv"));
        _glTextureParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREPARAMETERIUIVPROC>(loader.Invoke("glTextureParameterIuiv"));
        _glTextureParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREPARAMETERIVPROC>(loader.Invoke("glTextureParameteriv"));
        _glGenerateTextureMipmap = Marshal.GetDelegateForFunctionPointer<PFNGLGENERATETEXTUREMIPMAPPROC>(loader.Invoke("glGenerateTextureMipmap"));
        _glBindTextureUnit = Marshal.GetDelegateForFunctionPointer<PFNGLBINDTEXTUREUNITPROC>(loader.Invoke("glBindTextureUnit"));
        _glGetTextureImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTUREIMAGEPROC>(loader.Invoke("glGetTextureImage"));
        _glGetCompressedTextureImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETCOMPRESSEDTEXTUREIMAGEPROC>(loader.Invoke("glGetCompressedTextureImage"));
        _glGetTextureLevelParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTURELEVELPARAMETERFVPROC>(loader.Invoke("glGetTextureLevelParameterfv"));
        _glGetTextureLevelParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTURELEVELPARAMETERIVPROC>(loader.Invoke("glGetTextureLevelParameteriv"));
        _glGetTextureParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTUREPARAMETERFVPROC>(loader.Invoke("glGetTextureParameterfv"));
        _glGetTextureParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTUREPARAMETERIIVPROC>(loader.Invoke("glGetTextureParameterIiv"));
        _glGetTextureParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTUREPARAMETERIUIVPROC>(loader.Invoke("glGetTextureParameterIuiv"));
        _glGetTextureParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTUREPARAMETERIVPROC>(loader.Invoke("glGetTextureParameteriv"));
        _glCreateVertexArrays = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEVERTEXARRAYSPROC>(loader.Invoke("glCreateVertexArrays"));
        _glDisableVertexArrayAttrib = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEVERTEXARRAYATTRIBPROC>(loader.Invoke("glDisableVertexArrayAttrib"));
        _glEnableVertexArrayAttrib = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEVERTEXARRAYATTRIBPROC>(loader.Invoke("glEnableVertexArrayAttrib"));
        _glVertexArrayElementBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYELEMENTBUFFERPROC>(loader.Invoke("glVertexArrayElementBuffer"));
        _glVertexArrayVertexBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYVERTEXBUFFERPROC>(loader.Invoke("glVertexArrayVertexBuffer"));
        _glVertexArrayVertexBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYVERTEXBUFFERSPROC>(loader.Invoke("glVertexArrayVertexBuffers"));
        _glVertexArrayAttribBinding = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYATTRIBBINDINGPROC>(loader.Invoke("glVertexArrayAttribBinding"));
        _glVertexArrayAttribFormat = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYATTRIBFORMATPROC>(loader.Invoke("glVertexArrayAttribFormat"));
        _glVertexArrayAttribIFormat = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYATTRIBIFORMATPROC>(loader.Invoke("glVertexArrayAttribIFormat"));
        _glVertexArrayAttribLFormat = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYATTRIBLFORMATPROC>(loader.Invoke("glVertexArrayAttribLFormat"));
        _glVertexArrayBindingDivisor = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXARRAYBINDINGDIVISORPROC>(loader.Invoke("glVertexArrayBindingDivisor"));
        _glGetVertexArrayiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXARRAYIVPROC>(loader.Invoke("glGetVertexArrayiv"));
        _glGetVertexArrayIndexediv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXARRAYINDEXEDIVPROC>(loader.Invoke("glGetVertexArrayIndexediv"));
        _glGetVertexArrayIndexed64iv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXARRAYINDEXED64IVPROC>(loader.Invoke("glGetVertexArrayIndexed64iv"));
        _glCreateSamplers = Marshal.GetDelegateForFunctionPointer<PFNGLCREATESAMPLERSPROC>(loader.Invoke("glCreateSamplers"));
        _glCreateProgramPipelines = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEPROGRAMPIPELINESPROC>(loader.Invoke("glCreateProgramPipelines"));
        _glCreateQueries = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEQUERIESPROC>(loader.Invoke("glCreateQueries"));
        _glGetQueryBufferObjecti64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYBUFFEROBJECTI64VPROC>(loader.Invoke("glGetQueryBufferObjecti64v"));
        _glGetQueryBufferObjectiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYBUFFEROBJECTIVPROC>(loader.Invoke("glGetQueryBufferObjectiv"));
        _glGetQueryBufferObjectui64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYBUFFEROBJECTUI64VPROC>(loader.Invoke("glGetQueryBufferObjectui64v"));
        _glGetQueryBufferObjectuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYBUFFEROBJECTUIVPROC>(loader.Invoke("glGetQueryBufferObjectuiv"));
        _glMemoryBarrierByRegion = Marshal.GetDelegateForFunctionPointer<PFNGLMEMORYBARRIERBYREGIONPROC>(loader.Invoke("glMemoryBarrierByRegion"));
        _glGetTextureSubImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXTURESUBIMAGEPROC>(loader.Invoke("glGetTextureSubImage"));
        _glGetCompressedTextureSubImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETCOMPRESSEDTEXTURESUBIMAGEPROC>(loader.Invoke("glGetCompressedTextureSubImage"));
        _glGetGraphicsResetStatus = Marshal.GetDelegateForFunctionPointer<PFNGLGETGRAPHICSRESETSTATUSPROC>(loader.Invoke("glGetGraphicsResetStatus"));
        _glGetnCompressedTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETNCOMPRESSEDTEXIMAGEPROC>(loader.Invoke("glGetnCompressedTexImage"));
        _glGetnTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETNTEXIMAGEPROC>(loader.Invoke("glGetnTexImage"));
        _glGetnUniformdv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNUNIFORMDVPROC>(loader.Invoke("glGetnUniformdv"));
        _glGetnUniformfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNUNIFORMFVPROC>(loader.Invoke("glGetnUniformfv"));
        _glGetnUniformiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNUNIFORMIVPROC>(loader.Invoke("glGetnUniformiv"));
        _glGetnUniformuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETNUNIFORMUIVPROC>(loader.Invoke("glGetnUniformuiv"));
        _glReadnPixels = Marshal.GetDelegateForFunctionPointer<PFNGLREADNPIXELSPROC>(loader.Invoke("glReadnPixels"));
        _glTextureBarrier = Marshal.GetDelegateForFunctionPointer<PFNGLTEXTUREBARRIERPROC>(loader.Invoke("glTextureBarrier"));
#endif
#if OGL_V_4_6
        _glSpecializeShader = Marshal.GetDelegateForFunctionPointer<PFNGLSPECIALIZESHADERPROC>(loader.Invoke("glSpecializeShader"));
        _glMultiDrawArraysIndirectCount = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWARRAYSINDIRECTCOUNTPROC>(loader.Invoke("glMultiDrawArraysIndirectCount"));
        _glMultiDrawElementsIndirectCount = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWELEMENTSINDIRECTCOUNTPROC>(loader.Invoke("glMultiDrawElementsIndirectCount"));
        _glPolygonOffsetClamp = Marshal.GetDelegateForFunctionPointer<PFNGLPOLYGONOFFSETCLAMPPROC>(loader.Invoke("glPolygonOffsetClamp"));
#endif
    }
#endif
}
