using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VijayTmBar.Models
{
    public class tbl_Employee
    {
        ////////////////////////////

        [Key]
        public int ID { get; set; }

        //public int BranchID { get; set; }

        [Required(ErrorMessage = "Enter Your Full Name")]
        [DisplayName("Full Name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Name is not valid")]
        [MaxLength(50)]
        public string FullName { get; set; }

        public string EmpCode { get; set; }

        [Required(ErrorMessage = "Enter Your Mobile Number")]
        [DisplayName("Mobile Number")]
        [RegularExpression("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Mobile Number is not valid")]
        [MaxLength(10)]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Enter Your Whatsapp Number")]
        [DisplayName("Whatspp No.")]
        [RegularExpression("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Mobile Number is not valid")]
        [MaxLength(10)]
        public string WhatsAppNo { get; set; }

        //[Required(ErrorMessage = "Enter Your Email")]
        //[DisplayName("Email ID")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        //[MaxLength(50)]
        //public string StudEmail { get; set; }

        [DisplayName("Address")]
        public string FullAddress { get; set; }

        //[Required]
        //[DisplayName("City")]
        //public string StudCity { get; set; }

        //[Required]
        //[DisplayName("Dist")]
        //public string StudDist { get; set; }

        [Required]
        [DisplayName("Password")]
        public string UPassword { get; set; }

        public string Sts { get; set; }

        // public bool isChangePassword { get; set; }

        public string Token { get; set; }

        public string OTP { get; set; }

        public DateTime Edate { get; set; }

        // public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Enter Your Current Password")]
        [DisplayName("Current Password")]
        [MaxLength(50)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Enter Your New Password")]
        [DisplayName("New Password")]
        [MaxLength(50)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Re-Enter New Password")]
        [DisplayName("Re-Enter New Password")]
        [MaxLength(50)]
        public string ReEnterNewPassword { get; set; }

        //[Required(ErrorMessage = "Upload Your Photo")]
        // public string StudPhoto { get; set; }

        //public string StudProfile { get; set; }

        //public bool IsScholarComplete { get; set; }

        //public string RegNo { get; set; }
        public string DeviceId { get; set; }
        public string Type { get; set; }  
        public string InLate { get; set; }
        public string InLong { get; set; }
        public int Distance_Mtr { get; set; }




    }

}
#if false // Decompilation log
'40' items in cache
------------------
Resolve: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll'
------------------
Resolve: 'System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
Found single assembly: 'System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.ComponentModel.DataAnnotations.dll'
------------------
Resolve: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.dll'
#endif