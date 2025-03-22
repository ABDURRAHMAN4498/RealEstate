namespace  RealEstate_Dapper_Api.Dtos.ProductDetailDtos
{
    /*
    [ProductDetailId]
      ,[ProductSize]
      ,[BadRoomCount]
      ,[BathRoomCount]
      ,[RoomCount]
      ,[GaragSize]
      ,[BuildYear]
      ,[Price]
      ,[Location]
      ,[VideoUrl]
      ,[ProductId]
    
    */
    public class GetProductDetailDto
    {
        public int ProductDetailId { get; set; }
        public int BadRoomCount { get; set; }
        public int BathRoomCount { get; set; }
        public int RoomCount { get; set; }
        public int GaragSize { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public int ProductId { get; set; }
    }
}