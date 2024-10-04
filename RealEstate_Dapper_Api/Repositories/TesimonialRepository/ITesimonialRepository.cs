using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TesimonialRepository
{
    public interface ITesimonialRepository
    {
        public Task<List<ResultTestimonialDto>> GatAllTestimonialAsync();
        void CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        void DeleteTestimonial(int id);
        void UpdateTestimonial(UpdateTesimonialDto updateTesimonialDto);
        Task<GetByIdTestimonialDto> GetTestimonial(int id);
    }
}