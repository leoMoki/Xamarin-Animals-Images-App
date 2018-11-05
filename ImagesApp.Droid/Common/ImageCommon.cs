using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;

namespace ImagesApp.Droid.Common
{
    public class ImageCommon
    {
        public async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
        {
            Bitmap imageBitmap = null;

            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = await webClient.DownloadDataTaskAsync(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                imageBitmap = null;
            }

            return imageBitmap;
        }

        public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                imageBitmap = null;
            }

            return imageBitmap;
        }

        public Java.IO.File createImageFile(string guidFoto, Java.IO.File storageDir)
        {
            //StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            //StrictMode.SetVmPolicy(builder.Build());

            String imageFileName = guidFoto;
            Java.IO.File image = Java.IO.File.CreateTempFile(
                    imageFileName,
                    ".jpg",
                    storageDir
            );

            image.SetWritable(true);
            image.SetReadable(true);

            image.RenameTo(new Java.IO.File(guidFoto + ".jpg"));

            return image;
        }

        public string FileToString64(Bitmap bitmap, string routeEx)
        {
            string result = string.Empty;

            try
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);

                    var bytes = stream.ToArray();
                    var str = Convert.ToBase64String(bytes);
                    result = str;
                    return result;
                }
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        private void PreviewFoto(Context Context, string file, Java.IO.File storageDir)
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse(storageDir + "/" + file);

            Intent intent = new Intent();
            intent.SetAction(Intent.ActionView);

            intent.SetDataAndType(uri, "image/*");
            Context.StartActivity(intent);
        }
    }
}