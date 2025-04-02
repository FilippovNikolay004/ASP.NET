using homework.Models;
using System.IO;
using System.Text.Json;

namespace homework.Services {
    public class FileNoteService : INoteService {
        private readonly string directory = @"D:\Step\3 course\ASP.NET\lesson12\homework\notes.json";

        public void Save(Note note) {
            List<Note> notes = LoadAll();
            note.Id = GetNextId().ToString();
            note.CreatedAt = DateTime.Now;
            notes.Add(note);

            // Записываем в JSON
            string json = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(directory, json);
        }
        public Note Load(string id) {
            List<Note> notes = LoadAll();
            return notes.FirstOrDefault(n => n.Id == id);
        }

        public List<Note> LoadAll() {
            if (!File.Exists(directory)) {
                return new List<Note>();
            }

            string json = File.ReadAllText(directory);
            return JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
        }

        private int GetNextId() {
            List<Note> notes = LoadAll();
            return notes.Count == 0 ? 1 : notes.Max(n => int.Parse(n.Id)) + 1;
        }
    }
}
