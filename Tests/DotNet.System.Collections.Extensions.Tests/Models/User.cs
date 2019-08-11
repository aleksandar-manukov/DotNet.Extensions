namespace DotNet.System.Collections.Extensions.Tests.Models
{
    public class User
    {
        public User(int id, int score)
        {
            this.Id = id;
            this.Score = score;
        }

        public int Id { get; set; }
        public int Score { get; set; }
    }
}