using Inventario.Modelos;

namespace Inventario.Escritorio;

public partial class FormProducto : Form
{
    // Producto nuevo o producto con los datos editados; las validaciones salen de Producto
    public Producto? ProductoCreado { get; private set; }

    // Modo agregar (también lo usa el diseñador de Visual Studio)
    public FormProducto() => InitializeComponent();

    // Modo editar: el código y el stock no se cambian aquí
    public FormProducto(Producto productoExistente) : this()
    {
        Text = "Editar producto";
        txtCodigo.Text = productoExistente.Codigo;
        txtNombre.Text = productoExistente.Nombre;
        nudPrecio.Value = productoExistente.Precio;
        nudStock.Value = productoExistente.Stock;

        txtCodigo.Enabled = false;
        nudStock.Enabled = false;   // el stock solo cambia con Vender y Agregar stock
    }

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
