<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="demoWebFormTaskMukeshShelar.WelcomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Page</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const fileInput1 = document.getElementById('<%= FileUpload1.ClientID %>');
            console.log(fileInput1.id);
            const fileInput2 = document.getElementById('<%= FileUpload2.ClientID %>');
            console.log(fileInput2.id);
            const fileNameSpan1 = document.getElementById("fileName1");
            const fileNameSpan2 = document.getElementById("fileName2");

            if (fileInput2) {
                fileInput2.addEventListener("change", function () {
                    if (fileInput2.files && fileInput2.files[0]) {
                        fileNameSpan2.innerText = fileInput2.files[0].name;
                    }
                });
            }
            if (fileInput1) {
                fileInput1.addEventListener("change", function () {
                    if (fileInput1.files && fileInput1.files[0]) {
                        fileNameSpan1.innerText = fileInput1.files[0].name;
                    }
                });
            }
        });

    </script>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #2e3b4e;
            color: #fff;
            font-family: "Ubuntu Mono";
        }

        a {
            text-decoration: none;
            cursor: pointer;
        }

        h2 {
            letter-spacing: 1.9px;
            font-size: 4rem;
        }

        .nav-tabs {
            border-bottom: 3px solid #f7d33d;
            position: absolute;
            top: 190px;
            margin: 0 -2em;
            padding: 1em;
        }

        .nav-item {
            margin-right: 10px;
        }

        .nav-link {
            background-color: #2e3b4e;
            color: #fff;
            border: none;
            font-weight: bold;
            border-radius: 5px 5px 0 0;
            padding: 10px 20px;
            transition: background-color 0.3s ease;
        }

            .nav-link:hover {
                background-color: #f7d33d;
                color: #2e3b4e;
            }

            .nav-link.active {
                background-color: #f7d33d;
                color: #fff;
                border-radius: 5px 5px 0 0;
            }

            .nav-link.disabled {
                background-color: #444;
                color: #777;
            }

        span {
            color: blue;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form runat="server" enctype="multipart/form-data">
        <h5 style="margin-bottom: 30rem;">Welcome to the Registration Website</h5>
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" aria-current="page" runat="server" onserverclick="redirectToUsersListPage">User Details</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" aria-current="page" runat="server" onclick="setUserIdHeader()" data-bs-toggle="modal" data-bs-target="#uploadModal">Upload Document</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" aria-current="page" runat="server" onclick="setUserIdHeader()" data-bs-toggle="modal" data-bs-target="#convertModal">Convert Into tif Format</a>
            </li>
        </ul>

        <%--modal code on the click of Upload Document--%>

        <div class="modal fade" id="uploadModal" tabindex="-1" aria-labelledby="uploadModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Label ID="lblUserIdInModalHeader" runat="server" CssClass="text-primary"></asp:Label>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file-upload" />
                        <span id="fileName1" class="file-name"></span>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" CssClass="btn btn-primary" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>

        <%--modal for convert to tif format document--%>
        <div class="modal fade" id="convertModal" tabindex="-1" aria-labelledby="convertModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Label ID="lblConvertUserIdInModalHeader" runat="server" CssClass="text-primary"></asp:Label>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="file-upload" />
                        <span id="fileName2" class="file-name"></span>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button ID="btnConvert" runat="server" Text="Convert to Tif" OnClick="btnConvertDocumentTif_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
