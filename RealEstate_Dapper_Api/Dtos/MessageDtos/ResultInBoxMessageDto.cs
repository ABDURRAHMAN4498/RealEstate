using System.Security.Principal;

namespace RealEstate_Dapper_Api.Dtos.MessageDtos
{
    public class ResultInBoxMessageDto
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string UserImageUrl { get; set; }

    }
    /*
     SELECT TOP (1000) [MessageId]
      ,[Sender]
      ,[Receiver]
      ,[Subject]
      ,[Detail]
      ,[SendDate]
      ,[IsRead]
  FROM [DbDapperRealEstat].[dbo].[Message]
     */
}
