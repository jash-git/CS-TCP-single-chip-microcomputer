namespace V8_command_sample
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.buttAddCard = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.buttDeleteCard = new System.Windows.Forms.Button();
            this.buttSetTime = new System.Windows.Forms.Button();
            this.buttGetRecord = new System.Windows.Forms.Button();
            this.txtrecord = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttConnect
            // 
            this.buttConnect.Location = new System.Drawing.Point(268, 35);
            this.buttConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttConnect.Name = "buttConnect";
            this.buttConnect.Size = new System.Drawing.Size(87, 28);
            this.buttConnect.TabIndex = 0;
            this.buttConnect.Text = "Connect";
            this.buttConnect.UseVisualStyleBackColor = true;
            this.buttConnect.Click += new System.EventHandler(this.buttConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(110, 8);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(146, 23);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "192.168.1.204";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(110, 43);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(146, 23);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "5001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Card Code:";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(110, 82);
            this.txtCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(146, 23);
            this.txtCard.TabIndex = 6;
            this.txtCard.Text = "0123456789ABCDEF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 143);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 23);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "CCCCCCCCCCCCCCCC";
            // 
            // buttAddCard
            // 
            this.buttAddCard.Location = new System.Drawing.Point(268, 103);
            this.buttAddCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttAddCard.Name = "buttAddCard";
            this.buttAddCard.Size = new System.Drawing.Size(87, 28);
            this.buttAddCard.TabIndex = 9;
            this.buttAddCard.Text = "Add card";
            this.buttAddCard.UseVisualStyleBackColor = true;
            this.buttAddCard.Click += new System.EventHandler(this.buttAddCard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "index:";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(110, 114);
            this.txtIndex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(146, 23);
            this.txtIndex.TabIndex = 11;
            this.txtIndex.Text = "0888";
            // 
            // buttDeleteCard
            // 
            this.buttDeleteCard.Location = new System.Drawing.Point(268, 135);
            this.buttDeleteCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttDeleteCard.Name = "buttDeleteCard";
            this.buttDeleteCard.Size = new System.Drawing.Size(87, 28);
            this.buttDeleteCard.TabIndex = 12;
            this.buttDeleteCard.Text = "Delete card";
            this.buttDeleteCard.UseVisualStyleBackColor = true;
            this.buttDeleteCard.Click += new System.EventHandler(this.buttDeleteCard_Click);
            // 
            // buttSetTime
            // 
            this.buttSetTime.Location = new System.Drawing.Point(369, 135);
            this.buttSetTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttSetTime.Name = "buttSetTime";
            this.buttSetTime.Size = new System.Drawing.Size(246, 28);
            this.buttSetTime.TabIndex = 13;
            this.buttSetTime.Text = "Set Time(2020/02/15  08:36:42)";
            this.buttSetTime.UseVisualStyleBackColor = true;
            this.buttSetTime.Click += new System.EventHandler(this.buttSetTime_Click);
            // 
            // buttGetRecord
            // 
            this.buttGetRecord.Location = new System.Drawing.Point(10, 171);
            this.buttGetRecord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttGetRecord.Name = "buttGetRecord";
            this.buttGetRecord.Size = new System.Drawing.Size(87, 28);
            this.buttGetRecord.TabIndex = 14;
            this.buttGetRecord.Text = "Get record";
            this.buttGetRecord.UseVisualStyleBackColor = true;
            this.buttGetRecord.Click += new System.EventHandler(this.buttGetRecord_Click);
            // 
            // txtrecord
            // 
            this.txtrecord.Location = new System.Drawing.Point(10, 206);
            this.txtrecord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtrecord.Name = "txtrecord";
            this.txtrecord.Size = new System.Drawing.Size(1205, 277);
            this.txtrecord.TabIndex = 15;
            this.txtrecord.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 492);
            this.Controls.Add(this.txtrecord);
            this.Controls.Add(this.buttGetRecord);
            this.Controls.Add(this.buttSetTime);
            this.Controls.Add(this.buttDeleteCard);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttAddCard);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttConnect);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "V8 command sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button buttAddCard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Button buttDeleteCard;
        private System.Windows.Forms.Button buttSetTime;
        private System.Windows.Forms.Button buttGetRecord;
        private System.Windows.Forms.RichTextBox txtrecord;
    }
}

