using System;


namespace WebApi.Entity
{
    public class TestPropiedades1 : EntityBase
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public TestPropiedadesHija testPropiedadesHija { get; set; }



    }
}
