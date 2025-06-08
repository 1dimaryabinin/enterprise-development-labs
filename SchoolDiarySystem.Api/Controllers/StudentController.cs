using Microsoft.AspNetCore.Mvc;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Api.Services;


namespace SchoolDiarySystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IService<StudentGetDto, StudentPostDto> service) : ControllerBase
    {
        /// <summary>
        /// Получает всех студентов.
        /// </summary>
        /// <returns>Список всех студентов.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<StudentGetDto>> GetAll()
        {
            var students = service.GetAll();
            return Ok(students);
        }

        /// <summary>
        /// Получает студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Студент с указанным идентификатором.</returns>
        /// <response code="200">Возвращает студента.</response>
        /// <response code="404">Если студент не найден.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<StudentGetDto> GetById(int id)
        {
            var student = service.GetById(id);
            if (student == null) 
                return NotFound($"Студент с идентификатором {id} не найден");

            return Ok(student);
        }

        /// <summary>
        /// Создает нового студента.
        /// </summary>
        /// <param name="value">Данные для создания нового студента.</param>
        /// <returns>Созданный студент.</returns>
        /// <response code="201">Возвращает созданного студента.</response>
        /// <response code="400">Если данные студента некорректны.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<StudentGetDto> Post([FromBody] StudentPostDto value)
        {
            if (value == null)
                return BadRequest("Студент не может быть null");

            var newId = service.Post(value);
            var newStudentDto = service.GetById(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newStudentDto);
        }

        /// <summary>
        /// Обновляет существующего студента.
        /// </summary>
        /// <param name="id">Идентификатор студента для обновления.</param>
        /// <param name="updatedStudentDto">Обновленные данные студента.</param>
        /// <returns>Обновленный студент.</returns>
        /// <response code="200">Возвращает обновленного студента.</response>
        /// <response code="400">Если данные студента некорректны.</response>
        /// <response code="404">Если студент не найден.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentGetDto> Put(int id, [FromBody] StudentPostDto updatedStudentDto)
        {
            if (updatedStudentDto == null)
                return BadRequest("Студент не может быть null");

            var updatedStudent = service.Put(id, updatedStudentDto);
            if (updatedStudent == null)
                return NotFound($"Студент с идентификатором {id} не найден");

            return Ok(updatedStudent);
        }

        /// <summary>
        /// Удаляет студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента для удаления.</param>
        /// <returns>Результат удаления.</returns>
        /// <response code="204">Возвращает сообщение об успешном удалении.</response>
        /// <response code="404">Если студент не найден.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            var deletedStudent = service.Delete(id);
            if (!deletedStudent)
                return NotFound($"Студент с идентификатором {id} не найден");

            return NoContent();
        }
    }
}
