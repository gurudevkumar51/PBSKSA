using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AdminDal.Entity
{
    public class NewsModel
    {
        [Display(Name = "News Id")]
        public int News_Id { get; set; }

        [Display(Name = "News Title")]
        [StringLength(50, ErrorMessage = "News title cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "Please provide news title.")]
        public string News_Title { get; set; }

        [Display(Name = "Content")]
        [StringLength(2000, ErrorMessage = "News title cannot be longer than 2000 characters.")]
        [Required(ErrorMessage = "Please enter news content.")]
        [UIHint("tinymce_jquery_full")]
        public string News_Content { get; set; }

        public Nullable<int> Admin_Id { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Entered_Date { get; set; }
        [Display (Name="Active Status")]
        [Required(ErrorMessage = "Please select news status.")]
        [UIHint("Is_Active")]
        public bool Is_Active { get; set; }
        public Nullable<bool> Is_Deleted { get; set; }

        public Admin Admin { get; set; }
    }
}
