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

