<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveUsersList.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.ActiveUsersList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Active Users List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <style>
        .page-header {
            text-align: center;
            margin-bottom: 20px;
        }

        .gridViewDataBound .table {
            border-radius: 8px;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
        }

        .gridViewDataBound th {
            background-color: #007BFF;
            color: white;
            text-align: center;
        }

        .gridViewDataBound td {
            text-align: center;
            vertical-align: middle;
        }

        .btn-custom {
            background-color: #28a745;
            color: white;
            border: none;
        }

        .btn-custom:hover {
            background-color: #218838;
        }
    </style>
    <script type="text/javascript">
        function showAlert() {
            alert("No users to display...");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid mt-4">
            <div class="page-header">
                <h2 class="text-primary text-start">Active Users List</h2>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="activeUsersList"
                    AutoGenerateColumns="true" ShowHeaderWhenEmpty="true" AllowPaging="true"
                    OnPageIndexChanging ="GridView1_PageIndexChanging" PageSize="10"
                    CssClass="table table-striped table-hover text-capitalize gridViewDataBound"
                    runat="server">
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76A9CBj1pnkP3CZhbykCkXTbsFZVJGt/NaJD3EaW8bX9jIh5lyrdiF5cLKbUQDM" crossorigin="anonymous"></script>
</body>
</html>
