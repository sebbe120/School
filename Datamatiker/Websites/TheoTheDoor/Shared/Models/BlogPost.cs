using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoTheDoor.Shared.Models
{
    /// <summary>
    /// A BlogPost consists of a header:PostTitle, a short description of the week:PostIntroduction,
    /// and sections for each day of the work week:PostContentMonday-PostContentFriday, and lastly a footer:PostedDate
    /// All rendered in the order: Header-Description-Sections-Footer
    /// </summary>
    public class BlogPost
    {
        public int PostId { get; set; }
        // The header which will be the week
        public string PostTitle { get; set; }
        // The overall description / introduction to the weeks content
        public string PostIntroduction { get; set; }
        public DateOnly PostedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        // Below are sections for each day of the work week. Not all days will be recorded, so they can be null
        public string PostContentMonday { get; set; } = "";
        public string PostContentTuesday { get; set; } = "";
        public string PostContentWednesday { get; set; } = "";
        public string PostContentThursday { get; set; } = "";
        public string PostContentFriday { get; set; } = "";
    }
}
