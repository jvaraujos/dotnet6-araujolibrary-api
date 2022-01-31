using AutoMapper;
using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Application.Features.Books.Commands.CreateBook;
using Araujo.Library.Application.Profiles;
using Araujo.Library.Application.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Araujo.Library.Application.UnitTests.Books.Commands
{
    public class CreateBookCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBookCommandHandler> _logger;
        private readonly Mock<IBookRepository> _mockBookRepository;

        public CreateBookCommandHandlerTests()
        {
            _logger = new Mock<ILogger<CreateBookCommandHandler>>().Object;

            _mockBookRepository = RepositoryMocks.GetBookRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidBook_AddedToBookRepo()
        {
            var handler = new CreateBookCommandHandler(_logger, _mockBookRepository.Object, _mapper);

            await handler.Handle(new CreateBookCommand()
            {
                Author = "Sabugosa",
                BookCategoryId = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
                Pages = 32,
                Publisher = "Editora Abril",
                Title = "Sitio do pica-pau amarelo"
            }, CancellationToken.None);

            var allBooks = await _mockBookRepository.Object.ListAllAsync();
            allBooks.Count.ShouldBe(5);
        }
    }
}
