using homework.Models;

namespace homework.Services {
    public class BrowserNoteService : INoteService {
        private static List<Note> _notes = new List<Note>(); // Храним заметки в памяти
        private static int _nextId = 1; // Счётчик ID заметок

        public void Save(Note note) {
            note.Id = _nextId.ToString();
            note.CreatedAt = DateTime.Now;
            _notes.Add(note);
            _nextId++;
        }

        public Note? Load(string id) {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public List<Note> LoadAll() {
            return _notes;
        }
    }
}
