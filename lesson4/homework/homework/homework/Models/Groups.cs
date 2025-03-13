using StudentsMVC;

namespace homework.Models {
    public class Groups {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }


        public ICollection<Student> Student { get; set; }
        public ICollection<TeacherSubjectGroup> TeacherSubjectGroups { get; set; }
    }
}
