namespace Assignment.Infrastructure;

public class WorkItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public User? AssignedTo { get; set; }
    public string? Description { get; set; }
    public State State { get; set; }
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}

/*Id : int
Title : string(100), required
AssignedTo : optional reference to User entity
Description : string(max), optional
State : enum (New, Active, Resolved, Closed, Removed), required
Tags : many-to-many reference to Tag entity*/