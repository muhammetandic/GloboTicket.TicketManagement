using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
    }
}
