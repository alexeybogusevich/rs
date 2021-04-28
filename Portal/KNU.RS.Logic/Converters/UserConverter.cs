using KNU.RS.Data.Enums;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Helpers;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Models.User;

namespace KNU.RS.Logic.Converters
{
    public static class UserConverter
    {
        public static UserInfo Convert(User user)
        {
            return new UserInfo
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Gender = user?.Gender ?? Gender.Male,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address,
                Birthday = user.Birthday,
                Age = DateTimeHelper.GetAge(user.Birthday),
                FormattedBirthday = user.Birthday.ToString("dd.MM.yyyy"),
                HasPhoto = user.HasPhoto
            };
        }

        public static RegistrationModel ConvertProfile(User user)
        {
            return new RegistrationModel
            {
                Address = user.Address,
                Birthday = user.Birthday,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber
            };
        }

        public static FooterInfo ConvertFooter(User user)
        {
            return new FooterInfo
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                HasPhoto = user.HasPhoto
            };
        }
    }
}
