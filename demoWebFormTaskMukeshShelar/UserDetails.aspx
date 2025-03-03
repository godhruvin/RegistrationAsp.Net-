<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />

    <style>
        body {
            font-family: "Courier New, Courier, monospace";
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            position: relative;
        }

        .form-row {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
            margin-top: 10px;
        }

        .form-group {
            flex: 1;
            margin-right: 10px;
        }

            .form-group:last-child {
                margin-right: 0;
            }


        .form-container {
            background: #ffffff;
            /* margin-top: 20px; */
            padding: 12px 18px;
            border-radius: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            width: 1200px;
            height: auto;
        }

            .form-container h2 {
                text-align: center;
                margin-bottom: 15px;
                color: #333333;
                letter-spacing: 3px;
            }

            .form-container label {
                font-size: 14px;
                font-weight: bold;
                color: #555555;
                margin-bottom: 5px;
            }

            .form-container input[type="text"],
            .form-container input[type="email"],
            .form-container input[type="password"],
            .form-container input[type="date"],
            .form-container textarea {
                width: 100%;
                padding: 8px;
                border: 1px solid #ddd;
                border-radius: 5px;
                font-size: 14px;
                box-shadow: inset 0 1px 2px rgba(0, 0, 0, 0.1);
            }

                .form-container input:focus,
                .form-container textarea:focus {
                    outline: none;
                    border-color: #007bff;
                    box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
                }

            .form-container .radio-group {
                display: flex;
                justify-content: flex-start;
                margin-bottom: 10px;
            }

            .form-container textarea {
                resize: none;
                margin-top: 10px;
            }

            .form-container button {
                padding: 10px;
                font-size: 16px;
                font-weight: bold;
                color: #ffffff;
                background-color: #007bff;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }

            .form-container button:hover {
               background-color: #0056b3;
            }

        .btn {
            margin-top: 13px;
            width: 120px;
            font-size: 1.2rem;
        }

        .gender-radio input[type="radio"] {
            margin-right: 8px;
        }

        .gender-radio label {
            margin-right: 20px;
        }

            .gender-radio label:last-child {
                margin-right: 5px;
            }

        .update-section {
            position: absolute;
            display: flex;
            gap: 7px;
            font-size: x-large;
        }

            .update-section #updatelbl {
                color: red;
            }
    </style>

    <script>

        document.addEventListener("DOMContentLoaded", function () {


            document.getElementById('<%= DateOfBirth.ClientID %>').addEventListener('change', function () {
                 var selectedDate = this.value;

                 if (selectedDate) {
                     var dob = new Date(selectedDate);
                     var today = new Date(); // Get the current date
                     var age = today.getFullYear() - dob.getFullYear();

                     var m = today.getMonth(), d = today.getDate();
                     if (m < dob.getMonth() || (m === dob.getMonth() && d < dob.getDate())) {
                         age--;
                     }

                     document.getElementById('<%= Age.ClientID %>').value = age;
             }
         });
         });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="update-section">
                <asp:Label ID="updatelbl" runat="server">Update</asp:Label>
                <asp:CheckBox ID="Update" runat="server" OnCheckedChanged="Checkedbtnchange" AutoPostBack="true" />
            </div>
            <h2>&nbsp;User Details</h2>
            <asp:Label ID="lblUserId" runat="server" Text="User ID" CssClass="form-label"></asp:Label>
            &nbsp;&nbsp;
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uid" Display="Dynamic" ErrorMessage="UserId is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;
           <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="uid" Display="Dynamic" ErrorMessage="User ID must be between 4 and 10 characters long." ForeColor="Red" ValidationExpression="^.{4,10}$"></asp:RegularExpressionValidator>
            &nbsp;<asp:TextBox ID="uid" runat="server" CssClass="form-control" placeholder="Enter your User ID"></asp:TextBox>

            <div class="form-row">

                <div class="form-group">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="form-label"></asp:Label>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FirstName" Display="Dynamic" ErrorMessage="FirstName is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" placeholder="Enter your First Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="form-label"></asp:Label>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastName" Display="Dynamic" ErrorMessage="LastName is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="LastName" runat="server" CssClass="form-control" placeholder="Enter your Last Name"></asp:TextBox>
                </div>
            </div>


            <div class="form-row">
                <div class="form-group">
                    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date of Birth" CssClass="form-label"></asp:Label>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DateOfBirth" Display="Dynamic" ErrorMessage="Date Of Birth is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="DateOfBirth" runat="server" TextMode="Date" CssClass="form-control" placeholder="Enter your DateOFBirth"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblage" runat="server" Text="Age" CssClass="form-label"></asp:Label>
                    &nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Age" ErrorMessage="Age is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;<asp:TextBox ID="Age" runat="server" TextMode="Number" CssClass="form-control" placeholder="Enter your Age"></asp:TextBox>
                </div>
            </div>


            <div class="form-row">
                <div class="form-group">
                    <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile Number" CssClass="form-label"></asp:Label>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="MobileNumber" ErrorMessage="Mobile Number is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MobileNumber" Display="Dynamic" ErrorMessage="Mobile number must be exactly 10 digits and contain only numbers." ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                    &nbsp;
                   &nbsp;<asp:TextBox ID="MobileNumber" runat="server" CssClass="form-control" placeholder="Enter your Mobile Number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                    &nbsp;&nbsp;
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="Email is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="Email is not in proper Format" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter your Email Address"></asp:TextBox>
                </div>
            </div>


            <div class="form-row">
                <div class="form-group">
                    <asp:Label ID="lblGender" runat="server" Text="Gender" CssClass="form-label"></asp:Label>
                    &nbsp;
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Gender" Display="Dynamic" ErrorMessage="Gender is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <div class="radio-group">
                        <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal" CssClass="gender-radio">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status" CssClass="form-label"></asp:Label>
                    &nbsp;
                   <div class="mb-3">
                       <asp:DropDownList ID="MaritalStatus" runat="server">
                           <asp:ListItem Value="Single">Single</asp:ListItem>
                           <asp:ListItem Value="Married">Married</asp:ListItem>
                           <asp:ListItem Value="Divorced">Divorced</asp:ListItem>
                           <asp:ListItem Value="Widowed">Widowed</asp:ListItem>
                       </asp:DropDownList>
                   </div>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group">
                    <label for="ddlStates" runat="server">State</label>
                    <asp:DropDownList ID="ddlStates" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStates_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label for="ddlCities" runat="server">City</asp:Label>
                    <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control" AutoPostBack="true">
                    </asp:DropDownList>

                </div>
            </div>


            <asp:Label ID="lblRemarks" runat="server" Text="Remarks" CssClass="form-label"></asp:Label>
            &nbsp;
           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ErrorMessage="Remarks is Required" ForeColor="Red" ControlToValidate="Remarks"></asp:RequiredFieldValidator>
            <asp:TextBox ID="Remarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Placeholder="Any additional remarks"></asp:TextBox>
            <asp:Button ID="save" runat="server" Text="Save" CssClass="btn btn-success" OnClick="OnUpdateBtnClickSaveUserData" />
        </div>
    </form>
</body>
</html>
