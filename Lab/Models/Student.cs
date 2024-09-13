using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab.Models
{
    public class Student
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Tên là bắt buộc")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có độ dài từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        
        [Required(ErrorMessage = "Email là bắt buộc")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Địa chỉ email phải có đuôi gmail.com")]
        public string? Email { get; set; }

        
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Mật khẩu phải có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        public Branch? Branch { get; set; }
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải trong khoảng từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        public DateTime DateOfBirth { get; set; }

        public byte[] ProfilePicture { get; set; }

        
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        [Required(ErrorMessage = "Điểm là bắt buộc")]
        public double Grade { get; set; }
    }
}
