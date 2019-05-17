using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class SignUpInfoService
    {
        /***/
        [Required(ErrorMessage = "UserName required !")]
        [Display(Name = "User Name: ")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "EmailAddress required !")]
        [Display(Name ="Email Address: ")]
        public string EmailAddress { set; get; }
        [Required(ErrorMessage = "Password required !")]
        [Display(Name ="Password: ")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Confirm Password required !")]
        [Display(Name ="Confirm Password: ")]
        public string ConfirmPassword { set; get; }
        /***/
        /***/
        [Required(ErrorMessage = "User Name required !")]
        [Display(Name = "User Name: ")]
        public string UserLoginName { set; get; }
        [Required(ErrorMessage = "Password required !")]
        [Display(Name = "Password: ")]
        public string UserLoginPassword { set; get; }
        /***/
        [Required(ErrorMessage = "Password image !")]
        public HttpPostedFileBase Source { get; set; }
    }
}