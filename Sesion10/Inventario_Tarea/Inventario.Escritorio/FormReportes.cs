using Inventario.Servicios;

namespace Inventario.Escritorio;

public partial class FormReportes : Form
{
    private const int CantidadMasValiosos = 5;

    private readonly ServicioInventario? _servicio;

    // Constructor vacío para el diseñador de Visual Studio
    public FormReportes() => InitializeComponent();

    public FormReportes(ServicioInventario servicio) : this() => _servicio = servicio;

    // Las tablas se llenan al abrir la ventana, cuando ya existen sus controles
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (_servicio is null) return;

        // Más valiosos = mayor valor en inventario (precio x stock)
        dgvMasValiosos.DataSource = _servicio.Listar()
            .Select(p => new { p.Codigo, p.Nombre, p.Precio, p.Stock, Valor = p.Precio * p.Stock })
            .OrderByDescending(p => p.Valor)
            .Take(CantidadMasValiosos)
            .ToList();
        FormatoMoneda(dgvMasValiosos, "Precio", "Valor");

        dgvStockBajo.DataSource = _servicio.StockBajo();
        FormatoMoneda(dgvStockBajo, "Precio");
    }

    private static void FormatoMoneda(DataGridView tabla, params string[] columnas)
    {
        foreach (string columna in columnas)
            tabla.Columns[columna]!.DefaultCellStyle.Format = "C0";
    }
}
