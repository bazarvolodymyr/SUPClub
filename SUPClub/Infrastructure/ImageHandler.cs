namespace SUPClub.Infrastructure
{
    public class ImageHandler
    {
        private IWebHostEnvironment _hostEnvironment;
        public ImageHandler(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task<string> SaveImg(IFormFile img)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "img/", img.FileName);
            await using FileStream stream = new FileStream(path, FileMode.Create);
            await img.CopyToAsync(stream);
            return path;
        }
    }
}
