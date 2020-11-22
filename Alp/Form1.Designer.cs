namespace Alp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаФайлаcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаФайлаxlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обработкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регрессионныйАнализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыРегрессионногоАнализаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.расчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фурьеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.start_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgv_Employees = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Filtr = new System.Windows.Forms.Button();
            this.start_f = new System.Windows.Forms.TextBox();
            this.end_f = new System.Windows.Forms.TextBox();
            this.dgv_filtr = new System.Windows.Forms.DataGridView();
            this.dgv_range = new System.Windows.Forms.DataGridView();
            this.btn_range = new System.Windows.Forms.Button();
            this.txt_Num = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lable_result = new System.Windows.Forms.Label();
            this.txt_Min = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_regress = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.range_Filtr = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.check_Filtr = new System.Windows.Forms.CheckBox();
            this.check_Range = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_range = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label_drop = new System.Windows.Forms.Label();
            this.toolTip_copy = new System.Windows.Forms.ToolTip(this.components);
            this.main_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.start_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filtr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_range)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.range_Filtr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.range_Filtr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_range)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.обработкаToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(1084, 24);
            this.main_menu.TabIndex = 1;
            this.main_menu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузкаФайлаcsvToolStripMenuItem,
            this.загрузкаФайлаxlsToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.MouseHover += new System.EventHandler(this.файлToolStripMenuItem_MouseHover);
            // 
            // загрузкаФайлаcsvToolStripMenuItem
            // 
            this.загрузкаФайлаcsvToolStripMenuItem.Name = "загрузкаФайлаcsvToolStripMenuItem";
            this.загрузкаФайлаcsvToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.загрузкаФайлаcsvToolStripMenuItem.Text = "Загрузка файла .csv";
            this.загрузкаФайлаcsvToolStripMenuItem.Click += new System.EventHandler(this.ЗагрузкаФайлаcsvToolStripMenuItem_Click);
            // 
            // загрузкаФайлаxlsToolStripMenuItem
            // 
            this.загрузкаФайлаxlsToolStripMenuItem.Name = "загрузкаФайлаxlsToolStripMenuItem";
            this.загрузкаФайлаxlsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.загрузкаФайлаxlsToolStripMenuItem.Text = "Загрузка файла .xlsx";
            this.загрузкаФайлаxlsToolStripMenuItem.Click += new System.EventHandler(this.ЗагрузкаФайлаxlsToolStripMenuItem_Click);
            // 
            // обработкаToolStripMenuItem
            // 
            this.обработкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.регрессионныйАнализToolStripMenuItem,
            this.результатыРегрессионногоАнализаToolStripMenuItem,
            this.toolStripSeparator1,
            this.расчётToolStripMenuItem,
            this.фурьеToolStripMenuItem});
            this.обработкаToolStripMenuItem.Name = "обработкаToolStripMenuItem";
            this.обработкаToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.обработкаToolStripMenuItem.Text = "Обработка";
            this.обработкаToolStripMenuItem.MouseHover += new System.EventHandler(this.обработкаToolStripMenuItem_MouseHover);
            // 
            // регрессионныйАнализToolStripMenuItem
            // 
            this.регрессионныйАнализToolStripMenuItem.Name = "регрессионныйАнализToolStripMenuItem";
            this.регрессионныйАнализToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.регрессионныйАнализToolStripMenuItem.Text = "Регрессионный анализ";
            this.регрессионныйАнализToolStripMenuItem.Click += new System.EventHandler(this.РегрессионныйАнализToolStripMenuItem_Click);
            // 
            // результатыРегрессионногоАнализаToolStripMenuItem
            // 
            this.результатыРегрессионногоАнализаToolStripMenuItem.Name = "результатыРегрессионногоАнализаToolStripMenuItem";
            this.результатыРегрессионногоАнализаToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.результатыРегрессионногоАнализаToolStripMenuItem.Text = "Результаты регрессионного анализа";
            this.результатыРегрессионногоАнализаToolStripMenuItem.Click += new System.EventHandler(this.РезультатыРегрессионногоАнализаToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(273, 6);
            // 
            // расчётToolStripMenuItem
            // 
            this.расчётToolStripMenuItem.Name = "расчётToolStripMenuItem";
            this.расчётToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.расчётToolStripMenuItem.Text = "Расчёт";
            // 
            // фурьеToolStripMenuItem
            // 
            this.фурьеToolStripMenuItem.Name = "фурьеToolStripMenuItem";
            this.фурьеToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.фурьеToolStripMenuItem.Text = "Фурье";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.MouseHover += new System.EventHandler(this.справкаToolStripMenuItem_MouseHover);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // start_chart
            // 
            this.start_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_chart.BackColor = System.Drawing.Color.Gainsboro;
            this.start_chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            chartArea5.Name = "ChartArea1";
            chartArea5.Position.Auto = false;
            chartArea5.Position.Height = 94F;
            chartArea5.Position.Width = 81F;
            chartArea5.Position.X = 1.5F;
            chartArea5.Position.Y = 3F;
            this.start_chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.start_chart.Legends.Add(legend5);
            this.start_chart.Location = new System.Drawing.Point(12, 279);
            this.start_chart.Name = "start_chart";
            this.start_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Color = System.Drawing.Color.Black;
            series13.Legend = "Legend1";
            series13.Name = "Input";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Color = System.Drawing.Color.Red;
            series14.Legend = "Legend1";
            series14.Name = "Filtr";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Color = System.Drawing.Color.LightSkyBlue;
            series15.Legend = "Legend1";
            series15.Name = "Range";
            series15.YValuesPerPoint = 6;
            this.start_chart.Series.Add(series13);
            this.start_chart.Series.Add(series14);
            this.start_chart.Series.Add(series15);
            this.start_chart.Size = new System.Drawing.Size(783, 249);
            this.start_chart.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(3, 202);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(178, 33);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            // 
            // dgv_Employees
            // 
            this.dgv_Employees.AllowUserToAddRows = false;
            this.dgv_Employees.AllowUserToDeleteRows = false;
            this.dgv_Employees.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Employees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgv_Employees.Location = new System.Drawing.Point(204, 27);
            this.dgv_Employees.Name = "dgv_Employees";
            this.dgv_Employees.ReadOnly = true;
            this.dgv_Employees.Size = new System.Drawing.Size(193, 240);
            this.dgv_Employees.TabIndex = 4;
            this.dgv_Employees.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Dgv_Employees_RowPostPaint);
            this.dgv_Employees.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Dgv_Employees_RowsAdded);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(77, 178);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(104, 21);
            this.cboSheet.TabIndex = 6;
            this.cboSheet.Visible = false;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.CboSheet_SelectedIndexChanged);
            this.cboSheet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboSheet_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(910, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "try";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_Filtr
            // 
            this.btn_Filtr.BackColor = System.Drawing.Color.MintCream;
            this.btn_Filtr.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Filtr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.btn_Filtr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn_Filtr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Filtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_Filtr.Location = new System.Drawing.Point(680, 389);
            this.btn_Filtr.Name = "btn_Filtr";
            this.btn_Filtr.Size = new System.Drawing.Size(88, 23);
            this.btn_Filtr.TabIndex = 9;
            this.btn_Filtr.Text = "Фильтр";
            this.btn_Filtr.UseVisualStyleBackColor = false;
            this.btn_Filtr.Click += new System.EventHandler(this.Button2_Click);
            // 
            // start_f
            // 
            this.start_f.Location = new System.Drawing.Point(680, 366);
            this.start_f.Multiline = true;
            this.start_f.Name = "start_f";
            this.start_f.Size = new System.Drawing.Size(41, 20);
            this.start_f.TabIndex = 11;
            this.start_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.start_f.TextChanged += new System.EventHandler(this.Start_f_TextChanged);
            this.start_f.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Start_f_KeyPress);
            // 
            // end_f
            // 
            this.end_f.Location = new System.Drawing.Point(727, 366);
            this.end_f.Multiline = true;
            this.end_f.Name = "end_f";
            this.end_f.Size = new System.Drawing.Size(41, 20);
            this.end_f.TabIndex = 12;
            this.end_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.end_f.TextChanged += new System.EventHandler(this.end_f_TextChanged);
            this.end_f.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Start_f_KeyPress);
            // 
            // dgv_filtr
            // 
            this.dgv_filtr.AllowUserToAddRows = false;
            this.dgv_filtr.AllowUserToDeleteRows = false;
            this.dgv_filtr.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_filtr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_filtr.Location = new System.Drawing.Point(403, 27);
            this.dgv_filtr.Name = "dgv_filtr";
            this.dgv_filtr.ReadOnly = true;
            this.dgv_filtr.Size = new System.Drawing.Size(193, 240);
            this.dgv_filtr.TabIndex = 13;
            this.dgv_filtr.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Dgv_Employees_RowPostPaint);
            // 
            // dgv_range
            // 
            this.dgv_range.AllowUserToAddRows = false;
            this.dgv_range.AllowUserToDeleteRows = false;
            this.dgv_range.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_range.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_range.Location = new System.Drawing.Point(602, 27);
            this.dgv_range.Name = "dgv_range";
            this.dgv_range.ReadOnly = true;
            this.dgv_range.Size = new System.Drawing.Size(193, 240);
            this.dgv_range.TabIndex = 14;
            this.dgv_range.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Dgv_Employees_RowPostPaint);
            // 
            // btn_range
            // 
            this.btn_range.BackColor = System.Drawing.Color.MintCream;
            this.btn_range.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_range.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.btn_range.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn_range.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_range.Location = new System.Drawing.Point(680, 444);
            this.btn_range.Name = "btn_range";
            this.btn_range.Size = new System.Drawing.Size(88, 23);
            this.btn_range.TabIndex = 15;
            this.btn_range.Text = "Диапазон";
            this.btn_range.UseVisualStyleBackColor = false;
            this.btn_range.Click += new System.EventHandler(this.Btn_range_Click);
            // 
            // txt_Num
            // 
            this.txt_Num.Location = new System.Drawing.Point(973, 150);
            this.txt_Num.Name = "txt_Num";
            this.txt_Num.Size = new System.Drawing.Size(41, 20);
            this.txt_Num.TabIndex = 18;
            this.txt_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(979, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "N";
            // 
            // lable_result
            // 
            this.lable_result.AutoSize = true;
            this.lable_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lable_result.Location = new System.Drawing.Point(802, 394);
            this.lable_result.MaximumSize = new System.Drawing.Size(270, 0);
            this.lable_result.MinimumSize = new System.Drawing.Size(270, 0);
            this.lable_result.Name = "lable_result";
            this.lable_result.Size = new System.Drawing.Size(270, 18);
            this.lable_result.TabIndex = 20;
            this.lable_result.Text = "Вывод работы программы:";
            // 
            // txt_Min
            // 
            this.txt_Min.Location = new System.Drawing.Point(1031, 150);
            this.txt_Min.Name = "txt_Min";
            this.txt_Min.Size = new System.Drawing.Size(41, 20);
            this.txt_Min.TabIndex = 21;
            this.txt_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1039, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Min";
            // 
            // btn_regress
            // 
            this.btn_regress.BackColor = System.Drawing.Color.MintCream;
            this.btn_regress.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_regress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.btn_regress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn_regress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_regress.Location = new System.Drawing.Point(680, 473);
            this.btn_regress.Name = "btn_regress";
            this.btn_regress.Size = new System.Drawing.Size(88, 23);
            this.btn_regress.TabIndex = 15;
            this.btn_regress.Text = "Анализ";
            this.btn_regress.UseVisualStyleBackColor = false;
            this.btn_regress.Click += new System.EventHandler(this.РегрессионныйАнализToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MintCream;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(801, 473);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(271, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Результаты регрессионного анализа";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.РезультатыРегрессионногоАнализаToolStripMenuItem_Click);
            // 
            // range_Filtr
            // 
            this.range_Filtr.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(0, 0);
            this.range_Filtr.Location = new System.Drawing.Point(55, 531);
            this.range_Filtr.Name = "range_Filtr";
            this.range_Filtr.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.range_Filtr.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.range_Filtr.Properties.Maximum = 0;
            this.range_Filtr.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.range_Filtr.Size = new System.Drawing.Size(602, 45);
            this.range_Filtr.TabIndex = 27;
            this.range_Filtr.ValueChanged += new System.EventHandler(this.range_Filtr_ValueChanged);
            this.range_Filtr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.range_Filtr_MouseUp);
            // 
            // check_Filtr
            // 
            this.check_Filtr.AutoSize = true;
            this.check_Filtr.BackColor = System.Drawing.Color.Transparent;
            this.check_Filtr.Enabled = false;
            this.check_Filtr.FlatAppearance.BorderSize = 0;
            this.check_Filtr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Filtr.Location = new System.Drawing.Point(753, 398);
            this.check_Filtr.Name = "check_Filtr";
            this.check_Filtr.Size = new System.Drawing.Size(12, 11);
            this.check_Filtr.TabIndex = 29;
            this.check_Filtr.UseVisualStyleBackColor = false;
            // 
            // check_Range
            // 
            this.check_Range.AutoSize = true;
            this.check_Range.BackColor = System.Drawing.Color.Transparent;
            this.check_Range.Checked = true;
            this.check_Range.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Range.Enabled = false;
            this.check_Range.FlatAppearance.BorderSize = 0;
            this.check_Range.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Range.Location = new System.Drawing.Point(753, 452);
            this.check_Range.Name = "check_Range";
            this.check_Range.Size = new System.Drawing.Size(12, 11);
            this.check_Range.TabIndex = 30;
            this.check_Range.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(814, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_range
            // 
            this.txt_range.DecimalPlaces = 1;
            this.txt_range.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txt_range.Location = new System.Drawing.Point(693, 418);
            this.txt_range.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txt_range.Name = "txt_range";
            this.txt_range.Size = new System.Drawing.Size(72, 20);
            this.txt_range.TabIndex = 32;
            this.txt_range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_range.ValueChanged += new System.EventHandler(this.txt_range_ValueChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1000, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 33;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.cboSheet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label_drop);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 240);
            this.panel1.TabIndex = 34;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel1.DragLeave += new System.EventHandler(this.panel1_DragLeave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Путь к файлу:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_drop
            // 
            this.label_drop.Location = new System.Drawing.Point(-1, 94);
            this.label_drop.Name = "label_drop";
            this.label_drop.Size = new System.Drawing.Size(185, 25);
            this.label_drop.TabIndex = 0;
            this.label_drop.Text = "Перетащите файлы сюда";
            this.label_drop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip_copy
            // 
            this.toolTip_copy.AutoPopDelay = 5000;
            this.toolTip_copy.InitialDelay = 200;
            this.toolTip_copy.ReshowDelay = 100;
            this.toolTip_copy.ShowAlways = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1084, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txt_range);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgv_Employees);
            this.Controls.Add(this.check_Range);
            this.Controls.Add(this.check_Filtr);
            this.Controls.Add(this.range_Filtr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Min);
            this.Controls.Add(this.lable_result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Num);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_regress);
            this.Controls.Add(this.btn_range);
            this.Controls.Add(this.dgv_range);
            this.Controls.Add(this.dgv_filtr);
            this.Controls.Add(this.end_f);
            this.Controls.Add(this.start_f);
            this.Controls.Add(this.btn_Filtr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.start_chart);
            this.Controls.Add(this.main_menu);
            this.MainMenuStrip = this.main_menu;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.start_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_filtr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_range)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.range_Filtr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.range_Filtr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_range)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обработкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart start_chart;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Filtr;
        private System.Windows.Forms.TextBox start_f;
        private System.Windows.Forms.TextBox end_f;
        private System.Windows.Forms.DataGridView dgv_Employees;
        private System.Windows.Forms.DataGridView dgv_filtr;
        private System.Windows.Forms.ToolStripMenuItem регрессионныйАнализToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_range;
        private System.Windows.Forms.Button btn_range;
        private System.Windows.Forms.ToolStripMenuItem результатыРегрессионногоАнализаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem расчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фурьеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_Num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lable_result;
        private System.Windows.Forms.TextBox txt_Min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem загрузкаФайлаcsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаФайлаxlsToolStripMenuItem;
        private System.Windows.Forms.Button btn_regress;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.RangeTrackBarControl range_Filtr;
        private System.Windows.Forms.CheckBox check_Filtr;
        private System.Windows.Forms.CheckBox check_Range;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown txt_range;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_drop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip_copy;
    }
}

