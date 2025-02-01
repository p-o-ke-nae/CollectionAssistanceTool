using CollectionAssistanceTool.Core.Entities;

namespace CollectionAssistanceTool.Infrastructure.Repositories
{
    /// <summary>
    /// 列項目のリポジトリインターフェース
    /// </summary>
    public interface IColumnRepository
    {
        /// <summary>
        /// 列項目を取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>列項目のリスト</returns>
        IEnumerable<CATColumn> GetColumns(string sheetId);

        /// <summary>
        /// 列項目を追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">追加する列項目</param>
        void AddColumn(string sheetId, CATColumn column);

        /// <summary>
        /// 列項目を更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">更新する列項目</param>
        void UpdateColumn(string sheetId, CATColumn column);

        /// <summary>
        /// 列項目を削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除する列項目のID</param>
        void DeleteColumn(string sheetId, int id);
    }
}
