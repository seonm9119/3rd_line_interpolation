namespace Final_Term3
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기본확대ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.차회선확ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.차회선보간법ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.결과화면ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.윤곽추출ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuzzyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vsobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ROI = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.maskToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(725, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.endToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.openToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(122, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.endToolStripMenuItem.Text = "End";
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.기본확대ToolStripMenuItem,
            this.차회선확ToolStripMenuItem,
            this.차회선보간법ToolStripMenuItem,
            this.결과화면ToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.processingToolStripMenuItem.Text = "Processing";
            // 
            // 기본확대ToolStripMenuItem
            // 
            this.기본확대ToolStripMenuItem.Name = "기본확대ToolStripMenuItem";
            this.기본확대ToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.기본확대ToolStripMenuItem.Text = "기본확대";
            this.기본확대ToolStripMenuItem.Click += new System.EventHandler(this.기본확대ToolStripMenuItem_Click);
            // 
            // 차회선확ToolStripMenuItem
            // 
            this.차회선확ToolStripMenuItem.Name = "차회선확ToolStripMenuItem";
            this.차회선확ToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.차회선확ToolStripMenuItem.Text = "최근방 이웃 보간법";
            this.차회선확ToolStripMenuItem.Click += new System.EventHandler(this.차회선확ToolStripMenuItem_Click);
            // 
            // 차회선보간법ToolStripMenuItem
            // 
            this.차회선보간법ToolStripMenuItem.Name = "차회선보간법ToolStripMenuItem";
            this.차회선보간법ToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.차회선보간법ToolStripMenuItem.Text = "3차 회선 보간법";
            this.차회선보간법ToolStripMenuItem.Click += new System.EventHandler(this.차회선보간법ToolStripMenuItem_Click);
            // 
            // 결과화면ToolStripMenuItem
            // 
            this.결과화면ToolStripMenuItem.Name = "결과화면ToolStripMenuItem";
            this.결과화면ToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.결과화면ToolStripMenuItem.Text = "결과화면";
            this.결과화면ToolStripMenuItem.Click += new System.EventHandler(this.결과화면ToolStripMenuItem_Click);
            // 
            // maskToolStripMenuItem
            // 
            this.maskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.윤곽추출ToolStripMenuItem,
            this.fuzzyToolStripMenuItem,
            this.vsobelToolStripMenuItem});
            this.maskToolStripMenuItem.Name = "maskToolStripMenuItem";
            this.maskToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.maskToolStripMenuItem.Text = "Mask";
            // 
            // 윤곽추출ToolStripMenuItem
            // 
            this.윤곽추출ToolStripMenuItem.Name = "윤곽추출ToolStripMenuItem";
            this.윤곽추출ToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.윤곽추출ToolStripMenuItem.Text = "LOG";
            this.윤곽추출ToolStripMenuItem.Click += new System.EventHandler(this.윤곽추출ToolStripMenuItem_Click);
            // 
            // fuzzyToolStripMenuItem
            // 
            this.fuzzyToolStripMenuItem.Name = "fuzzyToolStripMenuItem";
            this.fuzzyToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.fuzzyToolStripMenuItem.Text = "Fuzzy";
            this.fuzzyToolStripMenuItem.Click += new System.EventHandler(this.fuzzyToolStripMenuItem_Click);
            // 
            // vsobelToolStripMenuItem
            // 
            this.vsobelToolStripMenuItem.Name = "vsobelToolStripMenuItem";
            this.vsobelToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.vsobelToolStripMenuItem.Text = "v_sobel";
            this.vsobelToolStripMenuItem.Click += new System.EventHandler(this.vsobelToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ROI
            // 
            this.ROI.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ROI.Cursor = System.Windows.Forms.Cursors.Default;
            this.ROI.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ROI.Location = new System.Drawing.Point(546, 439);
            this.ROI.Name = "ROI";
            this.ROI.Size = new System.Drawing.Size(151, 49);
            this.ROI.TabIndex = 3;
            this.ROI.Text = "ROI";
            this.ROI.UseVisualStyleBackColor = false;
            this.ROI.Click += new System.EventHandler(this.ROI_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(546, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "추출";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ROI);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ROI;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기본확대ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 차회선확ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 차회선보간법ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 결과화면ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 윤곽추출ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuzzyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vsobelToolStripMenuItem;
    }
}

