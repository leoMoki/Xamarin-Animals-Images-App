namespace ImagesApp.Services.Config
{
    public class ApiConfigCats : APIConfig
    {
        public ApiConfigCats(string Params = null)
        {
            BaseAdress = "https://api.thecatapi.com/v1/";
            Url = "images/search?";
            ContentType = "application/json";
            ApiKey = "ab5ffdb3-b8f2-4159-9706-990ccc46b1b3";
        }
    }
}
