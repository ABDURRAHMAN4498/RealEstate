namespace RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
/*
 * [PropertyAmenitiesId]
      ,[PropertyId]
      ,[AmenityId]
      ,[Status]
 */
public class ResultPropertyAmenityByStatusTrueDto
{
    public int PropertyAmenityId  { get; set; }
    // public int PropertyId  { get; set; }
    // public int AmenityId  { get; set; }
    // public int Status  { get; set; }
    public string Title { get; set; }
}