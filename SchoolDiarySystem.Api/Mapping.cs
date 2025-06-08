using AutoMapper;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Api
{
    /// <summary>
    /// Настройка маппинга между моделями и DTO.
    /// </summary>
    public class Mapping : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Mapping"/>.
        /// </summary>
        public Mapping()
        {
            // Настройка маппинга для студентов
            CreateMap<Student, StudentGetDto>().ReverseMap();
            CreateMap<Student, StudentPostDto>().ReverseMap();

            // Настройка маппинга для школьных классов
            CreateMap<SchoolClass, SchoolClassGetDto>().ReverseMap();
            CreateMap<SchoolClass, SchoolClassPostDto>().ReverseMap();

            // Настройка маппинга для оценок
            CreateMap<Grade, GradeGetDto>().ReverseMap();

            // Настройка маппинга для предметов
            CreateMap<Subject, SubjectGetDto>().ReverseMap();
            CreateMap<Subject, SubjectPostDto>().ReverseMap();
        }
    }
}