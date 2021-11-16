namespace TechApi.DTO.Util
{
    public class ResponseResultDTO
    {
        public bool Success { get; set; } = false;
        public string ErrorMsg { get; set; } = "";
        public dynamic Data { get; set; }
    }
}