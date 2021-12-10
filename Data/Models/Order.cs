using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { set; get; }

        [Display(Name = "Введите имя")]
        [StringLength(20,ErrorMessage ="{0} должно быть от {2} до {1} символов длинной.",MinimumLength =2)]
        
        [Required(ErrorMessage ="Длина имени не менее 2 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(20, ErrorMessage = "{0} должна быть от {2} до {1} символов длинной.", MinimumLength = 2)]
        [Required(ErrorMessage = "Длина имени не менее 2 символов")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(30, ErrorMessage = "{0} должен быть от {2} до {1} символов длинной.", MinimumLength = 5)]
        [Required(ErrorMessage = "Длина адресса не менее 5 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [StringLength(15, ErrorMessage = "{0} должен быть от {2} до {1} символов длинной.", MinimumLength = 7)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не менее 7 символов")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "{0} должен быть от {2} до {1} символов длинной.", MinimumLength = 10)]
        [Required(ErrorMessage = "Длина email не менее 10 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
