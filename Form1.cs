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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GlobalVars.imie);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }

}
