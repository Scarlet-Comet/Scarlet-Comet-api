using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scarlet.Comet.Domain.Catalog;

namespace Scarlet.Comet.Domain.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Can_Create_New_Item()
        {
            var item = new Item(1, "Name", 10.00m, "Description", "image.jpg");

            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("Name", item.Name);
            Assert.AreEqual(10.00m, item.Price);
            Assert.AreEqual("Description", item.Description);
            Assert.AreEqual("image.jpg", item.ImageUrl);
        }

        [TestMethod]
        public void Can_Create_Add_Rating()
        {
            var item = new Item(1, "Name", 10.00m, "Description", "image.jpg");
            var rating = new Rating(5, "Name", "Review");

            item.AddRating(rating);

            Assert.AreEqual(rating, item.Ratings[0]);
        }
    }
}