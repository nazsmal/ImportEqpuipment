using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Import_Eqp.EqpService;
using Npoi.Mapper;
using Import_Eqp;

namespace ImportEquipment
{
    public partial class Form1 : Form
    {
        private IList<Eqpuipment> _eqpuipments;
        private IList<string> _exportResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                DefaultExt = "*.xls;*.xlsx",
                Title = "Выберите документ Excel",
                Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"
            };

            timer1.Enabled = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
                return;
            }
            try
            {
                var mapper = new Mapper(open.FileName);
                var rows = mapper.Take<Eqpuipment>("Лист1",65535).ToList();
                _eqpuipments = rows.Select(r => r.Value).ToList();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DataSource = _eqpuipments;
                MessageBox.Show("Файл успешно считан!", "Считывание файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка при считывании excel файла", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
   
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Button_ON()
        {
            button4.Enabled = true;
            button5.Enabled = true;
            button8.Enabled = true;
        }
        private void Button_OFF()
        {
            button4.Enabled = false;
            button5.Enabled = false;
            button8.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button_OFF();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                Button_ON();
        }
        private void Clear()
        {
            dataGridView1.DataSource = null;
            _eqpuipments.Clear();
            textBox1.Clear();
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            Button_OFF();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(+5);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar2.Increment(+10);
            if (progressBar2.Value == 100)
            {
                timer2.Enabled = false;
            }

        }
        public void Eqp()
        {
            using (var client = new EqpIntegrationServiceClient())
            {
                try
                {
                    client.Open();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Произошла ошибка: Нет связи с сервером\nУбедитесь в том, что правильно указана строка подключения в файле:\nImportEqpuipment.exe.config");
                    Close();
                }
                _exportResult = new List<string>();
                foreach (var eqpuipment in _eqpuipments)
                {
                    var req = new EqpInsertUpdateRequest()
                    {
                        headerField = new EqpInsertUpdateRequestHeader() { fileIdField = 0 },
                        itemField = new EqpInsertUpdateRequestItem()
                        {
                            //заполнить обязателными полями
                            itemNameField = eqpuipment.FullName ?? string.Empty, //not null
                            typeNameField = eqpuipment.EqpTypeName ?? string.Empty, //not null
                            kindField = eqpuipment.EqpKindName ?? string.Empty, //not null
                            stateField = eqpuipment.EqpStateName ?? string.Empty, //not null
                            mnfNumField = eqpuipment.MnfNum ?? string.Empty,
                            extensionIdField = eqpuipment.MnfNum ?? string.Empty, //привязка по заводкому номеру
                            legalBasisField = eqpuipment.LegalBasis ?? string.Empty, //not null
                            checkTypeField = eqpuipment.EqpCheckTypeName ?? string.Empty, //not null
                            mnfField = eqpuipment.Mnf ?? string.Empty,
                            mnfDateField = eqpuipment.MnfDateStr.ToString("yyyy-MM-dd"),
                            invNumField = string.IsNullOrWhiteSpace(eqpuipment.InvNum) ? "-" : eqpuipment.InvNum, //not null
                            locationField = eqpuipment.Location ?? string.Empty, //not null
                            //startUpField = eqpuipment.StartUpDateStr == default(DateTime) ? string.Empty : eqpuipment.StartUpDateStr.ToString("yyyy.MM.dd"),
                            startUpField = eqpuipment.StartUpDateStr.ToString("yyyy-MM-dd"),
                            //purposeField = eqpuipment.Purpose ?? string.Empty,
                            executerField = eqpuipment.UserId ?? string.Empty, //not null
                            //itemNoteField = eqpuipment.Note ?? string.Empty,
                            intervalTypeField = eqpuipment.IntervalTypeName ?? string.Empty, //not null
                            intervalLenField = eqpuipment.IntervalLenStr.ToString() ?? string.Empty, //not null
                            checkDateField = eqpuipment.CheckDateStr.ToString("yyyy-MM-dd"),
                            checkNextDateField = eqpuipment.NextDateStr.ToString("yyyy-MM-dd"),
                            checkPlaceField = eqpuipment.ECLPlace ?? string.Empty,
                            checkDocField = eqpuipment.ECLDoc ?? string.Empty,
                            checkDocDateField = eqpuipment.CheckDateStr.ToString("yyyy-MM-dd"),
                            //checkCommentField = eqpuipment.ECLComment ?? string.Empty,
                            subdivisionField = eqpuipment.EqpSubDivisions ?? string.Empty, //not null
                            inAccrScopeField = eqpuipment.InScopeAccreditation.ToString() ?? string.Empty, //not null
                        }
                    };
                    try
                    {
                        var answer = client.InsUpd(req);
                        eqpuipment.Service_Response = answer.headerField.errMsgField;
                    }
                    catch (EndpointNotFoundException)
                    {
                        MessageBox.Show("Произошла ошибка:\nНет связи с сервером\nУбедитесь в том, что:\n1. Серверный модуль интеграции I-LDS работает;\n2. Правильно указана строка подключения в файле: ImportEqpuipment.exe.config;\n3. Активность сервиса интеграции в файле: Indusoft.LDS.Server.DIM.Eqp.dll.config.");
                        Close();
                    }
                }

                client.Close();
                dataGridView1.Refresh();
            }
        }
        void button5_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            Eqp();  
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
