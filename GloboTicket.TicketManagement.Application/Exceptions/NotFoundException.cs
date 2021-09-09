using System;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, Object key) : base($"{name} ({key}) is not found.")
        {

        }
    }
}
