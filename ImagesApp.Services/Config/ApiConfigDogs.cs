namespace ImagesApp.Services.Config
{
    public class ApiConfigDogs : APIConfig
    {
        public ApiConfigDogs(string Params = null)
        {
            BaseAdress = "https://api.thedogapi.com/v1/";
            Url = "images/search?";
            ContentType = "application/json";
            ApiKey = "088ca1c7-cd9e-4f7f-aacf-0e2edf5993c5";
        }
    }
}
