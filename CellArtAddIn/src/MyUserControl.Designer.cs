namespace CellArtAddIn
{
    partial class MyUserControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pathTbx = new System.Windows.Forms.TextBox();
            this.c_browseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_numCellHeight = new System.Windows.Forms.NumericUpDown();
            this.c_numCellWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.c_executeBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c_labelSize = new System.Windows.Forms.Label();
            this.c_pbxImage = new bambit.forms.controls.PictureBoxExtended();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_numResoHori = new System.Windows.Forms.NumericUpDown();
            this.c_numResoVert = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.c_colorMode2003 = new System.Windows.Forms.RadioButton();
            this.c_colorModeAll = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.c_btnSetTransparency = new System.Windows.Forms.Button();
            this.c_txtTransparency = new System.Windows.Forms.TextBox();
            this.c_pbxTransparency = new System.Windows.Forms.PictureBox();
            this.c_cbxUseTransparency = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_numCellHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_numCellWidth)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_numResoHori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_numResoVert)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pbxTransparency)).BeginInit();
            this.SuspendLayout();
            // 
            // pathTbx
            // 
            this.pathTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTbx.Location = new System.Drawing.Point(3, 5);
            this.pathTbx.Name = "pathTbx";
            this.pathTbx.Size = new System.Drawing.Size(322, 19);
            this.pathTbx.TabIndex = 0;
            // 
            // c_browseBtn
            // 
            this.c_browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_browseBtn.Location = new System.Drawing.Point(331, 3);
            this.c_browseBtn.Name = "c_browseBtn";
            this.c_browseBtn.Size = new System.Drawing.Size(75, 23);
            this.c_browseBtn.TabIndex = 1;
            this.c_browseBtn.Text = "Browse";
            this.c_browseBtn.UseVisualStyleBackColor = true;
            this.c_browseBtn.Click += new System.EventHandler(this.c_browseBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "width";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.c_numCellHeight);
            this.groupBox1.Controls.Add(this.c_numCellWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 52);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cell (Pixel)";
            // 
            // c_numCellHeight
            // 
            this.c_numCellHeight.Location = new System.Drawing.Point(215, 17);
            this.c_numCellHeight.Maximum = new decimal(new int[] {
            548,
            0,
            0,
            0});
            this.c_numCellHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c_numCellHeight.Name = "c_numCellHeight";
            this.c_numCellHeight.Size = new System.Drawing.Size(82, 19);
            this.c_numCellHeight.TabIndex = 1;
            this.c_numCellHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // c_numCellWidth
            // 
            this.c_numCellWidth.Location = new System.Drawing.Point(54, 17);
            this.c_numCellWidth.Maximum = new decimal(new int[] {
            2044,
            0,
            0,
            0});
            this.c_numCellWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c_numCellWidth.Name = "c_numCellWidth";
            this.c_numCellWidth.Size = new System.Drawing.Size(82, 19);
            this.c_numCellWidth.TabIndex = 0;
            this.c_numCellWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(163, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "height";
            // 
            // c_executeBtn
            // 
            this.c_executeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_executeBtn.Enabled = false;
            this.c_executeBtn.Location = new System.Drawing.Point(331, 36);
            this.c_executeBtn.Name = "c_executeBtn";
            this.c_executeBtn.Size = new System.Drawing.Size(75, 23);
            this.c_executeBtn.TabIndex = 2;
            this.c_executeBtn.Text = "Execute";
            this.c_executeBtn.UseVisualStyleBackColor = true;
            this.c_executeBtn.Click += new System.EventHandler(this.c_executeBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.c_labelSize);
            this.groupBox3.Controls.Add(this.c_pbxImage);
            this.groupBox3.Location = new System.Drawing.Point(3, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 221);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image";
            // 
            // c_labelSize
            // 
            this.c_labelSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.c_labelSize.Location = new System.Drawing.Point(17, 201);
            this.c_labelSize.Name = "c_labelSize";
            this.c_labelSize.Size = new System.Drawing.Size(370, 17);
            this.c_labelSize.TabIndex = 1;
            this.c_labelSize.Text = "label5";
            this.c_labelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_pbxImage
            // 
            this.c_pbxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_pbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c_pbxImage.Location = new System.Drawing.Point(7, 19);
            this.c_pbxImage.Name = "c_pbxImage";
            this.c_pbxImage.Size = new System.Drawing.Size(389, 179);
            this.c_pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.c_pbxImage.TabIndex = 0;
            this.c_pbxImage.TabStop = false;
            this.c_pbxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.c_pbxImage_MouseDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "horizontal";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(163, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "vertical";
            // 
            // c_numResoHori
            // 
            this.c_numResoHori.Location = new System.Drawing.Point(71, 16);
            this.c_numResoHori.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.c_numResoHori.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c_numResoHori.Name = "c_numResoHori";
            this.c_numResoHori.Size = new System.Drawing.Size(65, 19);
            this.c_numResoHori.TabIndex = 0;
            this.c_numResoHori.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // c_numResoVert
            // 
            this.c_numResoVert.Location = new System.Drawing.Point(215, 17);
            this.c_numResoVert.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.c_numResoVert.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c_numResoVert.Name = "c_numResoVert";
            this.c_numResoVert.Size = new System.Drawing.Size(82, 19);
            this.c_numResoVert.TabIndex = 1;
            this.c_numResoVert.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.c_numResoVert);
            this.groupBox2.Controls.Add(this.c_numResoHori);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resolution (Pixel per Cell)";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.c_colorMode2003);
            this.groupBox4.Controls.Add(this.c_colorModeAll);
            this.groupBox4.Location = new System.Drawing.Point(3, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 52);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Color Mode";
            // 
            // c_colorMode2003
            // 
            this.c_colorMode2003.AutoSize = true;
            this.c_colorMode2003.Location = new System.Drawing.Point(119, 19);
            this.c_colorMode2003.Name = "c_colorMode2003";
            this.c_colorMode2003.Size = new System.Drawing.Size(190, 16);
            this.c_colorMode2003.TabIndex = 1;
            this.c_colorMode2003.Text = "Use only 2003 compatible colors";
            this.c_colorMode2003.UseVisualStyleBackColor = true;
            // 
            // c_colorModeAll
            // 
            this.c_colorModeAll.AutoSize = true;
            this.c_colorModeAll.Checked = true;
            this.c_colorModeAll.Location = new System.Drawing.Point(7, 19);
            this.c_colorModeAll.Name = "c_colorModeAll";
            this.c_colorModeAll.Size = new System.Drawing.Size(94, 16);
            this.c_colorModeAll.TabIndex = 0;
            this.c_colorModeAll.TabStop = true;
            this.c_colorModeAll.Text = "Use all colors";
            this.c_colorModeAll.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.c_btnSetTransparency);
            this.groupBox5.Controls.Add(this.c_txtTransparency);
            this.groupBox5.Controls.Add(this.c_pbxTransparency);
            this.groupBox5.Controls.Add(this.c_cbxUseTransparency);
            this.groupBox5.Location = new System.Drawing.Point(3, 205);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(403, 53);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Transparency Color";
            // 
            // c_btnSetTransparency
            // 
            this.c_btnSetTransparency.Location = new System.Drawing.Point(355, 14);
            this.c_btnSetTransparency.Name = "c_btnSetTransparency";
            this.c_btnSetTransparency.Size = new System.Drawing.Size(41, 23);
            this.c_btnSetTransparency.TabIndex = 1;
            this.c_btnSetTransparency.Text = "Set";
            this.c_btnSetTransparency.UseVisualStyleBackColor = true;
            this.c_btnSetTransparency.Click += new System.EventHandler(this.c_btnSetTransparency_Click);
            // 
            // c_txtTransparency
            // 
            this.c_txtTransparency.Location = new System.Drawing.Point(203, 16);
            this.c_txtTransparency.Name = "c_txtTransparency";
            this.c_txtTransparency.ReadOnly = true;
            this.c_txtTransparency.Size = new System.Drawing.Size(146, 19);
            this.c_txtTransparency.TabIndex = 2;
            this.c_txtTransparency.Text = "(R, G, B) = (255, 255, 255)";
            // 
            // c_pbxTransparency
            // 
            this.c_pbxTransparency.BackColor = System.Drawing.Color.White;
            this.c_pbxTransparency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c_pbxTransparency.Location = new System.Drawing.Point(176, 18);
            this.c_pbxTransparency.Name = "c_pbxTransparency";
            this.c_pbxTransparency.Size = new System.Drawing.Size(21, 16);
            this.c_pbxTransparency.TabIndex = 1;
            this.c_pbxTransparency.TabStop = false;
            // 
            // c_cbxUseTransparency
            // 
            this.c_cbxUseTransparency.AutoSize = true;
            this.c_cbxUseTransparency.Location = new System.Drawing.Point(8, 18);
            this.c_cbxUseTransparency.Name = "c_cbxUseTransparency";
            this.c_cbxUseTransparency.Size = new System.Drawing.Size(143, 16);
            this.c_cbxUseTransparency.TabIndex = 0;
            this.c_cbxUseTransparency.Text = "Use transparency color";
            this.c_cbxUseTransparency.UseVisualStyleBackColor = true;
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.c_executeBtn);
            this.Controls.Add(this.c_browseBtn);
            this.Controls.Add(this.pathTbx);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(413, 488);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_numCellHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_numCellWidth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_numResoHori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_numResoVert)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pbxTransparency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTbx;
        private System.Windows.Forms.Button c_browseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown c_numCellWidth;
        private System.Windows.Forms.NumericUpDown c_numCellHeight;
        private System.Windows.Forms.Button c_executeBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label c_labelSize;
        private bambit.forms.controls.PictureBoxExtended c_pbxImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown c_numResoHori;
        private System.Windows.Forms.NumericUpDown c_numResoVert;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton c_colorMode2003;
        private System.Windows.Forms.RadioButton c_colorModeAll;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button c_btnSetTransparency;
        private System.Windows.Forms.TextBox c_txtTransparency;
        private System.Windows.Forms.PictureBox c_pbxTransparency;
        private System.Windows.Forms.CheckBox c_cbxUseTransparency;
    }
}
