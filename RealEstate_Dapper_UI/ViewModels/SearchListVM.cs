using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_UI.ViewModels;

public class SearchListVM
{
    public List<ResultCategoryDto> Categories { get; set; }
    public List<string> Cities  { get; set; }
    
}