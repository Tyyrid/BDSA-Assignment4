namespace Assignment.Infrastructure;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
}

/*Id : int
Name : string(50), required, unique
WorkItems : many-to-many reference to WorkItem entity*/
