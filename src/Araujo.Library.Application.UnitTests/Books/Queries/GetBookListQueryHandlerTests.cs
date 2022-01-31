using AutoMapper;
using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Application.Features.Books.Queries.GetBookList;
using Araujo.Library.Application.Profiles;
using Araujo.Library.Application.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Araujo.Library.Application.UnitTests.Books.Queries
{
    public class GetBookListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly ILogger<GetBookListQueryHandler> _logger;

        public GetBookListQueryHandlerTests()
        {
            _mockBookRepository = RepositoryMocks.GetBookRepository();

            _logger = new Mock<ILogger<GetBookListQueryHandler>>().Object;
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetBookListTest()
        {

            var handler = new GetBookListQueryHandler(_logger, _mockBookRepository.Object, _mapper);

            var result = await handler.Handle(new GetBookListQuery(1, 25, true), CancellationToken.None);

            result.ShouldBeOfType<List<BookListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
