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
        public int Width { get; set; }

        /// <summary>
        /// 列を表示するか非表示にするか
        /// </summary>
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// 編集可否
        /// </summary>
        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        /// <summary>
        /// 表示する情報のタイプ（文字、画像など）
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// ヘッダの表示の有無
        /// </summary>
        [JsonPropertyName("isShowHeader")]
        public bool IsShowHeader { get; set; }

        /// <summary>
        /// 個別の設定を格納するプロパティ
        /// </summary>
        [JsonPropertyName("settings")]
        public Dictionary<string, string> Settings { get; set; }
    }
}

