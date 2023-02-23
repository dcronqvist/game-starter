using System;
using System.Diagnostics.CodeAnalysis;
using GameStarter.Content.Loading;
using Symphony;

namespace GameStarter.Graphics;

public abstract class Shader : GLContentItem<string>
{
    public uint ShaderID { get; protected set; }

    public Shader(IContentSource source, string content) : base(source, content)
    {
    }

    public override void InitGL(string newContent)
    {
        if (this.TryCreateShader(newContent, out uint shader, out string error))
        {
            this.ShaderID = shader;
        }
        else
        {
            throw new Exception(error);
        }
    }

    public abstract bool TryCreateShader(string code, out uint shaderID, [NotNullWhen(false)] out string error);
}