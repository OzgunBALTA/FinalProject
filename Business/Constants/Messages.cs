using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages : IMessages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductNameAlreadyExists = "Bu İsimde Başka Bir Ürün Var";
        public static string ProductCountOfCategoryError = "Bir Kategoride En Fazla 10 Ürün Bulanabilir.";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldığından Dolayı Yeni Ürün Eklenemez.";

        public static string MaintenanceTime = "22.00-22.59 arasında sistem bakımda";

        public static string AuthorizationDenied = "Bu İşlem İçin Yetkiniz Yok";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Anahtar Oluşturuldu";

        public static string CategoryAdded = "Kategori Eklendi";
        public static string CategoryDeleted = "Kategori Silindi";
        public static string CategoryUpdated = "Kategori Güncellendi";

        public static string ProductImageUploaded = "Ürün Resmi Yüklendi";
        public static string ProductImageDeleted = "Ürün Resmi Silindi";
        public static string ProductImageUpdated = "Ürün Resmi Güncellendi";

        public static string OrderAdded = "Sipariş Eklendi";
        public static string OrderDeleted = "Sipariş Silindi";
        public static string OrderUpdated = "Sipariş Güncellendi";

    }
}
