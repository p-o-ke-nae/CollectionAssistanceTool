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
        public int Id { get; set; }

        /// <summary>
        /// �\������w�b�_��
        /// </summary>
        public string HeaderName { get; set; }

        /// <summary>
        /// �\����
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// ���\�����邩��\���ɂ��邩
        /// </summary>
        public bool IsVisible { get; set; }
    }
}

