namespace Tonvo.MVVM.Models
{
    public interface IModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
