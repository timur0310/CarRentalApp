namespace CarRental
{
    partial class GroupsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAppend = new System.Windows.Forms.ToolStripButton();
            this.tsbChange = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chViewStatistics = new System.Windows.Forms.CheckBox();
            this.chFormalizeContracts = new System.Windows.Forms.CheckBox();
            this.chEnableGarageEdit = new System.Windows.Forms.CheckBox();
            this.chEnableClientsEdit = new System.Windows.Forms.CheckBox();
            this.chEnableEmployeesEdit = new System.Windows.Forms.CheckBox();
            this.chEnablePassword = new System.Windows.Forms.CheckBox();
            this.chEnableChangeRights = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbGroupUsers = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lvTable, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 242F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 548);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAppend,
            this.tsbChange,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(626, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAppend
            // 
            this.tsbAppend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAppend.Image = ((System.Drawing.Image)(resources.GetObject("tsbAppend.Image")));
            this.tsbAppend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAppend.Name = "tsbAppend";
            this.tsbAppend.Size = new System.Drawing.Size(63, 22);
            this.tsbAppend.Text = "Добавить";
            this.tsbAppend.Click += new System.EventHandler(this.tsbAppend_Click);
            // 
            // tsbChange
            // 
            this.tsbChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbChange.Enabled = false;
            this.tsbChange.Image = ((System.Drawing.Image)(resources.GetObject("tsbChange.Image")));
            this.tsbChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChange.Name = "tsbChange";
            this.tsbChange.Size = new System.Drawing.Size(65, 22);
            this.tsbChange.Text = "Изменить";
            this.tsbChange.Click += new System.EventHandler(this.tsbChange_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(55, 22);
            this.tsbDelete.Text = "Удалить";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(626, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(518, 17);
            this.toolStripStatusLabel1.Text = "Данная форма предоставляет возможность устанавливать права доступа для пользовате" +
    "лей";
            // 
            // lvTable
            // 
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6});
            this.lvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTable.FullRowSelect = true;
            this.lvTable.HideSelection = false;
            this.lvTable.Location = new System.Drawing.Point(3, 48);
            this.lvTable.MultiSelect = false;
            this.lvTable.Name = "lvTable";
            this.lvTable.ShowItemToolTips = true;
            this.lvTable.Size = new System.Drawing.Size(620, 233);
            this.lvTable.TabIndex = 2;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.SelectedIndexChanged += new System.EventHandler(this.lvTable_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Наименование";
            this.columnHeader6.Width = 600;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(3, 287);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 236);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chViewStatistics);
            this.tabPage1.Controls.Add(this.chFormalizeContracts);
            this.tabPage1.Controls.Add(this.chEnableGarageEdit);
            this.tabPage1.Controls.Add(this.chEnableClientsEdit);
            this.tabPage1.Controls.Add(this.chEnableEmployeesEdit);
            this.tabPage1.Controls.Add(this.chEnablePassword);
            this.tabPage1.Controls.Add(this.chEnableChangeRights);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(612, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Установка прав для данной группы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chViewStatistics
            // 
            this.chViewStatistics.AutoSize = true;
            this.chViewStatistics.Location = new System.Drawing.Point(19, 180);
            this.chViewStatistics.Name = "chViewStatistics";
            this.chViewStatistics.Size = new System.Drawing.Size(136, 19);
            this.chViewStatistics.TabIndex = 6;
            this.chViewStatistics.Text = "Доступ к статистике";
            this.chViewStatistics.UseVisualStyleBackColor = true;
            this.chViewStatistics.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chFormalizeContracts
            // 
            this.chFormalizeContracts.AutoSize = true;
            this.chFormalizeContracts.Location = new System.Drawing.Point(19, 155);
            this.chFormalizeContracts.Name = "chFormalizeContracts";
            this.chFormalizeContracts.Size = new System.Drawing.Size(145, 19);
            this.chFormalizeContracts.TabIndex = 5;
            this.chFormalizeContracts.Text = "Оформлять договора";
            this.chFormalizeContracts.UseVisualStyleBackColor = true;
            this.chFormalizeContracts.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chEnableGarageEdit
            // 
            this.chEnableGarageEdit.AutoSize = true;
            this.chEnableGarageEdit.Location = new System.Drawing.Point(19, 130);
            this.chEnableGarageEdit.Name = "chEnableGarageEdit";
            this.chEnableGarageEdit.Size = new System.Drawing.Size(159, 19);
            this.chEnableGarageEdit.TabIndex = 4;
            this.chEnableGarageEdit.Text = "Редактировать автопарк";
            this.chEnableGarageEdit.UseVisualStyleBackColor = true;
            this.chEnableGarageEdit.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chEnableClientsEdit
            // 
            this.chEnableClientsEdit.AutoSize = true;
            this.chEnableClientsEdit.Location = new System.Drawing.Point(19, 105);
            this.chEnableClientsEdit.Name = "chEnableClientsEdit";
            this.chEnableClientsEdit.Size = new System.Drawing.Size(160, 19);
            this.chEnableClientsEdit.TabIndex = 3;
            this.chEnableClientsEdit.Text = "Редактировать клиентов";
            this.chEnableClientsEdit.UseVisualStyleBackColor = true;
            this.chEnableClientsEdit.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chEnableEmployeesEdit
            // 
            this.chEnableEmployeesEdit.AutoSize = true;
            this.chEnableEmployeesEdit.Location = new System.Drawing.Point(19, 80);
            this.chEnableEmployeesEdit.Name = "chEnableEmployeesEdit";
            this.chEnableEmployeesEdit.Size = new System.Drawing.Size(179, 19);
            this.chEnableEmployeesEdit.TabIndex = 2;
            this.chEnableEmployeesEdit.Text = "Редактировать сотрудников";
            this.chEnableEmployeesEdit.UseVisualStyleBackColor = true;
            this.chEnableEmployeesEdit.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chEnablePassword
            // 
            this.chEnablePassword.AutoSize = true;
            this.chEnablePassword.Location = new System.Drawing.Point(19, 55);
            this.chEnablePassword.Name = "chEnablePassword";
            this.chEnablePassword.Size = new System.Drawing.Size(123, 19);
            this.chEnablePassword.TabIndex = 1;
            this.chEnablePassword.Text = "Изменять пароли";
            this.chEnablePassword.UseVisualStyleBackColor = true;
            this.chEnablePassword.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chEnableChangeRights
            // 
            this.chEnableChangeRights.AutoSize = true;
            this.chEnableChangeRights.Location = new System.Drawing.Point(19, 30);
            this.chEnableChangeRights.Name = "chEnableChangeRights";
            this.chEnableChangeRights.Size = new System.Drawing.Size(160, 19);
            this.chEnableChangeRights.TabIndex = 0;
            this.chEnableChangeRights.Text = "Изменять права доступа";
            this.chEnableChangeRights.UseVisualStyleBackColor = true;
            this.chEnableChangeRights.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Укажите действия, доступные для данной группы:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(612, 208);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Добавление пользователей для данной группы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 147);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lbGroupUsers);
            this.groupBox4.Location = new System.Drawing.Point(303, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(287, 116);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Пользователи в данной группе";
            // 
            // lbGroupUsers
            // 
            this.lbGroupUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGroupUsers.FormattingEnabled = true;
            this.lbGroupUsers.ItemHeight = 15;
            this.lbGroupUsers.Location = new System.Drawing.Point(3, 19);
            this.lbGroupUsers.Name = "lbGroupUsers";
            this.lbGroupUsers.Size = new System.Drawing.Size(281, 94);
            this.lbGroupUsers.TabIndex = 0;
            this.lbGroupUsers.SelectedIndexChanged += new System.EventHandler(this.lbGroupUsers_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Location = new System.Drawing.Point(179, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 116);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Управление";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 81);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Удалить все";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(15, 52);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(15, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lbUsers);
            this.groupBox2.Location = new System.Drawing.Point(6, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 119);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пользователи";
            // 
            // lbUsers
            // 
            this.lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 15;
            this.lbUsers.Location = new System.Drawing.Point(3, 19);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(161, 97);
            this.lbUsers.TabIndex = 0;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(7, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(515, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Изменение прав для текущего пользователя произойдёт после повторного входа в сист" +
    "ему";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(472, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Пользователь может находится в нескольких группах и получать суммарные права";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(519, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Добавьте пользователей в данную группу для предоставления им прав доступа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите группу из списка или создайте из меню:";
            // 
            // GroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 548);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GroupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Меню управления доступом";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupsForm_FormClosing);
            this.Load += new System.EventHandler(this.GroupsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton tsbAppend;
        private System.Windows.Forms.ToolStripButton tsbChange;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chViewStatistics;
        private System.Windows.Forms.CheckBox chFormalizeContracts;
        private System.Windows.Forms.CheckBox chEnableGarageEdit;
        private System.Windows.Forms.CheckBox chEnableClientsEdit;
        private System.Windows.Forms.CheckBox chEnableEmployeesEdit;
        private System.Windows.Forms.CheckBox chEnablePassword;
        private System.Windows.Forms.CheckBox chEnableChangeRights;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbGroupUsers;
    }
}