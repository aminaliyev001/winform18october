using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text)
                || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Butun xanalar doldurulmalidir"); return;
            }
            string personInfo = $"{textBox2.Text}, {textBox3.Text}, {textBox4.Text}, {textBox5.Text}, {textBox6.Text}";
            listBox1.Items.Add(personInfo);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            List<string> items = new List<string>();
            foreach (var item in listBox1.Items)
            {
                items.Add(item.ToString());
            }
            string j = JsonSerializer.Serialize(items);
            string filename = textBox1.Text;
            File.WriteAllText($"{filename}.json", j);
            MessageBox.Show("File a yuklendi!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            string filename = textBox1.Text;
            if (File.Exists($"{filename}.json"))
            {
                string j = File.ReadAllText("data.json");
                List<string> items = JsonSerializer.Deserialize<List<string>>(j);
                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    listBox1.Items.Add(item);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
                return;

        }
    }
}