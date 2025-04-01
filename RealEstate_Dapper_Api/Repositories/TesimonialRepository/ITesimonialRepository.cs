using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TesimonialRepository
{
    public interface ITesimonialRepository
    {
        public Task<List<ResultTestimonialDto>> GatAllTestimonialAsync();
        Task CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        Task DeleteTestimonial(int id);
        Task UpdateTestimonial(UpdateTesimonialDto updateTesimonialDto);
        Task<GetByIdTestimonialDto> GetTestimonial(int id);
    }
}