namespace mohsin
{
    partial class feedback
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
            this.eventidlabel = new System.Windows.Forms.Label();
            this.reviewlabel = new System.Windows.Forms.Label();
            this.sugglabel = new System.Windows.Forms.Label();
            this.eventidtextbox = new System.Windows.Forms.TextBox();
            this.eventreviewstextbox = new System.Windows.Forms.TextBox();
            this.additionalcommentstextbox = new System.Windows.Forms.TextBox();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.submitbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(494, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feedback";
            // 
            // eventidlabel
            // 
            this.eventidlabel.AutoSize = true;
            this.eventidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventidlabel.Location = new System.Drawing.Point(274, 212);
            this.eventidlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eventidlabel.Name = "eventidlabel";
            this.eventidlabel.Size = new System.Drawing.Size(81, 20);
            this.eventidlabel.TabIndex = 1;
            this.eventidlabel.Text = "Event ID";
            // 
            // reviewlabel
            // 
            this.reviewlabel.AutoSize = true;
            this.reviewlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewlabel.Location = new System.Drawing.Point(274, 262);
            this.reviewlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reviewlabel.Name = "reviewlabel";
            this.reviewlabel.Size = new System.Drawing.Size(132, 20);
            this.reviewlabel.TabIndex = 1;
            this.reviewlabel.Text = "Event Reviews";
            // 
            // sugglabel
            // 
            this.sugglabel.AutoSize = true;
            this.sugglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sugglabel.Location = new System.Drawing.Point(274, 326);
            this.sugglabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sugglabel.Name = "sugglabel";
            this.sugglabel.Size = new System.Drawing.Size(456, 20);
            this.sugglabel.TabIndex = 1;
            this.sugglabel.Text = "Additional comments or suggestions for improvement";
            // 
            // eventidtextbox
            // 
            this.eventidtextbox.Location = new System.Drawing.Point(500, 202);
            this.eventidtextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventidtextbox.Name = "eventidtextbox";
            this.eventidtextbox.Size = new System.Drawing.Size(148, 26);
            this.eventidtextbox.TabIndex = 3;
            // 
            // eventreviewstextbox
            // 
            this.eventreviewstextbox.Location = new System.Drawing.Point(498, 262);
            this.eventreviewstextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventreviewstextbox.Multiline = true;
            this.eventreviewstextbox.Name = "eventreviewstextbox";
            this.eventreviewstextbox.Size = new System.Drawing.Size(440, 58);
            this.eventreviewstextbox.TabIndex = 4;
            // 
            // additionalcommentstextbox
            // 
            this.additionalcommentstextbox.Location = new System.Drawing.Point(500, 375);
            this.additionalcommentstextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.additionalcommentstextbox.Multiline = true;
            this.additionalcommentstextbox.Name = "additionalcommentstextbox";
            this.additionalcommentstextbox.Size = new System.Drawing.Size(480, 126);
            this.additionalcommentstextbox.TabIndex = 5;
            // 
            // cancelbutton
            // 
            this.cancelbutton.BackColor = System.Drawing.Color.IndianRed;
            this.cancelbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbutton.Location = new System.Drawing.Point(382, 594);
            this.cancelbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(112, 38);
            this.cancelbutton.TabIndex = 6;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // submitbutton
            // 
            this.submitbutton.BackColor = System.Drawing.Color.IndianRed;
            this.submitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submitbutton.Location = new System.Drawing.Point(603, 594);
            this.submitbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitbutton.Name = "submitbutton";
            this.submitbutton.Size = new System.Drawing.Size(112, 38);
            this.submitbutton.TabIndex = 7;
            this.submitbutton.Text = "Submit";
            this.submitbutton.UseVisualStyleBackColor = false;
            this.submitbutton.Click += new System.EventHandler(this.submitbutton_Click);
            // 
            // feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.submitbutton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.additionalcommentstextbox);
            this.Controls.Add(this.eventreviewstextbox);
            this.Controls.Add(this.eventidtextbox);
            this.Controls.Add(this.sugglabel);
            this.Controls.Add(this.reviewlabel);
            this.Controls.Add(this.eventidlabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "feedback";
            this.Text = "feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label eventidlabel;
        private System.Windows.Forms.Label reviewlabel;
        private System.Windows.Forms.Label sugglabel;
        private System.Windows.Forms.TextBox eventidtextbox;
        private System.Windows.Forms.TextBox eventreviewstextbox;
        private System.Windows.Forms.TextBox additionalcommentstextbox;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button submitbutton;
    }
}