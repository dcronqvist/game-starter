using System;
using System.Drawing;
using System.Numerics;
using static GameStarter.Display.GL;

namespace GameStarter.Graphics.Rendering;

public static class PrimitiveRenderer
{
    // Which shader to be used
    public static bool WireFrameMode { get; set; } = false;


    // Rectangle
    private static uint recVAO;
    private static uint recVBO;

    // Circle
    private const int circlePoints = 35;
    private static uint circVAO;
    private static uint circVBO;

    public static void InitGL()
    {
        InitRectangleRenderData();
        InitCircleRenderData();
    }

    public static void ToggleWireframe()
    {
        WireFrameMode = !WireFrameMode;
    }

    public static unsafe void InitRectangleRenderData()
    {
        recVAO = glGenVertexArray();
        glBindVertexArray(recVAO);

        recVBO = glGenBuffer();
        glBindBuffer(GL_ARRAY_BUFFER, recVBO);

        float[] vertices = { 
                // pos      // color
                0.0f, 1.0f, 1.0f, 0.0f, 0.0f, 1.0f, //downLeft
                1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 1.0f, //topRight
                0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, //topLeft

                0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, //downLeft
                1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, //downRight
                1.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, //topRight
            };

        fixed (float* vert = &vertices[0])
        {
            glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, vert, GL_DYNAMIC_DRAW);
        }

        glEnableVertexAttribArray(0);
        glVertexAttribPointer(0, 2, GL_FLOAT, false, sizeof(float) * 6, (void*)0);

        glEnableVertexAttribArray(1);
        glVertexAttribPointer(1, 4, GL_FLOAT, false, sizeof(float) * 6, (void*)(sizeof(float) * 2));

