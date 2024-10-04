using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TesimonialRepository
{
    public class TesimonialRepository : ITesimonialRepository
    {
        private readonly Context _context;

        public TesimonialRepository(Context context)
        {
            _context = context;
        }

        public void CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTestimonial(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultTestimonialDto>> GatAllTestimonialAsync()
        {
            string query = "select * from Testimonial";
            using(var connection = _context.CreaConnection()){
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdTestimonialDto> GetTestimonial(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTestimonial(UpdateTesimonialDto updateTesimonialDto)
        {
            throw new NotImplementedException();
        }
    }
}