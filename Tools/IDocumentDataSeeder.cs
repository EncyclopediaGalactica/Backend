#region

using DocumentDomain.Contracts;

#endregion

namespace EncyclopediaGalactica.Tools;

public interface IDocumentDataSeeder
{
    Task SeedDocuments(int amount);

    Task<DocumentResult> SeedDocument();
}