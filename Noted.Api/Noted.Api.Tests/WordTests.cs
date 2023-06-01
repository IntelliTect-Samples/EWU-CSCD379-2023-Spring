using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class WordTests : DatabaseTestBase
    {
        [TestMethod]
        public async Task GetWord()
        {
            using var db = new AppDbContext(Options);
            Word word = new() { Text = "hello" };
            db.Words.Add(word);
            Assert.AreEqual(0, word.WordId);
            await db.SaveChangesAsync();
            Assert.AreNotEqual(0, word.WordId);

            DateWord date1 = new() {
                Date = new DateTime(2023, 1, 1),
                WordId = word.WordId
            };
            db.DateWords.Add(date1);
            DateWord date2 = new()
            {
                Date = new DateTime(2023, 1, 2),
                Word = word
            };
            db.DateWords.Add(date2);
            await db.SaveChangesAsync();
            
            var wordSelect = db.Words
                .Include(f => f.DateWords)
                .Where(w => w.WordId == word.WordId);

            Assert.AreEqual(1, wordSelect.Count());
            Assert.AreEqual(2, wordSelect.First().DateWords.Count());


        }
    }
}
