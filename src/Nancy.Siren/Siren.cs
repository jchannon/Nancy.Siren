namespace Nancy.Siren
{
    using System.Collections.Generic;

    public class Siren
    {
        public string[] @class { get; set; }
        public dynamic properties { get; set; }
        public List<Entity> entities { get; set; }
        public List<Action> actions { get; set; }
        public List<Link> links { get; set; }
    }

    public class Entity
    {
        public string[] @class { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public dynamic properties { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Action
    {
        public string name { get; set; }
        public string title { get; set; }
        public string method { get; set; }
        public string href { get; set; }
        public string type { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }
}