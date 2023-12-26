<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ShareFiles.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 27px;
            width: 193px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="font-family: Arial; font-size: medium"> ShareText</p>
            <p> Write your Text<asp:TextBox ID="TextBox3" runat="server" Height="96px" TextMode="MultiLine" Width="690px" ValidateRequestMode="Disabled"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
            </p>
            <p> Generated ID <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p> &nbsp;</p>
            <p> Enter the ID
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Text" />
            </p>
            <p> Result<asp:TextBox ID="TextBox4" runat="server" Height="97px" ReadOnly="True" TextMode="MultiLine" Width="738px" ValidateRequestMode="Disabled"></asp:TextBox>
            </p>
            <p> &nbsp;</p>
            <p> 
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Clear All" />
            </p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <hr />
            <h1 class="article__title" style="padding: 0px 0px 20px; margin: 0px; outline: 0px; box-sizing: border-box; font-family: Arial, Helvetica, sans-serif; -webkit-font-smoothing: antialiased; font-weight: normal; line-height: 1.2; font-size: small; color: rgb(0, 0, 0); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">All right reserved © ShareFile 2023&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Developed by-
                <asp:LinkButton ID="LinkButton1" runat="server" onclientclick="window.open('https://www.linkedin.com/in/iwasimkhan01/');"  target="_self">Wasim Khan</asp:LinkButton>
            </h1>
            <p> &nbsp;</p>
        </div>
    </form>
</body>
</html>
