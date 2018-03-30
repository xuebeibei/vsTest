using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SickRoom
    {
        public List<CommContracts.SickRoom> GetAllSickRoom(string strName = "")
        {
            List<CommContracts.SickRoom> list = new List<CommContracts.SickRoom>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SickRooms
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.SickRoom ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SickRoom, CommContracts.SickRoom>();
                    });
                    var mapper = config.CreateMapper();
                    //CommContracts.Department department = new CommContracts.Department();
                    //department.ID = ass.Department.ID;
                    //department.Name = ass.Department.Name;
                    //department.ParentID = ass.Department.ParentID;
                    //department.IsDoctorDepartment = (ass.Department.DepartmentEnum == DAL.DepartmentEnum.临床科室);

                    CommContracts.SickRoom temp = mapper.Map<CommContracts.SickRoom>(ass);
                    //temp.Department = department;
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveSickRoom(CommContracts.SickRoom sickRoom)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.SickRoom, DAL.SickRoom>();
                });
                var mapper = config.CreateMapper();

                DAL.SickRoom temp = new DAL.SickRoom();
                temp = mapper.Map<DAL.SickRoom>(sickRoom);

                ctx.SickRooms.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteSickRoom(int sickRoomID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SickRooms.FirstOrDefault(m => m.ID == sickRoomID);
                if (temp != null)
                {
                    ctx.SickRooms.Remove(temp);
                }

                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateSickRoom(CommContracts.SickRoom sickRoom)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SickRooms.FirstOrDefault(m => m.ID == sickRoom.ID);
                if (temp != null)
                {
                    temp.Name = sickRoom.Name;
                    temp.SickRoomEnum = (DAL.SickRoomEnum)sickRoom.SickRoomEnum;
                    temp.DepartmentID = sickRoom.DepartmentID;
                    temp.Address = sickRoom.Address;
                }
                else
                {
                    return false;
                }

                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }
    }
}
