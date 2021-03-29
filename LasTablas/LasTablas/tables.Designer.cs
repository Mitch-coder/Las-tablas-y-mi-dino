namespace Tables
{
    partial class Tables
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
            this.label2 = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TextBox();
            this.limit = new System.Windows.Forms.TextBox();
            this.Multiply = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Limit";
            // 
            // table
            // 
            this.table.Location = new System.Drawing.Point(33, 118);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(88, 22);
            this.table.TabIndex = 2;
            this.table.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Table_KeyPress);
            // 
            // limit
            // 
            this.limit.Location = new System.Drawing.Point(34, 226);
            this.limit.Name = "limit";
            this.limit.Size = new System.Drawing.Size(98, 22);
            this.limit.TabIndex = 3;
            this.limit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Limit_KeyPress);
            // 
            // Multiply
            // 
            this.Multiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(223)))), ((int)(((byte)(22)))));
            this.Multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Multiply.Location = new System.Drawing.Point(12, 295);
            this.Multiply.Name = "Multiply";
            this.Multiply.Size = new System.Drawing.Size(140, 84);
            this.Multiply.TabIndex = 4;
            this.Multiply.Text = "Multiply";
            this.Multiply.UseVisualStyleBackColor = false;
            this.Multiply.Click += new System.EventHandler(this.Multiply_Click);
            // 
            // listResult
            // 
            this.listResult.ItemHeight = 16;
            this.listResult.Location = new System.Drawing.Point(186, 71);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(238, 324);
            this.listResult.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result:";
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(219)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(451, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.Multiply);
            this.Controls.Add(this.limit);
            this.Controls.Add(this.table);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Tables";
            this.Text = "Tables";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox table;
        private System.Windows.Forms.TextBox limit;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.Label label3;
    }
}

