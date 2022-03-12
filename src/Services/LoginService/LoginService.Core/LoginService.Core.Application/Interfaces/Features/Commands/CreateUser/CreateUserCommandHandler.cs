using AutoMapper;
using LoginService.Core.Application.Interfaces.UnitOfWorks;
using LoginService.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;


        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            User user = _autoMapper.Map<User>(request);
            EntityState result = await _unitOfWork.UserRepository.AddAsync(user);
            int affectedRowCount= await _unitOfWork.SaveChangesAsync();
            if (result == EntityState.Added && affectedRowCount>0)
            {
                return new CreateUserCommandResponse
                {
                    Message = EntityState.Added.ToString(),
                    Succeed = true
                };
            }
            else
            {
                return new CreateUserCommandResponse
                {
                    Message = result.ToString(),
                    Succeed = false
                };

            }

        }
    }
}
