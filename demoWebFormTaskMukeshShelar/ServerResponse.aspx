<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerResponse.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.ServerResponse" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>500 - Internal Server Error</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            padding-top: 100px;
        }

        .error-container {
            border: 2px solid #FF0000;
            background-color: #FFDDDD;
            padding: 20px;
            display: inline-block;
            border-radius: 10px;
        }

            .error-container h1 {
                color: #FF0000;
                font-size: 50px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="error-container">
            <h1>500 - Internal Server Error</h1>
        </div>
    </form>
</body>
</html>
