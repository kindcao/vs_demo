using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using Helper;

namespace DAL
{
    public class AddessDAL
    {

        public DataTable query(AddressModel model)
        {
            OracleParameter[] parameters = null;
            string str = "select t1.ID, t1.NAME,t2.name ANAME,t3.name ONAME  from T_ADDRESS t1 ,T_AREA t2, t_Operator t3  where t1.areaid=t2.id and t1.operatorid=t3.id order by id desc";
            //
            if (model.Name != null && model.Name.Trim().Length > 0)
            {
                str = "select t1.ID, t1.NAME,t2.name ANAME,t3.name ONAME  from T_ADDRESS t1 ,T_AREA t2, t_Operator t3  where t1.areaid=t2.id and t1.operatorid=t3.id and t1.NAME like :name  order by id desc";
                parameters = new OracleParameter[] { new OracleParameter(":name", OracleType.VarChar) };
                parameters[0].Value = OracleHelper.HandleLikeKey(model.Name);
            }
            return OracleHelper.ExecuteDataTable(OracleHelper.connstr, CommandType.Text, str, parameters);
        }
        public AddressModel queryById(Int32 id)
        {
            AddressModel model = new AddressModel();
            string str = "select ID,NAME,AREAID,OPERATORID from T_ADDRESS t where ID=" + id;
            DataTable dt = OracleHelper.ExecuteDataTable(OracleHelper.connstr, CommandType.Text, str, null);
            if (dt.Rows.Count == 1)
            {
                model.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                model.Name = dt.Rows[0]["NAME"].ToString();
                model.AreaId = Convert.ToInt32(dt.Rows[0]["AREAID"]);
                model.OperatorId = Convert.ToInt32(dt.Rows[0]["OPERATORID"]);
            }
            return model;
        }

        public DataTable queryArea()
        {
            string str = "select ID,NAME from T_AREA t";
            return OracleHelper.ExecuteDataTable(OracleHelper.connstr, CommandType.Text, str, null);
        }

        public DataTable queryOperator()
        {
            string str = "select ID,NAME from T_OPERATOR t";
            return OracleHelper.ExecuteDataTable(OracleHelper.connstr, CommandType.Text, str, null);
        }

        public int queryMaxId()
        {
            string str = "select max(ID) ID from T_ADDRESS t";
            object obj = OracleHelper.ExecuteScalar(OracleHelper.connstr, CommandType.Text, str, null);
            return Convert.ToInt32(obj);
        }

        public Int32 save(AddressModel model)
        {
            int flag = -1;
            string str = "insert into T_ADDRESS(id,name,areaid,operatorid) values(:id,:name,:areaid,:operatorid)";
            OracleParameter[] parameters = {
                 new OracleParameter(":id",OracleType.Int32),
                 new OracleParameter(":name",OracleType.VarChar),
                 new OracleParameter(":areaid",OracleType.Int32),
                 new OracleParameter(":operatorid",OracleType.Int32)                                          
                                           };
            parameters[1].Value = model.Name;
            parameters[2].Value = model.AreaId;
            parameters[3].Value = model.OperatorId;

            if (model.Id==null||model.Id == 0)
            {
                parameters[0].Value = queryMaxId() + 1;
            }
            else
            {
                str = "update T_ADDRESS set name=:name,areaid=:areaid,operatorid=:operatorid where id=:id";
                parameters[0].Value = model.Id;
            }

            //
            flag = OracleHelper.ExecuteNonQuery(OracleHelper.connstr, CommandType.Text, str, parameters);
            return flag;
        }

        public Int32 delete(Int32 id)
        {
            int flag = -1;        
            string str = "delete T_ADDRESS t where ID=" + id;
            //
            flag = OracleHelper.ExecuteNonQuery(OracleHelper.connstr, CommandType.Text, str, null);
            return flag;
        }
    }
}
