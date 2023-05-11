namespace Wordle.Api.Data
{
	public class Player
	{
		public int PlayerId { get; set; }
		public required string Name { get; set; }
		public int GameCount { get; set; }
		public double AverageAttempts { get; set; }
		public int AverageSeconds { get; set; }

		public static void SeedPlayers(AppDbContext db)
		{
			if (!db.Players.Any())
			{
				Player player = new() { Name = "User" };
				db.Players.Add(player);
				db.SaveChanges();
			}
		}
	}
}

