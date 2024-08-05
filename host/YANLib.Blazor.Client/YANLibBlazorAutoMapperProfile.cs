using AutoMapper;

namespace YANLib.Blazor.Client;

public class YANLibBlazorAutoMapperProfile : Profile
{
    public YANLibBlazorAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();

        //Define your AutoMapper configuration here for the Blazor project.
    }
}