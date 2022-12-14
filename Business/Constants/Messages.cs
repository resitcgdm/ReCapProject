using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarsUpdated = "Arabalar güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi"; 
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi"; 
        public static string ColorUpdated = "Renk güncellendi";
        public static string Failed = "Araba teslimi gerçekleşmemiştir";
        public static string RentedCarAdded = "Araba kiralananlara eklendi";
        public static string RentedCarDeleted = "Araba kiralananlardan silindi";
        public static string RentedCarUpdated = "Kiralanan araba güncellendi";
        public static string CarCountOfBrandError="Aynı markadan en fazla 15 araba listelenebilir";
        public static string CarNameAlreadyExists = "Böyle bir isimde araba zaten var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldı";
        public static string ACarCanNotMoreThan5Images="Bir araba için 5 resimden fazlası yüklenemez ";
        public static string ImageNotFound="Resim bulunamadı";
        public static string ImageDeleted="Resim silindi";
        public static string ErrorMessage="Hata!!";
        public static string ImageUpdated="Resim yüklendi";
        public static string ImageError="Resim hatası";
        public static string ImageAdded="Resim eklendi";
    }
}
