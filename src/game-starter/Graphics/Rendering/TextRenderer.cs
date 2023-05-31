using System;
using System.Drawing;
using System.Numerics;
using static DotGL.GL;

namespace GameStarter.Graphics.Rendering;

public static class TextRenderer
{
    private static uint quadVAO;
    private static uint quadVBO;

    private static float[] GetUVCoordinateData(int textureWith, int textureHeight, RectangleF rec, TextureRenderEffects effects)
    {
        float sourceX = rec.X / textureWith;
        float sourceY = rec.Y / textureHeight;
        float sourceWidth = rec.Width / textureWith;
        float sourceHeight = rec.Height / textureHeight;

        float[] data = { 
            // tex
            sourceX, sourceY + sourceHeight, //downLeft
            sourceX + sourceWidth, sourceY, //topRight
            sourceX, sourceY, //topLeft

            sourceX, sourceY + sourceHeight, //downLeft
            sourceX + sourceWidth, sourceY + sourceHeight, //downRight
            sourceX + sourceWidth, sourceY  //topRight
        };

        if (effects.HasFlag(TextureRenderEffects.FlipHorizontal) && effects.HasFlag(TextureRenderEffects.FlipVertical))
        {
            data = new float[] {
                sourceX + sourceWidth, sourceY, // topRight
                sourceX, sourceY + sourceHeight, // downLeft
                sourceX + sourceWidth, sourceY + sourceHeight, // downRight

                sourceX + sourceWidth, sourceY, // topRight
                sourceX, sourceY, // topLeft
                sourceX, sourceY + sourceHeight, // downLeft
            };
        }
        else if (effects.HasFlag(TextureRenderEffects.FlipHorizontal))
        {
            data = new float[] {
                sourceX + sourceWidth, sourceY + sourceHeight, // downRight
                sourceX, sourceY, // topLeft
                sourceX + sourceWidth, sourceY, // topRight

                sourceX + sourceWidth, sourceY + sourceHeight, // downRight
                sourceX, sourceY + sourceHeight, // downLeft
                sourceX, sourceY, // topLeft
            };
        }
        else if (effects.HasFlag(TextureRenderEffects.FlipVertical))
        {
            data = new float[] {
                sourceX, sourceY, // topLeft
                sourceX + sourceWidth, sourceY + sourceHeight, // downRight
                sourceX, sourceY + sourceHeight, // downLeft

                sourceX, sourceY, // topLeft
                sourceX + sourceWidth, sourceY, // topRight
                sourceX + sourceWidth, sourceY + sourceHeight, // downRight
            };
        }

        return data;
    }

    public static void RenderText(Font font, string text, Vector2 position, Vector2 scale, float rotation, ColorF color, Camera2D camera)
    {
        RenderText(font, text, position, scale, rotation, (c, i) => color, camera);
    }

    public static void RenderText(Font font, string text, Vector2 position, Vector2 scale, float rotation, Func<char, int, ColorF> charColor, Camera2D camera)
    {
        RenderText(font, text, position, scale, rotation, (c, i) => Vector2.Zero, charColor, camera);
    }

    public static void RenderText(Font font, string text, Vector2 position, Vector2 scale, float rotation, Func<char, int, Vector2> charOffset, Func<char, int, ColorF> charColor, Camera2D camera)
    {
        var measure = font.MeasureString(text);
        var scaledMeasure = measure * scale;

        float x = position.X;
        float y = position.Y + measure.Y * scale.Y;

        var texture = font.TextureAtlas;
        var shader = MainGame.ContentManager.GetContentItem<ShaderProgram>("resources:core/shaders/msdf.shader");

        for (int i = 0; i < text.Length; i++)
        {
            var c = text[i];
            var glyph = font.GetCharacter(c);

            if (glyph.AtlasBounds is null)
            {
                x += glyph.Advance * font.Content.Atlas.Size * scale.X;
                continue;
            }

            var planeBounds = glyph.PlaneBounds;
            var atlasBounds = glyph.AtlasBounds;

            var offset = charOffset(c, i);
            float x0 = x + (planeBounds.Left * font.Content.Atlas.Size * scale.X + offset.X);
            float y0 = y - (planeBounds.Top * font.Content.Atlas.Size * scale.Y + offset.Y);

            var uv = glyph.AtlasBounds.ToUVRect(texture.Size);

            Vector2 pos = new Vector2(x0, y0);
            pos = pos.RotateAround(position, -rotation);
            ColorF bgColor = ColorF.Transparent;
            ColorF fgColor = charColor(c, i);
            RectangleF sourceRectangle = uv;
            TextureRenderEffects effects = TextureRenderEffects.None;

            shader.Use(() =>
            {
                Matrix4x4 modelMatrix = Utilities.CreateModelMatrixFromPosition(pos, rotation, Vector2.Zero, scale * new Vector2(sourceRectangle.Width, sourceRectangle.Height));

                shader.SetMatrix4x4("projection", camera.GetProjectionMatrix());
                shader.SetVec4("bgColor", bgColor.R, bgColor.G, bgColor.B, bgColor.A);
                shader.SetVec4("fgColor", fgColor.R, fgColor.G, fgColor.B, fgColor.A);
                shader.SetInt("msdf", 0);
                shader.SetFloatArray("uvCoords", GetUVCoordinateData(texture.Width, texture.Height, sourceRectangle, effects));
                shader.SetMatrix4x4("model", modelMatrix);
                shader.SetFloat("pxRange", font.Content.Atlas.DistanceRange);

                glActiveTexture(GL_TEXTURE0);
                glBindTexture(GL_TEXTURE_2D, texture.GLID);

                glBindVertexArray(quadVAO);
                glDrawArrays(GL_TRIANGLES, 0, 6);
                glBindVertexArray(0);
            });

            x += glyph.Advance * font.Content.Atlas.Size * scale.X;
        }
    }

    public static unsafe void InitGL()
    {
        // Configure VAO, VBO
        quadVAO = glGenVertexArray(); // Created vertex array object
        glBindVertexArray(quadVAO);

        quadVBO = glGenBuffer();

        float[] vertices = { 
            // pos     
            0.0f, 1.0f, // down left
            1.0f, 0.0f, // top right
            0.0f, 0.0f, // top left

            0.0f, 1.0f, // down left
            1.0f, 1.0f, // down right
            1.0f, 0.0f, // top right
        };

        glBindBuffer(GL_ARRAY_BUFFER, quadVBO);

        fixed (float* v = &vertices[0])
        {
            glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
        }

        glEnableVertexAttribArray(0);
        glVertexAttribPointer(0, 2, GL_FLOAT, false, 2 * sizeof(float), (void*)0);

        glBindBuffer(GL_ARRAY_BUFFER, 0);
        glBindVertexArray(0);
    }
}