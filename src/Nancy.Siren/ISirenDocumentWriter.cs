namespace Nancy.Siren
{
    using System;
    using System.Collections.Generic;

    public interface ISirenDocumentWriter<TItem>
    {
        Siren Write(IEnumerable<TItem> data, Uri uri);
        Siren Write(TItem data, Uri uri);
    }
}
