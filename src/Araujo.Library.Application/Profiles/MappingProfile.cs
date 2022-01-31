using AutoMapper;
using Araujo.Library.Application.Features.Books.Commands.CreateBook;
using Araujo.Library.Application.Features.Books.Commands.UpdateBook;
using Araujo.Library.Application.Features.Books.Queries.GetBookDetail;
using Araujo.Library.Application.Features.Books.Queries.GetBookList;
using Araujo.Library.Application.Features.Courses.Commands.CreateCourse;
using Araujo.Library.Application.Features.Courses.Commands.UpdateCourse;
using Araujo.Library.Application.Features.Courses.Queries.GetCourseDetail;
using Araujo.Library.Application.Features.Courses.Queries.GetCourseList;
using Araujo.Library.Application.Features.Students.Commands.CreateStudent;
using Araujo.Library.Application.Features.Students.Commands.UpdateStudent;
using Araujo.Library.Application.Features.Students.Queries.GetStudentDetail;
using Araujo.Library.Application.Features.Students.Queries.GetStudentList;
using Araujo.Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Araujo.Library.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookListVm>();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, CreateBookCommandDto>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<Book, BookDetailVm>().ReverseMap();

            CreateMap<Student, StudentListVm>();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, CreateStudentCommandDto>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
            CreateMap<Student, StudentDetailVm>().ReverseMap();

            CreateMap<Course, CourseListVm>();
            CreateMap<Course, CreateCourseCommand>().ReverseMap();
            CreateMap<Course, CreateCourseCommandDto>().ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();
            CreateMap<Course, CourseDetailVm>().ReverseMap();

        }
    }
}
