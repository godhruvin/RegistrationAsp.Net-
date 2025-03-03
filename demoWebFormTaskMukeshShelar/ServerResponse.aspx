<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>500 - Internal Server Error</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" />
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
<%--        <!-- Toast Element -->
        <div class="position-fixed top-0 end-0 p-3" style="z-index: 1055;">
            <div id="toastExample" class="toast align-items-center text-bg-primary border-0" role="alert" aria-live="assertive" aria-atomic="true">
                <div class="d-flex">
                    <div class="toast-body">
                        Oops! Your Session is Expired..
                    </div>
                    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                </div>
            </div>
        </div>
     <%--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>--%>

<%--<script type="text/javascript">
    document.addEventListener("DOMContentLoaded", () => {
        confirmationToNavigateLoginPage();
    });

    function confirmationToNavigateLoginPage(toastId) {
        const toastElement = document.getElementById(toastId);
        console.log("Toast element:", toastElement); // Debugging
        if (toastElement) {
            const toast = new bootstrap.Toast(toastElement);
            toast.show();
        } else {
            console.error("Toast element not found!");
        }
    }


</script>--%>
</body>
</html>
