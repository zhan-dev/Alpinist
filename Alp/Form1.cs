using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;


//using System.Data.OleDb;

namespace Alp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void ЗагрузкаФайлаcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; //filter
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // openFileDialog.ShowDialog();
                dgv_Employees.Visible = true; //Видимость DataGreed
                textBox1.Visible = true; //Видимость пути файла
                cboSheet.Visible = false; //Видимость combobox

                textBox1.Text = openFileDialog.FileName;
                BindDataCSV(textBox1.Text);      
            }                   
        }
        private void BindDataCSV(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                //first line to create header              
                string firstLine = lines[1]; //указание начальной строки для названий столбцов

                string[] headerLabels = firstLine.Split(','); //разделитель стобцов в файле

                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                //for data

                for (int i = 2; i < lines.Length; i++) //где i-первая строка начала нужной выборки данных
                {
                    string[] dataWords = lines[i].Split(',');

                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;

                    foreach (string headerWord in headerLabels)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }

                if (dt.Rows.Count > 0)
                {
                    dgv_Employees.DataSource = dt;
                }   
            }
            // Замена разделителя '.' на ','
            for (int i = 0; i < dgv_Employees.Rows.Count; ++i)
            {
                dgv_Employees[1, i].Value = dgv_Employees[1, i].Value.ToString().Replace('.', ',');
                dgv_Employees[2, i].Value = dgv_Employees[2, i].Value.ToString().Replace('.', ',');
            }

            //Нумерация
            for (int i = 0; i < dgv_Employees.Rows.Count; ++i)
            {   
                dgv_Employees.Rows[i].Cells[0].Value = i + 1; //Нумерация после построения
            }

            //Построение графика
            start_chart.Series[0].Points.Clear();
            start_chart.Series[1].Points.Clear();

            for (int i = 0; i < dgv_Employees.Rows.Count; ++i)
            {
                start_chart.Series[0].Points.AddXY(Convert.ToDouble(dgv_Employees[0, i].Value),
                                                   Convert.ToDouble(dgv_Employees[2, i].Value));
            }


            start_f.Clear(); end_f.Clear();

            range_Filtr.Properties.Maximum = Convert.ToInt32(dgv_Employees.RowCount); //Количество значений в таблице
            range_Filtr.EditValue = new TrackBarRange(0, dgv_Employees.RowCount); //Ползунок в конец


            //Размеры строк дата грид
            dgv_Employees.Columns[0].Width = 40;
            dgv_Employees.Columns[1].Width = 70;
            dgv_Employees.Columns[2].Width = 70;

        }       

        private void Dgv_Employees_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            
            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);              
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ЗагрузкаФайлаxlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            { Filter = "XLSX files (*.xlsx)|*.xlsx|XLS files (*.xls)|*.xls|All files (*.*)|*.*", ValidateNames = true })
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    start_chart.Series[0].Points.Clear(); //Очистка графика
                    dgv_Employees.Visible = true; //Видимость DataGreed
                    textBox1.Visible = true; //Видимость пути файла
                    cboSheet.Visible = true; //Видимость combobox
                    
                    textBox1.Text = dialog.FileName;
                    
                    using (var stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        try
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                });
                                tableCollection = result.Tables;
                                cboSheet.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cboSheet.Items.Add(table.TableName); //add sheet to combobox

                                dgv_Employees.DataSource = result.Tables[0]; // По умолчанию открывается лист №1
                                cboSheet.Text = cboSheet.Items[0].ToString(); //По умолчанию в combobox загружается лист №1

                                range_Filtr.Properties.Maximum = Convert.ToInt32(dgv_Employees.RowCount); //Количество значений в таблице
                                range_Filtr.EditValue = new TrackBarRange(0, dgv_Employees.RowCount); //Ползунок в конец

                                //Размеры строк дата грид
                                dgv_Employees.Columns[0].Width = 40;
                                dgv_Employees.Columns[1].Width = 70;
                                dgv_Employees.Columns[2].Width = 70;

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "System error");
                        }
                        
                    }
                }
        }

        DataTableCollection tableCollection;       

        private void CboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()]; 
            dgv_Employees.DataSource = dt;

            //Нумерация
            for (int i = 0; i < dgv_Employees.Rows.Count; ++i)
            {
                dgv_Employees.Rows[i].Cells[0].Value = i + 1; //Нумерация после построения
            }

            //Очистка линий и построение графика
            start_chart.Series[0].Points.Clear();
            start_chart.Series[1].Points.Clear();

            for (int i = 0; i < dgv_Employees.Rows.Count; ++i)
            {
                start_chart.Series[0].Points.AddXY(Convert.ToDouble(dgv_Employees[0, i].Value),
                                                   Convert.ToDouble(dgv_Employees[2, i].Value));
            }

            //?????????????????????????????????????
            range_Filtr.Properties.Maximum = Convert.ToInt32(dgv_Employees.RowCount); //Количество значений в таблице
            range_Filtr.EditValue = new TrackBarRange(0, dgv_Employees.RowCount); //Ползунок в конец


            //Размеры строк дата грид
            dgv_Employees.Columns[0].Width = 40;
            dgv_Employees.Columns[1].Width = 70;
            dgv_Employees.Columns[2].Width = 70;
        }

        private void CboSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //запрет ввода в combobox
        }


        Form_regression form2_regression;
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                   
                if (form2_regression == null || form2_regression.IsDisposed)
                {
                    form2_regression = new Form_regression();
                    form2_regression.Show();

                }
                else
                {
                    form2_regression.Show();
                }

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dgv_filtr.Visible = true;
            //Присваивание размерности исходной таблицы к новой
            dgv_filtr.RowCount = dgv_Employees.RowCount;
            dgv_filtr.ColumnCount = dgv_Employees.ColumnCount;

            //Имя и размер колонки нумерации
            dgv_filtr.Columns[0].HeaderText = dgv_Employees.Columns[0].HeaderText;
            dgv_filtr.Columns[0].Width = dgv_Employees.Columns[0].Width;
            dgv_filtr.Columns[1].Width = dgv_Employees.Columns[1].Width;
            dgv_filtr.Columns[2].Width = dgv_Employees.Columns[2].Width;
            //dgv_filtr.Columns[0].Visible = false; //скрытие столбика нумерации

            dgv_filtr.Columns[1].HeaderText = "Time";
            dgv_filtr.Columns[2].HeaderText = "Impuls";

            //А теперь пройдемся циклом по всем ячейкам
            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_filtr.Columns.Count; ++j)
                {
                    dgv_filtr[j, i].Value = dgv_Employees[j, i].Value;
                }
                //dgv_filtr.Rows[i].Cells[0].Value = i + 1; //Нумерация после построения
                //dgv_filtr.Rows[i].Cells[1].Value = dgv_Employees.Rows[i].Cells[0].Value; //альтернативная загрузка по столбцам
                //dgv_filtr.Rows[i].Cells[2].Value = dgv_Employees.Rows[i].Cells[1].Value;
            }

            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_filtr.Columns.Count; ++j)
                {
                    //Ручной фильтр
                    if (Convert.ToDouble(start_f.Text) <= Convert.ToDouble(dgv_filtr[0, i].Value) 
                                                    && 
                        Convert.ToDouble(end_f.Text) >= Convert.ToDouble(dgv_filtr[0, i].Value))
                    {
                        dgv_filtr[j, i].Value = dgv_filtr[j, i].Value;
                    }
                    else
                    {
                        dgv_filtr[j, i].Value = 0;
                    }        
                }
            }
            //Цикл удаления
            for (int i = dgv_filtr.RowCount - 1; i > -1; i--)
            {
                //if (Convert.ToDouble(dgv_filtr[0, i].Value) == 0)
                if (Convert.ToDouble(dgv_filtr.Rows[i].Cells[0].Value) == 0)
                {
                    dgv_filtr.Rows.RemoveAt(i);
                }
            }
            //Очистка линий и построение графика
            start_chart.Series[1].Points.Clear();

            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                start_chart.Series[1].Points.AddXY(Convert.ToDouble(dgv_filtr[0, i].Value),
                                                   Convert.ToDouble(dgv_filtr[2, i].Value));
            }

            //Чек фильтр
            check_Filtr.Checked = true;

        }

        private void Start_f_TextChanged(object sender, EventArgs e)
        {
            Method_Filtr_un_checked(false);

            if ( (start_f.Text=="") || (end_f.Text == "") || (float.Parse(start_f.Text) >= float.Parse(end_f.Text)) )
            {
                btn_Filtr.Enabled = false;
            }
            else
            {
                btn_Filtr.Enabled = true;
                range_Filtr.EditValue = new TrackBarRange(Convert.ToInt32(start_f.Text), range_Filtr.Value.Maximum);
            }
        }

        bool Method_Filtr_un_checked(bool Filtr_t_or_f)
        {
            return check_Filtr.Checked = Filtr_t_or_f;
        }

        private void Dgv_Employees_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // выдает первый и последний порядковые номера
            //this.dgv_Employees.Rows[e.RowIndex].Cells[0].Value = this.dgv_Employees.Rows.Count;

        }

        private void Start_f_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void РегрессионныйАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form2_regression == null || form2_regression.IsDisposed)
            {
                form2_regression = new Form_regression();
            }

            // Линейная
            form2_regression.dgv_line.RowCount = this.dgv_range.RowCount;
            form2_regression.dgv_line.ColumnCount = this.dgv_range.ColumnCount + 4;

            //Имя и размер колонки нумерации
            form2_regression.dgv_line.Columns[0].HeaderText = this.dgv_range.Columns[0].HeaderText;
            form2_regression.dgv_line.Columns[1].HeaderText = this.dgv_range.Columns[1].HeaderText;
            form2_regression.dgv_line.Columns[2].HeaderText = this.dgv_range.Columns[2].HeaderText;
            form2_regression.dgv_line.Columns[3].HeaderText = "x ^ 2";
            form2_regression.dgv_line.Columns[4].HeaderText = "x * y";
            form2_regression.dgv_line.Columns[5].HeaderText = "Function";
            form2_regression.dgv_line.Columns[6].HeaderText = "Error";


            form2_regression.dgv_line.Columns[0].Width = this.dgv_range.Columns[0].Width;
            form2_regression.dgv_line.Columns[1].Width = this.dgv_range.Columns[1].Width;
            form2_regression.dgv_line.Columns[2].Width = this.dgv_range.Columns[2].Width;
            form2_regression.dgv_line.Columns[3].Width = 70;
            form2_regression.dgv_line.Columns[4].Width = 70;
            form2_regression.dgv_line.Columns[5].Width = 70;
            form2_regression.dgv_line.Columns[6].Width = 70;

            for (int i = 0; i < dgv_range.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_range.Columns.Count; ++j)
                {
                    form2_regression.dgv_line[j, i].Value = this.dgv_range[j, i].Value;
                }
            }

            //Переменные
            var sum_X_lin = Convert.ToDouble(0);
            var sum_XX_lin = Convert.ToDouble(0);
            var sum_XY_lin = Convert.ToDouble(0);
            var sum_Y_lin = Convert.ToDouble(0);

            //Расчет линейной функции
            for (int i = 0; i < form2_regression.dgv_line.Rows.Count; ++i)
            {
                form2_regression.dgv_line[3, i].Value = Math.Pow(
                    Convert.ToDouble(this.form2_regression.dgv_line[1, i].Value), 2);

                form2_regression.dgv_line[4, i].Value = Convert.ToDouble(form2_regression.dgv_line[1, i].Value)
                                                           * Convert.ToDouble(form2_regression.dgv_line[2, i].Value);


                sum_X_lin = Convert.ToDouble(form2_regression.dgv_line[1, i].Value) + sum_X_lin;
                form2_regression.txt1_line.Text = Convert.ToString(sum_X_lin);

                sum_XX_lin = Convert.ToDouble(form2_regression.dgv_line[3, i].Value) + sum_XX_lin;
                form2_regression.txt2_line.Text = Convert.ToString(sum_XX_lin);

                sum_XY_lin = Convert.ToDouble(form2_regression.dgv_line[4, i].Value) + sum_XY_lin;
                form2_regression.txt3_line.Text = Convert.ToString(sum_XY_lin);

                sum_Y_lin = Convert.ToDouble(form2_regression.dgv_line[2, i].Value) + sum_Y_lin;
                form2_regression.txt4_line.Text = Convert.ToString(sum_Y_lin);

                var Num = Convert.ToDouble(this.txt_Num.Text);

                //Коэффициенты 
                form2_regression.txt5_line.Text = Convert.ToString(
                    ((Convert.ToDouble(form2_regression.txt2_line.Text) * Convert.ToDouble(form2_regression.txt4_line.Text)) -
                    (Convert.ToDouble(form2_regression.txt1_line.Text) * Convert.ToDouble(form2_regression.txt3_line.Text))) /
                    ((Num * Convert.ToDouble(form2_regression.txt2_line.Text)) -
                    (Convert.ToDouble(form2_regression.txt1_line.Text) * Convert.ToDouble(form2_regression.txt1_line.Text)))
                                                                    );

                form2_regression.txt6_line.Text = Convert.ToString(
                    ((Num * Convert.ToDouble(form2_regression.txt3_line.Text)) -
                    (Convert.ToDouble(form2_regression.txt1_line.Text) * Convert.ToDouble(form2_regression.txt4_line.Text))) /
                    (Num * Convert.ToDouble(form2_regression.txt2_line.Text) -
                    (Convert.ToDouble(form2_regression.txt1_line.Text) * Convert.ToDouble(form2_regression.txt1_line.Text)))
                                                                    );
            }
            var sum_error_lin = Convert.ToDouble(0);

            for (int i = 0; i < form2_regression.dgv_line.Rows.Count; ++i)
            {
                form2_regression.dgv_line[5, i].Value = Convert.ToDouble(form2_regression.txt5_line.Text) +
                        Convert.ToDouble(form2_regression.dgv_line[1, i].Value) * Convert.ToDouble(form2_regression.txt6_line.Text);

                form2_regression.dgv_line[6, i].Value = Math.Pow(
                    (Convert.ToDouble(form2_regression.dgv_line[5, i].Value) -
                                    Convert.ToDouble(form2_regression.dgv_line[2, i].Value)), 2);

                sum_error_lin = Convert.ToDouble(form2_regression.dgv_line[6, i].Value) + sum_error_lin;
                form2_regression.txt7_line.Text = Convert.ToString(sum_error_lin);

                form2_regression.txt8_line.Text = Convert.ToString(
                        Math.Sqrt(Convert.ToDouble(form2_regression.txt7_line.Text) /
                        (Convert.ToDouble(this.txt_Num.Text) - 2)));
            }

            //Округление линейной
            for (int i = 0; i < form2_regression.dgv_line.Rows.Count; ++i)
            {
                form2_regression.dgv_line[3, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_line[3, i].Value), 4);
                form2_regression.dgv_line[4, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_line[4, i].Value), 4);
                form2_regression.dgv_line[5, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_line[5, i].Value), 4);
                form2_regression.dgv_line[6, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_line[6, i].Value), 4);

                form2_regression.txt1_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt1_line.Text), 4));
                form2_regression.txt2_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt2_line.Text), 4));
                form2_regression.txt3_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt3_line.Text), 4));
                form2_regression.txt4_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt4_line.Text), 4));
                form2_regression.txt5_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt5_line.Text), 4));
                form2_regression.txt6_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt6_line.Text), 4));
                form2_regression.txt7_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt7_line.Text), 4));

                form2_regression.txt8_line.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt8_line.Text), 7));
            }

            // Показательная
            form2_regression.dgv_pokazat.RowCount = this.dgv_range.RowCount;
            form2_regression.dgv_pokazat.ColumnCount = this.dgv_range.ColumnCount + 5;

            //Имя и размер колонки нумерации
            form2_regression.dgv_pokazat.Columns[0].HeaderText = this.dgv_range.Columns[0].HeaderText;
            form2_regression.dgv_pokazat.Columns[1].HeaderText = this.dgv_range.Columns[1].HeaderText;
            form2_regression.dgv_pokazat.Columns[2].HeaderText = this.dgv_range.Columns[2].HeaderText;
            form2_regression.dgv_pokazat.Columns[3].HeaderText = "x ^ 2";
            form2_regression.dgv_pokazat.Columns[4].HeaderText = "Log (y)";
            form2_regression.dgv_pokazat.Columns[5].HeaderText = "x*Log(y)";
            form2_regression.dgv_pokazat.Columns[6].HeaderText = "Function";
            form2_regression.dgv_pokazat.Columns[7].HeaderText = "Error";


            form2_regression.dgv_pokazat.Columns[0].Width = this.dgv_range.Columns[0].Width;
            form2_regression.dgv_pokazat.Columns[1].Width = this.dgv_range.Columns[1].Width;
            form2_regression.dgv_pokazat.Columns[2].Width = this.dgv_range.Columns[2].Width;
            form2_regression.dgv_pokazat.Columns[3].Width = 70;
            form2_regression.dgv_pokazat.Columns[4].Width = 70;
            form2_regression.dgv_pokazat.Columns[5].Width = 70;
            form2_regression.dgv_pokazat.Columns[6].Width = 70;
            form2_regression.dgv_pokazat.Columns[7].Width = 70;

            for (int i = 0; i < dgv_range.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_range.Columns.Count; ++j)
                {
                    form2_regression.dgv_pokazat[j, i].Value = this.dgv_range[j, i].Value;
                }
            }

            //Переменные
            var sum_X_pokazat = Convert.ToDouble(0);
            var sum_XX_pokazat = Convert.ToDouble(0);
            var sum_Log_Y_pokazat = Convert.ToDouble(0);
            var sum_Log_Y_X_pokazat = Convert.ToDouble(0);

            //Расчет показательной функции
            for (int i = 0; i < form2_regression.dgv_pokazat.Rows.Count; ++i)
            {
                form2_regression.dgv_pokazat[3, i].Value = Math.Pow(
                    Convert.ToDouble(this.form2_regression.dgv_pokazat[1, i].Value), 2);

                form2_regression.dgv_pokazat[4, i].Value = Math.Log(
                    Convert.ToDouble(form2_regression.dgv_pokazat[2, i].Value));

                form2_regression.dgv_pokazat[5, i].Value = Convert.ToDouble(form2_regression.dgv_pokazat[1, i].Value) *
                                                           Convert.ToDouble(form2_regression.dgv_pokazat[4, i].Value);

                sum_X_pokazat = Convert.ToDouble(form2_regression.dgv_pokazat[1, i].Value) + sum_X_pokazat;
                form2_regression.txt1_pokazat.Text = Convert.ToString(sum_X_pokazat);

                sum_XX_pokazat = Convert.ToDouble(form2_regression.dgv_pokazat[3, i].Value) + sum_XX_pokazat;
                form2_regression.txt2_pokazat.Text = Convert.ToString(sum_XX_pokazat);

                sum_Log_Y_pokazat = Convert.ToDouble(form2_regression.dgv_pokazat[4, i].Value) + sum_Log_Y_pokazat;
                form2_regression.txt3_pokazat.Text = Convert.ToString(sum_Log_Y_pokazat);

                sum_Log_Y_X_pokazat = Convert.ToDouble(form2_regression.dgv_pokazat[5, i].Value) + sum_Log_Y_X_pokazat;
                form2_regression.txt4_pokazat.Text = Convert.ToString(sum_Log_Y_X_pokazat);

                //Коэффициенты 
                var Num = Convert.ToDouble(this.txt_Num.Text);
                double pm, pm1, bp, ap;

                pm1 = Convert.ToDouble(form2_regression.txt3_pokazat.Text) / Num;
                pm = Convert.ToDouble(form2_regression.txt1_pokazat.Text) / Num;

                bp = (sum_Log_Y_X_pokazat / sum_X_pokazat - pm1) / (sum_XX_pokazat / sum_X_pokazat - pm);
                ap = Math.Exp(pm1 - bp * pm);

                form2_regression.txt5_pokazat.Text = Convert.ToString(ap);
                form2_regression.txt6_pokazat.Text = Convert.ToString(bp);

            }
            var sum_error_pokazat = Convert.ToDouble(0);
            double stepen;

            for (int i = 0; i < form2_regression.dgv_pokazat.Rows.Count; ++i)
            {

                stepen = Convert.ToDouble(form2_regression.txt6_pokazat.Text) *
                         Convert.ToDouble(form2_regression.dgv_pokazat[1, i].Value);

                form2_regression.dgv_pokazat[6, i].Value = Convert.ToDouble(form2_regression.txt5_pokazat.Text) *
                    (Math.Exp(Math.Log(Math.Exp(1)) * stepen));

                form2_regression.dgv_pokazat[7, i].Value = Math.Pow(
                    (Convert.ToDouble(form2_regression.dgv_pokazat[2, i].Value) -
                    Convert.ToDouble(form2_regression.dgv_pokazat[6, i].Value)), 2);

                sum_error_pokazat = Convert.ToDouble(form2_regression.dgv_pokazat[7, i].Value) + sum_error_pokazat;
                form2_regression.txt7_pokazat.Text = Convert.ToString(sum_error_pokazat);

                form2_regression.txt8_pokazat.Text = Convert.ToString(
                        Math.Sqrt(Convert.ToDouble(form2_regression.txt7_pokazat.Text) /
                        (Convert.ToDouble(this.txt_Num.Text) - 2)));
            }

            //Округление показательной
            for (int i = 0; i < form2_regression.dgv_pokazat.Rows.Count; ++i)
            {
                form2_regression.dgv_pokazat[3, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_pokazat[3, i].Value), 4);
                form2_regression.dgv_pokazat[4, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_pokazat[4, i].Value), 4);
                form2_regression.dgv_pokazat[5, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_pokazat[5, i].Value), 4);
                form2_regression.dgv_pokazat[6, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_pokazat[6, i].Value), 4);
                form2_regression.dgv_pokazat[7, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_pokazat[7, i].Value), 4);

                form2_regression.txt1_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt1_pokazat.Text), 4));
                form2_regression.txt2_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt2_pokazat.Text), 4));
                form2_regression.txt3_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt3_pokazat.Text), 4));
                form2_regression.txt4_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt4_pokazat.Text), 4));
                form2_regression.txt5_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt5_pokazat.Text), 4));
                form2_regression.txt6_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt6_pokazat.Text), 4));
                form2_regression.txt7_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt7_pokazat.Text), 4));

                form2_regression.txt8_pokazat.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt8_pokazat.Text), 7));
            }

            // Степенная
            form2_regression.dgv_stepen.RowCount = this.dgv_range.RowCount;
            form2_regression.dgv_stepen.ColumnCount = this.dgv_range.ColumnCount + 6;

            //Имя и размер колонки нумерации
            form2_regression.dgv_stepen.Columns[0].HeaderText = this.dgv_range.Columns[0].HeaderText;
            form2_regression.dgv_stepen.Columns[1].HeaderText = this.dgv_range.Columns[1].HeaderText;
            form2_regression.dgv_stepen.Columns[2].HeaderText = this.dgv_range.Columns[2].HeaderText;
            form2_regression.dgv_stepen.Columns[3].HeaderText = "Log ( x )";
            form2_regression.dgv_stepen.Columns[4].HeaderText = "Log ( y )";
            form2_regression.dgv_stepen.Columns[5].HeaderText = "Log(x)^2";
            form2_regression.dgv_stepen.Columns[6].HeaderText = "Log(x)*Log(y)";
            form2_regression.dgv_stepen.Columns[7].HeaderText = "Function";
            form2_regression.dgv_stepen.Columns[8].HeaderText = "Error";


            form2_regression.dgv_stepen.Columns[0].Width = this.dgv_range.Columns[0].Width;
            form2_regression.dgv_stepen.Columns[1].Width = this.dgv_range.Columns[1].Width;
            form2_regression.dgv_stepen.Columns[2].Width = this.dgv_range.Columns[2].Width;
            form2_regression.dgv_stepen.Columns[3].Width = 70;
            form2_regression.dgv_stepen.Columns[4].Width = 70;
            form2_regression.dgv_stepen.Columns[5].Width = 70;
            form2_regression.dgv_stepen.Columns[6].Width = 70;
            form2_regression.dgv_stepen.Columns[7].Width = 70;
            form2_regression.dgv_stepen.Columns[8].Width = 70;

            for (int i = 0; i < dgv_range.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_range.Columns.Count; ++j)
                {
                    form2_regression.dgv_stepen[j, i].Value = this.dgv_range[j, i].Value;
                }
            }

            //Переменные
            var sum_Y_stepen = Convert.ToDouble(0);
            var sum_Log_X_stepen = Convert.ToDouble(0);
            var sum_Log_Y_stepen = Convert.ToDouble(0);
            var sum_Log_X_X_stepen = Convert.ToDouble(0);
            var sum_Log_X_Log_Y_stepen = Convert.ToDouble(0);

            //Расчет показательной функции
            for (int i = 0; i < form2_regression.dgv_stepen.Rows.Count; ++i)
            {
                form2_regression.dgv_stepen[3, i].Value = Math.Log10(
                    Convert.ToDouble(this.form2_regression.dgv_stepen[1, i].Value));

                form2_regression.dgv_stepen[4, i].Value = Math.Log10(
                    Convert.ToDouble(form2_regression.dgv_stepen[2, i].Value));

                form2_regression.dgv_stepen[5, i].Value = Math.Pow(
                    Convert.ToDouble(form2_regression.dgv_stepen[3, i].Value), 2);

                form2_regression.dgv_stepen[6, i].Value = Convert.ToDouble(form2_regression.dgv_stepen[3, i].Value) *
                    Convert.ToDouble(form2_regression.dgv_stepen[4, i].Value);


                sum_Y_stepen = Convert.ToDouble(form2_regression.dgv_stepen[2, i].Value) + sum_Y_stepen;
                form2_regression.txt1_stepen.Text = Convert.ToString(sum_Y_stepen);

                sum_Log_X_stepen = Convert.ToDouble(form2_regression.dgv_stepen[3, i].Value) + sum_Log_X_stepen;
                form2_regression.txt2_stepen.Text = Convert.ToString(sum_Log_X_stepen);

                sum_Log_Y_stepen = Convert.ToDouble(form2_regression.dgv_stepen[4, i].Value) + sum_Log_Y_stepen;
                form2_regression.txt3_stepen.Text = Convert.ToString(sum_Log_Y_stepen);

                sum_Log_X_X_stepen = Convert.ToDouble(form2_regression.dgv_stepen[5, i].Value) + sum_Log_X_X_stepen;
                form2_regression.txt4_stepen.Text = Convert.ToString(sum_Log_X_X_stepen);

                sum_Log_X_Log_Y_stepen = Convert.ToDouble(form2_regression.dgv_stepen[6, i].Value) + sum_Log_X_Log_Y_stepen;
                form2_regression.txt5_stepen.Text = Convert.ToString(sum_Log_X_Log_Y_stepen);

                //Коэффициенты 
                double b_stepen, log_a0_stepen, a0_stepen;

                b_stepen =
                    (Convert.ToDouble(form2_regression.txt5_stepen.Text) / Convert.ToDouble(form2_regression.txt2_stepen.Text) -
                     Convert.ToDouble(form2_regression.txt3_stepen.Text) / Convert.ToDouble(this.txt_Num.Text))
                                                                        /
                    (Convert.ToDouble(form2_regression.txt4_stepen.Text) / Convert.ToDouble(form2_regression.txt2_stepen.Text) -
                     Convert.ToDouble(form2_regression.txt2_stepen.Text) / Convert.ToDouble(this.txt_Num.Text));

                log_a0_stepen =
                    Convert.ToDouble(form2_regression.txt3_stepen.Text) / Convert.ToDouble(this.txt_Num.Text) -
                    (b_stepen * (Convert.ToDouble(form2_regression.txt2_stepen.Text) / Convert.ToDouble(this.txt_Num.Text)));

                a0_stepen = Math.Exp(log_a0_stepen * Math.Log(10));

                form2_regression.txt6_stepen.Text = Convert.ToString(a0_stepen);
                form2_regression.txt7_stepen.Text = Convert.ToString(b_stepen);

            }

            var sum_error_stepen = Convert.ToDouble(0);

            for (int i = 0; i < form2_regression.dgv_stepen.Rows.Count; ++i)
            {

                form2_regression.dgv_stepen[7, i].Value = Convert.ToDouble(form2_regression.txt6_stepen.Text) *
                    (Math.Exp(Convert.ToDouble(form2_regression.txt7_stepen.Text) *
                     Math.Log(Convert.ToDouble(form2_regression.dgv_stepen[1, i].Value))));

                form2_regression.dgv_stepen[8, i].Value = Math.Pow(
                    (Convert.ToDouble(form2_regression.dgv_stepen[2, i].Value) -
                    Convert.ToDouble(form2_regression.dgv_stepen[7, i].Value)), 2);

                sum_error_stepen = Convert.ToDouble(form2_regression.dgv_stepen[8, i].Value) + sum_error_stepen;
                form2_regression.txt8_stepen.Text = Convert.ToString(sum_error_stepen);

                form2_regression.txt9_stepen.Text = Convert.ToString(
                        Math.Sqrt(Convert.ToDouble(form2_regression.txt8_stepen.Text) /
                        (Convert.ToDouble(this.txt_Num.Text) - 2)));
            }

            //Округление степенной
            for (int i = 0; i < form2_regression.dgv_stepen.Rows.Count; ++i)
            {
                form2_regression.dgv_stepen[3, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_stepen[3, i].Value), 4);
                form2_regression.dgv_stepen[4, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_stepen[4, i].Value), 4);
                form2_regression.dgv_stepen[5, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_stepen[5, i].Value), 4);
                form2_regression.dgv_stepen[6, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_stepen[6, i].Value), 4);
                form2_regression.dgv_stepen[7, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_stepen[7, i].Value), 4);
                form2_regression.dgv_stepen[8, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_stepen[8, i].Value), 4);

                form2_regression.txt1_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt1_stepen.Text), 4));
                form2_regression.txt2_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt2_stepen.Text), 4));
                form2_regression.txt3_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt3_stepen.Text), 4));
                form2_regression.txt4_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt4_stepen.Text), 4));
                form2_regression.txt5_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt5_stepen.Text), 4));
                form2_regression.txt6_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt6_stepen.Text), 4));
                form2_regression.txt7_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt7_stepen.Text), 4));
                form2_regression.txt8_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt8_stepen.Text), 4));

                form2_regression.txt9_stepen.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt9_stepen.Text), 7));
            }

            // Парабола 2-го порядка
            form2_regression.dgv_parabola.RowCount = this.dgv_range.RowCount;
            form2_regression.dgv_parabola.ColumnCount = this.dgv_range.ColumnCount + 7;

            //Имя и размер колонки нумерации
            form2_regression.dgv_parabola.Columns[0].HeaderText = this.dgv_range.Columns[0].HeaderText;
            form2_regression.dgv_parabola.Columns[1].HeaderText = this.dgv_range.Columns[1].HeaderText;
            form2_regression.dgv_parabola.Columns[2].HeaderText = this.dgv_range.Columns[2].HeaderText;
            form2_regression.dgv_parabola.Columns[3].HeaderText = "( x ^ 2 )";
            form2_regression.dgv_parabola.Columns[4].HeaderText = "( x ^ 3 )";
            form2_regression.dgv_parabola.Columns[5].HeaderText = "( x ^ 4 )";
            form2_regression.dgv_parabola.Columns[6].HeaderText = "( x * y )";
            form2_regression.dgv_parabola.Columns[7].HeaderText = "(x^2 * y)";
            form2_regression.dgv_parabola.Columns[8].HeaderText = "Function";
            form2_regression.dgv_parabola.Columns[9].HeaderText = "Error";

            form2_regression.dgv_parabola.Columns[0].Width = this.dgv_range.Columns[0].Width;
            form2_regression.dgv_parabola.Columns[1].Width = this.dgv_range.Columns[1].Width;
            form2_regression.dgv_parabola.Columns[2].Width = this.dgv_range.Columns[2].Width;
            form2_regression.dgv_parabola.Columns[3].Width = 70;
            form2_regression.dgv_parabola.Columns[4].Width = 70;
            form2_regression.dgv_parabola.Columns[5].Width = 70;
            form2_regression.dgv_parabola.Columns[6].Width = 70;
            form2_regression.dgv_parabola.Columns[7].Width = 70;
            form2_regression.dgv_parabola.Columns[8].Width = 70;
            form2_regression.dgv_parabola.Columns[9].Width = 70;

            for (int i = 0; i < dgv_range.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_range.Columns.Count; ++j)
                {
                    form2_regression.dgv_parabola[j, i].Value = this.dgv_range[j, i].Value;
                }
            }

            //Переменные
            var sum_X_parabola = Convert.ToDouble(0);
            var sum_Y_parabola = Convert.ToDouble(0);
            var sum_X_2_parabola = Convert.ToDouble(0);
            var sum_X_3_parabola = Convert.ToDouble(0);
            var sum_X_4_parabola = Convert.ToDouble(0);
            var sum_X_Y_parabola = Convert.ToDouble(0);
            var sum_X_2_Y_parabola = Convert.ToDouble(0);

            //Расчет показательной функции
            for (int i = 0; i < form2_regression.dgv_parabola.Rows.Count; ++i)
            {
                form2_regression.dgv_parabola[3, i].Value = Math.Pow(
                    Convert.ToDouble(form2_regression.dgv_parabola[1, i].Value), 2);

                form2_regression.dgv_parabola[4, i].Value = Math.Pow(
                    Convert.ToDouble(form2_regression.dgv_parabola[1, i].Value), 3);

                form2_regression.dgv_parabola[5, i].Value = Math.Pow(
                    Convert.ToDouble(form2_regression.dgv_parabola[1, i].Value), 4);

                form2_regression.dgv_parabola[6, i].Value = Convert.ToDouble(form2_regression.dgv_parabola[1, i].Value) *
                                                            Convert.ToDouble(form2_regression.dgv_parabola[2, i].Value);

                form2_regression.dgv_parabola[7, i].Value = Convert.ToDouble(form2_regression.dgv_parabola[2, i].Value) *
                                                            Convert.ToDouble(form2_regression.dgv_parabola[3, i].Value);


                sum_X_parabola = Convert.ToDouble(form2_regression.dgv_parabola[1, i].Value) + sum_X_parabola;
                form2_regression.txt1_parabola.Text = Convert.ToString(sum_X_parabola);

                sum_Y_parabola = Convert.ToDouble(form2_regression.dgv_parabola[2, i].Value) + sum_Y_parabola;
                form2_regression.txt2_parabola.Text = Convert.ToString(sum_Y_parabola);

                sum_X_2_parabola = Convert.ToDouble(form2_regression.dgv_parabola[3, i].Value) + sum_X_2_parabola;
                form2_regression.txt3_parabola.Text = Convert.ToString(sum_X_2_parabola);

                sum_X_3_parabola = Convert.ToDouble(form2_regression.dgv_parabola[4, i].Value) + sum_X_3_parabola;
                form2_regression.txt4_parabola.Text = Convert.ToString(sum_X_3_parabola);

                sum_X_4_parabola = Convert.ToDouble(form2_regression.dgv_parabola[5, i].Value) + sum_X_4_parabola;
                form2_regression.txt5_parabola.Text = Convert.ToString(sum_X_4_parabola);

                sum_X_Y_parabola = Convert.ToDouble(form2_regression.dgv_parabola[6, i].Value) + sum_X_Y_parabola;
                form2_regression.txt6_parabola.Text = Convert.ToString(sum_X_Y_parabola);

                sum_X_2_Y_parabola = Convert.ToDouble(form2_regression.dgv_parabola[7, i].Value) + sum_X_2_Y_parabola;
                form2_regression.txt7_parabola.Text = Convert.ToString(sum_X_2_Y_parabola);

                //Коэффициенты 
                //var Num = Convert.ToDouble(this.txt_Num.Text);
                double a_2_parabola, a_1_parabola, a_0_parabola;
                double a_X, a_Y, a_X_2, a_X_3, a_X_4, a_X_Y, a_X_2_Y;

                a_X = Convert.ToDouble(form2_regression.txt1_parabola.Text);
                a_Y = Convert.ToDouble(form2_regression.txt2_parabola.Text);
                a_X_2 = Convert.ToDouble(form2_regression.txt3_parabola.Text);
                a_X_3 = Convert.ToDouble(form2_regression.txt4_parabola.Text);
                a_X_4 = Convert.ToDouble(form2_regression.txt5_parabola.Text);
                a_X_Y = Convert.ToDouble(form2_regression.txt6_parabola.Text);
                a_X_2_Y = Convert.ToDouble(form2_regression.txt7_parabola.Text);

                a_2_parabola = (Convert.ToDouble(this.txt_Num.Text) * (a_X_Y * a_X_3 - a_X_2_Y * a_X_2) +
                     a_X * (a_X_2_Y * a_X - a_Y * a_X_3) +
                     a_X_2 * (a_X_2 * a_Y - a_X * a_X_Y))
                                            /
                    (a_X_2 *
                    (Math.Pow(a_X_2, 2) - 2 * a_X * a_X_3 - Convert.ToDouble(this.txt_Num.Text) * a_X_4) +
                     Convert.ToDouble(this.txt_Num.Text) * Math.Pow(a_X_3, 2) + (a_X_4 * Math.Pow(a_X, 2)));

                form2_regression.txt10_parabola.Text = Convert.ToString(a_2_parabola);

                a_1_parabola = (a_Y * a_X - Convert.ToDouble(this.txt_Num.Text) * a_X_Y - a_2_parabola *
                    (a_X_2 * a_X - Convert.ToDouble(this.txt_Num.Text) * a_X_3))
                                                /
                    (Math.Pow(a_X, 2) - Convert.ToDouble(this.txt_Num.Text) * a_X_2);

                form2_regression.txt9_parabola.Text = Convert.ToString(a_1_parabola);

                a_0_parabola = (a_Y - a_1_parabola * a_X - a_2_parabola * a_X_2) /
                    Convert.ToDouble(this.txt_Num.Text);

                form2_regression.txt8_parabola.Text = Convert.ToString(a_0_parabola);
            }

            var sum_error_parabola = Convert.ToDouble(0);

            for (int i = 0; i < form2_regression.dgv_parabola.Rows.Count; ++i)
            {

                form2_regression.dgv_parabola[8, i].Value = Convert.ToDouble(form2_regression.txt8_parabola.Text) +
                    Convert.ToDouble(form2_regression.txt9_parabola.Text) *
                    Convert.ToDouble(form2_regression.dgv_parabola[1, i].Value) +
                    Convert.ToDouble(form2_regression.txt10_parabola.Text) *
                    Convert.ToDouble(form2_regression.dgv_parabola[3, i].Value);

                form2_regression.dgv_parabola[9, i].Value = Math.Pow(
                    (Convert.ToDouble(form2_regression.dgv_parabola[2, i].Value) -
                    Convert.ToDouble(form2_regression.dgv_parabola[8, i].Value)), 2);

                sum_error_parabola = Convert.ToDouble(form2_regression.dgv_parabola[9, i].Value) + sum_error_parabola;
                form2_regression.txt11_parabola.Text = Convert.ToString(sum_error_parabola);

                form2_regression.txt12_parabola.Text = Convert.ToString(
                        Math.Sqrt(Convert.ToDouble(form2_regression.txt11_parabola.Text) /
                        (Convert.ToDouble(this.txt_Num.Text) - 2)));
            }

            //Округление параболы 2-го порядка
            for (int i = 0; i < form2_regression.dgv_parabola.Rows.Count; ++i)
            {
                form2_regression.dgv_parabola[3, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[3, i].Value), 4);
                form2_regression.dgv_parabola[4, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[4, i].Value), 4);
                form2_regression.dgv_parabola[5, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[5, i].Value), 4);
                form2_regression.dgv_parabola[6, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[6, i].Value), 4);
                form2_regression.dgv_parabola[7, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[7, i].Value), 4);
                form2_regression.dgv_parabola[8, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[8, i].Value), 4);
                form2_regression.dgv_parabola[9, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_parabola[9, i].Value), 4);

                form2_regression.txt1_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt1_parabola.Text), 4));
                form2_regression.txt2_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt2_parabola.Text), 4));
                form2_regression.txt3_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt3_parabola.Text), 4));
                form2_regression.txt4_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt4_parabola.Text), 4));
                form2_regression.txt5_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt5_parabola.Text), 4));
                form2_regression.txt6_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt6_parabola.Text), 4));
                form2_regression.txt7_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt7_parabola.Text), 4));
                form2_regression.txt8_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt8_parabola.Text), 4));
                form2_regression.txt9_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt9_parabola.Text), 4));
                form2_regression.txt10_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt10_parabola.Text), 4));
                form2_regression.txt11_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt11_parabola.Text), 4));

                form2_regression.txt12_parabola.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt12_parabola.Text), 7));
            }

            // Логарифмическая
            form2_regression.dgv_logorifm.RowCount = this.dgv_range.RowCount;
            form2_regression.dgv_logorifm.ColumnCount = this.dgv_range.ColumnCount + 8;

            //Имя и размер колонки нумерации
            form2_regression.dgv_logorifm.Columns[0].HeaderText = this.dgv_range.Columns[0].HeaderText;
            form2_regression.dgv_logorifm.Columns[1].HeaderText = this.dgv_range.Columns[1].HeaderText;
            form2_regression.dgv_logorifm.Columns[2].HeaderText = this.dgv_range.Columns[2].HeaderText;
            form2_regression.dgv_logorifm.Columns[3].HeaderText = "Log(x)";
            form2_regression.dgv_logorifm.Columns[4].HeaderText = "Log(x) * x";
            form2_regression.dgv_logorifm.Columns[5].HeaderText = "Log(x) * y";
            form2_regression.dgv_logorifm.Columns[6].HeaderText = "(x * y)";
            form2_regression.dgv_logorifm.Columns[7].HeaderText = "( x^2)";
            form2_regression.dgv_logorifm.Columns[8].HeaderText = "Log(x)^2";
            form2_regression.dgv_logorifm.Columns[9].HeaderText = "Function";
            form2_regression.dgv_logorifm.Columns[10].HeaderText = "Error";

            form2_regression.dgv_logorifm.Columns[0].Width = this.dgv_range.Columns[0].Width;
            form2_regression.dgv_logorifm.Columns[1].Width = this.dgv_range.Columns[1].Width;
            form2_regression.dgv_logorifm.Columns[2].Width = this.dgv_range.Columns[2].Width;
            form2_regression.dgv_logorifm.Columns[3].Width = 60;
            form2_regression.dgv_logorifm.Columns[4].Width = 60;
            form2_regression.dgv_logorifm.Columns[5].Width = 60;
            form2_regression.dgv_logorifm.Columns[6].Width = 60;
            form2_regression.dgv_logorifm.Columns[7].Width = 60;
            form2_regression.dgv_logorifm.Columns[8].Width = 60;
            form2_regression.dgv_logorifm.Columns[9].Width = 60;
            form2_regression.dgv_logorifm.Columns[10].Width = 60;

            for (int i = 0; i < dgv_range.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_range.Columns.Count; ++j)
                {
                    form2_regression.dgv_logorifm[j, i].Value = this.dgv_range[j, i].Value;
                }
            }

            //Переменные
            var sum_X_logorifm = Convert.ToDouble(0);
            var sum_Y_logorifm = Convert.ToDouble(0);
            var sum_Log_X_logorifm = Convert.ToDouble(0);
            var sum_X_Log_X_logorifm = Convert.ToDouble(0);
            var sum_Y_Log_X_logorifm = Convert.ToDouble(0);
            var sum_X_Y_logorifm = Convert.ToDouble(0);
            var sum_X_X_logorifm = Convert.ToDouble(0);
            var sum_Log_X_2_logorifm = Convert.ToDouble(0);

            //Расчет показательной функции
            for (int i = 0; i < form2_regression.dgv_logorifm.Rows.Count; ++i)
            {
                form2_regression.dgv_logorifm[3, i].Value = Math.Log(
                    Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value));

                form2_regression.dgv_logorifm[4, i].Value =
                    Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value) *
                    Convert.ToDouble(form2_regression.dgv_logorifm[3, i].Value);

                form2_regression.dgv_logorifm[5, i].Value =
                    Convert.ToDouble(form2_regression.dgv_logorifm[2, i].Value) *
                    Convert.ToDouble(form2_regression.dgv_logorifm[3, i].Value);

                form2_regression.dgv_logorifm[6, i].Value =
                    Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value) *
                    Convert.ToDouble(form2_regression.dgv_logorifm[2, i].Value);

                form2_regression.dgv_logorifm[7, i].Value = Math.Pow(
                    Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value), 2);

                form2_regression.dgv_logorifm[8, i].Value =
                    Math.Log(Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value)) *
                    Math.Log(Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value));

                sum_X_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value) + sum_X_logorifm;
                form2_regression.txt1_logorifm.Text = Convert.ToString(sum_X_logorifm);

                sum_Y_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[2, i].Value) + sum_Y_logorifm;
                form2_regression.txt2_logorifm.Text = Convert.ToString(sum_Y_logorifm);

                sum_Log_X_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[3, i].Value) + sum_Log_X_logorifm;
                form2_regression.txt3_logorifm.Text = Convert.ToString(sum_Log_X_logorifm);

                sum_X_Log_X_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[4, i].Value) + sum_X_Log_X_logorifm;
                form2_regression.txt4_logorifm.Text = Convert.ToString(sum_X_Log_X_logorifm);

                sum_Y_Log_X_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[5, i].Value) + sum_Y_Log_X_logorifm;
                form2_regression.txt5_logorifm.Text = Convert.ToString(sum_Y_Log_X_logorifm);

                sum_X_Y_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[6, i].Value) + sum_X_Y_logorifm;
                form2_regression.txt6_logorifm.Text = Convert.ToString(sum_X_Y_logorifm);

                sum_X_X_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[7, i].Value) + sum_X_X_logorifm;
                form2_regression.txt7_logorifm.Text = Convert.ToString(sum_X_X_logorifm);

                sum_Log_X_2_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[8, i].Value) + sum_Log_X_2_logorifm;
                form2_regression.txt8_logorifm.Text = Convert.ToString(sum_Log_X_2_logorifm);

            }

            //Коэффициенты 
            double m_X_log, m_Y_log;
            double s_1, s_2, s_3, s_4, s_5, s_6, s_7;
            double a_1_logorifm, d_1_logorifm, b_1_logorifm;

            s_1 = sum_X_Log_X_logorifm / sum_Log_X_logorifm;
            s_2 = sum_X_Y_logorifm / sum_X_logorifm;
            s_3 = sum_Y_Log_X_logorifm / sum_Log_X_logorifm;
            s_4 = sum_X_X_logorifm / Convert.ToDouble(this.txt_Num.Text);
            s_5 = sum_X_Log_X_logorifm / sum_X_logorifm;
            s_6 = sum_Log_X_logorifm / Convert.ToDouble(this.txt_Num.Text);
            s_7 = sum_Log_X_2_logorifm / sum_Log_X_logorifm;

            m_X_log = sum_X_logorifm / Convert.ToDouble(this.txt_Num.Text);
            m_Y_log = sum_Y_logorifm / Convert.ToDouble(this.txt_Num.Text);

            form2_regression.txt14_logorifm.Text = Convert.ToString(s_1);
            form2_regression.txt15_logorifm.Text = Convert.ToString(s_2);
            form2_regression.txt16_logorifm.Text = Convert.ToString(s_3);
            form2_regression.txt17_logorifm.Text = Convert.ToString(s_4);
            form2_regression.txt18_logorifm.Text = Convert.ToString(s_5);
            form2_regression.txt19_logorifm.Text = Convert.ToString(s_6);
            form2_regression.txt20_logorifm.Text = Convert.ToString(s_7);

            d_1_logorifm = (s_1 * (s_2 - m_Y_log) + m_X_log * (s_3 - s_2) + s_4 * (m_Y_log - s_3)) /
                           (s_1 * (s_5 - s_6) + m_X_log * (s_7 - s_5) + s_4 * (s_6 - s_7));

            form2_regression.txt10_logorifm.Text = Convert.ToString(d_1_logorifm);

            b_1_logorifm = (d_1_logorifm * (s_5 - s_6) + m_Y_log - s_2) / (m_X_log - s_4);

            form2_regression.txt11_logorifm.Text = Convert.ToString(b_1_logorifm);

            a_1_logorifm = m_Y_log - b_1_logorifm * m_X_log - d_1_logorifm * s_6;

            form2_regression.txt9_logorifm.Text = Convert.ToString(a_1_logorifm);


            var sum_error_logorifm = Convert.ToDouble(0);

            for (int i = 0; i < form2_regression.dgv_logorifm.Rows.Count; ++i)
            {

                form2_regression.dgv_logorifm[9, i].Value =
                    Convert.ToDouble(form2_regression.txt9_logorifm.Text) + Convert.ToDouble(form2_regression.txt11_logorifm.Text) *
                    Convert.ToDouble(form2_regression.dgv_logorifm[1, i].Value) +
                    Convert.ToDouble(form2_regression.txt10_logorifm.Text) * Convert.ToDouble(form2_regression.dgv_logorifm[3, i].Value);

                form2_regression.dgv_logorifm[10, i].Value = Math.Pow(
                    (Convert.ToDouble(form2_regression.dgv_logorifm[2, i].Value) -
                    Convert.ToDouble(form2_regression.dgv_logorifm[9, i].Value)), 2);

                sum_error_logorifm = Convert.ToDouble(form2_regression.dgv_logorifm[10, i].Value) + sum_error_logorifm;
                form2_regression.txt12_logorifm.Text = Convert.ToString(sum_error_logorifm);

                form2_regression.txt13_logorifm.Text = Convert.ToString(
                        Math.Sqrt(Convert.ToDouble(form2_regression.txt12_logorifm.Text) /
                        (Convert.ToDouble(this.txt_Num.Text) - 2)));
            }

            //Округление логарифмической
            for (int i = 0; i < form2_regression.dgv_logorifm.Rows.Count; ++i)
            {
                form2_regression.dgv_logorifm[3, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[3, i].Value), 4);
                form2_regression.dgv_logorifm[4, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[4, i].Value), 4);
                form2_regression.dgv_logorifm[5, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[5, i].Value), 4);
                form2_regression.dgv_logorifm[6, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[6, i].Value), 4);
                form2_regression.dgv_logorifm[7, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[7, i].Value), 4);
                form2_regression.dgv_logorifm[8, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[8, i].Value), 4);
                form2_regression.dgv_logorifm[9, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[9, i].Value), 4);
                form2_regression.dgv_logorifm[10, i].Value = Math.Round(Convert.ToDouble(form2_regression.dgv_logorifm[10, i].Value), 4);

                form2_regression.txt1_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt1_logorifm.Text), 4));
                form2_regression.txt2_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt2_logorifm.Text), 4));
                form2_regression.txt3_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt3_logorifm.Text), 4));
                form2_regression.txt4_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt4_logorifm.Text), 4));
                form2_regression.txt5_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt5_logorifm.Text), 4));
                form2_regression.txt6_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt6_logorifm.Text), 4));
                form2_regression.txt7_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt7_logorifm.Text), 4));
                form2_regression.txt8_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt8_logorifm.Text), 4));
                form2_regression.txt9_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt9_logorifm.Text), 4));
                form2_regression.txt10_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt10_logorifm.Text), 4));
                form2_regression.txt11_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt11_logorifm.Text), 4));
                form2_regression.txt12_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt12_logorifm.Text), 4));

                form2_regression.txt13_logorifm.Text = Convert.ToString(Math.Round(Convert.ToDouble(form2_regression.txt13_logorifm.Text), 7));
            }

            double[] numbers_regress = 
                {
                    Convert.ToDouble(form2_regression.txt8_line.Text),
                    Convert.ToDouble(form2_regression.txt8_pokazat.Text),
                    Convert.ToDouble(form2_regression.txt9_stepen.Text),
                    Convert.ToDouble(form2_regression.txt12_parabola.Text),
                    Convert.ToDouble(form2_regression.txt13_logorifm.Text)
                };

            double min = numbers_regress.Min(); //Минимум

            this.txt_Min.Text = Convert.ToString(min);

            if (min == Convert.ToDouble(form2_regression.txt8_line.Text))
            {
                Method_Regress_Result("линейный", null);
            }
            else if (min == Convert.ToDouble(form2_regression.txt8_pokazat.Text))
            {
                Method_Regress_Result("показательный", null);
            }
            else if(min == Convert.ToDouble(form2_regression.txt9_stepen.Text))
            {
                Method_Regress_Result("степенной", null);
            }
            else if(min == Convert.ToDouble(form2_regression.txt12_parabola.Text))
            {
                Method_Regress_Result("параболический", "2 - го порядка");
            }
            else if(min == Convert.ToDouble(form2_regression.txt13_logorifm.Text))
            {
                Method_Regress_Result("логарифмический", null);
            }
            else
            {
                MessageBox.Show("Ошибка","Что-то пошло не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            form2_regression.Hide();
            MessageBox.Show("Регрессионный анализ выполнен", "Результат",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Метод для результата регрессионного анализа (текстовый вывод)
        string Method_Regress_Result(string regress_Result, string parabola_2_go_poryadka) 
        {
            return this.lable_result.Text = 
                $"Из всех проанализированных методов наиболее точно описывает функцию {regress_Result} метод\n{parabola_2_go_poryadka}";
        }

        private void Btn_range_Click(object sender, EventArgs e)
        {
            dgv_range.RowCount = dgv_filtr.RowCount;
            dgv_range.ColumnCount = dgv_filtr.ColumnCount;

            //Имя и размер колонки нумерации
            dgv_range.Columns[0].HeaderText = dgv_filtr.Columns[0].HeaderText;
            dgv_range.Columns[1].HeaderText = dgv_filtr.Columns[1].HeaderText;
            dgv_range.Columns[2].HeaderText = dgv_filtr.Columns[2].HeaderText;

            dgv_range.Columns[0].Width = dgv_filtr.Columns[0].Width;
            dgv_range.Columns[1].Width = dgv_filtr.Columns[1].Width;
            dgv_range.Columns[2].Width = dgv_filtr.Columns[2].Width;

            var range = Convert.ToDouble(txt_range.Text);

            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_filtr.Columns.Count; ++j)
                {
                    if (Convert.ToDouble(dgv_filtr[2, i].Value) > range)
                    {
                        dgv_range[j, i].Value = dgv_filtr[j, i].Value;
                    }
                    else
                    {
                        dgv_range[j, i].Value = 0;
                    }
                }
            }
            //Цикл удаления
            for (int i = dgv_range.RowCount - 1; i > -1; i--)
            {
                if (Convert.ToDouble(dgv_range.Rows[i].Cells[0].Value) == 0)
                {
                    dgv_range.Rows.RemoveAt(i);
                }
            }

            //Отметки на графике
            start_chart.Series[2].Points.Clear(); //очистка

            // Видимая граница
            for (int i = 0; i < dgv_range.Rows.Count; ++i)
            {
                start_chart.Series[2].Points.AddXY(Convert.ToDouble(dgv_range[0, i].Value), range);

            }

            this.txt_Num.Text = (dgv_range.Rows.Count).ToString(); //Количество значений в таблице

            //check
            check_Range.Checked = true;

        }

        private void РезультатыРегрессионногоАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2_regression.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_about_program about_program = new Form_about_program();
            about_program.ShowDialog();
        }

        private void файлToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            файлToolStripMenuItem.ShowDropDown(); //при наведении на главное меню
        }

        private void обработкаToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            обработкаToolStripMenuItem.ShowDropDown(); //при наведении на главное меню
        }

        private void справкаToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            справкаToolStripMenuItem.ShowDropDown(); //при наведении на главное меню
        }


        private void range_Filtr_ValueChanged(object sender, EventArgs e)
        {
            start_f.Text = range_Filtr.Value.Minimum.ToString();
            end_f.Text = range_Filtr.Value.Maximum.ToString();
        }

        private void range_Filtr_MouseUp(object sender, MouseEventArgs e)
        {
            dgv_filtr.Visible = true;
            //Присваивание размерности исходной таблицы к новой
            dgv_filtr.RowCount = dgv_Employees.RowCount;
            dgv_filtr.ColumnCount = dgv_Employees.ColumnCount;

            //Имя и размер колонки нумерации
            dgv_filtr.Columns[0].HeaderText = dgv_Employees.Columns[0].HeaderText;
            dgv_filtr.Columns[0].Width = dgv_Employees.Columns[0].Width;
            dgv_filtr.Columns[1].Width = dgv_Employees.Columns[1].Width;
            dgv_filtr.Columns[2].Width = dgv_Employees.Columns[2].Width;
            //dgv_filtr.Columns[0].Visible = false; //скрытие столбика нумерации

            dgv_filtr.Columns[1].HeaderText = "Time";
            dgv_filtr.Columns[2].HeaderText = "Impuls";

            //А теперь пройдемся циклом по всем ячейкам
            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_filtr.Columns.Count; ++j)
                {
                    dgv_filtr[j, i].Value = dgv_Employees[j, i].Value;
                }
                //dgv_filtr.Rows[i].Cells[0].Value = i + 1; //Нумерация после построения
                //dgv_filtr.Rows[i].Cells[1].Value = dgv_Employees.Rows[i].Cells[0].Value; //альтернативная загрузка по столбцам
                //dgv_filtr.Rows[i].Cells[2].Value = dgv_Employees.Rows[i].Cells[1].Value;
            }

            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                for (int j = 0; j < dgv_filtr.Columns.Count; ++j)
                {
                    //Ручной фильтр
                    if (Convert.ToDouble(start_f.Text) <= Convert.ToDouble(dgv_filtr[0, i].Value)
                                                    &&
                        Convert.ToDouble(end_f.Text) >= Convert.ToDouble(dgv_filtr[0, i].Value))
                    {
                        dgv_filtr[j, i].Value = dgv_filtr[j, i].Value;
                    }
                    else
                    {
                        dgv_filtr[j, i].Value = 0;
                    }
                }
            }
            //Цикл удаления
            for (int i = dgv_filtr.RowCount - 1; i > -1; i--)
            {
                //if (Convert.ToDouble(dgv_filtr[0, i].Value) == 0)
                if (Convert.ToDouble(dgv_filtr.Rows[i].Cells[0].Value) == 0)
                {
                    dgv_filtr.Rows.RemoveAt(i);
                }
            }
            //Очистка линий и построение графика
            start_chart.Series[1].Points.Clear();

            for (int i = 0; i < dgv_filtr.Rows.Count; ++i)
            {
                start_chart.Series[1].Points.AddXY(Convert.ToDouble(dgv_filtr[0, i].Value),
                                                   Convert.ToDouble(dgv_filtr[2, i].Value));
            }

            Method_Filtr_un_checked(true);

        }

        private void end_f_TextChanged(object sender, EventArgs e)
        {
            Method_Filtr_un_checked(false);

            if ((start_f.Text == "") || (end_f.Text == "") || (float.Parse(start_f.Text) >= float.Parse(end_f.Text)))
            {
                btn_Filtr.Enabled = false;
            }
            else
            {
                btn_Filtr.Enabled = true;
                range_Filtr.EditValue = new TrackBarRange(range_Filtr.Value.Minimum, Convert.ToInt32(end_f.Text));
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            { Filter = "XLSX files (*.xlsx)|*.xlsx|XLS files (*.xls)|*.xls|All files (*.*)|*.*", ValidateNames = true }) // лишнее

            start_chart.Series[0].Points.Clear(); //Очистка графика
            dgv_Employees.Visible = true; //Видимость DataGreed
            textBox1.Visible = true; //Видимость пути файла
            cboSheet.Visible = true; //Видимость combobox

            var wayToExcelFile = @"C:\Users\SAY10\Desktop\2500 чисел.xlsx";

            textBox1.Text = wayToExcelFile;

            using (var stream = File.Open(wayToExcelFile, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                        tableCollection = result.Tables;
                        cboSheet.Items.Clear();
                        foreach (DataTable table in tableCollection)
                            cboSheet.Items.Add(table.TableName); //add sheet to combobox

                        dgv_Employees.DataSource = result.Tables[0]; // По умолчанию открывается лист №1
                        cboSheet.Text = cboSheet.Items[0].ToString(); //По умолчанию в combobox загружается лист №1


                        range_Filtr.Properties.Maximum = Convert.ToInt32(dgv_Employees.RowCount); //Количество значений в таблице
                        range_Filtr.EditValue = new TrackBarRange(0, dgv_Employees.RowCount); //Ползунок в конец

                        //Размеры строк дата грид
                        dgv_Employees.Columns[0].Width = 40;
                        dgv_Employees.Columns[1].Width = 70;
                        dgv_Employees.Columns[2].Width = 70;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "System error");
                }

            }
        }

        private void txt_range_ValueChanged(object sender, EventArgs e)
        {
            check_Filtr.Checked = false;

            if (txt_range.Value.ToString() == "")
            {
                btn_range.Enabled = false;
                btn_range.Text = "N O";
            }
            else
            {
                btn_range.Enabled = true;
                btn_range.Text = "Диапазон";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(".xlsx") || textBox1.Text.Contains(".xls"))
            {
                MessageBox.Show("Файл Эксель");
            }
            else if (textBox1.Text.Contains(".csv"))
            {
                MessageBox.Show("Файл CSV");
            }
            else
            {
                MessageBox.Show("Загрузи файл .csv или .xlsx");
            }
        }

        private void label4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("хай");
        }
    }

}
