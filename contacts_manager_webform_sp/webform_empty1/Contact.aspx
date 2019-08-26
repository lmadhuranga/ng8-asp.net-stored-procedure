<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="webform_empty1.Contact" %>

<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Bootstrap Example</title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
<div class="container">
    <h1>Contact Manager</h1>
    <form id="contactForm" runat="server">
        <asp:LinkButton ID="lnkCreate" runat="server" CssClass="btn btn-primary" OnClick="link_Create">Create</asp:LinkButton>
        <asp:HiddenField ID="hfContactID" runat="server" />
        <div id="contactFormDiv" runat="server">
            <h2>Add Or Update Contact</h2>
            <table class="table">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name" ></asp:Label>
                    </td>
                    <td colspan="2"> 
                        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Mobile" ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMobile" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Address" ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> 
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click"/>
                    </td>
                </tr> 
            </table>
        </div>
        <div id="ErrorMessageDiv">
            <table >
                <tr>
                    <td> 
                    </td>
                    <td colspan="2">
                            <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td> 
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table> 
        </div>

        <br />
        <div id="gridViewDiv" runat="server">
            <h2>Contact List</h2>
            <asp:GridView ID="gvContact" CssClass="table" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:TemplateField>
                        <ItemTemplate>	
                            <asp:LinkButton ID="lnkView" runat="server" CssClass="btn btn-info btn-sm" CommandArgument='<%# Eval("ContactID") %>' OnClick="link_View">View <span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                            &nbsp;|&nbsp; 
                            <asp:LinkButton ID="lnkDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("ContactID") %>' OnClick="link_Delete">Delete <span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div> 
    </form> 
</div>
</body>
</html>
 
