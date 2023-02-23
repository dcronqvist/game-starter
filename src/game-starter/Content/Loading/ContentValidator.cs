using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using GameStarter.Content;
using Symphony;

namespace GameStarter.Content.Loading;

public class ContentValidator : IContentStructureValidator<ContentMeta>
{
    private string[] _blacklist;

    public ContentValidator(params string[] blacklist)
    {
        _blacklist = blacklist;
    }

    public bool TryValidateStructure(IContentStructure structure, [NotNullWhen(true)] out ContentMeta metadata, [NotNullWhen(false)] out string error)
    {
        try
        {
            if (!structure.HasEntry("meta.json"))
            {
                error = "No meta.json found";
                metadata = null;
                return false;
            }

            using (var stream = structure.GetEntryStream("meta.json", out var entry))
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                metadata = JsonSerializer.Deserialize<ContentMeta>(stream, options);

                if (this._blacklist.Contains(metadata.Name))
                {
                    error = "Blacklisted";
                    metadata = null;
                    return false;
                }

                error = null;
                return true;
            }
        }
        catch (System.Exception e)
        {
            error = e.Message;
            metadata = null;
            return false;
        }
    }
}