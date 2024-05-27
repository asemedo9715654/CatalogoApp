namespace CatalogoApp.Models
{
    public class TableInfo
    {
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public List<FieldInfo> Fields { get; set; }
    }
}
