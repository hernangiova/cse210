using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "Learning C# for beginners",
            "Peter Programer",
            2000
        );

        video1.AddComment(new Comment("Rodrigo", "This was a great video!!"));
        video1.AddComment(new Comment("Edelvais", "I will be waiting for the nex chapter"));
        video1.AddComment(new Comment("John", "Great explanation!"));

        Video video2 = new Video(
            "Duendes captadores en camara PT4",
            "DocTops",
            1800
        );

        video2.AddComment(new Comment("Giovani", "This video made me feel baddd!"));
        video2.AddComment(new Comment("Heissel", "I want more videos like this"));
        video2.AddComment(new Comment("Xiomara", "There is a screamer in min 10:05 ahahahha"));

        Video video3 = new Video(
            "Missin You Like This",
            "Post Malone",
            180
        );

        video3.AddComment(new Comment("Peter", "What a beautiful song, I love it"));
        video3.AddComment(new Comment("Travis", "I cried a lot with the song"));
        video3.AddComment(new Comment("John", "This album is fireee"));
        video3.AddComment(new Comment("Ternus", "Love u posty!!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()}");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}