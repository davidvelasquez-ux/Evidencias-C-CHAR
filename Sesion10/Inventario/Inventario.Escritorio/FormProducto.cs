using Inventario.Modelos;

namespace Inventario.Escritorio;

public partial class FormProducto : Form
{
    // Producto nuevo; las validaciones salen de Producto
    public Producto? ProductoCreado { get; private set; }

    public FormProducto() => InitializeComponent();

    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        errorProvider1.Clear();
        try
        {
            ProductoCreado = new Producto(txtCodigo.Text, txtNombre.Text, nudPrecio.Value, (int)nudStock.Value);
            DialogResult = DialogResult.OK;   // cierra la ventanilla: ¡aprobado!
        }
        catch (ArgumentException ex)
        {
            errorProvider1.SetError(btnGuardar, ex.Message);
        }
    }
}
