using Microsoft.VisualBasic;
using System.Data;
using System.IO;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public DataGridView dataGridView1 = new DataGridView();
        public static class GlobalVars
        {
            public static string imie = "";
            public static string nazwisko = "";
            public static string Wiek = "";
            public static string Stanowisko = "";
            public static int Ad = 0;

        }
       
        public Form1()
        {
            InitializeComponent();   
            dataGridView1.Dock = DockStyle.Fill;

            dataGridView1.Columns.Add("Column1", "Imie:");
            dataGridView1.Columns.Add("Column2", "Nazwisko:");
            dataGridView1.Columns.Add("Column3", "Wiek:");
            dataGridView1.Columns.Add("Column4", "Stanowisko:");



            dataGridView1.Rows.Add(new object[] { "Imie_1", "Nazwisko_1","40","Sanowisko_1" });
            dataGridView1.Rows.Add(new object[] { "Imie_2", "Nazwisko_2", "25", "Sanowisko_2" });
            dataGridView1.Rows.Add(new object[] { "Imie_3", "Nazwisko_3","32","Sanowisko_1" });
            dataGridView1.Rows.Add(new object[] { "Imie_4", "Nazwisko_4","23","Sanowisko_2" });


            Controls.Add(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }

        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            List<string> csvLines = new List<string>();

            // Nag³ówek
            var columnNames = dataGridView.Columns.Cast<DataGridViewColumn>()
                                                  .Select(col => col.HeaderText);
            csvLines.Add(string.Join(",", columnNames));

            // Dane
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var values = row.Cells.Cast<DataGridViewCell>()
                                          .Select(c => c.Value?.ToString() ?? ""); // Obs³uga null
                    csvLines.Add(string.Join(",", values));
                }
            }

            // Zapis do pliku
            File.WriteAllLines(filePath, csvLines);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string To_delete = Interaction.InputBox("Podaj index do usuniecia");

            if (int.TryParse(To_delete, out int index))
            {
                if (index >= 0 && index < dataGridView1.Rows.Count) {
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawny index");
            }
        }

        private void LoadCSVToDataGridView(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = File.ReadAllLines(filePath, System.Text.Encoding.UTF8);

            if (lines.Length == 0)
            {
                MessageBox.Show("Plik CSV jest pusty.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Rows.Clear();

            if (dataGridView1.Columns.Count == 0)
            {
                string[] headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
                foreach (string header in headers)
                {
                    dataGridView1.Columns.Add(header, header);
                }
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                if (values.Length == dataGridView1.Columns.Count)
                {
                    dataGridView1.Rows.Add(values);
                }
                else
                {
                    MessageBox.Show($"B³¹d w linii {i + 1}: ró¿na liczba kolumn.", "B³¹d CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadCSVToDataGridView("C:\\Users\\Maciej\\source\\repos\\App3\\Plik.csv");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportToCSV(dataGridView1, "C:\\Users\\Maciej\\source\\repos\\App3\\Plik.csv");
        }
    }

}
