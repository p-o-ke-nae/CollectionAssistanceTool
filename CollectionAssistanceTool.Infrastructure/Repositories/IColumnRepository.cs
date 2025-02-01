using CollectionAssistanceTool.Core.Entities;

namespace CollectionAssistanceTool.Infrastructure.Repositories
{
    /// <summary>
    /// �񍀖ڂ̃��|�W�g���C���^�[�t�F�[�X
    /// </summary>
    public interface IColumnRepository
    {
        /// <summary>
        /// �񍀖ڂ��擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>�񍀖ڂ̃��X�g</returns>
        IEnumerable<CATColumn> GetColumns(string sheetId);

        /// <summary>
        /// �񍀖ڂ�ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�ǉ�����񍀖�</param>
        void AddColumn(string sheetId, CATColumn column);

        /// <summary>
        /// �񍀖ڂ��X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�X�V����񍀖�</param>
        void UpdateColumn(string sheetId, CATColumn column);

        /// <summary>
        /// �񍀖ڂ��폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜����񍀖ڂ�ID</param>
        void DeleteColumn(string sheetId, int id);
    }
}
