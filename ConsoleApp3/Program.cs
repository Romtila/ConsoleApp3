using Autofac;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserService>();

            builder.RegisterType<VideoService>();

            builder.RegisterType<CommentService>();

            builder.RegisterGeneric(typeof(BaseRepository<>));

            var container = builder.Build();

            var userService = container.Resolve<UserService>();

            var videoService = container.Resolve<VideoService>();
            
            var commentService = container.Resolve<CommentService>();



            #region 

            //var userService = new UserService();

            //userService.CreateUser(user);

            //user.Username = "login";

            //userService.UpdateUser(user);            

            //var userService = new BaseService();

            //var list = userService.GetManyUser();

            //var list2 = list.Select(i => i.Username).ToList();

            //var list3 = list.Select(Selector).ToList();

            //var list4 = list.Where(x => x.Username.Length > 5).Select(x => x.Username).ToList();

            //var someuser = userService.GetUser(ObjectId.Parse("5fc22b348a31cfd313def07c"));

            //var list5 = list.Where(x => x.Tags.Any(y => y.Length > 3)).Select(x => x.Id).ToList();

            //var list6 = list.Where(x => x.Username.Length > 5).SelectMany(x => x.Tags).Where(x => x.Length < 10).Distinct().ToList();

            #endregion
        }

        public static string Selector(User user)
        {
            return user.Username;
        }
    }

    public interface IHasId
    {
        ObjectId Id { get; set; }
    }

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

