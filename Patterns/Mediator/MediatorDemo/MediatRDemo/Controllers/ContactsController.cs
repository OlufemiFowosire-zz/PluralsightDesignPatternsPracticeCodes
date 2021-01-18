using MediatR;
using MediatRDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute]Query query)
        {
            return await mediator.Send(query);
        }


        #region Nested Classes
        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }
        public class ContactHandler : IRequestHandler<Query, Contact>
        {
            private readonly ContactsContext db;
            public ContactHandler(ContactsContext db)
            {
                this.db = db;
            }

            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return db.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }
        }
        #endregion
    }
}
