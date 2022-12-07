<%@ Page Title="" Language="C#" MasterPageFile="~/User/usermaster.Master" AutoEventWireup="true" CodeBehind="viewcomplaint.aspx.cs" Inherits="Online_Product_Complaint_Registration.User.viewcomplaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Complaint Status</h1>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="cId" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="cmdate" HeaderText="Complaint Date" />
                <asp:BoundField DataField="product" HeaderText="Product Name" />
                <asp:BoundField DataField="uid" HeaderText="User id" />
                <asp:BoundField DataField="username" HeaderText="User Name" />
                <asp:BoundField DataField="msg" HeaderText="Complaint Message" />
                <asp:BoundField DataField="cmstatus" HeaderText="Complaint status" />
            </Columns>
           
        </asp:GridView>
    </form>
</asp:Content>
