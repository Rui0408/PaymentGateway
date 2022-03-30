using AutoMapper;

namespace PaymentGateway.Srv.Commands.Base
{
    public class CommandHandlerBase
    {
        public readonly IMapper _mapper;

        public CommandHandlerBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
