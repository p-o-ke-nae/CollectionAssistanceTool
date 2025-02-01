using CollectionAssistanceTool.Core.Entities;

namespace CollectionAssistanceTool.Infrastructure.Repositories
{
    /// <summary>
    /// ���R�[�h�̃��|�W�g���C���^�[�t�F�[�X
    /// </summary>
    public interface IRecordRepository
    {
        /// <summary>
        /// ���R�[�h���擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>���R�[�h�̃��X�g</returns>
        IEnumerable<CATRecord> GetRecords(string sheetId);

        /// <summary>
        /// ���R�[�h��ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�ǉ����郌�R�[�h</param>
        void AddRecord(string sheetId, CATRecord record);

        /// <summary>
        /// ���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�X�V���郌�R�[�h</param>
        void UpdateRecord(string sheetId, CATRecord record);

        /// <summary>
        /// ���R�[�h���폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜���郌�R�[�h��ID</param>
        void DeleteRecord(string sheetId, int id);
    }
}
