using System;
using System.Collections.Generic;

namespace Service.Contract.Models
{
    public class UserViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<PointViewModel> Points { get; set; }
    }
}