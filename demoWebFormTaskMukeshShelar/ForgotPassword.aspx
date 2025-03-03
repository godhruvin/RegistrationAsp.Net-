<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.ForgotPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
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
            width: 400px;
            padding: 30px 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2), 0 6px 20px rgba(0, 0, 0, 0.19);
            text-align: center;
        }

            .form-container h2 {
                margin-bottom: 20px;
                color: #333;
            }

        .form-label {
            display: block;
            text-align: left;
            margin-bottom: 5px;
            font-size: 14px;
            font-weight: 600;
            color: #555;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.1);
            font-size: 14px;
        }

            .form-control:focus {
                border-color: #007bff;
                box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
                outline: none;
            }

        .form-btn {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
        }

            .form-btn:hover {
                background-color: #0056b3;
            }

        .validation-error {
            font-size: 12px;
            color: red;
            text-align: left;
            margin-bottom: 10px;
        }

        .eyeiconopen {
            display: none;
            color: black;
        }

        .eyeiconopen,
        .eyeiconclose {
            position: absolute;
            top: 53%;
            right: -11px;
            transform: translateY(-50%);
            cursor: pointer;
            font-size: 16px;
        }

        /* Hide the close icon by default */
        .eyeiconclose {
            display: block;
            color: black;
        }
        /* Parent container for password field and icons */
        .password-container {
            position: relative;
            width: 100%; /* Ensure it matches your input field width */
        }

    </style>

    <script type="text/javascript">
        function togglePasswordVisibility() {

            var eyeopen = document.querySelector(".eyeiconopen");
            var eyeclose = document.querySelector(".eyeiconclose");
            var txtPasswd = document.getElementById("<%= txtForgotPassword.ClientID %>");

            if (getComputedStyle(eyeopen).display == 'block') {
                eyeopen.style.display = 'none';
                eyeclose.style.display = 'block';

            } else {
                eyeopen.style.display = 'block';
                eyeclose.style.display = 'none';
            }

            if (txtPasswd.type == 'password') {
                txtPasswd.type = "text";
                eyeopen.style.display = 'block';
                eyeclose.style.display = 'none';
            } else {
                txtPasswd.type = "password";
                eyeopen.style.display = 'none';
                eyeclose.style.display = 'block';
            }
        }
    </script>

</head>
<body>
    <form runat="server" id="form1">
        <div class="form-container">
            <h2>Forgot Password</h2>
            <label class="form-label" for="Email">Email</label>
            <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter your Email Address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="Email is Required" CssClass="validation-error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="Invalid email format" CssClass="validation-error" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"></asp:RegularExpressionValidator>

            <label class="form-label" for="MobileNumber">Mobile Number</label>
            <asp:TextBox ID="MobileNumber" runat="server" CssClass="form-control" placeholder="Enter your Mobile Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="MobileNumber" ErrorMessage="Mobile Number is Required" CssClass="validation-error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MobileNumber" Display="Dynamic" ErrorMessage="Mobile number must be exactly 10 digits." CssClass="validation-error" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>

            <div class="password-container">
                <label class="form-label" for="txtForgotPassword">New Password</label>
                <asp:TextBox ID="txtForgotPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your new password"></asp:TextBox>
                <i class="eyeiconopen bi bi-eye" onclick="togglePasswordVisibility()"></i>
                <i class="eyeiconclose bi bi-eye-slash" onclick="togglePasswordVisibility()"></i>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtForgotPassword" Display="Dynamic" ErrorMessage="Password is Required" CssClass="validation-error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtForgotPassword" Display="Dynamic" ErrorMessage="Password must be at least 5 characters long." CssClass="validation-error" ValidationExpression="^.{5,}$"></asp:RegularExpressionValidator>

            </div>
            <asp:Button ID="btnProceed" runat="server" Text="Proceed" CssClass="form-btn" OnClick="BtnProceed_clickToForgotPassword" />
        </div>
    </form>
</body>
</html>
