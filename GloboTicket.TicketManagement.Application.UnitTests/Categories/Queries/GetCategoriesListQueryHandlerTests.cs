using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mock;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRespository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRespository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile<MappingProfile>();
              });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRespository.Object);
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<CategoryListVm>>();
            result.Count.ShouldBe(4);
        }

    }
}
