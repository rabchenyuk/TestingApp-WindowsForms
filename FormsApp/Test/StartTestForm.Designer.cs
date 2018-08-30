namespace FormsApp.Test
{
    partial class StartTestForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.selectList = new System.Windows.Forms.ComboBox();
            this.buttonPassTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Назва тесту";
            // 
            // selectList
            // 
            this.selectList.BackColor = System.Drawing.SystemColors.Window;
            this.selectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectList.FormattingEnabled = true;
            this.selectList.ItemHeight = 24;
            this.selectList.Location = new System.Drawing.Point(75, 53);
            this.selectList.Name = "selectList";
            this.selectList.Size = new System.Drawing.Size(341, 32);
            this.selectList.TabIndex = 2;
            // 
            // buttonPassTest
            // 
            this.buttonPassTest.Location = new System.Drawing.Point(152, 155);
            this.buttonPassTest.Name = "buttonPassTest";
            this.buttonPassTest.Size = new System.Drawing.Size(174, 60);
            this.buttonPassTest.TabIndex = 4;
            this.buttonPassTest.Text = "Пройти тест";
            this.buttonPassTest.UseVisualStyleBackColor = true;
            this.buttonPassTest.Click += new System.EventHandler(this.buttonPassTest_Click);
            // 
            // StartTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 297);
            this.Controls.Add(this.buttonPassTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectList);
            this.Name = "StartTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartTestForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartTestForm_FormClosed);
            this.Load += new System.EventHandler(this.StartTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectList;
        private System.Windows.Forms.Button buttonPassTest;
    }
}