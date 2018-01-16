﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum SickRoomEnum
    {
        普通病房,
        重症病房
    }

    [DataContract]
    public class SickRoom
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public SickRoomEnum SickRoomEnum { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public Department Department { get; set; }
        //[DataMember]
        //public List<SickBed> SickBeds { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            var ro = obj as SickRoom;
            if (ro == null)
                return false;
            if (ro.ID != this.ID)
                return false;
            return true;
        }
    }
}
