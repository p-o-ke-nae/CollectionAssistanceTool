using CollectionAssistanceTool.Core.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CollectionAssistanceTool.Infrastructure.Repositories.impl
{
    /// <summary>
    /// Google スプレッドシートを使用した IColumnRepository の実装クラス
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
        /// 列項目を取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>列項目のリスト</returns>
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
        /// 列項目を追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">追加する列項目</param>
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
        /// 列項目を更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">更新する列項目</param>
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
        /// 列項目を削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除する列項目のID</param>
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
