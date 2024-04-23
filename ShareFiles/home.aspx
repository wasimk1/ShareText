<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ShareFiles.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Share Text - Wasim Khan</title>

    <link href="CSS/StyleSheet.css" rel="stylesheet" />

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet"/>
</head>
<body>
    <main class="main-all">
        <div class="header">
            <p>
                <asp:Label runat="server" Text=" Share Text" ID="lblwebname"></asp:Label>
            </p>
        </div>

        <div class="content-all">
            <form id="form1" runat="server">
                <div class="con-validate-user">
                    <asp:Label ID="Label2" runat="server" Text="Enter the UserName"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtusername" runat="server" Width="173px" OnTextChanged="txtusername_TextChanged"></asp:TextBox>
                    <asp:Button class="btn" ID="btnusersubmit" runat="server" OnClick="btnusersubmit_Click" Text="Submit" Font-Bold="True" AutoPostBack="True" />
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Visible="False">Clear</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Visible="False">Referesh</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button class="btn" ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" Visible="False" />
                </div>
                <br />
                <hr />
                <div class="con-validate-send-receive">
                    <div class="send-left">
                        <asp:Label ID="Label6" runat="server" Text="SEND" Visible="False"></asp:Label>
                    </div>
                    <div class="rec-right">
                        <asp:Label ID="Label8" runat="server" Text="CHECK TO RECEIVE" Visible="False"></asp:Label>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Visible="False" />
                        <asp:Label ID="Label11" runat="server" Text="RECEIVE" Visible="False"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="RECEIVE" Visible="False"></asp:Label>
                    </div>
                </div>


                <div class="con-table">
                    <table style="width: 100%; border: 10px;" id="tableview" runat="server">
                        <tr>
                            <td>
                                <p align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Write your Text" Visible="False"></asp:Label>
                                    <asp:TextBox ID="TextBox3" runat="server" Height="100px" TextMode="MultiLine" Width="500px" ValidateRequestMode="Disabled" Visible="False"></asp:TextBox>
                                </p>
                                <p align="left">
                                    <asp:Button class="btn" ID="Button4" runat="server" OnClick="Button4_Click" Text="Clear All"  Visible="False" />
                                </p>
                                <p align="left">
                                    <asp:Label ID="Label4" runat="server" Text="Select Person" Visible="False"></asp:Label>
                                    &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="17px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="160px" CausesValidation="True" Visible="False">
                </asp:DropDownList>&nbsp;
                <asp:Button class="btn" ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" Width="69px" Visible="False" />
                                </p>

                                <p align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Generated ID" Visible="False"></asp:Label>
                                    &nbsp;<asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                                </p>
                            </td>


                            <td>
                                <p>
                                    <asp:Button class="btn" ID="Button5" runat="server" OnClick="Button5_Click" Text="Get all Text" Visible="False" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Select User" Visible="False"></asp:Label>

                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="17px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="160px" CausesValidation="True" Visible="False">
                                    </asp:DropDownList>
                                    <asp:Button class="btn" runat="server" Text="Refresh" OnClick="Unnamed1_Click" ID="btnref" Visible="False"></asp:Button>

                                </p>
                                <br />
                                <div style="height: 300px; overflow: auto" align="center">
                                    <p align="center">
                                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="442px" Font-Names="Calibri" Font-Size="Small">
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" />
                                        </asp:GridView>
                                    </p>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>



                <%--<p align="center" font-family: Arial; font-size: medium"> 
                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; --%>
                <%--<asp:RadioButton ID="rdsendbtn" runat="server" AutoPostBack="True" GroupName="rdgroup" OnCheckedChanged="rdsendbtn_CheckedChanged" Text="Send" Visible="False" Font-Bold="True" Font-Names="Cascadia Mono" Font-Size="Medium" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rdbtnreceive" runat="server" AutoPostBack="True" GroupName="rdgroup" OnCheckedChanged="rdbtnreceive_CheckedChanged" Text="Receive" Visible="False" Font-Bold="True" Font-Names="Cascadia Mono" Font-Size="Medium" />
            </p>--%>
                <%--<p> Enter the ID
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Get Text" />
            &nbsp;&nbsp;
            </p>
            <p> Result<asp:TextBox ID="TextBox4" runat="server" Height="97px" ReadOnly="True" TextMode="MultiLine" Width="738px" ValidateRequestMode="Disabled"></asp:TextBox>
            </p>--%>

                <hr />
                <div class="footer">
                    <p>
                        <asp:Label ID="Lblfooter" runat="server" Text="All right reserved © ShareFile"></asp:Label>
                        <asp:Label ID="Lblyear" runat="server"></asp:Label>
                        Developed by -
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.open('https://www.linkedin.com/in/iwasimkhan01/');" target="_self">Wasim Khan</asp:LinkButton>
                    </p>
                </div>
            </form>
        </div>
    </main>
</body>
</html>
