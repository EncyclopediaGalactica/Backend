namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;

using Entity;

public static class FiletypeMapper
{
    public static Filetype MapToFiletypeEntity(this FiletypeInput filetypeInput) =>
        new()
        {
            Id            = filetypeInput.Id,
            Name          = filetypeInput.Name,
            Description   = filetypeInput.Description,
            FileExtension = filetypeInput.FileExtension,
        };

    public static FiletypeResult MapToFiletypeResult(this Filetype filetype) =>
        new()
        {
            Id            = filetype.Id,
            Name          = filetype.Name,
            Description   = filetype.Description,
            FileExtension = filetype.FileExtension,
        };

    public static List<FiletypeResult> MapToFiletypeResultList(this List<Filetype> filetypes)
    {
        List<FiletypeResult> result = new();
        if (!filetypes.Any())
        {
            return result;
        }

        filetypes.ForEach(item => result.Add(new FiletypeResult
        {
            Id            = item.Id,
            Name          = item.Name,
            Description   = item.Description,
            FileExtension = item.FileExtension,
        }));
        return result;
    }
}