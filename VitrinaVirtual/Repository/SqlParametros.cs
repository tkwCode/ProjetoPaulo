namespace VitrinaVirtual
{
    /// <summary>
    /// Classe responsável pela criação de parâmetros.
    /// </summary>
    public class SqlParametros
    {
        /// <summary>
        /// O nome do parâmetro a inserrir.
        /// </summary>
        public string Parametro { get; set; }

        /// <summary>
        /// O valor do parâmetro.
        /// </summary>
        public object Valor { get; set; }
    }
}
