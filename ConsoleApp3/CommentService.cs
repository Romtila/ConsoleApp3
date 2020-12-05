namespace ConsoleApp3
{
    public class CommentService
    {
        private readonly UserService _userService;

        private readonly VideoService _videoService;

        public CommentService(VideoService videoService, UserService userService)
        {
            _videoService = videoService;
            _userService = userService;
        }
    }
}
// создать класс userService, в который передаем модель UserView, а внутри добавить проверки, 
// например чтобы длина логина была длиннее чегонить, пароль проверка, несколько полей добавить в документ User, типа мейл и др.
// а потом UserrService создает мне User по UserView. 
// и тоже самое VideoService аналогично с userService, в классе Video + должен быть Object ID "OwnerId", это Id того юзера, котоырй его создал  
// Когад мы пытаемся создать видео, проверяем, что User (OwnerId в Video) реально существует такой User

