using System;
using static DotGL.GL;

namespace GameStarter.Graphics;

public class Shader
{
    public uint ShaderID { get; protected set; }

    public unsafe Shader(string source, uint shaderType)
    {
        uint vs = glCreateShader(shaderType);
        glShaderSource(vs, source);
        glCompileShader(vs);

        int* status = stackalloc int[1];
        glGetShaderiv(vs, GL_COMPILE_STATUS, status);

        if (*status == GL_FALSE)
        {
            int* length = stackalloc int[1];
            glGetShaderiv(vs, GL_INFO_LOG_LENGTH, length);
            string info = glGetShaderInfoLog(vs, *length);

            glDeleteShader(vs);
            throw new Exception($"Failed to compile shader: {info}");
        }

        this.ShaderID = vs;
    }
}
