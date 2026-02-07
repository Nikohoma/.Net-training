namespace SocialMediaPostManagement
{
    /// <summary>
    /// User Type
    /// </summary>
    public class User
    {
        private static int _counter = 1;
        public string UserId { get; } = "";
        public string UserName { get; set; }
        public string Bio { get; set; }
        public int FollowersCount { get; set; }

        public List<string> Following = new List<string>();

        // Constructor
        public User()
        {
            UserId += _counter++.ToString();
        }
    }

    /// <summary>
    /// Post Type
    /// </summary>
    public class Post
    {
        private static int _counter = 100;
        public string PostId { get; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public string PostType { get; set; }
        public int Likes { get; set; }

        public List<string> Comments = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        public Post()
        {
            PostId = _counter++.ToString();
        }
    }

    /// <summary>
    /// Social Media Manager Class
    /// </summary>
    public class SocialMediaManager
    {
        public static List<User> Users = new List<User>();   // Store all users
        public static List<Post> Posts = new List<Post>();   // Store all posts

        /// <summary>
        /// Method to register users of User Type and store them into users list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="bio"></param>
        public void RegisterUser(string userName, string bio)
        {
            User u = new User()
            {
                UserName = userName,
                Bio = bio
            };
            Users.Add(u);
            Console.WriteLine("User added successfully.");
        }

        /// <summary>
        /// Method to create Post with given inputs and store them into posts list.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        public void CreatePost(string userId, string content, string type)
        {
            Post p = new Post();
            p.UserId = userId;
            p.Content = content;
            p.PostType = type;
            p.PostTime = DateTime.Now;

            Posts.Add(p);
            Console.WriteLine("Post Created Successfully.");
        }

        /// <summary>
        /// Method to update likes on given post.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        public void LikePost(string postId, string userId)
        {
            foreach (Post p in Posts)
            {
                if (p.PostId == postId && p.UserId == userId)
                {
                    p.Likes += 1;
                    Console.WriteLine($"{userId} liked {postId}");
                }
            }

        }

        /// <summary>
        /// Method to add comment to the given post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <param name="comment"></param>
        public void AddComment(string postId, string userId, string comment)
        {
            foreach (Post p in Posts)
            {
                if (p.PostId == postId && p.UserId == userId)
                {
                    p.Comments.Add(comment);
                    Console.WriteLine($"User {userId} commented on Post {postId}");
                }
            }
        }

        /// <summary>
        /// Method to group posts by user
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, List<Post>> GroupPostsByUser()
        {
            return Posts.GroupBy(p => p.UserId).ToDictionary(p => p.Key, p => p.ToList());
        }

        /// <summary>
        /// Method to get posts with likes > minLikes
        /// </summary>
        /// <param name="minLikes"></param>
        /// <returns>List</returns>
        public List<Post> GetTrendingPosts(int minLikes)
        {
            return Posts.Where(p => p.Likes >= minLikes).ToList();
        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Instance
            SocialMediaManager smm = new SocialMediaManager();
            // Calling RegisterUser()
            smm.RegisterUser("Nikhil", "Something in Bio.");
            // Creating Post
            smm.CreatePost("1", "Post 101 created", "Text");
            smm.CreatePost("1", "Video Post created", "Video");
            smm.CreatePost("12", "Post 102 created", "Image");
            // Like Post
            smm.LikePost("101", "1");
            // Add Comment to the post
            smm.AddComment("102", "1", "Image Post");
            // Get All Posts grouped by usee
            Console.WriteLine("Posts by Users: ");
            foreach (var s in smm.GroupPostsByUser())
            {
                Console.WriteLine($"User ID : {s.Key}");
                foreach (var v in s.Value)
                {
                    Console.WriteLine($" - Post Content : {v.Content}");
                }
            }
            // Get all trending posts
            Console.WriteLine("Trending Posts: ");
            foreach (var p in smm.GetTrendingPosts(1))
            {
                Console.WriteLine($"Post Id : {p.PostId} , Post Content : {p.Content}, Post Likes : {p.Likes}");
            }


        }
    }



}