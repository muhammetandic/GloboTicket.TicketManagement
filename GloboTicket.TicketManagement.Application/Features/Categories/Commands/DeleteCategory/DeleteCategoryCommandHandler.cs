using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.CategoryId);
            await _categoryRepository.DeleteAsync(categoryToDelete);
            return Unit.Value;
        }
    }
}
