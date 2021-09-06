using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
