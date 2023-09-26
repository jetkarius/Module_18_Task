using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using System.Xml.Linq;

namespace Module_18_Task
{
    internal class Downloader
    {
        public void Operation()
        {

            Console.WriteLine("\n Введите Url Видео.");
            string videoUrl = Console.ReadLine();

            GetAsync(videoUrl);

            Console.ReadKey();

            Console.WriteLine("\n Скачиваю.");

            DownloadAsync(videoUrl);

            Console.ReadKey();

            static async Task GetAsync(string videoUrl)
            {
                var youtube = new YoutubeClient();
                //Console.WriteLine("\n Получаю информацию о видео.");

                var video = await youtube.Videos.GetAsync(videoUrl);

                //Console.WriteLine($"\n{videoUrl}");
                Console.WriteLine($"\n{video.Title}");
                //Console.WriteLine($"\n{video.UploadDate.DateTime.ToLongDateString()}");
                //Console.WriteLine($"\n{video.Duration}");
                Console.WriteLine("\n Нажмите любую клавишу для продолжения.");
            }

            static async Task DownloadAsync(string videoUrl)
            {
                var youtube = new YoutubeClient();

                var video = await youtube.Videos.GetAsync(videoUrl);
                
                using var progress = new ProgressIndicator();
                await youtube.Videos.DownloadAsync(videoUrl, "title.mp4",  progress);
                
                Console.WriteLine("Скачивание завершено.");

                string src = @"T:\source\repos\Module_18_Task\Module_18_Task\bin\Debug\net6.0\title.mp4";

                var newName = video.Title;

                string dest = @"T:\YouTubeVideo\\" + newName + ".mp4";

                
                try
                {
                    File.Move(src, dest);

                    if (!File.Exists(src))
                    {
                        Console.WriteLine("Файл успешно перемещён и переименован.");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Возникли проблемы", e.ToString());
                }
               
            }
        }
    }
}
