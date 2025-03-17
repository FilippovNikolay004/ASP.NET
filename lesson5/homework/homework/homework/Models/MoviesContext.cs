using Microsoft.EntityFrameworkCore;

namespace homework.Models {
    public class MoviesContext : DbContext {
        public DbSet<Movies> Movies { get; set; }
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) {
            if (Database.EnsureCreated()) {
                Movies?.AddRange(
                    new Movies {
                        MoveName = "Джентльмены",
                        Director = "Гай Ричи",
                        Genre = "Боевик, комедия",
                        ReleaseYear = 2019,
                        PathToPoster = "/images/gentlemen.jpg",
                        ShortDescription = "Британский наркобарон пытается продать свою империю американским миллиардерам."
                    },
                    new Movies {
                        MoveName = "Начало",
                        Director = "Кристофер Нолан",
                        Genre = "Фантастика, боевик, триллер",
                        ReleaseYear = 2010,
                        PathToPoster = "/images/inception.jpg",
                        ShortDescription = "Вор, специализирующийся на краже секретов через сны, получает шанс на искупление."
                    },
                    new Movies {
                        MoveName = "Интерстеллар",
                        Director = "Кристофер Нолан",
                        Genre = "Фантастика, драма, приключения",
                        ReleaseYear = 2014,
                        PathToPoster = "/images/interstellar.jpg",
                        ShortDescription = "Команда исследователей отправляется в путешествие через червоточину в поисках нового дома для человечества."
                    },
                    new Movies {
                        MoveName = "Легенда",
                        Director = "Брайан Хелгеленд",
                        Genre = "Криминал, триллер, биография",
                        ReleaseYear = 2015,
                        PathToPoster = "/images/legend.jpg",
                        ShortDescription = "История близнецов Крэй, известных гангстеров 1960-х годов в Лондоне."
                    },
                    new Movies {
                        MoveName = "Аватар",
                        Director = "Джеймс Кэмерон",
                        Genre = "Фантастика, боевик, приключения",
                        ReleaseYear = 2009,
                        PathToPoster = "/images/avatar.jpg",
                        ShortDescription = "Бывший морпех отправляется на планету Пандора, чтобы добыть ценный ресурс, и оказывается втянутым в конфликт между людьми и местными жителями."
                    },
                    new Movies {
                        MoveName = "Астрал",
                        Director = "Джеймс Ван",
                        Genre = "Ужасы, триллер",
                        ReleaseYear = 2010,
                        PathToPoster = "/images/insidious.jpg",
                        ShortDescription = "Семья пытается спасти своего сына, который впал в кому и оказался в потустороннем мире."
                    },
                    new Movies {
                        MoveName = "Гнев человеческий",
                        Director = "Гай Ричи",
                        Genre = "Боевик, триллер",
                        ReleaseYear = 2021,
                        PathToPoster = "/images/wrathofman.jpg",
                        ShortDescription = "Таинственный человек устраивается на работу в инкассаторскую компанию, чтобы отомстить за смерть сына."
                    },
                    new Movies {
                        MoveName = "Железный человек",
                        Director = "Джон Фавро",
                        Genre = "Фантастика, боевик, приключения",
                        ReleaseYear = 2008,
                        PathToPoster = "/images/ironman.jpg",
                        ShortDescription = "Гениальный изобретатель Тони Старк создает высокотехнологичный костюм, чтобы бороться со злом."
                    },
                    new Movies {
                        MoveName = "Темный рыцарь",
                        Director = "Кристофер Нолан",
                        Genre = "Боевик, триллер, криминал",
                        ReleaseYear = 2008,
                        PathToPoster = "/images/thedarkknight.jpg",
                        ShortDescription = "Бэтмен противостоит Джокеру, который погружает Готэм в хаос."
                    },
                    new Movies {
                        MoveName = "Зеленая книга",
                        Director = "Питер Фаррелли",
                        Genre = "Драма, комедия, биография",
                        ReleaseYear = 2018,
                        PathToPoster = "/images/greenbook.jpg",
                        ShortDescription = "Итало-американский вышибала нанимается водителем афроамериканского пианиста во время тура по южным штатам США в 1960-х годах."
                    },
                    new Movies {
                        MoveName = "1+1",
                        Director = "Оливье Накаш, Эрик Толедано",
                        Genre = "Драма, комедия, биография",
                        ReleaseYear = 2011,
                        PathToPoster = "/images/intouchables.jpg",
                        ShortDescription = "Парализованный аристократ нанимает в качестве помощника молодого человека из неблагополучного района."
                    },
                    new Movies {
                        MoveName = "Джокер",
                        Director = "Тодд Филлипс",
                        Genre = "Триллер, драма, криминал",
                        ReleaseYear = 2019,
                        PathToPoster = "/images/joker.jpg",
                        ShortDescription = "История происхождения Артура Флека, человека, который становится Джокером."
                    },
                    new Movies {
                        MoveName = "Паразиты",
                        Director = "Пон Джун-хо",
                        Genre = "Триллер, драма, комедия",
                        ReleaseYear = 2019,
                        PathToPoster = "/images/parasite.jpg",
                        ShortDescription = "Бедная семья постепенно внедряется в жизнь богатой семьи."
                    },
                    new Movies {
                        MoveName = "Бойцовский клуб",
                        Director = "Дэвид Финчер",
                        Genre = "Триллер, драма",
                        ReleaseYear = 1999,
                        PathToPoster = "/images/fightclub.jpg",
                        ShortDescription = "Человек, страдающий бессонницей, знакомится с загадочным Тайлером Дёрденом и основывает подпольный бойцовский клуб."
                    },
                    new Movies {
                        MoveName = "Криминальное чтиво",
                        Director = "Квентин Тарантино",
                        Genre = "Криминал, драма, комедия",
                        ReleaseYear = 1994,
                        PathToPoster = "/images/pulpfiction.jpg",
                        ShortDescription = "Несколько историй из жизни преступников в Лос-Анджелесе."
                    }
                );

                SaveChanges();
            }
        }
    }
}
