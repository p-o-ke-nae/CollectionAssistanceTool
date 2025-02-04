using System.Text.Json.Serialization;

namespace CollectionAssistanceTool.Core.Entities
{
    /// <summary>
    /// �񍀖ڂ�\���G���e�B�e�B
    /// </summary>
    public class CATColumn
    {
        /// <summary>
        /// �񍀖ڂ�ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// �\������w�b�_��
        /// </summary>
        [JsonPropertyName("headerName")]
        public string HeaderName { get; set; }

        /// <summary>
        /// �\����
        /// </summary>
        [JsonPropertyName("width")]
        public string Width { get; set; }

        /// <summary>
        /// ���\�����邩��\���ɂ��邩
        /// </summary>
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }
    }
}

