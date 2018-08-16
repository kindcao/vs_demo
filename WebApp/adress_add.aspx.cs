using DAL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        AddessDAL dal = new AddessDAL();
        if (!IsPostBack)
        {
            //--------------dpl_area
            DataTable dt = dal.queryArea();
            dpl_area.DataSource = dt.DefaultView;
            dpl_area.DataValueField = dt.Columns[0].ColumnName;
            dpl_area.DataTextField = dt.Columns[1].ColumnName;
            dpl_area.DataBind();
            //
            dpl_area.Items.Insert(0, new ListItem("---Select---", ""));

            //--------------dpl_operator
            DataTable dt2 = dal.queryOperator();
            dpl_operator.DataSource = dt2.DefaultView;
            dpl_operator.DataValueField = dt.Columns[0].ColumnName;
            dpl_operator.DataTextField = dt.Columns[1].ColumnName;
            dpl_operator.DataBind();
            //
            dpl_operator.Items.Insert(0, new ListItem("---Select---", ""));           
                 
            //
            object id = Request.QueryString["ID"];
            if (id != null && id.ToString().Trim().Length > 0)
            {
                AddressModel model = dal.queryById(Convert.ToInt32(id.ToString().Trim()));
                hf_id.Value = model.Id.ToString();
                txtBox_address.Text = model.Name;
                dpl_area.SelectedValue = model.AreaId + "";
                dpl_operator.SelectedValue = model.OperatorId + "";
                btSave.Text = "Update";
            }
            else
            {
                hf_id.Value = "";
            }
        }
    }


    protected void btReset_Click(object sender, EventArgs e)
    {
        // txtBox_address.Text = "";
        dpl_area.SelectedValue = -1 + "";
        dpl_operator.SelectedValue = -1 + "";
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        AddessDAL dal = new AddessDAL();
        AddressModel model = new AddressModel();
        if (null != hf_id.Value && hf_id.Value.Trim().Length > 0)
        {
            model.Id = Convert.ToInt32(hf_id.Value);
        }
        model.Name = txtBox_address.Text;
        model.AreaId = Convert.ToInt32(dpl_area.SelectedValue);
        model.OperatorId = Convert.ToInt32(dpl_operator.SelectedValue);
        //        
        int flag = dal.save(model);
        if (flag < 0)
        {
            lb_error.Text = "save error!";
        }
        Response.Redirect("/address_list.aspx");
    }
}
