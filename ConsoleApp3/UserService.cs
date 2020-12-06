using MongoDB.Bson;
using System;
using System.Linq;

namespace ConsoleApp3
{
    public class UserService
    {
        private readonly BaseRepository<User> _baseRepository;

        public Guid guid;

        public UserService(BaseRepository<User> userRepository)
        {
            _baseRepository = userRepository;

            guid = Guid.NewGuid();
        }

        public void CreateUser(UserView userView)
        {
            ValidateUsername(userView.Username);

            ValidatePassword(userView.Password);

            var user = new User() { Id = userView.Id, Username = userView.Username, Password = userView.Password, FirstName = userView.FirstName, LastName = userView.LastName, Email = userView.Email, BirthDay = userView.BirthDay, Tags = userView.Tags };

            _baseRepository.Create(user);
        }

        private static void ValidateUsername(string username)//проверка username
        {
            if (string.IsNullOrEmpty(username)) throw new Exception("Username is empty");

            if (username.Length < 5) throw new Exception("Length of username < 5");
        }

        private static void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new Exception("Password is empty");

            if (password.Length < 6) throw new Exception("Length of password < 6");

            if (password.Any(char.IsUpper) &&
                password.Any(char.IsLower) &&
                password.Any(char.IsNumber))
                throw new Exception("Password должен иметь хотя бы один символ верхнего и маленького регистра и цифру");
        }
    }
}
// создать класс userService, в который передаем модель UserView, 
//а внутри добавить проверки, 

// например чтобы длина логина была длиннее чегонить, пароль проверка, 
//несколько полей добавить в документ User, типа мейл и др.

// а потом UserService создает мне User по UserView. 
// и тоже самое VideoService аналогично с userService, 
//в классе Video + должен быть Object ID "OwnerId", это Id того юзера, котоырй его создал 

// Когад мы пытаемся создать видео, проверяем, 
//что User (OwnerId в Video) реально существует такой User

