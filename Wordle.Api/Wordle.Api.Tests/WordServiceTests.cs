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
    public class WordServiceTests : DatabaseTestBase
    {
        [TestMethod]
        public async Task GetWord()
        {
            using var context = new AppDbContext(Options);
            var service = new WordService(context);
            Word.SeedWords(context);

            var word = await service.GetRandomWord();

            Assert.IsNotNull(word);
            Assert.AreEqual(5, word.Length);
        }
    }
}
