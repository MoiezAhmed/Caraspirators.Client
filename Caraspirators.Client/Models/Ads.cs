

namespace Caraspirators.Client.Models;

public class Ads {
     public int Id { get; set; }
     public string ImageUrl { get; set; }
     public string ClickUrl { get; set; }
     public string Title { get; set; }
     public string Description { get; set; }
     public int Priority { get; set; }
     public DateTime? StartDate { get; set; }
     public DateTime? EndDate { get; set; }
     public bool IsActive { get; set; }

public async Task<bool> ClickedAsync()
{
    // Implement logic to log ad click (e.g., update database)
    await SaveAdClickAsync(this);
    return true;
}

private async Task  SaveAdClickAsync(Ads ad)
{
    // Implement logic to save ad click to database using appropriate data access layer
    // ...
}
}

public class AdClick
{
    public int Id { get; set; }
    public int AdId { get; set; }
    public DateTime Timestamp { get; set; }
    public string UserId { get; set; } // Optional if not tracked

    public Ads Ad { get; set; } // Navigation property for linked ad object
}
