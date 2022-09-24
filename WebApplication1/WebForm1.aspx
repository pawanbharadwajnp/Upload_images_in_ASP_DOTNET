<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 362px;
        }
        .auto-style3 {
            width: 362px;
            height: 34px;
        }
        .auto-style4 {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table cellpadding="4" cellspacing="4" class="auto-style1">
            <tr>
                <td class="auto-style2">Image Upload</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Save" Width="105px" />
&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                <%--     to do this select grid view ->properties->behaviour->autoGenerateColumns->false--%>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                        <Columns>
                            <asp:TemplateField> 
                                <ItemTemplate> 
                                    <table>

                                        <tr>  
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("id") %> '></asp:Label> <!--gets id from database-->
                                            </td>
                                            <td>
                                                <asp:Image Height="150" Width="150" ID="Image1" runat="server" ImageUrl='<%# Eval("image_name") %> ' />

                                            </td>
                                        </tr>

                                    </table>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
    </body>
</html>
