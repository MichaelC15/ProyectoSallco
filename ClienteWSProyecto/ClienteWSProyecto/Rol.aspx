<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rol.aspx.cs" Inherits="ClienteWSProyecto.Rol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Consulta de Roles</title>
    <link href="https://cdn.datatables.net/v/bs5/jszip-3.10.1/dt-2.1.7/b-3.1.2/b-colvis-3.1.2/b-html5-3.1.2/b-print-3.1.2/datatables.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <style>
        body {
            background: linear-gradient(135deg, #b3c7e6 0%, #1d2b64 100%);
            height: 100vh;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }

        .form-container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 20px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            width: 100%;
            max-width: 800px;
        }

        h2 {
            color: #1d2b64;
            text-align: center;
        }

        .form-row {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
        }

        .form-group {
            flex: 1 1 45%;
            margin: 10px;
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
        }

            .btn-primary:hover {
                background-color: #0f1a3e;
            }

        .table-container {
            margin-top: 20px;
            width: 100%;
            max-width: 800px;
        }

        .btn-custom {
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Consulta de Roles</h2>
            <div class="form-row">
                <div class="form-group">
                    <label for="txtidRol" class="form-label">ID Rol:</label>
                    <div class="form-control">
                        <i class="fas fa-id-badge"></i>
                        <asp:TextBox ID="txtidRol" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvidRol" runat="server" ControlToValidate="txtidRol"
                            ErrorMessage="Debe ingresar ID del Rol" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombre" class="form-label">Nombre:</label>
                    <div class="form-control">
                        <i class="fas fa-user-tag"></i>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtDescripcion" class="form-label">Descripción:</label>
                    <div class="form-control">
                        <i class="fas fa-info-circle"></i>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Size="15pt" ForeColor="#3333FF"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click1" CssClass="btn btn-primary" />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click1" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="table-container">
            <table id="tablaRoles" class="table table-bordered" style="width: 100%">
                <thead>
                    <tr>
                        <th>ID Rol</th>
                        <th>Nombre</th>
                        <th>Descripción</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="phTablaRoles" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </form>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/v/bs5/jszip-3.10.1/dt-2.1.7/b-3.1.2/b-colvis-3.1.2/b-html5-3.1.2/b-print-3.1.2/datatables.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.1.7/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.10.1/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.1.7/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.1.7/js/buttons.print.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.70/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.70/vfs_fonts.js"></script>

   <script>
       $(document).ready(function () {
           var table = $('#tablaRoles').DataTable({
               "paging": true,
               "searching": true,
               "info": true,
               "autoWidth": false,
               "dom": 'Bfrtip',
               "buttons": [
                   {
                       extend: 'excelHtml5',
                       text: '<i class="fas fa-file-excel"></i> Exportar a Excel',
                       titleAttr: 'Exportar a Excel',
                       className: 'btn btn-success btn-custom',
                       title: 'Usuarios'
                   },
                   {
                       extend: 'pdfHtml5',
                       text: '<i class="fas fa-file-pdf"></i> Exportar a PDF',
                       titleAttr: 'Exportar a PDF',
                       className: 'btn btn-danger btn-custom', 
                       title: 'Usuarios'
                   }
               ],
               "language": {
                   "search": "Buscar:",
                   "lengthMenu": "Mostrar _MENU_ registros",
                   "info": "Mostrando _START_ de _TOTAL_ registros",
                   "infoEmpty": "No hay registros disponibles",
                   "paginate": {
                       "first": "Primero",
                       "last": "Último",
                       "next": "Siguiente",
                       "previous": "Anterior"
                   }
               }
           });

           // Botones de exportación manual
           $('#btnExportExcel').on('click', function () {
               table.button('.buttons-excel').trigger();
           });

           $('#btnExportPDF').on('click', function () {
               table.button('.buttons-pdf').trigger();
           });
       });
   </script>
</body>
</html>
