﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class HomeBLL : BaseBLL
    {
        public string GetMenuByPersonId(string personId)
        {
            HomeRepository home = new HomeRepository();
            return home.GetMenuByPersonId(personId);
        }
    }
}
