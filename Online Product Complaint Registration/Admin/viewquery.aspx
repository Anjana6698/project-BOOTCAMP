<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.Master" AutoEventWireup="true" CodeBehind="viewquery.aspx.cs" Inherits="Online_Product_Complaint_Registration.Admin.viewquery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Raise A Query</h1>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="qId" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="qid" HeaderText="Queryid" />
                <asp:BoundField DataField="productid" HeaderText="Product id" />
                <asp:BoundField DataField="uid" HeaderText="Userid" />
                <asp:BoundField DataField="qumsg" HeaderText="Query" />
                <asp:BoundField DataField="reply" HeaderText="Reply" />
                <asp:CommandField />
                <asp:CommandField EditText="confirm" HeaderText="Edit" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
