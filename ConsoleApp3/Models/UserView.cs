using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class UserView
    {
        public List<string> Tags { get; set; } = new List<string>();

        public ObjectId Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
// создать класс userService, в который передаем модель UserView, а внутри добавить проверки, 
// например чтобы длина логина была длиннее чегонить, пароль проверка, несколько полей добавить в документ User, типа мейл и др.
// а потом UserrService создает мне User по UserView. 
// и тоже самое VideoService аналогично с userService, в классе Video + должен быть Object ID "OwnerId", это Id того юзера, котоырй его создал  
// Когад мы пытаемся создать видео, проверяем, что User (OwnerId в Video) реально существует такой User

