using System.Linq;
 
using System.Data;
using System;
using System.Data.Common;
using System.Data.Objects;

namespace DAL
{
    public abstract class BaseRepository
    {
        public string Start_Time { get { return "Start_Time"; } }
        public string End_Time { get { return "End_Time"; } }
        public string Start_Int { get { return "Start_Int"; } }
        public string End_Int { get { return "End_Int"; } }

        public string End_String { get { return "End_String"; } }
        public string DDL_String { get { return "DDL_String"; } }

        /// <summary>
        /// 提交保存，持久化到数据库
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <returns>受影响行数</returns>
        public int Save(SysEntities db)
        {
            return db.SaveChanges();
        }
        /// <summary>
        /// 判断是否存在引用
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="field">字典表对象</param>
        /// <returns>是否存在引用（true:是，false:否）</returns>
        public bool ExistsReference(SysEntities db, SysField field)
        {
            bool bResult = false;
            if (db != null && field != null)
            {
                String sql = String.Format("select Value o from SysEntities.{0} as o where o.{1}=@id", field.MyTables, field.MyColums);
                var reader = db.CreateQuery<DbDataReader>(sql, new ObjectParameter("id", field.Id));
                bResult = reader.Count() > 0;
            }

            return bResult;
        }
    }
}
