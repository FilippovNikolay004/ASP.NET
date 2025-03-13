using System.ComponentModel.DataAnnotations.Schema;

namespace homework.Models {
    public class TeacherSubjectGroup {
        public int Id { get; set; }


        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }


        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }


        [ForeignKey("GroupId")]
        public Groups Group { get; set; }
    }
}
