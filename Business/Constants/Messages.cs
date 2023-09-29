using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        //public >> P
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "Invalid Product Name";
        public static string ProductCountOfCategoryError = "Invalid Category Count";
        public static string ProductNameAlreadyExists="Same name exists";
        public static string MaintenanceTime = "Maintenance Time";
        internal static string ProductsListed="Product listed";
        internal static string CategoryLimitExceded= "Limit Exceded";
        public static string AuthorizationDenied = "Auth denied";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin="Successfully login";
        public static string UserAlreadyExists="User already exists.";
        public static string AccessTokenCreated="Token Created";
    }
}
