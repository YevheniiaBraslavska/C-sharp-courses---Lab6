namespace SimCorp.IMS.WinFormsCalls {
    partial class CallsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.CallsViewList = new System.Windows.Forms.ListView();
            this.ContactCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // CallsViewList
            // 
            this.CallsViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContactCount,
            this.TimeDirection});
            this.CallsViewList.Location = new System.Drawing.Point(11, 14);
            this.CallsViewList.Name = "CallsViewList";
            this.CallsViewList.Size = new System.Drawing.Size(261, 235);
            this.CallsViewList.TabIndex = 0;
            this.CallsViewList.TileSize = new System.Drawing.Size(220, 30);
            this.CallsViewList.UseCompatibleStateImageBehavior = false;
            this.CallsViewList.View = System.Windows.Forms.View.Tile;
            // 
            // ContactCount
            // 
            this.ContactCount.Width = 100;
            // 
            // TimeDirection
            // 
            this.TimeDirection.Width = 220;
            // 
            // CallsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CallsViewList);
            this.MaximizeBox = false;
            this.Name = "CallsForm";
            this.Text = "Calls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView CallsViewList;
        private System.Windows.Forms.ColumnHeader ContactCount;
        private System.Windows.Forms.ColumnHeader TimeDirection;
    }
}

