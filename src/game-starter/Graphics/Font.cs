
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using GameStarter.Content.Loading;
using StbImageSharp;
using Symphony;
using static GameStarter.Display.GL;

namespace GameStarter.Graphics;

public class FontCharacterBounds
{
    public float Left { get; set; }
    public float Top { get; set; }
    public float Right { get; set; }
    public float Bottom { get; set; }

    public RectangleF ToUVRect(Vector2 atlasSize)
    {
        var x = this.Left;
        var y = atlasSize.Y - this.Top;

        var width = this.Right - this.Left;
        var height = this.Top - this.Bottom;

        return new RectangleF(x, y, width, height);
    }
}

public class FontCharacter
{
    public uint Unicode { get; set; }
    public float Advance { get; set; }
    public FontCharacterBounds PlaneBounds { get; set; }
    public FontCharacterBounds AtlasBounds { get; set; }
}

public class FontAtlasInfo
{
    public string Type { get; set; }
    public int DistanceRange { get; set; }
    public float Size { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public string YOrigin { get; set; }
}

public class FontMetricsInfo
{
    public int EmSize { get; set; }
    public float LineHeight { get; set; }
    public float Ascender { get; set; }
    public float Descender { get; set; }
    public float UnderlineY { get; set; }
    public float UnderlineThickness { get; set; }
}

public class FontData
{
    public FontAtlasInfo Atlas { get; set; }
    public string Name { get; set; }
    public FontMetricsInfo Metrics { get; set; }
    public List<FontCharacter> Glyphs { get; set; }
    public List<int> Kerning { get; set; }

    public ImageResult TextureAtlasData { get; set; }
}

public class Font : GLContentItem<FontData>
{
    public Texture2D TextureAtlas { get; private set; }

    public Font(IContentSource source, FontData content) : base(source, content)
    {

    }

    public override bool IsGLInitialized()
    {
        return this.TextureAtlas != null;
    }

    public override void InitGL(FontData newContent)
    {
        this.TextureAtlas = new Texture2D(this.Source, newContent.TextureAtlasData, GL_LINEAR, GL_LINEAR);
        this.TextureAtlas.InitGL(newContent.TextureAtlasData);
    }

    public override void DestroyGL()
    {
        this.TextureAtlas.Unload();
        this.TextureAtlas = null;
    }

    public FontCharacter GetCharacter(uint unicode)
    {
        return this.Content.Glyphs.Find((c) => c.Unicode == unicode);
    }
}