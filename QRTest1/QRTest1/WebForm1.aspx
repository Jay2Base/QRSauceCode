<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="QRTest1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Orginisation"></asp:Label>
            &nbsp;
            <asp:TextBox runat="server" ID="Organisation" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
            &nbsp;
            <asp:TextBox runat="server" ID="LastName" />
            <br />

    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Encode Data" />
    
    </div>
      <asp:Image runat="server" ID="QRImage" /> 
        <div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Decode Data" />
        </div> 
        <asp:Label ID="Decoded" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
