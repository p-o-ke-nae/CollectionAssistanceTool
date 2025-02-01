namespace CollectionAssistanceTool.Core.Entities
{
    /// <summary>
    /// レコードを表すエンティティ
    /// </summary>
    public class CATRecord
    {
        /// <summary>
        /// レコードのID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// レコードのデータ
        /// </summary>
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}

