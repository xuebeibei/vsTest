﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;
using System.Data;
using System.Globalization;
using System.Collections;

namespace BLL
{
    public class Triage
    {
        private CommContracts.Triage triage;
        public Triage()
        {
            triage = new CommContracts.Triage();
        }

        public bool SaveTriage(int nDoctorID, int nRegistrationID)
        {
        //    if (nDoctorID <= 0)
        //    {
        //        return false;
        //    }
        //    if (nRegistrationID <= 0)
        //    {
        //        return false;
        //    }

        //    using (DAL.HisContext ctx = new DAL.HisContext())
        //    {
        //        var aa = ctx.Triages.FirstOrDefault();
        //        if (aa == null)
        //        {
        //            aa = new DAL.Triage();
        //        }

        //        var uu = ctx.Employees.FirstOrDefault();
        //        if (uu == null)
        //        {
        //            uu = new DAL.Employee();
        //            uu.LoginName = "uu";
        //            uu.Password = "uu";
        //            uu = DAL.LoginStatus.login;
        //            uu.LastLogin = DateTime.Now;
        //            ctx.Users.Add(uu);
        //            ctx.SaveChanges();
        //        }

        //        aa.DoctorID = nDoctorID;
        //        aa.RegistrationID = nRegistrationID;
        //        aa.User = uu;
        //        aa.DateTime = DateTime.Now;
        //        ctx.Triages.Add(aa);
        //        try
        //        {
        //            ctx.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            string str = ex.Message;
        //            return false;
        //        }
        //    }

        //    return true;

        return false;
        }
    }
}
