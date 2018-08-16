<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="adress_add.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="/address_list.aspx">查询</a>
    <br />
    <h2 class="DDSubHeader">基本数据</h2>
    <br />

    <asp:HiddenField ID="hf_id" runat="server" />
    <table style="width: 80%;">
        <tr>
            <td class="auto-style1" style="text-align: right; width: 20%;">Address:</td>
            <td class="auto-style1" style="width: 30%;">
                <asp:TextBox ID="txtBox_address" runat="server" Width="250px" MaxLength="100" CssClass="required"></asp:TextBox>
            </td>
            <td class="auto-style1" style="text-align: right; width: 20%;">Area:</td>
            <td class="auto-style1" style="width: 30%;">
                <asp:DropDownList ID="dpl_area" runat="server" Height="19px" Width="250px" CssClass="required"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="text-align: right;">Operator:</td>
            <td class="auto-style1">
                <asp:DropDownList ID="dpl_operator" runat="server" Height="17px" Width="250px" CssClass="required"></asp:DropDownList>
            </td>
            <td class="auto-style1" style="text-align: center" colspan="2">
                <asp:Button ID="btSave" runat="server" Text="Save" OnClientClick="save()" Style="height: 21px" OnClick="btSave_Click" />
                &nbsp; 
                <button id="btReset" title="Reset">Reset</button>
            </td>
        </tr>
    </table>
    <asp:Label ID="lb_error" runat="server" Style="color: red"></asp:Label>
    <script type="text/javascript">
        // 
    
        function JqValidate()
        {
            return $( '#form1' ).validate({
                onsubmit: true,// 是否在提交是验证
                onfocusout: false,// 是否在获取焦点时验证
                onkeyup: false,// 是否在敲击键盘时验证
                rules:{
                    <%=txtBox_address.ClientID%>: "required",
                    <%=dpl_area.ClientID%>: "required",
                    <%=dpl_operator.ClientID%>: "required",
                },
                messages:{
                    <%=txtBox_address.ClientID%>: "fsafa",
                    <%=dpl_area.ClientID%>: "fsafaxxx" 
                },
                errorPlacement: function (error, element) { //指定错误信息位置
                    if (element.is(':radio') || element.is(':checkbox')) { //如果是radio或checkbox
                        var eid = element.attr('name'); //获取元素的name属性
                        error.appendTo(element.parent()); //将错误信息添加当前元素的父结点后面
                    } else {
                        error.insertAfter(element);
                    }
                },
                errorElement:'em' 
            });
        }
             

        $("#btReset").click(function() {
            $("input[type='text']").val(""); 
            $("#<%=dpl_area.ClientID%>").empty();
            $("#<%=dpl_operator.ClientID%>").empty(); 
        })

        function save() {
            if( JqValidate() ){  
                $( '#form1' ).submit();
                return true;
            }
            return false;
        }
    </script>
</asp:Content>

