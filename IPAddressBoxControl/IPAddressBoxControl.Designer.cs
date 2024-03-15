namespace IPAddressBoxControl
{
    partial class IPAddressBoxControl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(0, 0);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(93, 21);
            this.IPTextBox.TabIndex = 0;
            this.IPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IPTextBox_MouseClick);
            this.IPTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPTextBox_KeyPress);
            this.IPTextBox.Resize += new System.EventHandler(this.IPTextBox_Resize);
            // 
            // IPAddressBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IPTextBox);
            this.Name = "IPAddressBoxControl";
            this.Size = new System.Drawing.Size(165, 26);
            this.Load += new System.EventHandler(this.IPAddressBoxControl_Load);
            this.Move += new System.EventHandler(this.IPAddressBoxControl_Move);
            this.Resize += new System.EventHandler(this.IPAddressBoxControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPTextBox;
    }
}
