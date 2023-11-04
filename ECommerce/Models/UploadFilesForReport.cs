﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class UploadFilesForReport
    {
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}