namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;

public class GroupMembership
{
    public GroupMembership(Guid userId, int groupId)
    {
        if (groupId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(groupId), 
                "The group ID must be positive.");
        }

        UserId = userId;
        GroupId = groupId;
    }

    public Guid UserId { get; private set; }

    public int GroupId { get; private set; }

    public DateTimeOffset? JoinedAt { get; private set; }

    private GroupMembership() { }
}
