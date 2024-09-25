<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClienteWSProyecto.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Acceso al Sistema</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"/>
    <style>
        body {
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
            position: relative;
            overflow: hidden;
        }

        .background {
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-image: url('https://images.unsplash.com/photo-1603782637810-95d06f1d5663?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'); /* Cambia esta URL a tu imagen */
            background-size: cover;
            background-position: center;
            filter: blur(8px);
            z-index: 0;
        }

        .form-container {
            position: relative;
            background-color: rgba(255, 255, 255, 0.9);
            padding: 40px;
            border-radius: 15px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            width: 100%;
            max-width: 400px;
            z-index: 1;
        }

        h2 {
            color: #1d2b64;
            text-align: center;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-control {
            position: relative;
            min-width: 200px;
            height: 40px;
        }
        .form-control i {
            position: absolute;
            left: 10px;
            top: 12px;
            color: #999;
        }
        .form-control {
            padding-left: 30px;
        }
        .btn-primary {
            background-color: #1d2b64;
            border: none;
            width: 100%;
        }
        .btn-primary:hover {
            background-color: #0f1a3e;
        }
        .error-message {
            color: red;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <div class="background"></div>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Acceso al Sistema</h2>
            <div class="form-group">
                <label for="txtUser" class="form-label">Usuario:</label>
                <div class="form-control">
                    <i class="fas fa-user"></i>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUser"
                    ErrorMessage="Debe ingresar usuario" CssClass="error-message"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="txtPass" class="form-label">Contraseña:</label>
                <div class="form-control">
                    <i class="fas fa-lock"></i>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" Width="100%"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPass"
                    ErrorMessage="Debe ingresar contraseña" CssClass="error-message"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="15pt" ForeColor="#3333FF"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click1" />
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
