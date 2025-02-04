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
            try
            {
                var response = _httpClient.GetAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error retrieving records: {errorContent}");
                }
                var records = JsonSerializer.Deserialize<List<CATRecord>>(response.Content.ReadAsStringAsync().Result);
                return records;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving records", ex);
            }
        }

        /// <summary>
        /// ���R�[�h��ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�ǉ����郌�R�[�h</param>
        public void AddRecord(string sheetId, CATRecord record)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error adding record: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding record", ex);
            }
        }

        /// <summary>
        /// ���R�[�h���X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="record">�X�V���郌�R�[�h</param>
        public void UpdateRecord(string sheetId, CATRecord record)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
                var response = _httpClient.PutAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error updating record: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating record", ex);
            }
        }

        /// <summary>
        /// ���R�[�h���폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜���郌�R�[�h��ID</param>
        public void DeleteRecord(string sheetId, int id)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(new { Id = id }), Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error deleting record: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting record", ex);
            }
        }
    }
}
