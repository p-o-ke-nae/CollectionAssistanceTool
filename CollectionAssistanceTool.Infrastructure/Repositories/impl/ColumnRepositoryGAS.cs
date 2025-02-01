using CollectionAssistanceTool.Core.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CollectionAssistanceTool.Infrastructure.Repositories.impl
{
    /// <summary>
    /// Google �X�v���b�h�V�[�g���g�p���� IColumnRepository �̎����N���X
    /// </summary>
    public class ColumnRepositoryGAS : IColumnRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ColumnRepositoryGAS(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// �񍀖ڂ��擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>�񍀖ڂ̃��X�g</returns>
        public IEnumerable<CATColumn> GetColumns(string sheetId)
        {
            var response = _httpClient.GetStringAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}").Result;
            var columns = JsonSerializer.Deserialize<List<CATColumn>>(response);
            return columns;
        }

        /// <summary>
        /// �񍀖ڂ�ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�ǉ�����񍀖�</param>
        public void AddColumn(string sheetId, CATColumn column)
        {
            var content = new StringContent(JsonSerializer.Serialize(column), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}", content).Wait();
        }

        /// <summary>
        /// �񍀖ڂ��X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�X�V����񍀖�</param>
        public void UpdateColumn(string sheetId, CATColumn column)
        {
            var content = new StringContent(JsonSerializer.Serialize(column), Encoding.UTF8, "application/json");
            _httpClient.PutAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}", content).Wait();
        }

        /// <summary>
        /// �񍀖ڂ��폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜����񍀖ڂ�ID</param>
        public void DeleteColumn(string sheetId, int id)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { Id = id }), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}", content).Wait();
        }
    }
}
