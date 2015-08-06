namespace Nancy.Siren
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy.Responses.Negotiation;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;


    public class SirenResponseProcessor : IResponseProcessor
    {
        private static readonly IEnumerable<Tuple<string, MediaRange>> extensionMappings =
            new[] { new Tuple<string, MediaRange>("json", new MediaRange("application/vnd.siren+json")) };

        private readonly ISerializer serializer;

        private readonly IEnumerable<ILinkGenerator> linkGenerators;

        public SirenResponseProcessor(IEnumerable<ISerializer> serializers, IEnumerable<ILinkGenerator> linkGenerators)
        {
            this.linkGenerators = linkGenerators;
            this.serializer = serializers.FirstOrDefault(x => x.CanSerialize("application/json"));
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            if (IsExactSirenContentType(requestedMediaRange))
            {
                return new ProcessorMatch
                {
                    ModelResult = MatchResult.DontCare,
                    RequestedContentTypeResult = MatchResult.ExactMatch
                };
            }

            if (IsWildcardSirenContentType(requestedMediaRange))
            {
                return new ProcessorMatch
                {
                    ModelResult = MatchResult.DontCare,
                    RequestedContentTypeResult = MatchResult.NonExactMatch
                };
            }

            return new ProcessorMatch
            {
                ModelResult = MatchResult.DontCare,
                RequestedContentTypeResult = MatchResult.NoMatch
            };
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new SirenResponse(model, this.serializer, this.linkGenerators, context);
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get
            {
                return extensionMappings;
            }
        }

        private static bool IsExactSirenContentType(MediaRange requestedContentType)
        {
            if (requestedContentType.Type.IsWildcard && requestedContentType.Subtype.IsWildcard)
            {
                return true;
            }

            return requestedContentType.Matches("application/vnd.siren+json");
        }

        private static bool IsWildcardSirenContentType(MediaRange requestedContentType)
        {
            if (!requestedContentType.Type.IsWildcard && !string.Equals("application", requestedContentType.Type, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (requestedContentType.Subtype.IsWildcard)
            {
                return true;
            }

            var subtypeString = requestedContentType.Subtype.ToString();

            return (subtypeString.StartsWith("vnd", StringComparison.OrdinalIgnoreCase) &&
            subtypeString.EndsWith("siren+json", StringComparison.OrdinalIgnoreCase));
        }
    }

}

