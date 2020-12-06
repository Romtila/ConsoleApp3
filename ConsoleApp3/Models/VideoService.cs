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

        public void CreateVideo(string title, User user)
        {
            if (_userRepository.Get(user.Id) == null)
                throw new Exception("Такого юзера несуществует");
            var video = new Video()
            {
                OwnerId = user.Id,
                Title = title,
            };

            _videoRepository.Create(video);
        }
    }
}

