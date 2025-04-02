using homework.Models;

namespace homework.Services {
    public interface INoteService {
        // Сохранение заметки (в файл или в браузер)
        void Save(Note note);

        // Загрузка заметки (из файла или из хранилища браузера)
        Note Load(string id);

        // Оторажение всех заметок
        List<Note> LoadAll();
    }
}
