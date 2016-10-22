namespace Nancy.Siren
{
    using System;
    using System.IO;
    using Nancy.Configuration;
    using Nancy.Json;
    using System.Collections.Generic;

    public class SirenResponse : Response
    {
        private readonly ISerializer serializer;

        private readonly NancyContext context;

        private readonly IEnumerable<ILinkGenerator> linkGenerators;

        public SirenResponse(object model, ISerializer serializer, IEnumerable<ILinkGenerator> linkGenerators, NancyContext context)
        {
            this.context = context;
            if (serializer == null)
            {
                throw new InvalidOperationException("JSON Serializer not set");
            }

            this.linkGenerators = linkGenerators;
            this.serializer = serializer;
            this.Contents = model == null ? NoBody : GetSirenContents(model);
            this.ContentType = "application/vnd.siren+json"; 
            this.StatusCode = HttpStatusCode.OK;
        }

        private string DefaultContentType => string.Concat("application/json", Encoding);

        private string Encoding => string.Concat("; charset=",
            this.context.Environment.GetValue<JsonConfiguration>().DefaultEncoding.WebName);

        private Action<Stream> GetSirenContents(object model)
        {
            object viewmodel = null;
            foreach (var item in this.linkGenerators)
            {
                if (item.CanHandle(model.GetType()))
                {
                    viewmodel = item.Handle(model, this.context.Request.Url);
                    break;
                }
            }

            return stream => serializer.Serialize(DefaultContentType, viewmodel, stream);
        }
    }

}

