namespace CollectionAssistanceTool.Core.Entities
{
    /// <summary>
    /// ���R�[�h��\���G���e�B�e�B
    /// </summary>
    public class CATRecord
    {
        /// <summary>
        /// ���R�[�h��ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ���R�[�h�̃f�[�^
        /// </summary>
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}

