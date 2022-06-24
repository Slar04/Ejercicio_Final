using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Web_Api_Pedidos.Models
{

    public class ApiResult 
    {
        [Key]
        public bool ok { get; set; }

        public string msg { get; set; }

        public object data { get; set; }
        public List<string> col { get; set; }
        public List<object> rows { get; set; }

    }
}
