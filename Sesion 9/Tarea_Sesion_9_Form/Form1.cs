using System.Globalization;

namespace Tarea;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        cboOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDestino.DropDownStyle = ComboBoxStyle.DropDownList;
        cboOrigen.Items.AddRange(ConversorTemperatura.Unidades);
        cboDestino.Items.AddRange(ConversorTemperatura.Unidades);
    }

    private bool Validar(out double valor)
    {
        errorProvider1.Clear();
        bool ok = true;

        string texto = txtValor.Text.Trim().Replace(',', '.');
        if (!double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
        {
            errorProvider1.SetError(txtValor, "Ingresa un valor numérico.");
            ok = false;
        }
        if (cboOrigen.SelectedIndex < 0)
        {
            errorProvider1.SetError(cboOrigen, "Elige la unidad de origen.");
            ok = false;
        }
        if (cboDestino.SelectedIndex < 0)
        {
            errorProvider1.SetError(cboDestino, "Elige la unidad de destino.");
            ok = false;
        }
        return ok;
    }

    private void btnConvertir_Click(object sender, EventArgs e)
    {
        if (!Validar(out double valor))
        {
            lblResultado.Text = "Resultado:";
            return;
        }

        string origen = (string)cboOrigen.SelectedItem!;
        string destino = (string)cboDestino.SelectedItem!;
        double r = ConversorTemperatura.Convertir(valor, origen, destino);

        lblResultado.Text = string.Create(CultureInfo.CurrentCulture,
            $"Resultado: {valor:0.##} {origen} = {r:0.##} {destino}");
    }
}
