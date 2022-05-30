using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok !!!";
        public static string ClothesAddMessage = "Elbise eklendi.";
        public static string ClothesDeleteMessage = "Elbise silindi";
        public static string ClothesUpdateMessage = "Elbise güncellendi";
        public static string CategoryUpdatedMessage = "Kategori güncellendi.";
        public static string CategoryAddedMessage = "Kategori eklendi";
        public static string ColorAddMessage = "Renk eklendi.";
        public static string ColorDeleteMessage = "Renk silindi.";
        public static string ColorUpdateMessage = "Renk güncellendi.";
        public static string UserRegisteredMessage = "Kullanıcı kayıt oldu.";
        public static string UserAlreadyExist = "Kullanıcı zaten var";
        public static string UserEmailNotFound = "Kullanıcı emaili bulunamadı.";
        public static string PasswordError = "Parola Hatalı";
        public static string UserSuccessLoginMessage = "Giriş başarılı.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductUpdated = "Ürün güncellendi.";

        public static string ImageUploaded { get; internal set; }
    }
}
