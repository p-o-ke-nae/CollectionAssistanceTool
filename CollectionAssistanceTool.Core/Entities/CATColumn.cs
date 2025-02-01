namespace CollectionAssistanceTool.Core.Entities
{
    /// <summary>
    /// 列項目を表すエンティティ
    /// </summary>
    public class CATColumn
    {
        /// <summary>
        /// 列項目のID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 表示するヘッダ名
        /// </summary>
        public string HeaderName { get; set; }

        /// <summary>
        /// 表示幅
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 列を表示するか非表示にするか
        /// </summary>
        public bool IsVisible { get; set; }
    }
}

