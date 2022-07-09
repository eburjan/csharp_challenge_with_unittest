/*
 Developer Code Challenge
 
 Burjan Erno
*/

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace weborder_reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Title = "Choose WebOrder xml";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            button2.Enabled = false;

            ClearUi();
        }

        private UiResult uiResult;

        private void button1_Click(object sender, EventArgs e)
        {
            ClearUi();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                CheckFileExist();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckFileExist())
            {
                return;
            }

            ClearUi();
            ProcessXml();
            DisplayResult();
        }

        private void ClearUi()
        {
            label3.Text = string.Empty;
            label5.Text = string.Empty;
            label7.Text = string.Empty;
            label9.Text = string.Empty;
            label11.Text = string.Empty;
        }

        private void DisplayResult()
        {
            label3.Text = this.uiResult.Id;
            label5.Text = this.uiResult.Customer;
            label7.Text = this.uiResult.Date;
            label9.Text = this.uiResult.PriceAverage;
            label11.Text = this.uiResult.Total;
        }

        private bool CheckFileExist()
        {
            if (File.Exists(textBox1.Text))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

            return button2.Enabled;
        }

        private void ProcessXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WebOrder), new Type[] { typeof(WebOrderItem) });
            WebOrder webOrder;

            using (StreamReader streamReader = new StreamReader(textBox1.Text))
            {
                webOrder = (WebOrder)xmlSerializer.Deserialize(streamReader);
                streamReader.Close();
            }

            CalculateResult(webOrder);
        }

        private void CalculateResult(WebOrder webOrder)
        {
            decimal total = 0;
            decimal sumprice = 0;

            foreach (WebOrderItem webOrderItem in webOrder.Items)
            {
                sumprice += webOrderItem.Price;
                total += webOrderItem.Price * webOrderItem.Quantity;
            }

            decimal averagePrice = sumprice / webOrder.Items.Count;

            this.uiResult = new UiResult(
                webOrder.Id,
                webOrder.Customer,
                webOrder.Date.Value,
                averagePrice,
                total);
        }
    }
}
