using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using GameStarter.Content.Loading;
using GameStarter.Graphics;
using Symphony;

namespace GameStarter.Content.Loaders;

public class ShaderProgramLoader : IContentItemLoader
{
    public async IAsyncEnumerable<LoadEntryResult> TryLoadAsync(IContentSource source, IContentStructure structure, string pathToItem)
    {
        var fileName = Path.GetFileNameWithoutExtension(pathToItem);
        using (var stream = structure.GetEntryStream(pathToItem, out var entry))
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var json = sr.ReadToEnd();

                string vertexShaderSource = Utilities.GetSubstringBetweenDividers(json, "#VERTEX_BEGIN", "#VERTEX_END");
                string fragmentShaderSource = Utilities.GetSubstringBetweenDividers(json, "#FRAGMENT_BEGIN", "#FRAGMENT_END");

                var sp = new ShaderProgram(source, new ShaderProgramDescription() { VertexShader = vertexShaderSource, FragmentShader = fragmentShaderSource });
                yield return await LoadEntryResult.CreateSuccessAsync(pathToItem, sp);
            }
        }
    }
}