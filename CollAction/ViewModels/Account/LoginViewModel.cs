﻿using System.ComponentModel.DataAnnotations;

namespace CollAction.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        [Required]
        public string ReturnUrl { get; set; }

        [Required]
        public string ErrorUrl { get; set; }
    }
}