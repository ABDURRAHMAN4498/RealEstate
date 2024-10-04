namespace RealEstate_Dapper_Api.Dtos.TestimonialDtos
{
    public class GetByIdTestimonialDto
    {
        public int TesimonialId { get; set; }
        public string  NameSurname { get; set; }
        public string  Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}