namespace NtierStore
{
    partial class EntryForm
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
            this.Database = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.Label();
            this.Enter = new System.Windows.Forms.Button();
            this.Bookstoredb = new System.Windows.Forms.Label();
            this.Blackdiamond = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Violet;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bookstore Management";
            // 
            // Database
            // 
            this.Database.AutoSize = true;
            this.Database.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Database.Location = new System.Drawing.Point(12, 108);
            this.Database.Name = "Database";
            this.Database.Size = new System.Drawing.Size(113, 26);
            this.Database.TabIndex = 1;
            this.Database.Text = "Database :";
            // 
            // Server
            // 
            this.Server.AutoSize = true;
            this.Server.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Server.Location = new System.Drawing.Point(274, 105);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(144, 26);
            this.Server.TabIndex = 2;
            this.Server.Text = "ServerName :";
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.LimeGreen;
            this.Enter.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter.Location = new System.Drawing.Point(254, 192);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(94, 41);
            this.Enter.TabIndex = 5;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // Bookstoredb
            // 
            this.Bookstoredb.AutoSize = true;
            this.Bookstoredb.BackColor = System.Drawing.Color.DarkCyan;
            this.Bookstoredb.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bookstoredb.Location = new System.Drawing.Point(121, 108);
            this.Bookstoredb.Name = "Bookstoredb";
            this.Bookstoredb.Size = new System.Drawing.Size(136, 26);
            this.Bookstoredb.TabIndex = 6;
            this.Bookstoredb.Text = "Bookstoredb";
            // 
            // Blackdiamond
            // 
            this.Blackdiamond.AutoSize = true;
            this.Blackdiamond.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blackdiamond.Location = new System.Drawing.Point(413, 105);
            this.Blackdiamond.Name = "Blackdiamond";
            this.Blackdiamond.Size = new System.Drawing.Size(154, 26);
            this.Blackdiamond.TabIndex = 7;
            this.Blackdiamond.Text = "Blackdiamond";
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(598, 261);
            this.Controls.Add(this.Blackdiamond);
            this.Controls.Add(this.Bookstoredb);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.Database);
            this.Controls.Add(this.label1);
            this.Name = "EntryForm";
            this.Text = "EntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Database;
        private System.Windows.Forms.Label Server;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Label Bookstoredb;
        private System.Windows.Forms.Label Blackdiamond;
    }
}

