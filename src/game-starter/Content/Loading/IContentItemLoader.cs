using System.Collections.Generic;
using Symphony;

namespace GameStarter.Content.Loading;

public interface IContentItemLoader
{
    IAsyncEnumerable<LoadEntryResult> TryLoadAsync(IContentSource source, IContentStructure structure, string pathToItem);
}