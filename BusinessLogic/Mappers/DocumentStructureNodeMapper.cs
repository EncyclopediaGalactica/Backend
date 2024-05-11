namespace EncyclopediaGalactica.BusinessLogic.Mappers;

using Contracts;
using Entities;

/// <inheritdoc />
public partial class DocumentStructureNodeMapper : IDocumentStructureNodeMapper
{
    /// <inheritdoc />
    public DocumentStructureNode MapStructureNodeInputToStructureNode(DocumentStructureNodeInput structureNodeInput)
    {
        return new DocumentStructureNode
        {
            Id = structureNodeInput.Id,
            DocumentId = structureNodeInput.DocumentId,
            IsRootNode = structureNodeInput.IsRootNode
        };
    }

    /// <inheritdoc />
    public DocumentStructureNodeInput MapStructureNodeToStructureNodeResult(DocumentStructureNode s)
    {
        return new DocumentStructureNodeInput()
        {
            Id = s.Id,
            DocumentId = s.DocumentId,
        };
    }
}