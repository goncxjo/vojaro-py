namespace vojaro.core.Entities
{
    public partial class CarreraOrientacion
    {
        public long Id { get; set; }
        public long? CarreraId { get; set; }
        public string Nombre { get; set; }

        public virtual Carrera Carrera { get; set; }
    }
}
