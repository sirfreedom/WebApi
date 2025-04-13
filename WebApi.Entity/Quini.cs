using System;


namespace WebApi.Entity
{
    [Serializable]
    public class Quini : EntityBase
    {
        public string N1 { get; set; } = string.Empty;

        public string N2 { get; set; } = string.Empty;

        public string N3 { get; set; } = string.Empty;

        public string N4 { get; set; } = string.Empty;

        public string N5 { get; set; } = string.Empty;

        public string N6 { get; set; } = string.Empty;

        public string Fecha { get; set; } = string.Empty;

        public Byte DD { get; set; } = 0;
        public Byte MM { get; set; } = 0;
        public int YYYY { get; set; } = 0;


    }
}
