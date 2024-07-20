#region

#endregion

namespace EncyclopediaGalactica.Tools;

using DocumentDomain.Contracts;

public interface IDocumentDataSeeder
{
    Task SeedDocuments(int amount);

    Task<DocumentResult> SeedDocument();
}