namespace Nancy.Siren.Demo
{
    public static class FormatterExtensions
    {
        public static Response AsCreatedResource(this IResponseFormatter formatter, int id)
        {
            return CreateResponse(formatter, id.ToString());
        }

        private static Response CreateResponse(IResponseFormatter formatter, string id)
        {
            var url = formatter.Context.Request.Url.ToString();
            var response = new Response {StatusCode = HttpStatusCode.Created, Headers = {{"Location", url + "/" + id}}};

            return response;
        }
    }
}