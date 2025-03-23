using System.Security.Cryptography;

namespace RealEstate_Dapper_UI.Dtos.ProductDetailDtos;

public class GetProductDetailByIdDto
{
    public int productDetailId { get; set; }
    public int badRoomCount { get; set; }
    public int bathRoomCount { get; set; }
    public int roomCount { get; set; }
    public int garagSize { get; set; }
    public string buildYear { get; set; }
    public decimal price { get; set; }
    public string location { get; set; }
    public string videoUrl { get; set; }
    public int productId { get; set; }
    public int ProductSize { get; set; }
    
}