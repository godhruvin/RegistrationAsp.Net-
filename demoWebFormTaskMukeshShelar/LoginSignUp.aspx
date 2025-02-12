<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSignUp.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.LoginSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
    <title></title>
        <style>
        body {
            background-color: #f4f4f4;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .form-container {
            background: #ffffff;
            width: 350px;
            padding: 50px 50px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2), 0 6px 20px rgba(0, 0, 0, 0.19);
            text-align: center;
            position: relative;
        }

            .form-container h2 {
                margin-bottom: 20px;
                color: #333333;
            }

            .form-container #lblUserId, #lblPassword {
                display: block;
                margin-bottom: 8px;
                font-size: 14px;
                color: #555555;
                text-align: left;
            }

            .form-container #txtUserId,
            .form-container #txtPassword {
                width: 100%;
                padding: 10px;
                margin-bottom: 15px;
                border: 1px solid #ddd;
                border-radius: 5px;
                box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.1);
                font-size: 14px;
            }

                .form-container #txtUserId:disabled {
                    background-color: #f5f5f5;
                    color: #888888;
                }

            .form-container #btnLogin, #btnSignIn {
                width: 100%;
                padding: 12px;
                font-size: 16px;
                font-weight: bold;
                color: #ffffff;
                background-color: #007BFF;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                transition: all 0.3s ease;
            }

            .form-container button:hover {
                background-color: #0056b3;
                transform: translateY(-2px);
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }

            .form-container #btnSignIn {
                margin-top: 10px;
                background-color: #28a745;
            }

                .form-container #btnSignIn:hover {
                    background-color: #218838;
                }

        .forgot-password-link {
            text-decoration: none;
            display: block;
            margin-top: 10px;
            font-size: 14px;
            color: #007bff;
            transition: color 0.3s ease;
            position: absolute;
        }

            .forgot-password-link:hover {
                color: #0056b3;
            }
    </style>

     <script type="text/javascript">
        function toggleValidation(enable) {
            var validator1 = document.getElementById("<%= RequiredFieldValidator1.ClientID %>");
            var validator2 = document.getElementById("<%= RequiredFieldValidator2.ClientID %>");
            if (validator1 && validator2) {
                ValidatorEnable(validator1, enable);
                ValidatorEnable(validator2, enable);
            }
        }

        function showAlert() {
            alert("User Not Exists. Kindly Sign Up Instead.");
            var forgotPasswordLink = document.getElementById("<%= lnkForgotPassword.ClientID %>");
            if (forgotPasswordLink) {
                forgotPasswordLink.style.display = "none";
            }
            toggleValidation(false);
        }


    </script>
</head>
<body>
     <form id="form1" runat="server">
        <div class="form-container">
            <!-- User ID -->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserId" Display="Dynamic" ErrorMessage="UserId is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="lblUserId" runat="server" Text="User ID" CssClass="form-label"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserId" Display="Dynamic" ErrorMessage="User ID must be between 4 and 10 characters long." ForeColor="Red" ValidationExpression="^.{4,10}$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-input" placeholder="Enter your UserId"></asp:TextBox>

            <!-- Password -->
            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password must be at least 5 characters long." ForeColor="Red" ValidationExpression="^.{5,}$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input" placeholder="Enter your password"></asp:TextBox>

            <!-- Login Button -->
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_ServerClick" CssClass="form-btn" />


            <asp:HyperLink ID="lnkForgotPassword" runat="server" NavigateUrl="ForgotPassword.aspx" CssClass="forgot-password-link">
                Forgot Password?
            
            </asp:HyperLink>

            <!-- Sign-In Button (hidden initially) -->
            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_ServerClick" CssClass="form-btn" />
        </div>
    </form>
</body>
</html>
