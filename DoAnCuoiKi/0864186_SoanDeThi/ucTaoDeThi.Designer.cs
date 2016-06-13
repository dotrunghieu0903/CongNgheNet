namespace _0864186_SoanDeThi
{
    partial class ucTaoDeThi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaoDeThi));
            this.gbChonCauHoi = new System.Windows.Forms.GroupBox();
            this.lvChonCauHoi = new System.Windows.Forms.ListView();
            this.STT = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gbXuLy = new System.Windows.Forms.GroupBox();
            this.btnTaodeThi = new System.Windows.Forms.Button();
            this.gbChonCauHoi.SuspendLayout();
            this.gbXuLy.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbChonCauHoi
            // 
            this.gbChonCauHoi.Controls.Add(this.lvChonCauHoi);
            this.gbChonCauHoi.Location = new System.Drawing.Point(6, 3);
            this.gbChonCauHoi.Name = "gbChonCauHoi";
            this.gbChonCauHoi.Size = new System.Drawing.Size(872, 540);
            this.gbChonCauHoi.TabIndex = 0;
            this.gbChonCauHoi.TabStop = false;
            this.gbChonCauHoi.Text = "Chọn câu hỏi";
            // 
            // lvChonCauHoi
            // 
            this.lvChonCauHoi.CheckBoxes = true;
            this.lvChonCauHoi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.columnHeader2});
            listViewGroup1.Header = "";
            listViewGroup1.Name = "lvgTaoDe";
            this.lvChonCauHoi.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvChonCauHoi.Location = new System.Drawing.Point(6, 24);
            this.lvChonCauHoi.Name = "lvChonCauHoi";
            this.lvChonCauHoi.Size = new System.Drawing.Size(860, 515);
            this.lvChonCauHoi.TabIndex = 0;
            this.lvChonCauHoi.UseCompatibleStateImageBehavior = false;
            this.lvChonCauHoi.View = System.Windows.Forms.View.Details;
            // 
            // STT
            // 
            this.STT.Text = "STT";
            this.STT.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nội dung";
            this.columnHeader2.Width = 1000;
            // 
            // gbXuLy
            // 
            this.gbXuLy.Controls.Add(this.btnTaodeThi);
            this.gbXuLy.Location = new System.Drawing.Point(6, 549);
            this.gbXuLy.Name = "gbXuLy";
            this.gbXuLy.Size = new System.Drawing.Size(872, 60);
            this.gbXuLy.TabIndex = 1;
            this.gbXuLy.TabStop = false;
            // 
            // btnTaodeThi
            // 
            this.btnTaodeThi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTaodeThi.BackgroundImage")));
            this.btnTaodeThi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaodeThi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTaodeThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaodeThi.ForeColor = System.Drawing.Color.White;
            this.btnTaodeThi.Location = new System.Drawing.Point(750, 19);
            this.btnTaodeThi.Name = "btnTaodeThi";
            this.btnTaodeThi.Size = new System.Drawing.Size(100, 27);
            this.btnTaodeThi.TabIndex = 7;
            this.btnTaodeThi.Text = "Tạo đề thi";
            this.btnTaodeThi.UseVisualStyleBackColor = true;
            this.btnTaodeThi.Click += new System.EventHandler(this.btnTaodeThi_Click);
            // 
            // ucTaoDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.gbXuLy);
            this.Controls.Add(this.gbChonCauHoi);
            this.Name = "ucTaoDeThi";
            this.Size = new System.Drawing.Size(884, 615);
            this.gbChonCauHoi.ResumeLayout(false);
            this.gbXuLy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbChonCauHoi;
        private System.Windows.Forms.GroupBox gbXuLy;
        private System.Windows.Forms.Button btnTaodeThi;
        private System.Windows.Forms.ListView lvChonCauHoi;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader columnHeader2;




    }
}
