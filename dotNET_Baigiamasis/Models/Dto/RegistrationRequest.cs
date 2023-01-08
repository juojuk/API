﻿namespace dotNET_Baigiamasis.Models.Dto
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// (1, "admin"),(2, "editor"),(3, "viewer")
        /// </summary>
        public int RoleId { get; set; }
    }
}
