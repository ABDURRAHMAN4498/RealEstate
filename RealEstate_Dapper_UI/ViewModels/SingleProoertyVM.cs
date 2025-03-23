using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ProductImageDto;

namespace RealEstate_Dapper_UI.ViewModels;

public class SinglePropertyVM
{
    public ResultProductDto Product { get; set; }
    public GetProductDetailByIdDto ProductDetail { get; set; }
    public List<GetProductImageDto> ProductImage { get; set; }
    public  int Month { get; set; }
    public int Day { get; set; }
}