namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;

public class GroupMembership
{
    public GroupMembership(int userId, int groupId)
    {
        if (userId < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(userId), 
                "The user ID must starts with one");
        }
        if (groupId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(groupId), 
                "The group ID must be positive.");
        }

        UserId = userId;
        GroupId = groupId;
    }

    public int UserId { get; private set; }

    public int GroupId { get; private set; }

    public DateTimeOffset? JoinedAt { get; private set; }

    private GroupMembership() { }
}
