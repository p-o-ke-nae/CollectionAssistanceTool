using CollectionAssistanceTool.Core.Entities;
using CollectionAssistanceTool.Infrastructure.Repositories;
using CollectionAssistanceTool;
using System.Collections.Generic;

namespace CollectionAssistanceTool.API.Services.impl
{
    /// <summary>
    /// IRecordService�̎����N���X
    /// </summary>
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        /// <summary>
        /// ���R�[�h���擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>���R�[�h�̃��X�g</returns>
        public IEnumerable<CATRecord> GetRecords(string sheetId)
        {
            return _recordRepository.GetRecords(sheetId);
        }

        /// <summary>
        /// ���R�[�h��ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�ǉ����郌�R�[�h</param>
        public void AddRecord(string sheetId, CATRecord record)
        {
            _recordRepository.AddRecord(sheetId, record);
        }

        /// <summary>
        /// ���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�X�V���郌�R�[�h</param>
        public void UpdateRecord(string sheetId, CATRecord record)
        {
            _recordRepository.UpdateRecord(sheetId, record);
        }

        /// <summary>
        /// ���R�[�h���폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜���郌�R�[�h��ID</param>
        public void DeleteRecord(string sheetId, int id)
        {
            _recordRepository.DeleteRecord(sheetId, id);
        }
    }
}
