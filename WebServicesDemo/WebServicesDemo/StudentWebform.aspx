﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentWebform.aspx.cs" Inherits="WebServicesDemo.StudentWebform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function GetStudentById() {
            var studentId = document.getElementById('txtStudentId').value;
            WebServicesDemo.StudentService.GetStudentById(studentId, OnSuccess, OnFailure);
        }

        function OnSuccess(results) {
            document.getElementById('txtName').value = results["Name"];
            document.getElementById('txtGender').value = results["Gender"];
            document.getElementById('txtTotalMarks').value = results["TotalMarks"]
        }

        function OnFailure(error) {
            alert(error.get_message()) ;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/StudentService.asmx" />
            </Services>
        </asp:ScriptManager>
        <table style="font-family: Arial; border: 1px solid black">
            <tr>
                <td>
                    <b>ID</b>
                </td>
                <td>
                    <asp:TextBox ID="txtStudentId" runat="server"></asp:TextBox>
                    <input id="Button1" type="button" value="Get Student" onclick="GetStudentById()" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Gender</b>
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Total Marks</b>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalMarks" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
