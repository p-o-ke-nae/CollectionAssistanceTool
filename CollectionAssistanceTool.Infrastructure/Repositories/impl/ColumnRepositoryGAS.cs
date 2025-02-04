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
            try
            {
                var response = _httpClient.GetAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error retrieving columns: {errorContent}");
                }
                var str = response.Content.ReadAsStringAsync().Result;
                var columns = JsonSerializer.Deserialize<List<CATColumn>>(response.Content.ReadAsStringAsync().Result);
                return columns;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving columns", ex);
            }
        }

        /// <summary>
        /// �񍀖ڂ�ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�ǉ�����񍀖�</param>
        public void AddColumn(string sheetId, CATColumn column)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(column), Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error adding column: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding column", ex);
            }
        }

        /// <summary>
        /// �񍀖ڂ��X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�X�V����񍀖�</param>
        public void UpdateColumn(string sheetId, CATColumn column)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(column), Encoding.UTF8, "application/json");
                var response = _httpClient.PutAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error updating column: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating column", ex);
            }
        }

        /// <summary>
        /// �񍀖ڂ��폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜����񍀖ڂ�ID</param>
        public void DeleteColumn(string sheetId, int id)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(new { Id = id }), Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Column&sheetId={sheetId}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Error deleting column: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting column", ex);
            }
        }
    }
}