        glBindBuffer(GL_ARRAY_BUFFER, 0);
        glBindVertexArray(0);
    }

    public static unsafe void RenderRectangle(ShaderProgram shader, RectangleF rectangle, ColorF color, Camera2D camera)
    {
        RenderRectangle(shader, rectangle, color, color, camera);
    }

    public static unsafe void RenderRectangle(ShaderProgram shader, RectangleF rectangle, ColorF left, ColorF right, Camera2D camera)
    {
        RenderRectangle(shader, rectangle, 0f, left, right, left, right, camera);
    }

    public static unsafe void RenderRectangle(ShaderProgram shader, RectangleF rectangle, ColorF color, float rotation, Camera2D camera)
    {
        RenderRectangle(shader, rectangle, rotation, color, color, color, color, camera);
    }

    public static unsafe void RenderRectangle(ShaderProgram shader, RectangleF rectangle, float rotation, ColorF colorTopLeft, ColorF colorTopRight, ColorF colorDownLeft, ColorF colorDownRight, Camera2D camera)
    {
        // Make sure correct shader is in use

        shader.Use(() =>
        {
            // Get all values needed for positioning and sizing
            float x = rectangle.X;
            float y = rectangle.Y;
            float width = rectangle.Width;
            float height = rectangle.Height;

            // Create matrices
            Matrix4x4 trans = Matrix4x4.CreateTranslation(rectangle.X, rectangle.Y, 0);
            Matrix4x4 scale = Matrix4x4.CreateScale(rectangle.Width, rectangle.Height, 0);
            Matrix4x4 rot = Matrix4x4.CreateRotationZ(rotation);
            shader.SetMatrix4x4("model", scale * rot * trans); // And apply to shader

            /*
            Matrix4x4 transPos = Matrix4x4.CreateTranslation(rectangle.X, rectangle.Y, 0);
            Matrix4x4 transMid = Matrix4x4.CreateTranslation(rectangle.X / 2f, rectangle.Y / 2f, 0);
            Matrix4x4 rot = Matrix4x4.CreateRotationZ(rotation);
            Matrix4x4 scale = Matrix4x4.CreateScale(rectangle.Width, rectangle.Height, 0);
            shader.SetMatrix4x4("model",  scale * transMid * transPos);
            */

            shader.SetMatrix4x4("projection", camera.GetProjectionMatrix());
            shader.SetBool("useFalloff", false);

            // Apply color to shader

            float[][] colors = new float[][]
            {
                new float[]{ colorDownLeft.R, colorDownLeft.G, colorDownLeft.B, colorDownLeft.A },
                new float[]{ colorTopRight.R, colorTopRight.G, colorTopRight.B, colorTopRight.A },
                new float[]{ colorTopLeft.R, colorTopLeft.G, colorTopLeft.B, colorTopLeft.A },
                new float[]{ colorDownRight.R, colorDownRight.G, colorDownRight.B, colorDownRight.A },
            };

            glBindBuffer(GL_ARRAY_BUFFER, recVBO);
            fixed (float* downLeft = &colors[0][0], topRight = &colors[1][0], topLeft = &colors[2][0], downRight = &colors[3][0])
            {
                glBufferSubData(GL_ARRAY_BUFFER, 2 * sizeof(float), sizeof(float) * 4, downLeft);
                glBufferSubData(GL_ARRAY_BUFFER, 8 * sizeof(float), sizeof(float) * 4, topRight);
                glBufferSubData(GL_ARRAY_BUFFER, 14 * sizeof(float), sizeof(float) * 4, topLeft);
                glBufferSubData(GL_ARRAY_BUFFER, 20 * sizeof(float), sizeof(float) * 4, downLeft);
                glBufferSubData(GL_ARRAY_BUFFER, 26 * sizeof(float), sizeof(float) * 4, downRight);
                glBufferSubData(GL_ARRAY_BUFFER, 32 * sizeof(float), sizeof(float) * 4, topRight);
            }
            glBindBuffer(GL_ARRAY_BUFFER, 0);

            // Check if should be wireframe
            if (WireFrameMode)
                glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);

            // Bind VAO, draw tris, then undbind
            glBindVertexArray(recVAO);
            glDrawArrays(GL_TRIANGLES, 0, 6);
            glBindVertexArray(0);

            // End check for wireframe
            if (WireFrameMode)
                glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
        });
    }

    public static unsafe void RenderLine(ShaderProgram shader, Vector2 start, Vector2 end, int width, ColorF color, Camera2D camera)
    {
        RenderLine(shader, start, end, width, color, color, camera);
    }

    public static unsafe void RenderLine(ShaderProgram shader, Vector2 start, Vector2 end, int width, ColorF startCol, ColorF endCol, Camera2D camera)
    {
        // We need a rectangle which is located at start.
        // Its width will be equal to the distance from start to end
        // Its height will be equal to width, but this might get strange - prefer 1
        // The rotation will be equal to the arctan of triangle

        // Calculate width (distance from start to end)
        float distance = (end - start).Length();

        // Height should be one, bu
        int height = width;

        // Rotation (angle from start to end)
        float xDist = (end.X - start.X);
        float yDist = (end.Y - start.Y);

        float rotation = MathF.Atan2(yDist, xDist);

        RectangleF rec = new RectangleF(start.X, start.Y, distance, height);

        RenderRectangle(shader, rec, rotation, startCol, endCol, startCol, endCol, camera);
    }

    public static unsafe void InitCircleRenderData()
    {
        Vector2[] points = GenerateCirclePoints(circlePoints);
        int numSamplePoints = points.Length;

        circVAO = glGenVertexArray();
        glBindVertexArray(circVAO);

        circVBO = glGenBuffer();
        glBindBuffer(GL_ARRAY_BUFFER, circVBO);

        // ADD BUFFER DATA

        float[] vertexData = new float[numSamplePoints * 6];

        for (int i = 0; i < numSamplePoints * 6; i += 6)
        {
            Vector2 point = points[i / 6];

            // Position
            vertexData[i] = point.X;
            vertexData[i + 1] = point.Y;

            // Colors
            vertexData[i + 2] = 1f;
            vertexData[i + 3] = 1f;
            vertexData[i + 4] = 1f;
            vertexData[i + 5] = 1f;
        }

        fixed (float* vert = &vertexData[0])
        {
            glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertexData.Length, vert, GL_DYNAMIC_DRAW);
        }

        glVertexAttribPointer(0, 2, GL_FLOAT, false, sizeof(float) * 6, (void*)0);
        glEnableVertexAttribArray(0);

        glVertexAttribPointer(1, 4, GL_FLOAT, false, sizeof(float) * 6, (void*)(sizeof(float) * 2));
        glEnableVertexAttribArray(1);

        glBindBuffer(GL_ARRAY_BUFFER, 0);
        glBindVertexArray(0);
    }

    private static Vector2[] GenerateCirclePoints(int numSamplePoints)
    {
        Vector2[] points = new Vector2[numSamplePoints];
        float samplePointStepSize = MathF.PI * 2f / numSamplePoints;
        float phi = 0f;

        for (int i = 0; i < numSamplePoints; i++)
        {
            float x = MathF.Cos(phi);
            float y = MathF.Sin(phi);

            phi += samplePointStepSize;

            points[i] = new Vector2(x, y);
        }

        return points;
    }

    private static ColorF[] CreateColorArray(ColorF color)
    {
        ColorF[] arr = new ColorF[circlePoints];
        for (int i = 0; i < circlePoints; i++)
        {
            arr[i] = color;
        }

        return arr;
    }

    public static unsafe void RenderCircle(ShaderProgram shader, Vector2 position, float radius, ColorF color, bool useFalloff, Camera2D camera)
    {
        RenderCircle(shader, position, radius, CreateColorArray(color), useFalloff, camera);
    }

    public static unsafe void RenderCircle(ShaderProgram shader, Vector2 position, float radius, ColorF[] colorPoints, bool useFalloff, Camera2D camera)
    {
        shader.Use(() =>
        {
            Matrix4x4 trans = Matrix4x4.CreateTranslation(position.X, position.Y, 0);
            Matrix4x4 scale = Matrix4x4.CreateScale(radius);

            shader.SetMatrix4x4("model", scale * trans);
            shader.SetMatrix4x4("projection", camera.GetProjectionMatrix());

            shader.SetBool("useFalloff", useFalloff);

            shader.SetVec2("middlePos", position.X, position.Y);
            shader.SetFloat("distToMid", radius);

            glBindBuffer(GL_ARRAY_BUFFER, circVBO);
            for (int i = 0; i < circlePoints; i++)
            {
                float[] colors = new float[] { colorPoints[i].R, colorPoints[i].G, colorPoints[i].B, colorPoints[i].A };

                fixed (float* col = &colors[0])
                {
                    glBufferSubData(GL_ARRAY_BUFFER, (i + 1) * sizeof(float) * 2 + i * sizeof(float) * 4, sizeof(float) * colors.Length, col);
                }
            }
            glBindBuffer(GL_ARRAY_BUFFER, 0);


            glBindVertexArray(circVAO);
            glDrawArrays(GL_TRIANGLE_FAN, 0, circlePoints);
            glBindVertexArray(0);
        });
    }
}