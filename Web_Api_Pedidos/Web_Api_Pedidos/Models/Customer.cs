using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Pedidos.Models
{
    public  class Customer
    {
        //public Customer()
        //{
        //    Orders = new HashSet<Order>();
        //    CustomerTypes = new HashSet<CustomerDemographic>();
        //}

        [Required(ErrorMessage = @"Campo requerido")]
        [StringLength(5, ErrorMessage = @"Campo excede el tamanio")]
        public string CustomerId { get; set; } = null!;
        //
        [Required(ErrorMessage = @"Campo requerido")]
        [StringLength(40, ErrorMessage = @"Campo excede el tamanio")]
        public string CompanyName { get; set; } = null!;
        //

        [StringLength(30, ErrorMessage = @"Campo excede el tamanio")]
        public string? ContactName { get; set; }
        //
        
        [StringLength(30, ErrorMessage = @"Campo excede el tamanio")]
        public string? ContactTitle { get; set; }
        //
       
        [StringLength(60, ErrorMessage = @"Campo excede el tamanio")]
        public string? Address { get; set; }
        //
       
        [StringLength(15, ErrorMessage = @"Campo excede el tamanio")]        
        public string? City { get; set; }
        //
        
        [StringLength(15, ErrorMessage = @"Campo excede el tamanio")]                
        public string? Region { get; set; }
        //
       
        [StringLength(10, ErrorMessage = @"Campo excede el tamanio")]
        public string? PostalCode { get; set; }
        //
        
        [StringLength(15, ErrorMessage = @"Campo excede el tamanio")]
        public string? Country { get; set; }
        //
       
        [StringLength(24, ErrorMessage = @"Campo excede el tamanio")]
        public string? Phone { get; set; }
        //
        
        [StringLength(24, ErrorMessage = @"Campo excede el tamanio")]
        public string? Fax { get; set; }

        //Como se puede corregir estos indices, ya que si no los comento, afecta desde el swagger,para agregar los clientes porque pide a más tablas

        //public virtual ICollection<Order> Orders { get; set; }

        //public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; }
    }

    

}
