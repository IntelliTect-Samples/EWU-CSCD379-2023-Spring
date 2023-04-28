using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Wordle.API.Data
{
	public class Word
	{
		public int WordId { get; set; }
		public required string Text { get; set; }
		public bool isCommon { get; set; }

		public static void SeedWords(AppDbContext db)
			{
			if (!db.Words.Any())
				{
					var wordLines = System.IO.File.ReadAllLines("Content/Words.csv");
					foreach (var line in wordLines)
					{
					var parts = line.Split(',');
					var word = new Word()
						{
						Text = parts[0],
						isCommon = bool.Parse(parts[1])
						};
						db.Words.Add(word);
					}
					db.SaveChanges();
				}
			}
	}
}	