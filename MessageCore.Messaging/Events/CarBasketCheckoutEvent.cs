
namespace MessageCore.Messaging.Events
{
    public record CarBasketCheckoutEvent: IntegrationEvent
    {
        // بيانات العميل
        public string UserName { get; set; } = default!;  // اسم العميل
        public Guid CustomerId { get; set; } = default!;  // معرف العميل
        public decimal TotalPrice { get; set; } = default!;  // سعر السيارة الإجمالي

        // بيانات السيارة
        public string CarMake { get; set; } = default!;  // ماركة السيارة (مثال: تويوتا)
        public string CarModel { get; set; } = default!; // موديل السيارة (مثال: كامري)
        public int CarYear { get; set; }  // سنة صناعة السيارة
        public List<string> CarFeatures { get; set; } = new();  // قائمة ميزات السيارة (مثال: كاميرا خلفية، نظام تحكم بالحرارة)
        public string CarDescription { get; set; } = default!;  // وصف السيارة
        public string CarImageFile { get; set; } = default!;  // رابط أو اسم صورة السيارة
        public decimal CarPrice { get; set; }  // سعر السيارة

        // معلومات العميل
        public string FirstName { get; set; } = default!;  // الاسم الأول
        public string LastName { get; set; } = default!;   // الاسم الأخير
        public string EmailAddress { get; set; } = default!;  // البريد الإلكتروني
        public string AddressLine { get; set; } = default!;   // عنوان العميل
        public string Country { get; set; } = default!;  // الدولة
        public string State { get; set; } = default!;    // الولاية
        public string ZipCode { get; set; } = default!;  // الرمز البريدي

        // طريقة الدفع
        public string CardName { get; set; } = default!;  // اسم صاحب البطاقة
        public string CardNumber { get; set; } = default!;  // رقم البطاقة
        public string Expiration { get; set; } = default!;  // تاريخ انتهاء البطاقة
        public string CVV { get; set; } = default!;  // رمز الأمان
        public int PaymentMethod { get; set; } = default!;  // طريقة الدفع (مثال: بطاقة ائتمان، باي بال، إلخ)
    }
}
