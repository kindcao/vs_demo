<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="address_list.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="/adress_add.aspx">新增</a>
    <br />
    <table style="width: 80%;">
        <tr>
            <td class="auto-style1" style="text-align: right; width: 20%;">Address:</td>
            <td class="auto-style1" style="width: 30%;">
                <asp:TextBox ID="txtBox_address" runat="server" Width="250px" MaxLength="100" CssClass="required"></asp:TextBox>
            </td>
            <td class="auto-style1" style="text-align: left; width: 50%" colspan="2">
                <asp:Button ID="btQuery" runat="server" Text="Query" OnClientClick="query()" OnClick="btQuery_Click" Style="height: 21px" />
                 &nbsp; 
                <button id="btReset" title="Reset">Reset</button>
            </td>
        </tr>
    </table>
    <h2 class="DDSubHeader">列表数据</h2>
    <br />
    <asp:GridView ID="gv_address" runat="server" AutoGenerateColumns="False"
        CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="10" AllowPaging="true" PageSize="5" 
        OnPageIndexChanging="gv_address_PageIndexChanging" OnRowCommand="gv_address_RowCommand" OnRowDeleting="gv_address_RowDeleting" ShowHeaderWhenEmpty="true">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="chkID" runat="server" Checked='<%#Convert.ToBoolean(Convert.ToInt32(Eval("ID"))%2==0 ? 1:0)%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                <ItemTemplate>
                    <asp:HyperLink ID="lkID" runat="server" Text='<%# Eval("ID") %>' NavigateUrl='<%# "/adress_add.aspx?ID="+Eval("ID") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NAME" SortExpression="NAME">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ANAME" HeaderText="AREA" />
            <asp:BoundField DataField="ONAME" HeaderText="OPERATOR" />
            <asp:TemplateField HeaderText="Options">
                <ItemTemplate>
                    <asp:HyperLink ID="lbSH" runat="server" Text='审核' NavigateUrl="#"></asp:HyperLink>
                    <asp:LinkButton ID="lb_delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("ID") %>'
                        OnClientClick="javascript:return confirm('确定删除吗?')">删除</asp:LinkButton>                          
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
            <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
            <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
            <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
            <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
            到第<asp:TextBox runat="server" ID="inPageNum" Width="30px"></asp:TextBox>页
            <asp:Button ID="Button1" CommandName="go" runat="server" Text="GO" />
        </PagerTemplate>
        <HeaderStyle CssClass="th"></HeaderStyle>
        <RowStyle CssClass="td"></RowStyle>
    </asp:GridView>
    <script type="text/javascript">
        function query() {
            var _val = $("#<%=txtBox_address.ClientID%>").val();
            var flag = _val != "" && $.trim(_val).length >= 0;
            return flag;
        }

        $("#btReset").click(function () {
            $("#<%=txtBox_address.ClientID%>").val("");
        });
    </script>
</asp:Content>


