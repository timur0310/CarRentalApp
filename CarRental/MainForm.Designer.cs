namespace CarRental
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tsmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMakeContract = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListOfCars = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDictionaries = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCarBrands = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCarParks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParking = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lbUser = new System.Windows.Forms.Label();
            this.btnMakeContract = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnCarParks = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnAccessControl = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStripMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelMenu, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(413, 331);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenu,
            this.tsmiDocuments,
            this.tsmiDictionaries});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(413, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // tsmiMenu
            // 
            this.tsmiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMakeContract,
            this.miExit});
            this.tsmiMenu.Name = "tsmiMenu";
            this.tsmiMenu.Size = new System.Drawing.Size(53, 20);
            this.tsmiMenu.Text = "Меню";
            // 
            // tsmiMakeContract
            // 
            this.tsmiMakeContract.Name = "tsmiMakeContract";
            this.tsmiMakeContract.Size = new System.Drawing.Size(181, 22);
            this.tsmiMakeContract.Text = "Оформить договор";
            this.tsmiMakeContract.Click += new System.EventHandler(this.tsmiMakeContract_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(181, 22);
            this.miExit.Text = "Выход";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // tsmiDocuments
            // 
            this.tsmiDocuments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiListOfCars,
            this.tsmiEmployees,
            this.tsmiClients});
            this.tsmiDocuments.Name = "tsmiDocuments";
            this.tsmiDocuments.Size = new System.Drawing.Size(82, 20);
            this.tsmiDocuments.Text = "Документы";
            // 
            // tsmiListOfCars
            // 
            this.tsmiListOfCars.Name = "tsmiListOfCars";
            this.tsmiListOfCars.Size = new System.Drawing.Size(205, 22);
            this.tsmiListOfCars.Text = "Перечень автомобилей";
            this.tsmiListOfCars.Click += new System.EventHandler(this.tsmiListOfCars_Click);
            // 
            // tsmiEmployees
            // 
            this.tsmiEmployees.Name = "tsmiEmployees";
            this.tsmiEmployees.Size = new System.Drawing.Size(205, 22);
            this.tsmiEmployees.Text = "Сотрудники";
            this.tsmiEmployees.Click += new System.EventHandler(this.tsmiEmployees_Click);
            // 
            // tsmiClients
            // 
            this.tsmiClients.Name = "tsmiClients";
            this.tsmiClients.Size = new System.Drawing.Size(205, 22);
            this.tsmiClients.Text = "Клиенты";
            this.tsmiClients.Click += new System.EventHandler(this.tsmiClients_Click);
            // 
            // tsmiDictionaries
            // 
            this.tsmiDictionaries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCarBrands,
            this.tsmiCarParks,
            this.tsmiParking});
            this.tsmiDictionaries.Name = "tsmiDictionaries";
            this.tsmiDictionaries.Size = new System.Drawing.Size(94, 20);
            this.tsmiDictionaries.Text = "Справочники";
            // 
            // tsmiCarBrands
            // 
            this.tsmiCarBrands.Name = "tsmiCarBrands";
            this.tsmiCarBrands.Size = new System.Drawing.Size(126, 22);
            this.tsmiCarBrands.Text = "Марки";
            this.tsmiCarBrands.Click += new System.EventHandler(this.tsmiCarBrands_Click);
            // 
            // tsmiCarParks
            // 
            this.tsmiCarParks.Name = "tsmiCarParks";
            this.tsmiCarParks.Size = new System.Drawing.Size(126, 22);
            this.tsmiCarParks.Text = "Автопарк";
            this.tsmiCarParks.Click += new System.EventHandler(this.tsmiCarParks_Click);
            // 
            // tsmiParking
            // 
            this.tsmiParking.Name = "tsmiParking";
            this.tsmiParking.Size = new System.Drawing.Size(126, 22);
            this.tsmiParking.Text = "Стоянка";
            this.tsmiParking.Click += new System.EventHandler(this.tsmiParking_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.lbUser);
            this.panelMenu.Controls.Add(this.btnMakeContract);
            this.panelMenu.Controls.Add(this.btnClients);
            this.panelMenu.Controls.Add(this.btnStatistics);
            this.panelMenu.Controls.Add(this.btnEmployees);
            this.panelMenu.Controls.Add(this.btnCarParks);
            this.panelMenu.Controls.Add(this.btnChangeUser);
            this.panelMenu.Controls.Add(this.btnAccessControl);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(3, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(407, 301);
            this.panelMenu.TabIndex = 1;
            // 
            // lbUser
            // 
            this.lbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUser.AutoEllipsis = true;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUser.ForeColor = System.Drawing.Color.DimGray;
            this.lbUser.Location = new System.Drawing.Point(3, 2);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(401, 20);
            this.lbUser.TabIndex = 7;
            this.lbUser.Text = "Пользователь";
            // 
            // btnMakeContract
            // 
            this.btnMakeContract.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMakeContract.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeContract.Image")));
            this.btnMakeContract.Location = new System.Drawing.Point(19, 247);
            this.btnMakeContract.Name = "btnMakeContract";
            this.btnMakeContract.Size = new System.Drawing.Size(362, 43);
            this.btnMakeContract.TabIndex = 1;
            this.btnMakeContract.Text = "Оформление договора проката";
            this.btnMakeContract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMakeContract.UseVisualStyleBackColor = true;
            this.btnMakeContract.Click += new System.EventHandler(this.btnMakeContract_Click);
            // 
            // btnClients
            // 
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.Location = new System.Drawing.Point(212, 190);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(169, 43);
            this.btnClients.TabIndex = 0;
            this.btnClients.Text = "Клиенты";
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatistics.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistics.Image")));
            this.btnStatistics.Location = new System.Drawing.Point(19, 190);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(169, 43);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployees.Image")));
            this.btnEmployees.Location = new System.Drawing.Point(212, 133);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(169, 43);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Сотрудники";
            this.btnEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnCarParks
            // 
            this.btnCarParks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCarParks.Image = global::CarRental.Properties.Resources.Автопарк;
            this.btnCarParks.Location = new System.Drawing.Point(19, 133);
            this.btnCarParks.Name = "btnCarParks";
            this.btnCarParks.Size = new System.Drawing.Size(169, 43);
            this.btnCarParks.TabIndex = 4;
            this.btnCarParks.Text = "Автопарк";
            this.btnCarParks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarParks.UseVisualStyleBackColor = true;
            this.btnCarParks.Click += new System.EventHandler(this.btnCarParks_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeUser.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeUser.Image")));
            this.btnChangeUser.Location = new System.Drawing.Point(166, 79);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(215, 43);
            this.btnChangeUser.TabIndex = 5;
            this.btnChangeUser.Text = "Сменить пользователя";
            this.btnChangeUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // btnAccessControl
            // 
            this.btnAccessControl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAccessControl.Image = ((System.Drawing.Image)(resources.GetObject("btnAccessControl.Image")));
            this.btnAccessControl.Location = new System.Drawing.Point(166, 26);
            this.btnAccessControl.Name = "btnAccessControl";
            this.btnAccessControl.Size = new System.Drawing.Size(215, 43);
            this.btnAccessControl.TabIndex = 6;
            this.btnAccessControl.Text = "Управление доступом";
            this.btnAccessControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccessControl.UseVisualStyleBackColor = true;
            this.btnAccessControl.Click += new System.EventHandler(this.btnAccessControl_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 331);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АИС Автопрокат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocuments;
        private System.Windows.Forms.ToolStripMenuItem tsmiDictionaries;
        private System.Windows.Forms.ToolStripMenuItem tsmiMakeContract;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiListOfCars;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmployees;
        private System.Windows.Forms.ToolStripMenuItem tsmiClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiCarBrands;
        private System.Windows.Forms.ToolStripMenuItem tsmiCarParks;
        private System.Windows.Forms.ToolStripMenuItem tsmiParking;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnAccessControl;
        private System.Windows.Forms.Button btnMakeContract;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnCarParks;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Timer timer1;
    }
}

