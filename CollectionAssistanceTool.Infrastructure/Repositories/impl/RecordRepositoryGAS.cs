using CollectionAssistanceTool.Core.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CollectionAssistanceTool.Infrastructure.Repositories.impl
{
    /// <summary>
    /// Google �X�v���b�h�V�[�g���g�p���� IRecordRepository �̎����N���X
    /// </summary>
    public class RecordRepositoryGAS : IRecordRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RecordRepositoryGAS(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// ���R�[�h���擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>���R�[�h�̃��X�g</returns>
        public IEnumerable<CATRecord> GetRecords(string sheetId)
        {
            var response = _httpClient.GetStringAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}").Result;
            var records = JsonSerializer.Deserialize<List<CATRecord>>(response);
            return records;
        }

        /// <summary>
        /// ���R�[�h��ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�ǉ����郌�R�[�h</param>
        public void AddRecord(string sheetId, CATRecord record)
        {
            var content = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Wait();
        }

        /// <summary>
        /// ���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�X�V���郌�R�[�h</param>
        public void UpdateRecord(string sheetId, CATRecord record)
        {
            var content = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            _httpClient.PutAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Wait();
        }

        /// <summary>
        /// ���R�[�h���폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜���郌�R�[�h��ID</param>
        public void DeleteRecord(string sheetId, int id)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { Id = id }), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Wait();
        }
    }
}
