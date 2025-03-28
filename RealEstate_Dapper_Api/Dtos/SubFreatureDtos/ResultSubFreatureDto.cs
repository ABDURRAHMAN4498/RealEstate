namespace RealEstate_Dapper_Api.Dtos.SubFreatureDtos
{
    public class ResultSubFreatureDto
    {
        /*
        SubFeatureId, Icon, TopTitle, MainTitle, Description, SubTitle
        
        */
        public int SubFeatureId { get; set; }
        public string Icon { get; set; }
        public string TopTitle { get; set; }
        public string MainTitle { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
    }
}