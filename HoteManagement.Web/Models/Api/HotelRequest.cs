using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class HotelRequest
    {
        [Required(ErrorMessage = "请填写酒店名称")]
        public string HotelName { get; set; }

        public bool IsChain { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = "请选择过期时间")]
        public DateTime Expiretime { get; set; }

    }

    public class HotelEditRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请填写酒店名称")]
        public string HotelName { get; set; }

        public bool IsChain { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = "请选择过期时间")]
        public DateTime Expiretime { get; set; }

        public HotelEditRequest ParentHotel { get; set; }

    }

}