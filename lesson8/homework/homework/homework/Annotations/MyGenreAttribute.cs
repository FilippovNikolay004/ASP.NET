using System.ComponentModel.DataAnnotations;

namespace homework.Annotations {
    public class MyGenreAttribute :ValidationAttribute { 
        private readonly string[] _myGenres;

        public MyGenreAttribute(string[] genres) {
            _myGenres = genres;
        }

        public override bool IsValid(object? value) {
            if (value == null) 
                return false;

            string strValue = value.ToString();
            string[] inputGenres = strValue.Split(',');

            foreach (string inputGenre in inputGenres) {
                string trimmedGenre = inputGenre.Trim().ToLower();

                if (!_myGenres.Contains(trimmedGenre, StringComparer.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }
    }
}
