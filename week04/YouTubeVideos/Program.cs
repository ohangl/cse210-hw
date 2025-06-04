using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create 4 videos
            var video1 = new Video("Blog: One Week in Argentina with Me", "AliceSmith", 420);
            var video2 = new Video("How to cook a GREAT Asado", "ChefMario", 260);
            var video3 = new Video("Tips to control your anxiety", "RelaxWithJen", 815);
            var video4 = new Video("How to integrate AI into your Chatbot", "AIMaster", 630);

            // Add 3-4 comments to each video
            video1.AddComment(new Comment("YairFonzalida", "I am from Argentina!"));
            video1.AddComment(new Comment("MaximaDura", "Wanna visit there!!"));
            video1.AddComment(new Comment("KankeUwu", "U should come to Brasil"));

            video2.AddComment(new Comment("AdriDuranq23", "Try adding lemon next time."));
            video2.AddComment(new Comment("Carina488", "Super helpful!"));
            video2.AddComment(new Comment("Mili_Sca", "Do you know how to do Matambre a la pizza?"));

            video3.AddComment(new Comment("ohangl", "Thanks, it helped me to sleep"));
            video3.AddComment(new Comment("Facuuuu11", "Can you post a meditation next?"));
            video3.AddComment(new Comment("BendyBen", "Thanks for the tips!! Need more of them."));

            video4.AddComment(new Comment("GrGayle", "Mind-blowing stuff on connectivity."));
            video4.AddComment(new Comment("CSStudent", "I dont know whats going on with my Chatbot, there is somewhere i can contact you? "));
            video4.AddComment(new Comment("Amaliagrannata71", "I love your work, thanks for sharing!"));
            video4.AddComment(new Comment("FanohMe", "Amazing!!"));

            // Put all videos into a List<Video>
            var allVideos = new List<Video> { video1, video2, video3, video4 };

            // Iterate through each video and display its details
            foreach (var vid in allVideos)
            {
                Console.WriteLine("======================================");
                Console.WriteLine($"Title: {vid.Title}");
                Console.WriteLine($"Author: {vid.Author}");
                Console.WriteLine($"Length: {vid.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {vid.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (var c in vid.GetAllComments())
                {
                    Console.WriteLine($" - {c.CommenterName}: {c.Text}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
