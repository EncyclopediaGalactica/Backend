namespace EncyclopediaGalactica.DocumentDomain.Infrastructure.Mappers;

using BusinessLogic.Contracts;
using Entity;

public static class FiletypeMapper
{
    public static Filetype MapToFiletypeEntity(this FiletypeInput filetypeInput)
    {
        return new Filetype
        {
            Id = filetypeInput.Id,
            Name = filetypeInput.Name,
            Description = filetypeInput.Description,
            FileExtension = filetypeInput.FileExtension
        };
    }

    public static FiletypeResult MapToFiletypeResult(this Filetype filetype)
    {
        return new FiletypeResult
        {
            Id = filetype.Id,
            Name = filetype.Name,
            Description = filetype.Description,
            FileExtension = filetype.FileExtension
        };
    }
}