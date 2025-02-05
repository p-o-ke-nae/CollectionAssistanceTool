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
        /// �񍀖ڂ��擾���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <returns>�񍀖ڂ̃��X�g</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CATColumn>> GetColumns([FromQuery] string sheetId)
        {
            var columns = _columnService.GetColumns(sheetId);
            return Ok(columns);
        }

        /// <summary>
        /// �񍀖ڂ�ǉ����܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�ǉ�����񍀖�</param>
        [HttpPost]
        public IActionResult AddColumn([FromQuery] string sheetId, [FromBody] CATColumn column)
        {
            _columnService.AddColumn(sheetId, column);
            return Ok();
        }

        /// <summary>
        /// �񍀖ڂ��X�V���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="column">�X�V����񍀖�</param>
        [HttpPut]
        public IActionResult UpdateColumn([FromQuery] string sheetId, [FromBody] CATColumn column)
        {
            _columnService.UpdateColumn(sheetId, column);
            return Ok();
        }

        /// <summary>
        /// �񍀖ڂ��폜���܂�
        /// </summary>
        /// <param name="sheetId">�X�v���b�h�V�[�g��ID</param>
        /// <param name="id">�폜����񍀖ڂ�ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteColumn([FromQuery] string sheetId, int id)
        {
            _columnService.DeleteColumn(sheetId, id);
            return Ok();
        }
    }
}
