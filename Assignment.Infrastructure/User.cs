namespace Assignment.Infrastructure;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public virtual ICollection<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
}

/*Id : int
Name : string(100), required
Email : string(100), required, unique
WorkItems : list of WorkItem entities belonging to User*/