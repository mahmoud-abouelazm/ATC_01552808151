namespace EventManagmentAPI.Models
{
    public class StaticInfo
    {
        public static string AuthAPIBase {  get; set; }
        public enum ApiType{
            Get, Post,Delete,PUT
        }
    }
}
