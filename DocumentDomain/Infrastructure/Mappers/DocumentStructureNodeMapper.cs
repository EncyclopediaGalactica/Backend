#region

using DocumentDomain.Contracts;
using EncyclopediaGalactica.BusinessLogic.Entities;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Mappers;

/// <inheritdoc />
public class DocumentStructureNodeMapper : IDocumentStructureNodeMapper
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