namespace SchoolDiarySystem.Api.Services
{
    /// <summary>
    /// Интерфейс для сервиса, работающего с DTO.
    /// </summary>
    /// <typeparam name="TGetDto">Тип DTO для получения данных.</typeparam>
    /// <typeparam name="TPostDto">Тип DTO для передачи данных.</typeparam>
    public interface IService<TGetDto, TPostDto>
    {
        /// <summary>
        /// Получает все объекты.
        /// </summary>
        /// <returns>Список всех объектов в виде <see cref="IEnumerable{TGetDto}"/>.</returns>
        IEnumerable<TGetDto> GetAll();

        /// <summary>
        /// Получает объект по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор объекта.</param>
        /// <returns>Объект в виде <see cref="TGetDto"/> или null, если не найден.</returns>
        TGetDto? GetById(int id);

        /// <summary>
        /// Создает новый объект.
        /// </summary>
        /// <param name="postDto">Данные для создания нового объекта.</param>
        /// <returns>Идентификатор созданного объекта.</returns>
        int Post(TPostDto postDto);

        /// <summary>
        /// Обновляет существующий объект.
        /// </summary>
        /// <param name="id">Идентификатор объекта для обновления.</param>
        /// <param name="putDto">Обновленные данные объекта.</param>
        /// <returns>Обновленный объект в виде <see cref="TGetDto"/> или null, если не найден.</returns>
        TGetDto? Put (int id, TPostDto putDto);

        /// <summary>
        /// Удаляет объект по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор объекта для удаления.</param>
        /// <returns>True, если объект был успешно удален; иначе false.</returns>
        bool Delete(int id);
    }
}
