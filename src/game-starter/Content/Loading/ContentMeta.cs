using Symphony;

namespace GameStarter.Content.Loading;

public class ContentMeta : ContentMetadata
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Contact { get; set; }
    public string Description { get; set; }
    public string Homepage { get; set; }
    public string[] Dependencies { get; set; }
}