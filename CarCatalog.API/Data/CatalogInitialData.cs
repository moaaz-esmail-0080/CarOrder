using CarCatalog.API.Models;
using Marten;
using Marten.Schema;

namespace CarCatalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Models.Cars>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Models.Cars>(GetPreconfiguredCars());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Models.Cars> GetPreconfiguredCars() => new List<Models.Cars>()
            {
                new Models.Cars()
            {
              Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e913"),
              Name = "Toyota Camry",  // اسم السيارة
              Category = new List<string> { "Sedan", "Luxury" },  // تصنيف السيارة (مثال: "Sedan", "Luxury")
              Year = 2022,  // سنة الصنع
              Features = new List<string> { "Air Conditioning", "Bluetooth", "Leather Seats" },  // ميزات السيارة
              Description = "The Toyota Camry is known for its reliability and comfort.",  // وصف السيارة
              ImageFile = "car-1.png",  // اسم أو رابط صورة السيارة
              Price = 28000.00M  // سعر السيارة
            },
            new Models.Cars()
            {
                Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                Name = "Toyota Camry",  // اسم السيارة
              Category = new List<string> { "Sedan", "Luxury" },  // تصنيف السيارة (مثال: "Sedan", "Luxury")
              Year = 2022,  // سنة الصنع
              Features = new List<string> { "Air Conditioning", "Bluetooth", "Leather Seats" },  // ميزات السيارة
              Description = "The Toyota Camry is known for its reliability and comfort.",  // وصف السيارة
              ImageFile = "car-1.png",  // اسم أو رابط صورة السيارة
              Price = 28000.00M  // سعر السيارة
            },
            new Models.Cars()
            {
                Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
                Name = "Toyota Camry",  // اسم السيارة
              Category = new List<string> { "Sedan", "Luxury" },  // تصنيف السيارة (مثال: "Sedan", "Luxury")
              Year = 2022,  // سنة الصنع
              Features = new List<string> { "Air Conditioning", "Bluetooth", "Leather Seats" },  // ميزات السيارة
              Description = "The Toyota Camry is known for its reliability and comfort.",  // وصف السيارة
              ImageFile = "car-1.png",  // اسم أو رابط صورة السيارة
              Price = 28000.00M  // سعر السيارة
            },
            new Models.Cars()
            {
                Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
               Name = "Toyota Camry",  // اسم السيارة
              Category = new List<string> { "Sedan", "Luxury" },  // تصنيف السيارة (مثال: "Sedan", "Luxury")
              Year = 2022,  // سنة الصنع
              Features = new List<string> { "Air Conditioning", "Bluetooth", "Leather Seats" },  // ميزات السيارة
              Description = "The Toyota Camry is known for its reliability and comfort.",  // وصف السيارة
              ImageFile = "car-1.png",  // اسم أو رابط صورة السيارة
              Price = 28000.00M  // سعر السيارة
            },
            new Models.Cars()
            {
                Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
               Name = "Toyota Camry",  // اسم السيارة
              Category = new List<string> { "Sedan", "Luxury" },  // تصنيف السيارة (مثال: "Sedan", "Luxury")
              Year = 2022,  // سنة الصنع
              Features = new List<string> { "Air Conditioning", "Bluetooth", "Leather Seats" },  // ميزات السيارة
              Description = "The Toyota Camry is known for its reliability and comfort.",  // وصف السيارة
              ImageFile = "car-1.png",  // اسم أو رابط صورة السيارة
              Price = 28000.00M  // سعر السيارة
            }
            };

}
