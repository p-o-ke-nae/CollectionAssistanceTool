using CollectionAssistanceTool.Core.Entities;

namespace CollectionAssistanceTool.Infrastructure.Repositories
{
    /// <summary>
    /// レコードのリポジトリインターフェース
    /// </summary>
    public interface IRecordRepository
    {
        /// <summary>
        /// レコードを取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>レコードのリスト</returns>
        IEnumerable<CATRecord> GetRecords(string sheetId);

        /// <summary>
        /// レコードを追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">追加するレコード</param>
        void AddRecord(string sheetId, CATRecord record);

        /// <summary>
        /// レコードを更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">更新するレコード</param>
        void UpdateRecord(string sheetId, CATRecord record);

        /// <summary>
        /// レコードを削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除するレコードのID</param>
        void DeleteRecord(string sheetId, int id);
    }
}
