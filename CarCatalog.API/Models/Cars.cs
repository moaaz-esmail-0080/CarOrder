namespace CarCatalog.API.Models;

public class Cars
{
    public Guid Id { get; set; } = default!;  // معرف فريد للسيارة

    public string Name { get; set; } = default!;  // أسم السيارة(مثال: تويوتا)
    public List<string> Category { get; set; } = new();  // اصناف أو أنواع السيارات 
    public string Model { get; set; } = default!; // موديل السيارة (مثال: كامري)
    public int Year { get; set; }  // سنة صناعة السيارة
    public List<string> Features { get; set; } = new();  // قائمة ميزات السيارة (مثال: كاميرا خلفية، نظام تحكم بالحرارة)
    public string Description { get; set; } = default!;  // وصف السيارة
    public string ImageFile { get; set; } = default!;  // رابط أو اسم صورة السيارة
    public decimal Price { get; set; }  // سعر السيارة
}
