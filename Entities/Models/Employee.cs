using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(10, ErrorMessage = "First name cannot be longer than 20 characters")]
        public string FirstName { get; set; }

        [StringLength(60, ErrorMessage = "Address cannot be longer than 60 characters")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "City cannot be longer than 15 characters")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "Region cannot be longer than 15 characters")]
        public string Region { get; set; }

        [StringLength(10, ErrorMessage = "PostalCode cannot be longer than 10 characters")]
        public string PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "Country cannot be longer than 15 characters")]
        public string Country { get; set; }
    }
}
