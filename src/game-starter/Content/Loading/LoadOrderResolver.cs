using System.Collections.Generic;
using Symphony;
using QuikGraph;
using System.Linq;
using System.Text.Json;
using QuikGraph.Algorithms.TopologicalSort;

namespace GameStarter.Content.Loading;

public class LoadOrderResolver
{
    private List<IContentSource> _sources;
    private IContentLoader<ContentMeta> _loader;

    public LoadOrderResolver(IContentLoader<ContentMeta> loader, IEnumerable<IContentSource> sources)
    {
        _sources = sources.ToList();
        _loader = loader;
    }

    public IEnumerable<IContentSource> GetSourceLoadOrder()
    {
        var dependencyGraph = new QuikGraph.AdjacencyGraph<IContentSource, QuikGraph.Edge<IContentSource>>();

        // Add all sources to the graph
        foreach (var source in _sources)
        {
            dependencyGraph.AddVertex(source);
        }

        var getSourceFromName = (string name) => _sources.FirstOrDefault((source) => this._loader.GetIdentifierForSource(source) == name);

        foreach (var source in _sources)
        {
            using (var structure = source.GetStructure())
            {
                using (var metaFile = structure.GetEntryStream("meta.json", out var entry))
                {
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var meta = JsonSerializer.Deserialize<ContentMeta>(metaFile, options);

                    foreach (var dependency in meta.Dependencies)
                    {
                        if (getSourceFromName(dependency) is null)
                        {
                            // Missing dependency, cannot resolve load order
                            throw new System.Exception($"Missing dependency {dependency} for {this._loader.GetIdentifierForSource(source)}");
                        }

                        dependencyGraph.AddEdge(new QuikGraph.Edge<IContentSource>(source, getSourceFromName(dependency)));
                    }
                }
            }
        }

        var algo = new TopologicalSortAlgorithm<IContentSource, QuikGraph.Edge<IContentSource>>(dependencyGraph);

        algo.Compute();

        return algo.SortedVertices.Reverse();
    }
}