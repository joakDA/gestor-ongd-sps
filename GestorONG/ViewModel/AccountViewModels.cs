using GestorONG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestorONG.ViewModel
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        [StringLength(256, ErrorMessage = "El campo \"Correo electrónico\" no puede tener más de 256 caracteres.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        [StringLength(15, ErrorMessage = "El campo \"Nombre de usuario\" no puede tener más de 15 caracteres.")]
        public string UserName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(100, ErrorMessage = "El nombre de usuario no debe tener más de 100 carácteres.")]
        ///<summary>
        ///Correo electrónico del usuario. Será también lo que utilice para iniciar sesión.
        /// </summary>
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        ///<summary>
        ///Contraseña del usuario. Luego se cifrará para su comprobación con la base de datos.
        /// </summary>
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        ///<summary>
        ///Si se activa el check, se guardarán los datos del usuario para próximas veces (hasta que se borre).
        /// </summary>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// Model for register view
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// ID del registro de la base de datos.
        /// </summary>
        public string Id { get; set; }
        [Required]
        [Display(Name = "UserRoles")]
        /// <summary>
        /// Roles de usuario que va a tener asignados.
        /// </summary>
        public string[] UserRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [StringLength(100, ErrorMessage = "El nombre de usuario no debe tener más de 100 carácteres.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Model for list users with it roles in view
    /// </summary>
    public class UsersViewModel
    {
        #region PUBLIC_MEMBER_PROPERTIES

        /// <summary>
        /// List of users.
        /// </summary>
        public IList<ApplicationUser> users { get; set; }

        /// <summary>
        /// List of roles
        /// </summary>
        public IList<string> roles { get; set; }

        #endregion
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}