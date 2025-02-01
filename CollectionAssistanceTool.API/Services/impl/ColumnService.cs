using CollectionAssistanceTool.Core.Entities;
using CollectionAssistanceTool.Infrastructure.Repositories;
using System.Collections.Generic;

namespace CollectionAssistanceTool.API.Services.impl
{
    /// <summary>
    /// IColumnServiceの実装クラス
    /// </summary>
    public class ColumnService : IColumnService
    {
        private readonly IColumnRepository _columnRepository;

        public ColumnService(IColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }

        /// <summary>
        /// 列項目を取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>列項目のリスト</returns>
        public IEnumerable<CATColumn> GetColumns(string sheetId)
        {
            return _columnRepository.GetColumns(sheetId);
        }

        /// <summary>
        /// 列項目を追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">追加する列項目</param>
        public void AddColumn(string sheetId, CATColumn column)
        {
            _columnRepository.AddColumn(sheetId, column);
        }

        /// <summary>
        /// 列項目を更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">更新する列項目</param>
        public void UpdateColumn(string sheetId, CATColumn column)
        {
            _columnRepository.UpdateColumn(sheetId, column);
        }

        /// <summary>
        /// 列項目を削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除する列項目のID</param>
        public void DeleteColumn(string sheetId, int id)
        {
            _columnRepository.DeleteColumn(sheetId, id);
        }
    }
}
