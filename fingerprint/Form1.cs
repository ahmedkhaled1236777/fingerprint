using PdfSharp.Drawing;
using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace fingerprint


{
    public partial class Form1 : Form
    {


        List<Dictionary<String, dynamic>> attendances = new List<Dictionary<String, dynamic>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            attendances.Clear();
            int index = 1;
            // Configure these values for your Access file
            string accessFilePath = @"C:\Program Files (x86)\ZKTeco\att2000.mdb"; // or .mdb
            string tableName = "CHECKINOUT";
            string table2 = "USERINFO";

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accessFilePath};";


            try
            {
                button1.Text = ".... Ã«—Ì «·⁄—÷";
                button1.Enabled = false;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Query to select data
                    string query = $"SELECT * FROM {tableName}";
                    string query2 = $"SELECT * FROM {table2}";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    Dictionary<string, String> nameid = new Dictionary<string, string>();
                    Dictionary<string, String> found = new Dictionary<string, string>();

                    using (OleDbDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {

                            nameid.Add(reader2[0].ToString(), reader2[3].ToString());


                        }

                    }


                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
                        {
                            MessageBox.Show("‰Â«Ì… «· «—ÌŒ ÌÃ» «‰  ﬂÊ‰ «ﬂ»— „‰ «·»œ«ÌÂ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            listView1.Items.Clear();



                            while (reader.Read())
                            {
                                DateTime pareseddate = DateTime.Parse($"{reader[1].ToString()}").Date;
                                string paresedtime = DateTime.Parse($"{reader[1].ToString()}").ToString("hh:mm:ss tt");



                                if (pareseddate >= dateTimePicker1.Value.Date && pareseddate <= dateTimePicker2.Value.Date)
                                {

                                    String type = $"{reader[1].ToString()}";

                                    ListViewItem lv = new ListViewItem();
                                    lv.Text = $"{index }";
                                    lv.SubItems.Add(nameid[$"{reader[0].ToString()}"]);

                                    lv.SubItems.Add($"{reader[1].ToString()}");
                                    lv.SubItems.Add(found.Keys.Contains($"{nameid[$"{reader[0].ToString()}"]}-{pareseddate.ToShortDateString()}") ? "«‰’—«›" : "Õ÷Ê—");

                                    if (!found.Keys.Contains($"{nameid[$"{reader[0].ToString()}"]}-{pareseddate.ToShortDateString()}")){ found.Add($"{nameid[$"{reader[0].ToString()}"]}-{pareseddate.ToShortDateString()}", "found"); }
                                    Dictionary<string, dynamic> z = new Dictionary<string, dynamic>();
                                    z.Add("name", nameid[$"{reader[0].ToString()}"]);
                                    z.Add("date",pareseddate.ToShortDateString());
                                    z.Add("time", paresedtime);
                                    z.Add("status", found.Keys.Contains($"{nameid[$"{reader[0].ToString()}"]}-{pareseddate.ToShortDateString()}") ? "«‰’—«›" : "Õ÷Ê—");
                                    attendances.Add(z);
                                    listView1.Items.Add(lv);
                                    index++;


                                }

                            }
                        }
                    }
                }

                //  ApiService.PostAttendancesAsync(attendances)
                /* Console.WriteLine(attendances.Count.ToString());
                  foreach (var attend in attendances)
                   {
                       Console.WriteLine("{" + string.Join(",", attend.Select(kvp => $"{kvp.Key}:{kvp.Value}")) + "}"); 

                   }
                 // Console.WriteLine("{" + string.Join(",", attend.Select(kvp => $"{kvp.Key}:{kvp.Value}")) + "}"); 
                */


                if (attendances.Count == 0)
                {
                    //hgghvghvghvgh
                    MessageBox.Show($"·« ÌÊÃœ Õ÷Ê— Ê«‰’—«› ›Ì  ﬂ «·„œÂ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                button1.Text = "⁄—÷";
                button1.Enabled = true;


            }
            catch (Exception ex)
            {
                button1.Text = "⁄—÷";
                button1.Enabled = true;

                MessageBox.Show($"{ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           // uygyugy
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (attendances.Count == 0)
            {
                //hgghvghvghvgh
                MessageBox.Show($"·« ÌÊÃœ Õ÷Ê— Ê«‰’—«› ›Ì  ﬂ «·„œÂ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                button2.Text = "Ã«—Ì «· Õ„Ì·";
                button2.Enabled = false;
                string status = await ApiService.PostAttendancesAsync(attendances);
                button2.Text = " Õ„Ì·";
                button2.Enabled = true;
                MessageBox.Show($"{status}", "«· √ﬂÌœ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Initialize PDF writer
            PdfWriter writer = new PdfWriter("ahmed");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Add content
            document.Add(new Paragraph("Hello, World!"));
            document.Add(new Paragraph("This is a PDF created with iTextSharp in C# Windows Forms."));

            // Add a table
            Table table = new Table(2);
            table.AddCell("Name");
            table.AddCell("Value");
            table.AddCell("Item 1");
            table.AddCell("100");
            table.AddCell("Item 2");
            table.AddCell("200");
            document.Add(table);

            // Close document
            document.Close();

            MessageBox.Show("PDF created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
