namespace CarRental
{
    partial class BrandsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrandsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAppend = new System.Windows.Forms.ToolStripButton();
            this.tsbChange = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnAutoList = new System.Windows.Forms.Button();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            this.btnSavePhoto = new System.Windows.Forms.Button();
            this.tbDescriptor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openPhotoDialog = new System.Windows.Forms.OpenFileDialog();
            this.savePhotoDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lvTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 639);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAppend,
            this.tsbChange,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
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
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 617);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(558, 17);
            this.toolStripStatusLabel1.Text = "Данная форма предоставляет возможность ввода и редактирования данных о марках авт" +
    "омобилей";
            // 
            // lvTable
            // 
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTable.FullRowSelect = true;
            this.lvTable.HideSelection = false;
            this.lvTable.Location = new System.Drawing.Point(3, 28);
            this.lvTable.MultiSelect = false;
            this.lvTable.Name = "lvTable";
            this.lvTable.ShowItemToolTips = true;
            this.lvTable.Size = new System.Drawing.Size(208, 586);
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "Наименование";
            this.columnHeader2.Width = 200;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(217, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 586);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbPhoto);
            this.tabPage1.Controls.Add(this.btnAutoList);
            this.tabPage1.Controls.Add(this.btnSelectPhoto);
            this.tabPage1.Controls.Add(this.btnSavePhoto);
            this.tabPage1.Controls.Add(this.tbDescriptor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(404, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Марки автомобилей";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbPhoto
            // 
            this.pbPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPhoto.Location = new System.Drawing.Point(3, 6);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(395, 199);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 9;
            this.pbPhoto.TabStop = false;
            // 
            // btnAutoList
            // 
            this.btnAutoList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAutoList.Enabled = false;
            this.btnAutoList.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAutoList.Image = global::CarRental.Properties.Resources.catalog;
            this.btnAutoList.Location = new System.Drawing.Point(284, 211);
            this.btnAutoList.Name = "btnAutoList";
            this.btnAutoList.Size = new System.Drawing.Size(109, 35);
            this.btnAutoList.TabIndex = 2;
            this.btnAutoList.Text = "Список авто";
            this.btnAutoList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAutoList.UseVisualStyleBackColor = true;
            // 
            // btnSelectPhoto
            // 
            this.btnSelectPhoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectPhoto.Enabled = false;
            this.btnSelectPhoto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectPhoto.Image = global::CarRental.Properties.Resources.saveAll;
            this.btnSelectPhoto.Location = new System.Drawing.Point(3, 211);
            this.btnSelectPhoto.Name = "btnSelectPhoto";
            this.btnSelectPhoto.Size = new System.Drawing.Size(123, 35);
            this.btnSelectPhoto.TabIndex = 0;
            this.btnSelectPhoto.Text = "Выбрать фото";
            this.btnSelectPhoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectPhoto.UseVisualStyleBackColor = true;
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);
            // 
            // btnSavePhoto
            // 
            this.btnSavePhoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSavePhoto.Enabled = false;
            this.btnSavePhoto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSavePhoto.Image = global::CarRental.Properties.Resources.save;
            this.btnSavePhoto.Location = new System.Drawing.Point(132, 211);
            this.btnSavePhoto.Name = "btnSavePhoto";
            this.btnSavePhoto.Size = new System.Drawing.Size(146, 35);
            this.btnSavePhoto.TabIndex = 1;
            this.btnSavePhoto.Text = "Сохранить на диск";
            this.btnSavePhoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSavePhoto.UseVisualStyleBackColor = true;
            this.btnSavePhoto.Click += new System.EventHandler(this.btnSavePhoto_Click);
            // 
            // tbDescriptor
            // 
            this.tbDescriptor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescriptor.BackColor = System.Drawing.SystemColors.Window;
            this.tbDescriptor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriptor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbDescriptor.Location = new System.Drawing.Point(9, 267);
            this.tbDescriptor.MaxLength = 250;
            this.tbDescriptor.Multiline = true;
            this.tbDescriptor.Name = "tbDescriptor";
            this.tbDescriptor.ReadOnly = true;
            this.tbDescriptor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescriptor.Size = new System.Drawing.Size(389, 275);
            this.tbDescriptor.TabIndex = 0;
            this.tbDescriptor.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Описание:";
            // 
            // openPhotoDialog
            // 
            this.openPhotoDialog.DefaultExt = "jpg";
            this.openPhotoDialog.Filter = "*.jpg|*.jpg";
            // 
            // savePhotoDialog
            // 
            this.savePhotoDialog.DefaultExt = "jpg";
            this.savePhotoDialog.FileName = "avto.jpg";
            this.savePhotoDialog.Filter = "*.jpg|*.jpg";
            // 
            // BrandsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 639);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "BrandsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Марки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrandsForm_FormClosing);
            this.Load += new System.EventHandler(this.BrandsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton tsbAppend;
        private System.Windows.Forms.ToolStripButton tsbChange;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.TextBox tbDescriptor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSavePhoto;
        private System.Windows.Forms.Button btnAutoList;
        private System.Windows.Forms.Button btnSelectPhoto;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.OpenFileDialog openPhotoDialog;
        private System.Windows.Forms.SaveFileDialog savePhotoDialog;
    }
}