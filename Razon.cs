using System;
using System.Windows.Forms;

namespace FractionCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            string razon = razontextBox.Text;
            int numerator, denominator, result_numerator, result_denominator;
            float x1, x2, y1, y2, x, y, a, b;

            // Parse the input string to extract the numerator and denominator
            int slashPos = razon.IndexOf('/');
            if (slashPos != -1)
            {
                numerator = int.Parse(razon.Substring(0, slashPos));
                denominator = int.Parse(razon.Substring(slashPos + 1));

                // Calculate the result numerator and denominator
                result_numerator = numerator + denominator;
                result_denominator = denominator;

                // Simplify the fraction using the greatest common divisor (gcd)
                int common_divisor = GCD(result_numerator, result_denominator);
                result_numerator /= common_divisor;
                result_denominator /= common_divisor;

                razontextBox.Text = $"{result_numerator}/{result_denominator}";
            }
            else
            {
                MessageBox.Show("Entrada no válida. Asegúrate de usar el formato 'numerador/denominador'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit with an error code
            }

            x1 = float.Parse(x1textBox.Text);
            y1 = float.Parse(y1textBox.Text);
            x2 = float.Parse(x2textBox.Text);
            y2 = float.Parse(y2textBox.Text);

            a = x1 * denominator;
            x = (a + numerator * x2);
            b = y1 * denominator;
            y = (b + numerator * y2);

            // Display x and y as fractions
            xResultLabel.Text = $"Resultado x: {x}/{result_numerator}";
            yResultLabel.Text = $"Resultado y: {y}/{result_numerator}";
        }
    }
}
