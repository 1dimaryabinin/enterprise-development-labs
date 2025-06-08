using Microsoft.AspNetCore.Mvc;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Api.Services;


namespace SchoolDiarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController(IService<GradeGetDto, GradePostDto> service) : ControllerBase
    {
        /// <summary>
        /// Получает все оценки.
        /// </summary>
        /// <returns>Список всех оценок.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<GradeGetDto>> GetAll()
        {
            var grades = service.GetAll();
            return Ok(grades);
        }

        /// <summary>
        /// Получает оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки.</param>
        /// <returns>Оценка с указанным идентификатором.</returns>
        /// <response code="200">Возвращает оценку.</response>
        /// <response code="404">Если оценка не найдена.</response>
        [HttpGet("{id}")]
        public ActionResult<GradeGetDto> GetById(int id)
        {
            var grade = service.GetById(id);
            if (grade == null)
                return NotFound($"Оценка с идентификатором {id} не найдена");

            return Ok(grade);
        }

        /// <summary>
        /// Создает новую оценку.
        /// </summary>
        /// <param name="value">Данные для создания новой оценки.</param>
        /// <returns>Созданная оценка.</returns>
        /// <response code="201">Возвращает созданную оценку.</response>
        /// <response code="400">Если данные оценки некорректны.</response>
        [HttpPost]
        public ActionResult<GradeGetDto> Post([FromBody] GradePostDto value)
        {
            if (value == null)
                return BadRequest("Оценка не может быть null");

            var newId = service.Post(value);
            var newGradeDto = service.GetById(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newGradeDto);
        }

        /// <summary>
        /// Обновляет существующую оценку.
        /// </summary>
        /// <param name="id">Идентификатор оценки для обновления.</param>
        /// <param name="updatedGradeDto">Обновленные данные оценки.</param>
        /// <returns>Обновленная оценка.</returns>
        /// <response code="200">Возвращает обновленную оценку.</response>
        /// <response code="400">Если данные оценки некорректны.</response>
        /// <response code="404">Если оценка не найдена.</response>
        [HttpPut("{id}")]
        public ActionResult<GradeGetDto> Put(int id, [FromBody] GradePostDto updatedGradeDto)
        {
            if (updatedGradeDto == null)
                return BadRequest("Оценка не может быть null");

            var updatedGrade = service.Put(id, updatedGradeDto);
            if (updatedGrade == null)
                return NotFound($"Оценка с идентификатором {id} не найдена");

            return Ok(updatedGrade);
        }

        /// <summary>
        /// Удаляет оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки для удаления.</param>
        /// <returns>Результат удаления.</returns>
        /// <response code="204">Возвращает сообщение об успешном удалении.</response>
        /// <response code="404">Если оценка не найдена.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletedGrade = service.Delete(id);
            if (!deletedGrade)
                return NotFound($"Оценка с идентификатором {id} не найдена");
           
            return NoContent();
        }
    }
}
