namespace aspConf.Controllers {
    using System.Web.Mvc;
    using aspConf.Models;

    public class VideosController : ConfController {
        public ActionResult Index() {
            var videos = Channel9.Videos();
            return View(videos);
        }

        public ActionResult Player(string id) {
            var video = Channel9.GetVideo(id) ?? new Ch9Video();
            return View(video);
        }

        public override ActionResult Clear() {
            Channel9.Clear();

            return base.Clear();
        }
        
    }
}