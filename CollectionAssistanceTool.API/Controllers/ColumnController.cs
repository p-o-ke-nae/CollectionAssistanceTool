using CollectionAssistanceTool.Core.Entities;
using CollectionAssistanceTool.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CollectionAssistanceTool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnService _columnService;

        public ColumnController(IColumnService columnService)
        {
            _columnService = columnService;
        }

        /// <summary>
        /// 列項目を取得します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <returns>列項目のリスト</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CATColumn>> GetColumns([FromQuery] string sheetId)
        {
            var columns = _columnService.GetColumns(sheetId);
            return Ok(columns);
        }

        /// <summary>
        /// 列項目を追加します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">追加する列項目</param>
        [HttpPost]
        public IActionResult AddColumn([FromQuery] string sheetId, [FromBody] CATColumn column)
        {
            _columnService.AddColumn(sheetId, column);
            return Ok();
        }

        /// <summary>
        /// 列項目を更新します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="column">更新する列項目</param>
        [HttpPut]
        public IActionResult UpdateColumn([FromQuery] string sheetId, [FromBody] CATColumn column)
        {
            _columnService.UpdateColumn(sheetId, column);
            return Ok();
        }

        /// <summary>
        /// 列項目を削除します
        /// </summary>
        /// <param name="sheetId">スプレッドシートのID</param>
        /// <param name="id">削除する列項目のID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteColumn([FromQuery] string sheetId, int id)
        {
            _columnService.DeleteColumn(sheetId, id);
            return Ok();
        }
    }
}
