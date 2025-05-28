using MassTransit;
using Shared.Contracts.Models;

public class GetAllUsersConsumer : IConsumer<GetAllUsersQuery>
{
    private readonly IUserRepository _repository;

    public GetAllUsersConsumer(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAllUsersQuery> context)
    {
        var users = await _repository.GetAllAsync();

        var result = users.Select(u => new UserDto(
            u.Id.ToString(),
            u.Email,
            u.Name,
            u.Role,
            u.CreatedAt
        ));

        await context.RespondAsync(new GetAllUsersResponse(result));
    }
}
