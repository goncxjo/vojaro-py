namespace vojaro.core.Entities
{
    public partial class AsignaturaCorrelativa
    {
        public long AsignaturaId { get; set; }
        public long CorrelativaId { get; set; }
        public bool Regularizada { get; set; }
        public bool Aprobada { get; set; }

        public virtual Asignatura Asignatura { get; set; }
        public virtual Asignatura Correlativa { get; set; }
    }
}
