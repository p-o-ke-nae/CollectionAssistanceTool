using CollectionAssistanceTool.Core.Entities;
using CollectionAssistanceTool.Infrastructure.Repositories;
using System.Collections.Generic;

namespace CollectionAssistanceTool.API.Services.impl
{
    /// <summary>
    /// IColumnService�̎����N���X
    /// </summary>
    public class ColumnService : IColumnService
    {
        private readonly IColumnRepository _columnRepository;

        public ColumnService(IColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }

        /// <summary>
        /// �񍀖ڂ��擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>�񍀖ڂ̃��X�g</returns>
        public IEnumerable<CATColumn> GetColumns(string sheetId)
        {
            return _columnRepository.GetColumns(sheetId);
        }

        /// <summary>
        /// �񍀖ڂ�ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�ǉ�����񍀖�</param>
        public void AddColumn(string sheetId, CATColumn column)
        {
            _columnRepository.AddColumn(sheetId, column);
        }

        /// <summary>
        /// �񍀖ڂ��X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�X�V����񍀖�</param>
        public void UpdateColumn(string sheetId, CATColumn column)
        {
            _columnRepository.UpdateColumn(sheetId, column);
        }

        /// <summary>
        /// �񍀖ڂ��폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜����񍀖ڂ�ID</param>
        public void DeleteColumn(string sheetId, int id)
        {
            _columnRepository.DeleteColumn(sheetId, id);
        }
    }
}
