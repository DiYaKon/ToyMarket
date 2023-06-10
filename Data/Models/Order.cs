using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToyMarket.Data.Models
{
    public class Order
    {
        [BindNever] //не буде відображатись на формі
        public int id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина ім'я не більше 20 символів")]
        public string name { get; set; }
        [Display(Name = "Введіть прізвище")]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина прізвища не більше 20 символів")]
        public string surname { get; set; }
        [Display(Name = "Введіть адресу")]
        [StringLength(80)]
        [Required(ErrorMessage = "Довжина адреси не більше 80 символів")]
        public string address { get; set; }
        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина номера не більше 20 символів")]
        public string phone { get; set; }
        [Display(Name = "Введіть пошту")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Довжина email не більше 25 символів")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)] //поле не відображається в коді
        public DateTime orderTime { get; set; }
        [BindNever]
        public List<OrderDetail> orderDetails { get; set; }
    }
}
