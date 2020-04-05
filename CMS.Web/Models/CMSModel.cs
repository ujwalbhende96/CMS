using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Models
{
    public class CMSModel
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string mobileNo { get; set; }
    }
}