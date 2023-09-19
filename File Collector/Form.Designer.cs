namespace File_Collector
{
    partial class Form
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.AllowDrop = true;
            this.box.Dock = System.Windows.Forms.DockStyle.Top;
            this.box.Location = new System.Drawing.Point(0, 0);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(245, 19);
            this.box.TabIndex = 0;
            this.box.DragDrop += new System.Windows.Forms.DragEventHandler(this.box_DragDrop);
            this.box.DragEnter += new System.Windows.Forms.DragEventHandler(this.box_DragEnter);
            // 
            // Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 121);
            this.Controls.Add(this.box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "File Collector";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox box;
    }
}

