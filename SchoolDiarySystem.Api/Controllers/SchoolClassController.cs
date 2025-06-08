using Microsoft.AspNetCore.Mvc;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Api.Services;

namespace SchoolDiarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController(IService<SchoolClassGetDto, SchoolClassPostDto> service) : ControllerBase
    {
        /// <summary>
        /// Получает все школьные классы.
        /// </summary>
        /// <returns>Список всех школьных классов.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<SchoolClassGetDto>> GetAll()
        {
            var schoolClasses = service.GetAll();
            return Ok(schoolClasses);
        }

        /// <summary>
        /// Получает школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса.</param>
        /// <returns>Школьный класс с указанным идентификатором.</returns>
        /// <response code="200">Возвращает школьный класс.</response>
        /// <response code="404">Если школьный класс не найден.</response>
        [HttpGet("{id}")]
        public ActionResult<SchoolClassGetDto> GetById(int id)
        {
            var SchoolClass = service.GetById(id);
            if (SchoolClass == null)
                return NotFound($"Школьный класс с идентификатором {id} не найден");
           
            return Ok(SchoolClass);
        }

        /// <summary>
        /// Создает новый школьный класс.
        /// </summary>
        /// <param name="value">Данные для создания нового школьного класса.</param>
        /// <returns>Созданный школьный класс.</returns>
        /// <response code="201">Возвращает созданный школьный класс.</response>
        /// <response code="400">Если данные школьного класса некорректны.</response>
        [HttpPost]
        public ActionResult<SchoolClassGetDto> Post([FromBody] SchoolClassPostDto value)
        {
            if (value == null)
                return BadRequest("Школьный класс не может быть null");
            var newId = service.Post(value);
            var newSchoolClassDto = service.GetById(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newSchoolClassDto);
        }

        /// <summary>
        /// Обновляет существующий школьный класс.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса для обновления.</param>
        /// <param name="updatedSchoolClassDto">Обновленные данные школьного класса.</param>
        /// <returns>Обновленный школьный класс.</returns>
        /// <response code="200">Возвращает обновленный школьный класс.</response>
        /// <response code="400">Если данные школьного класса некорректны.</response>
        /// <response code="404">Если школьный класс не найден.</response>
        [HttpPut("{id}")]
        public ActionResult<SchoolClassGetDto> Put(int id, [FromBody] SchoolClassPostDto updatedSchoolClassDto)
        {
            if (updatedSchoolClassDto == null)
                return BadRequest("Школьный класс не может быть null");
            var updatedSchoolClass = service.Put(id, updatedSchoolClassDto);
            if (updatedSchoolClass == null)
                return NotFound($"Школьный класс с идентификатором {id} не найден");
            return Ok(updatedSchoolClass);
        }

        /// <summary>
        /// Удаляет школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса для удаления.</param>
        /// <returns>Результат удаления.</returns>
        /// <response code="204">Возвращает сообщение об успешном удалении.</response>
        /// <response code="404">Если школьный класс не найден.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletedSchoolClass = service.Delete(id);
            if (!deletedSchoolClass)
                return NotFound($"Школьный класс с идентификатором {id} не найден");
            return NoContent();
        }
    }
}
