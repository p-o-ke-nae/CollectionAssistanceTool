using System.Text.Json.Serialization;

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
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 表示するヘッダ名
        /// </summary>
        [JsonPropertyName("headerName")]
        public string HeaderName { get; set; }

        /// <summary>
        /// 表示幅
        /// </summary>
        [JsonPropertyName("width")]
        public string Width { get; set; }

        /// <summary>
        /// 列を表示するか非表示にするか
        /// </summary>
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }
    }
}

