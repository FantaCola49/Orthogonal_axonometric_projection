namespace ModelDesigner
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblScale = new System.Windows.Forms.Label();
            this.btnResetScale = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picOrhtog = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picAxon = new System.Windows.Forms.PictureBox();
            this.btnBuildAxonom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearLines = new System.Windows.Forms.Button();
            this.btnSetLines = new System.Windows.Forms.Button();
            this.dtgLines = new System.Windows.Forms.DataGridView();
            this.numLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointStart = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pointEnd = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearPoints = new System.Windows.Forms.Button();
            this.btnSetPoints = new System.Windows.Forms.Button();
            this.dtgPoints = new System.Windows.Forms.DataGridView();
            this.NumPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фАЙЛToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сПРАВКАToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrhtog)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAxon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLines)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPoints)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblScale);
            this.panel1.Controls.Add(this.btnResetScale);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.btnBuildAxonom);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1071, 748);
            this.panel1.TabIndex = 0;
            // 
            // lblScale
            // 
            this.lblScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblScale.AutoSize = true;
            this.lblScale.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScale.Location = new System.Drawing.Point(200, 691);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(66, 26);
            this.lblScale.TabIndex = 6;
            this.lblScale.Text = "Scale:";
            // 
            // btnResetScale
            // 
            this.btnResetScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetScale.Location = new System.Drawing.Point(25, 687);
            this.btnResetScale.Name = "btnResetScale";
            this.btnResetScale.Size = new System.Drawing.Size(134, 39);
            this.btnResetScale.TabIndex = 5;
            this.btnResetScale.Text = "Сбросить масштаб";
            this.btnResetScale.UseVisualStyleBackColor = true;
            this.btnResetScale.Click += new System.EventHandler(this.btnResetScale_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(358, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 720);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picOrhtog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 694);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ортогональная проекция";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picOrhtog
            // 
            this.picOrhtog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOrhtog.Location = new System.Drawing.Point(3, 3);
            this.picOrhtog.Name = "picOrhtog";
            this.picOrhtog.Size = new System.Drawing.Size(688, 688);
            this.picOrhtog.TabIndex = 0;
            this.picOrhtog.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picAxon);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 694);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Аксонометрия";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picAxon
            // 
            this.picAxon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAxon.Location = new System.Drawing.Point(3, 3);
            this.picAxon.Name = "picAxon";
            this.picAxon.Size = new System.Drawing.Size(688, 688);
            this.picAxon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAxon.TabIndex = 0;
            this.picAxon.TabStop = false;
            // 
            // btnBuildAxonom
            // 
            this.btnBuildAxonom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuildAxonom.Location = new System.Drawing.Point(25, 618);
            this.btnBuildAxonom.Name = "btnBuildAxonom";
            this.btnBuildAxonom.Size = new System.Drawing.Size(315, 39);
            this.btnBuildAxonom.TabIndex = 0;
            this.btnBuildAxonom.Text = "Построить";
            this.btnBuildAxonom.UseVisualStyleBackColor = true;
            this.btnBuildAxonom.Click += new System.EventHandler(this.btnBuildAxonom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearLines);
            this.groupBox2.Controls.Add(this.btnSetLines);
            this.groupBox2.Controls.Add(this.dtgLines);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(10, 310);
            this.groupBox2.MaximumSize = new System.Drawing.Size(330, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 289);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Линии";
            // 
            // btnClearLines
            // 
            this.btnClearLines.Location = new System.Drawing.Point(15, 255);
            this.btnClearLines.Name = "btnClearLines";
            this.btnClearLines.Size = new System.Drawing.Size(107, 28);
            this.btnClearLines.TabIndex = 5;
            this.btnClearLines.Text = "Очистить";
            this.btnClearLines.UseVisualStyleBackColor = true;
            this.btnClearLines.Click += new System.EventHandler(this.btnClearLines_Click);
            // 
            // btnSetLines
            // 
            this.btnSetLines.Location = new System.Drawing.Point(217, 255);
            this.btnSetLines.Name = "btnSetLines";
            this.btnSetLines.Size = new System.Drawing.Size(107, 28);
            this.btnSetLines.TabIndex = 5;
            this.btnSetLines.Text = "Задать линии";
            this.btnSetLines.UseVisualStyleBackColor = true;
            this.btnSetLines.Click += new System.EventHandler(this.btnSetLines_Click);
            // 
            // dtgLines
            // 
            this.dtgLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numLine,
            this.pointStart,
            this.pointEnd});
            this.dtgLines.Location = new System.Drawing.Point(15, 19);
            this.dtgLines.Name = "dtgLines";
            this.dtgLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLines.Size = new System.Drawing.Size(309, 230);
            this.dtgLines.TabIndex = 5;
            // 
            // numLine
            // 
            this.numLine.HeaderText = "№ линии";
            this.numLine.MinimumWidth = 60;
            this.numLine.Name = "numLine";
            this.numLine.ReadOnly = true;
            this.numLine.Width = 60;
            // 
            // pointStart
            // 
            this.pointStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pointStart.DefaultCellStyle = dataGridViewCellStyle1;
            this.pointStart.HeaderText = "Point 1";
            this.pointStart.Name = "pointStart";
            // 
            // pointEnd
            // 
            this.pointEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pointEnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointEnd.HeaderText = "Point 2";
            this.pointEnd.Name = "pointEnd";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearPoints);
            this.groupBox1.Controls.Add(this.btnSetPoints);
            this.groupBox1.Controls.Add(this.dtgPoints);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.MaximumSize = new System.Drawing.Size(330, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Точки";
            // 
            // btnClearPoints
            // 
            this.btnClearPoints.Location = new System.Drawing.Point(15, 252);
            this.btnClearPoints.Name = "btnClearPoints";
            this.btnClearPoints.Size = new System.Drawing.Size(107, 28);
            this.btnClearPoints.TabIndex = 4;
            this.btnClearPoints.Text = "Очистить";
            this.btnClearPoints.UseVisualStyleBackColor = true;
            this.btnClearPoints.Click += new System.EventHandler(this.btnClearPoints_Click);
            // 
            // btnSetPoints
            // 
            this.btnSetPoints.Location = new System.Drawing.Point(217, 252);
            this.btnSetPoints.Name = "btnSetPoints";
            this.btnSetPoints.Size = new System.Drawing.Size(107, 28);
            this.btnSetPoints.TabIndex = 3;
            this.btnSetPoints.Text = "Задать точки";
            this.btnSetPoints.UseVisualStyleBackColor = true;
            this.btnSetPoints.Click += new System.EventHandler(this.btnSetPoints_Click);
            // 
            // dtgPoints
            // 
            this.dtgPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumPoint,
            this.pointX,
            this.pointY,
            this.pointZ});
            this.dtgPoints.Location = new System.Drawing.Point(15, 19);
            this.dtgPoints.Name = "dtgPoints";
            this.dtgPoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPoints.Size = new System.Drawing.Size(309, 227);
            this.dtgPoints.TabIndex = 3;
            // 
            // NumPoint
            // 
            this.NumPoint.HeaderText = "№ точки";
            this.NumPoint.MinimumWidth = 60;
            this.NumPoint.Name = "NumPoint";
            this.NumPoint.ReadOnly = true;
            this.NumPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumPoint.Width = 60;
            // 
            // pointX
            // 
            this.pointX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pointX.HeaderText = "X";
            this.pointX.Name = "pointX";
            // 
            // pointY
            // 
            this.pointY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pointY.HeaderText = "Y";
            this.pointY.Name = "pointY";
            // 
            // pointZ
            // 
            this.pointZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pointZ.HeaderText = "Z";
            this.pointZ.Name = "pointZ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фАЙЛToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.сПРАВКАToolStripMenuItem,
            this.clearBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фАЙЛToolStripMenuItem
            // 
            this.фАЙЛToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.фАЙЛToolStripMenuItem.Name = "фАЙЛToolStripMenuItem";
            this.фАЙЛToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.фАЙЛToolStripMenuItem.Text = "ФАЙЛ";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.excelToolStripMenuItem.Text = "EXCEL";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // сПРАВКАToolStripMenuItem
            // 
            this.сПРАВКАToolStripMenuItem.Name = "сПРАВКАToolStripMenuItem";
            this.сПРАВКАToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.сПРАВКАToolStripMenuItem.Text = "СПРАВКА";
            this.сПРАВКАToolStripMenuItem.Click += new System.EventHandler(this.сПРАВКАToolStripMenuItem_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(83, 20);
            this.clearBtn.Text = "ОЧИСТИТЬ";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 772);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1087, 811);
            this.Name = "MainForm";
            this.Text = "Построение моделей";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOrhtog)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAxon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLines)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPoints)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фАЙЛToolStripMenuItem;
        private System.Windows.Forms.Button btnClearPoints;
        private System.Windows.Forms.Button btnSetPoints;
        private System.Windows.Forms.DataGridView dtgPoints;
        private System.Windows.Forms.Button btnClearLines;
        private System.Windows.Forms.Button btnSetLines;
        private System.Windows.Forms.DataGridView dtgLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLine;
        private System.Windows.Forms.DataGridViewComboBoxColumn pointStart;
        private System.Windows.Forms.DataGridViewComboBoxColumn pointEnd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picOrhtog;
        private System.Windows.Forms.PictureBox picAxon;
        private System.Windows.Forms.Button btnBuildAxonom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointX;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointY;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointZ;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сПРАВКАToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button btnResetScale;
        private System.Windows.Forms.ToolStripMenuItem clearBtn;
        private System.Windows.Forms.Label lblScale;
    }
}

