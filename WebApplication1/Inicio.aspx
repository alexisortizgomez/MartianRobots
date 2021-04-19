<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplication1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<%--<body>--%>
    <form id="form1" runat="server">
        <div>
            Ingrese las instrucciones:<br />
            <asp:TextBox ID="txtInput" runat="server" Height="178px" TextMode="MultiLine" Width="404px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
            <br />
            <br />
            Resultado:<br />
            <asp:TextBox ID="txtOutput" runat="server" Height="178px" TextMode="MultiLine" Width="404px"></asp:TextBox>
            <br />
        </div>
    </form>
</body>
</html>
