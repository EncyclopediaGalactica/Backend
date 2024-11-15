namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;
using Entity;

/// <inheritdoc />
public class DocumentStructureNodeMapper : IDocumentStructureNodeMapper
{
    /// <inheritdoc />
    public DocumentStructureNode MapStructureNodeInputToStructureNode(DocumentStructureNodeInput structureNodeInput) =>
        new()
        {
            Id         = structureNodeInput.Id,
            DocumentId = structureNodeInput.DocumentId,
            IsRootNode = structureNodeInput.IsRootNode,
        };

    /// <inheritdoc />
    public DocumentStructureNodeInput MapStructureNodeToStructureNodeResult(DocumentStructureNode s) =>
        new()
        {
            Id         = s.Id,
            DocumentId = s.DocumentId,
        };
}