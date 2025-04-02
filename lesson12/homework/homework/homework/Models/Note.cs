namespace homework.Models {
    public class Note {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
    }
}
