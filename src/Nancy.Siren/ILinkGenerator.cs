namespace Nancy.Siren
{
    using System;

    public interface ILinkGenerator
    {
        bool CanHandle(Type model);

        Siren Handle(object model, Uri uri);
    }
}