using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    public class VideoService
    {
        private readonly BaseRepository<User> _userRepository;

        private readonly BaseRepository<Video> _videoRepository;

        public VideoService(BaseRepository<User> userRepository, BaseRepository<Video> videoRepository)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        public void CreateVideo(VideoView videoView)
        {
            if (_userRepository.Get(videoView.OwnerId) == null)
                throw new Exception("Такого юзера несуществует");
            var video = new Video()
            {
                OwnerId = videoView.OwnerId,
                Title = videoView.Title,
                Length = videoView.Length,
                Id = videoView.Id,
                Tags = videoView.Tags
            };

            _videoRepository.Create(video);
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

