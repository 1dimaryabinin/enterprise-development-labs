using Microsoft.AspNetCore.Mvc;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Api.Services;


namespace SchoolDiarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(IService<SubjectGetDto, SubjectPostDto> service) : ControllerBase
    {
        /// <summary>
        /// Получает все предметы.
        /// </summary>
        /// <returns>Список всех предметов.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<SubjectGetDto>> GetAll()
        {
            var subjects = service.GetAll();
            return Ok(subjects);
        }

        /// <summary>
        /// Получает предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета.</param>
        /// <returns>Предмет с указанным идентификатором.</returns>
        /// <response code="200">Возвращает предмет.</response>
        /// <response code="404">Если предмет не найден.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<SubjectGetDto> GetById(int id)
        {
            var subject = service.GetById(id);
            if (subject == null)
                return NotFound($"Предмет с идентификатором {id} не найден");

            return Ok(subject);
        }

        /// <summary>
        /// Создает новый предмет.
        /// </summary>
        /// <param name="value">Данные для создания нового предмета.</param>
        /// <returns>Созданный предмет.</returns>
        /// <response code="201">Возвращает созданный предмет.</response>
        /// <response code="400">Если данные предмета некорректны.</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public ActionResult<SubjectGetDto> Post([FromBody] SubjectPostDto value)
        {
            if (value == null)
                return BadRequest("Предмет не может быть null");

            var newId = service.Post(value);
            var newSubjectDto = service.GetById(newId);
            return CreatedAtAction(nameof(GetById), new {id = newId}, newSubjectDto);
        }

        /// <summary>
        /// Обновляет существующий предмет.
        /// </summary>
        /// <param name="id">Идентификатор предмета для обновления.</param>
        /// <param name="updatedSubjectDto">Обновленные данные предмета.</param>
        /// <returns>Обновленный предмет.</returns>
        /// <response code="200">Возвращает обновленный предмет.</response>
        /// <response code="400">Если данные предмета некорректны.</response>
        /// <response code="404">Если предмет не найден.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<SubjectGetDto> Put(int id, [FromBody] SubjectPostDto updatedSubjectDto)
        {
            if (updatedSubjectDto == null)
                return BadRequest("Предмет не может быть null");

            var updatedSubject = service.Put(id, updatedSubjectDto);
            if (updatedSubject == null)
                return NotFound($"Предмет с идентификатором {id} не найден");

            return Ok(updatedSubject);
        }

        /// <summary>
        /// Удаляет предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета для удаления.</param>
        /// <returns>Результат удаления.</returns>
        /// <response code="204">Возвращает сообщение об успешном удалении.</response>
        /// <response code="404">Если предмет не найден.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            var deletedSubject = service.Delete(id);
            if (!deletedSubject)
                return NotFound($"Предмет с идентификатором {id} не найден");

            return NoContent();
        }
    }
}
