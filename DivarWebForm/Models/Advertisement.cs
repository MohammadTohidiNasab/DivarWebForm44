using System;
using System.Collections.Generic;

namespace DivarWebForm.Models
{
    public enum CategoryType
    {
        کتاب,
        خانه,
        موبایل,
        ماشین
    }

    public class Advertisement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }

        public int Price { get; set; }

        public CategoryType Category { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
