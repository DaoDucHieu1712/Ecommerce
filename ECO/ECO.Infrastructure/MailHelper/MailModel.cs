﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.MailHelper
{
    public class MailModel
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
