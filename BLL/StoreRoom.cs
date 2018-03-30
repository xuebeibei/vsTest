using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreRoom
    {
        public List<CommContracts.StoreRoom> GetAllStoreRoom(string strName = "")
        {
            List<CommContracts.StoreRoom> list = new List<CommContracts.StoreRoom>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.StoreRooms
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.StoreRoom ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.StoreRoom, CommContracts.StoreRoom>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.StoreRoom temp = mapper.Map<CommContracts.StoreRoom>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveStoreRoom(CommContracts.StoreRoom storeRoom)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.StoreRoom, DAL.StoreRoom>();
                });
                var mapper = config.CreateMapper();

                DAL.StoreRoom temp = new DAL.StoreRoom();
                temp = mapper.Map<DAL.StoreRoom>(storeRoom);

                ctx.StoreRooms.Add(temp);
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

        public bool DeleteStoreRoom(int storeRoomID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.StoreRooms.FirstOrDefault(m => m.ID == storeRoomID);
                if (temp != null)
                {
                    ctx.StoreRooms.Remove(temp);
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

        public bool UpdateStoreRoom(CommContracts.StoreRoom storeRoom)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.StoreRooms.FirstOrDefault(m => m.ID == storeRoom.ID);
                if (temp != null)
                {
                    temp.Name = storeRoom.Name;
                    temp.StoreRoomEnum = (DAL.StoreRoomEnum)storeRoom.StoreRoomEnum;
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
