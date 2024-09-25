<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ClienteWSProyecto.Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Dashboard - Industrias Textiles Sallco</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(135deg, #b3c7e6 0%, #1d2b64 100%);
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }

        .navbar {
            background-color: #1d2b64;
            padding: 15px;
        }

            .navbar a {
                color: white;
                margin: 0 15px;
                text-decoration: none;
                font-size: 18px;
            }

        .dashboard-container {
            flex: 1;
            padding: 20px;
        }

        .info-section {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 15px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            margin-bottom: 20px;
            text-align: center;
        }

            .info-section h3 {
                color: #1d2b64;
            }

            .info-section p {
                color: #333;
            }

        footer {
            background-color: #1d2b64;
            padding: 10px;
            text-align: center;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <asp:LinkButton ID="btnUsuario" runat="server" OnClick="btnUsuario_Click" CssClass="text-white">
                <i class="fas fa-users"></i> Usuarios
            </asp:LinkButton>
            <asp:LinkButton ID="btnRol" runat="server" OnClick="btnRol_Click" CssClass="text-white">
                <i class="fas fa-user-tag"></i> Roles
            </asp:LinkButton>
            <asp:LinkButton ID="btnProducto" runat="server" OnClick="btnProducto_Click" CssClass="text-white">
                <i class="fas fa-box"></i> Productos
            </asp:LinkButton>
            <asp:LinkButton ID="btnCliente" runat="server" OnClick="btnCliente_Click" CssClass="text-white">
                <i class="fas fa-users-cog"></i> Clientes
            </asp:LinkButton>
        </div>

        <div class="dashboard-container">
            <div class="info-section">
                <h3>Información de la Empresa</h3>
                <p>Industrias Textiles Sallco E.I.R.L. se dedica a la confección de uniformes de alta calidad, asegurando la mejor entrega para nuestros clientes. Nuestra misión es brindar productos que cumplan con los más altos estándares del mercado, ofreciendo soluciones eficientes y confiables para empresas de todo tipo.</p>
            </div>

            <div class="info-section">
                <h3>Datos Clave</h3>
                <p>Objetivo: Aumentar la confiabilidad de inventario y la exactitud a un 80% en los próximos 6 meses.</p>
                <p>Comparativa con el año anterior: Mejoramos la confiabilidad de inventario en un 10%.</p>
                <p>Estos indicadores impactan directamente en la satisfacción del cliente y la eficiencia operativa.</p>
                <p>Estamos implementando un nuevo sistema de gestión de inventarios y capacitación para el personal.</p>
            </div>
        </div>
    </form>

    <footer>
        <p>&copy; 2024 Industrias Textiles Sallco E.I.R.L. - Todos los derechos reservados</p>
    </footer>

    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
