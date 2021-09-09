using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.CategoryId);
            _mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommand), typeof(Category));
            await _categoryRepository.UpdateAsync(categoryToUpdate);
            return Unit.Value;
        }
    }
}
