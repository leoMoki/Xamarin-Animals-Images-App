namespace ImagesApp.Services.Config
{
    public class APIConfig
    {
        public string BaseAdress { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public string ApiKey { get; set; }
        public Params Params { get; set; }

        /// <summary>
        /// Método para montar a string url com parametros
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetUrlParams(Params p)
        {
            string result = string.Empty;

            if (p != null)
            {

                if (!string.IsNullOrEmpty(p.Size))
                    result = result + "size=" + p.Size + "&";

                if (!string.IsNullOrEmpty(p.MimeType))
                    result = result + "mime_types=" + p.MimeType + "&";

                if (!string.IsNullOrEmpty(p.Format))
                    result = result + "format=" + p.Format + "&";
                
                if (p.HasBreeds)
                    result = result + "has_breeds=1" + "&";



                if (!string.IsNullOrEmpty(p.Order))
                    result = result + "order=" + p.Order + "&";

                if (p.Page != null)
                    result = result + "page=" + p.Page + "&";

                if (p.Limit != null)
                    result = result + "limit=" + p.Limit + "&";


                //Retirando o último caracter &
                result = result.Remove(result.LastIndexOf("&"));
            }

            return result;
        }
    }
}
