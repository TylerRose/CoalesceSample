﻿using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalesceSample.Data.Models;
public class Image
{
    public int ImageId { get; set; }
    public byte[]? Content { get; set; }
}
