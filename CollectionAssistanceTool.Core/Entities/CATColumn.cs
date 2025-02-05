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
        public int Width { get; set; }

        /// <summary>
        /// ���\�����邩��\���ɂ��邩
        /// </summary>
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// �ҏW��
        /// </summary>
        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        /// <summary>
        /// �\��������̃^�C�v�i�����A�摜�Ȃǁj
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// �w�b�_�̕\���̗L��
        /// </summary>
        [JsonPropertyName("isShowHeader")]
        public bool IsShowHeader { get; set; }

        /// <summary>
        /// �ʂ̐ݒ���i�[����v���p�e�B
        /// </summary>
        [JsonPropertyName("settings")]
        public Dictionary<string, string> Settings { get; set; }
    }
}

