﻿using System.Linq;
 
using System.Data;
using System;
namespace DAL
{
    public abstract class BaseViewRepository
    {
        public string Start_Time { get { return "Start_Time"; } }
        public string End_Time { get { return "End_Time"; } }
        public string Start_Int { get { return "Start_Int"; } }
        public string End_Int { get { return "End_Int"; } }
        public string End_String { get { return "End_String"; } }
        public string DDL_String { get { return "DDL_String"; } }
    }
}
