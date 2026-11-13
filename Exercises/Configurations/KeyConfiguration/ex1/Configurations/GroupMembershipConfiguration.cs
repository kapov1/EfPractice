using EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Configurations;

public class GroupMembershipConfiguration : IEntityTypeConfiguration<GroupMembership>
{
    public void Configure(EntityTypeBuilder<GroupMembership> builder)
    {
        builder.ToTable("group_memberships", t =>
        {
            t.HasCheckConstraint("ck_group_membership_user_id", "user_id > 0");
            t.HasCheckConstraint("ck_group_membership_id", "group_id > 0");
        });

        builder.HasKey(g => new { g.GroupId, g.UserId });

        builder.Property(g => g.GroupId)
            .HasColumnName("group_id");

        builder.Property(g => g.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(g => g.JoinedAt)
            .HasColumnName("joined_at")
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
