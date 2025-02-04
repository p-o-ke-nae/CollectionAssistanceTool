using CollectionAssistanceTool.Core.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CollectionAssistanceTool.Infrastructure.Repositories.impl
{
    /// <summary>
    /// Google スプレッドシートを使用した IRecordRepository の実装クラス
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
        /// レコードを取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>レコードのリスト</returns>
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
        /// レコードを追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">追加するレコード</param>
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
        /// レコードを更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">更新するレコード</param>
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
        /// レコードを削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除するレコードのID</param>
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
