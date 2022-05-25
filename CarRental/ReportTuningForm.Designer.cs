namespace CarRental
{
    partial class ReportTuningForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudTurn = new System.Windows.Forms.NumericUpDown();
            this.nudVista = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb3D = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbColors = new System.Windows.Forms.CheckBox();
            this.cbLabels = new System.Windows.Forms.CheckBox();
            this.cbLegend = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbPie = new System.Windows.Forms.RadioButton();
            this.rbColumn = new System.Windows.Forms.RadioButton();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVista)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "За период";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(210, 19);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(142, 23);
            this.dtpToDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(29, 19);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(142, 23);
            this.dtpFromDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(177, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "с";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройка отображения";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudTurn);
            this.groupBox5.Controls.Add(this.nudVista);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.cb3D);
            this.groupBox5.Location = new System.Drawing.Point(249, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(92, 145);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3D опции";
            // 
            // nudTurn
            // 
            this.nudTurn.Location = new System.Drawing.Point(9, 107);
            this.nudTurn.Name = "nudTurn";
            this.nudTurn.Size = new System.Drawing.Size(48, 23);
            this.nudTurn.TabIndex = 2;
            // 
            // nudVista
            // 
            this.nudVista.Location = new System.Drawing.Point(9, 60);
            this.nudVista.Name = "nudVista";
            this.nudVista.Size = new System.Drawing.Size(48, 23);
            this.nudVista.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "°";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Поворот:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Перспектива:";
            // 
            // cb3D
            // 
            this.cb3D.AutoSize = true;
            this.cb3D.Location = new System.Drawing.Point(6, 22);
            this.cb3D.Name = "cb3D";
            this.cb3D.Size = new System.Drawing.Size(62, 19);
            this.cb3D.TabIndex = 0;
            this.cb3D.Text = "3D вид";
            this.cb3D.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbColors);
            this.groupBox4.Controls.Add(this.cbLabels);
            this.groupBox4.Controls.Add(this.cbLegend);
            this.groupBox4.Location = new System.Drawing.Point(130, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(113, 145);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Доп. настройки";
            // 
            // cbColors
            // 
            this.cbColors.AutoSize = true;
            this.cbColors.Checked = true;
            this.cbColors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbColors.Location = new System.Drawing.Point(6, 112);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(85, 19);
            this.cbColors.TabIndex = 2;
            this.cbColors.Text = "Разноцвет.";
            this.cbColors.UseVisualStyleBackColor = true;
            // 
            // cbLabels
            // 
            this.cbLabels.AutoSize = true;
            this.cbLabels.Checked = true;
            this.cbLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLabels.Location = new System.Drawing.Point(6, 76);
            this.cbLabels.Name = "cbLabels";
            this.cbLabels.Size = new System.Drawing.Size(75, 19);
            this.cbLabels.TabIndex = 1;
            this.cbLabels.Text = "Подписи";
            this.cbLabels.UseVisualStyleBackColor = true;
            // 
            // cbLegend
            // 
            this.cbLegend.AutoSize = true;
            this.cbLegend.Checked = true;
            this.cbLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLegend.Location = new System.Drawing.Point(6, 40);
            this.cbLegend.Name = "cbLegend";
            this.cbLegend.Size = new System.Drawing.Size(70, 19);
            this.cbLegend.TabIndex = 0;
            this.cbLegend.Text = "Легенда";
            this.cbLegend.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbPie);
            this.groupBox3.Controls.Add(this.rbColumn);
            this.groupBox3.Location = new System.Drawing.Point(6, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 145);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вид диаграммы";
            // 
            // rbPie
            // 
            this.rbPie.Image = global::CarRental.Properties.Resources.pie;
            this.rbPie.Location = new System.Drawing.Point(20, 93);
            this.rbPie.Name = "rbPie";
            this.rbPie.Size = new System.Drawing.Size(63, 49);
            this.rbPie.TabIndex = 1;
            this.rbPie.UseVisualStyleBackColor = true;
            // 
            // rbColumn
            // 
            this.rbColumn.Checked = true;
            this.rbColumn.Image = global::CarRental.Properties.Resources.column;
            this.rbColumn.Location = new System.Drawing.Point(20, 27);
            this.rbColumn.Name = "rbColumn";
            this.rbColumn.Size = new System.Drawing.Size(63, 49);
            this.rbColumn.TabIndex = 0;
            this.rbColumn.TabStop = true;
            this.rbColumn.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnter.Location = new System.Drawing.Point(214, 251);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Ввод";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ReportTuningForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 286);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportTuningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка изображения диаграмм";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVista)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.RadioButton rbPie;
        public System.Windows.Forms.RadioButton rbColumn;
        public System.Windows.Forms.CheckBox cbColors;
        public System.Windows.Forms.CheckBox cbLabels;
        public System.Windows.Forms.CheckBox cbLegend;
        public System.Windows.Forms.NumericUpDown nudTurn;
        public System.Windows.Forms.NumericUpDown nudVista;
        public System.Windows.Forms.DateTimePicker dtpToDate;
        public System.Windows.Forms.DateTimePicker dtpFromDate;
        public System.Windows.Forms.CheckBox cb3D;
    }
}