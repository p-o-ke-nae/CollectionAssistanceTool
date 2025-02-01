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
            var response = _httpClient.GetStringAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}").Result;
            var records = JsonSerializer.Deserialize<List<CATRecord>>(response);
            return records;
        }

        /// <summary>
        /// レコードを追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">追加するレコード</param>
        public void AddRecord(string sheetId, CATRecord record)
        {
            var content = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Wait();
        }

        /// <summary>
        /// レコードを更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">更新するレコード</param>
        public void UpdateRecord(string sheetId, CATRecord record)
        {
            var content = new StringContent(JsonSerializer.Serialize(record), Encoding.UTF8, "application/json");
            _httpClient.PutAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Wait();
        }

        /// <summary>
        /// レコードを削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除するレコードのID</param>
        public void DeleteRecord(string sheetId, int id)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { Id = id }), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_baseUrl}/exec?sheet=Record&sheetId={sheetId}", content).Wait();
        }
    }
}
