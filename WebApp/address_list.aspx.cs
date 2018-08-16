using DAL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bondDV();
        }
    }

    protected void gv_address_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_address.PageIndex = e.NewPageIndex;
            bondDV();

            TextBox tb = (TextBox)gv_address.BottomPagerRow.FindControl("inPageNum");
            tb.Text = (gv_address.PageIndex + 1).ToString();
        }
        catch
        {
        }
    }

    protected void gv_address_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "go")
        {
            try
            {
                TextBox tb = (TextBox)gv_address.BottomPagerRow.FindControl("inPageNum");
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                gv_address_PageIndexChanging(null, ea);
            }
            catch
            {
            }
        }
        else if (e.CommandName == "delete")
        {
            Int32 id = Convert.ToInt32(e.CommandArgument);
            AddessDAL dal = new AddessDAL();
            dal.delete(id);
            bondDV();
        }
    }

    private void bondDV()
    {
        AddessDAL dal = new AddessDAL();
        AddressModel model = new AddressModel();
        model.Name = txtBox_address.Text.Trim();
        DataTable dt = dal.query(model);
        if (dt.Rows.Count == 0)
        {
            gv_address.EmptyDataText = "No data!";
        }
        gv_address.DataSource = dt.DefaultView;
        gv_address.DataBind();
    }

    protected void btQuery_Click(object sender, EventArgs e)
    {
        bondDV();
    }
    protected void gv_address_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
