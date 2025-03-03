<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.UsersList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* Table Styles */
        .gridview-table {
            width: 100%;
            border-collapse: collapse;
            font-family: 'Arial', sans-serif;
        }

       .gridview-table th, .gridview-table td {
           padding: 15px;
           text-align: left;
           border: 1px solid #ddd;
       }

            .gridview-table th {
                background-color: #4CAF50;
                color: white;
                font-size: 16px;
            }

            .gridview-table td {
                font-size: 14px;
            }

            .gridview-table tr:nth-child(even) {
                background-color: #f9f9f9;
            }

            .gridview-table tr:hover {
                background-color: #f1f1f1;
            }

            .gridview-table a {
                color: darkblue;
                text-decoration: none;
                font-weight: bold;
            }

            .gridview-table a:hover {
                text-decoration: underline;
            }

        .gridview-button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 8px 16px;
            text-align: center;
            cursor: pointer;
            border-radius: 5px;
        }

            .gridview-button:hover {
                background-color: #45a049;
            }

        /* Responsive Design */
        @media screen and (max-width: 600px) {
            .gridview-table th, .gridview-table td {
                padding: 10px;
            }

            .gridview-table {
                font-size: 12px;
            }

            .gridview-button {
                font-size: 12px;
                padding: 6px 12px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewUsers" runat="server" CssClass="gridview-table" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" OnRowDataBound="GridViewUsers_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="UserId">
                    <ItemTemplate>
                        <asp:LinkButton ID="hlUserId" runat="server"
                            Text='<%# Eval("userId") %>'
                            OnClick="lnkUserId_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
