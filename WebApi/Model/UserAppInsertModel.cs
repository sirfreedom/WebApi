namespace WebApi.Model
{
    public class UserAppInsertModel
    {
        public int idtypeuserapp { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string pass { get; set; }
        public string username { get; set; }
        public string descriptiontext { get; set; }
        public string provincia { get; set; }
        public string calle { get; set; }
        public string logoimgtext { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public decimal latitud { get; set; }
        public double longitud { get; set; }
    }
}
