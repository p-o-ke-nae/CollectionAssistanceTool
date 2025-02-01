using CollectionAssistanceTool.Core.Entities;
using CollectionAssistanceTool.Infrastructure.Repositories;
using CollectionAssistanceTool;
using System.Collections.Generic;

namespace CollectionAssistanceTool.API.Services.impl
{
    /// <summary>
    /// IRecordServiceの実装クラス
    /// </summary>
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        /// <summary>
        /// レコードを取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>レコードのリスト</returns>
        public IEnumerable<CATRecord> GetRecords(string sheetId)
        {
            return _recordRepository.GetRecords(sheetId);
        }

        /// <summary>
        /// レコードを追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">追加するレコード</param>
        public void AddRecord(string sheetId, CATRecord record)
        {
            _recordRepository.AddRecord(sheetId, record);
        }

        /// <summary>
        /// レコードを更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="record">更新するレコード</param>
        public void UpdateRecord(string sheetId, CATRecord record)
        {
            _recordRepository.UpdateRecord(sheetId, record);
        }

        /// <summary>
        /// レコードを削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除するレコードのID</param>
        public void DeleteRecord(string sheetId, int id)
        {
            _recordRepository.DeleteRecord(sheetId, id);
        }
    }
}
