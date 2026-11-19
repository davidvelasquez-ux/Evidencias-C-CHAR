using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

namespace Inventario.Escritorio;

public partial class FormPrincipal : Form
{
    // El mismo servicio de la consola: la ventana solo es otro "mesero"
    private readonly ServicioInventario _servicio = new(new RepositorioJson("inventario.json"));

    public FormPrincipal()
    {
        InitializeComponent();
        CargarProductos();
    }

    // Vuelve a llenar la tabla respetando el texto de búsqueda y la fila seleccionada
    private void CargarProductos()
    {
        string? codigoSeleccionado = Seleccionado()?.Codigo;
        List<Producto> todos = _servicio.Listar();

        // BuscarPorTexto devuelve una lista vacía con texto en blanco, así que ese caso muestra todo
        List<Producto> productos = string.IsNullOrWhiteSpace(txtBuscar.Text)
            ? todos
            : _servicio.BuscarPorTexto(txtBuscar.Text);

        dgvProductos.DataSource = null;          // suelta la lista vieja
        dgvProductos.DataSource = productos;

        SeleccionarPorCodigo(codigoSeleccionado);

        // El valor total siempre es el de todo el inventario, aunque haya un filtro
        decimal valorInventario = todos.Sum(p => p.Precio * p.Stock);
        lblValor.Text = $"Valor del inventario: {valorInventario:C0}";
    }

    private Producto? Seleccionado() => dgvProductos.CurrentRow?.DataBoundItem as Producto;

    private void SeleccionarPorCodigo(string? codigo)
    {
        if (codigo is null) return;

        foreach (DataGridViewRow fila in dgvProductos.Rows)
        {
            if (fila.DataBoundItem is Producto producto && producto.Codigo == codigo)
            {
                dgvProductos.CurrentCell = fila.Cells[0];
                fila.Selected = true;
                return;
            }
        }
    }

    // Avisa si no hay fila seleccionada
    private Producto? PedirSeleccion()
    {
        Producto? producto = Seleccionado();
        if (producto is null)
            MessageBox.Show("Selecciona un producto.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return producto;
    }

    private void txtBuscar_TextChanged(object? sender, EventArgs e) => CargarProductos();

    private void dgvProductos_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (dgvProductos.Columns["Precio"] is DataGridViewColumn precio)
            precio.DefaultCellStyle.Format = "C0";

        if (dgvProductos.Rows.Count == 0) return;

        // Stock bajo según la regla del servicio, para no repetir el límite aquí
        HashSet<string> codigosStockBajo = _servicio.StockBajo().Select(p => p.Codigo).ToHashSet();

        foreach (DataGridViewRow fila in dgvProductos.Rows)
        {
            bool stockBajo = fila.DataBoundItem is Producto producto && codigosStockBajo.Contains(producto.Codigo);
            fila.DefaultCellStyle.BackColor = stockBajo ? Color.MistyRose : Color.Empty;
        }
    }

    private void btnAgregar_Click(object? sender, EventArgs e)
    {
        using var form = new FormProducto();
        if (form.ShowDialog(this) != DialogResult.OK || form.ProductoCreado is null) return;

        try
        {
            _servicio.Agregar(form.ProductoCreado);
            CargarProductos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "No se pudo agregar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnVender_Click(object? sender, EventArgs e)
    {
        if (PedirSeleccion() is not Producto producto) return;

        try
        {
            _servicio.Vender(producto.Codigo, (int)nudCantidad.Value);
            CargarProductos();
        }
        catch (StockInsuficienteException ex)
        {
            MessageBox.Show(ex.Message, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "No se pudo vender", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnAgregarStock_Click(object? sender, EventArgs e)
    {
        if (PedirSeleccion() is not Producto producto) return;

        try
        {
            _servicio.AgregarStock(producto.Codigo, (int)nudCantidad.Value);
            CargarProductos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "No se pudo agregar stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (PedirSeleccion() is not Producto producto) return;

        DialogResult respuesta = MessageBox.Show($"¿Eliminar {producto.Nombre}?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (respuesta != DialogResult.Yes) return;

        try
        {
            _servicio.Eliminar(producto.Codigo);
            CargarProductos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

}

