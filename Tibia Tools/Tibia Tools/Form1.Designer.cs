namespace Tibia_Tools
{
    partial class HuntLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuntLogForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.name_TB = new System.Windows.Forms.TextBox();
            this.date_TB = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.desc_TB = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.duration_TB = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.profit_TB = new System.Windows.Forms.TextBox();
            this.profitLabel = new System.Windows.Forms.Label();
            this.exp_TB = new System.Windows.Forms.TextBox();
            this.expLabel = new System.Windows.Forms.Label();
            this.party_TB = new System.Windows.Forms.TextBox();
            this.partyLabel = new System.Windows.Forms.Label();
            this.addHunt_Btn = new System.Windows.Forms.Button();
            this.type_CB = new System.Windows.Forms.ComboBox();
            this.partyBtn = new System.Windows.Forms.Button();
            this.generate_btn = new System.Windows.Forms.Button();
            this.level_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(77, 16);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Hunt Name:";
            // 
            // name_TB
            // 
            this.name_TB.HideSelection = false;
            this.name_TB.Location = new System.Drawing.Point(115, 7);
            this.name_TB.Name = "name_TB";
            this.name_TB.Size = new System.Drawing.Size(310, 26);
            this.name_TB.TabIndex = 1;
            // 
            // date_TB
            // 
            this.date_TB.Location = new System.Drawing.Point(115, 39);
            this.date_TB.Name = "date_TB";
            this.date_TB.Size = new System.Drawing.Size(310, 26);
            this.date_TB.TabIndex = 3;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 41);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(39, 16);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date:";
            // 
            // desc_TB
            // 
            this.desc_TB.Location = new System.Drawing.Point(115, 71);
            this.desc_TB.Name = "desc_TB";
            this.desc_TB.Size = new System.Drawing.Size(310, 26);
            this.desc_TB.TabIndex = 5;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(12, 73);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(77, 16);
            this.descLabel.TabIndex = 4;
            this.descLabel.Text = "Description:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(12, 105);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(41, 16);
            this.typeLabel.TabIndex = 6;
            this.typeLabel.Text = "Type:";
            // 
            // duration_TB
            // 
            this.duration_TB.Location = new System.Drawing.Point(115, 135);
            this.duration_TB.Name = "duration_TB";
            this.duration_TB.Size = new System.Drawing.Size(310, 26);
            this.duration_TB.TabIndex = 9;
            this.duration_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.duration_TB_KeyPress);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(12, 137);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(61, 16);
            this.durationLabel.TabIndex = 8;
            this.durationLabel.Text = "Duration:";
            // 
            // profit_TB
            // 
            this.profit_TB.Location = new System.Drawing.Point(115, 167);
            this.profit_TB.Name = "profit_TB";
            this.profit_TB.Size = new System.Drawing.Size(310, 26);
            this.profit_TB.TabIndex = 11;
            this.profit_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.profit_TB_KeyPress);
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Location = new System.Drawing.Point(12, 169);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(46, 16);
            this.profitLabel.TabIndex = 10;
            this.profitLabel.Text = "Profit: ";
            // 
            // exp_TB
            // 
            this.exp_TB.Location = new System.Drawing.Point(115, 199);
            this.exp_TB.Name = "exp_TB";
            this.exp_TB.Size = new System.Drawing.Size(310, 26);
            this.exp_TB.TabIndex = 13;
            this.exp_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.exp_TB_KeyPress);
            // 
            // expLabel
            // 
            this.expLabel.AutoSize = true;
            this.expLabel.Location = new System.Drawing.Point(12, 201);
            this.expLabel.Name = "expLabel";
            this.expLabel.Size = new System.Drawing.Size(34, 16);
            this.expLabel.TabIndex = 12;
            this.expLabel.Text = "EXP:";
            // 
            // party_TB
            // 
            this.party_TB.Location = new System.Drawing.Point(115, 231);
            this.party_TB.Name = "party_TB";
            this.party_TB.Size = new System.Drawing.Size(310, 26);
            this.party_TB.TabIndex = 15;
            // 
            // partyLabel
            // 
            this.partyLabel.AutoSize = true;
            this.partyLabel.Location = new System.Drawing.Point(12, 233);
            this.partyLabel.Name = "partyLabel";
            this.partyLabel.Size = new System.Drawing.Size(99, 16);
            this.partyLabel.TabIndex = 14;
            this.partyLabel.Text = "Party Members:";
            // 
            // addHunt_Btn
            // 
            this.addHunt_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addHunt_Btn.Location = new System.Drawing.Point(15, 313);
            this.addHunt_Btn.Name = "addHunt_Btn";
            this.addHunt_Btn.Size = new System.Drawing.Size(132, 55);
            this.addHunt_Btn.TabIndex = 18;
            this.addHunt_Btn.Text = "Add Hunt";
            this.addHunt_Btn.UseVisualStyleBackColor = true;
            this.addHunt_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // type_CB
            // 
            this.type_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_CB.FormattingEnabled = true;
            this.type_CB.Items.AddRange(new object[] {
            "Solo",
            "Duo",
            "Trio",
            "Quad"});
            this.type_CB.Location = new System.Drawing.Point(115, 101);
            this.type_CB.Name = "type_CB";
            this.type_CB.Size = new System.Drawing.Size(310, 24);
            this.type_CB.TabIndex = 17;
            // 
            // partyBtn
            // 
            this.partyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.partyBtn.Location = new System.Drawing.Point(290, 313);
            this.partyBtn.Name = "partyBtn";
            this.partyBtn.Size = new System.Drawing.Size(135, 55);
            this.partyBtn.TabIndex = 19;
            this.partyBtn.Text = "Party Profit Calculator";
            this.partyBtn.UseVisualStyleBackColor = true;
            this.partyBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // generate_btn
            // 
            this.generate_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generate_btn.Location = new System.Drawing.Point(153, 313);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(127, 55);
            this.generate_btn.TabIndex = 21;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // level_TB
            // 
            this.level_TB.Location = new System.Drawing.Point(115, 263);
            this.level_TB.Name = "level_TB";
            this.level_TB.Size = new System.Drawing.Size(310, 26);
            this.level_TB.TabIndex = 16;
            this.level_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.level_TB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Level:";
            // 
            // HuntLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 379);
            this.Controls.Add(this.level_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generate_btn);
            this.Controls.Add(this.partyBtn);
            this.Controls.Add(this.type_CB);
            this.Controls.Add(this.addHunt_Btn);
            this.Controls.Add(this.party_TB);
            this.Controls.Add(this.partyLabel);
            this.Controls.Add(this.exp_TB);
            this.Controls.Add(this.expLabel);
            this.Controls.Add(this.profit_TB);
            this.Controls.Add(this.profitLabel);
            this.Controls.Add(this.duration_TB);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.desc_TB);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.date_TB);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.name_TB);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HuntLogForm";
            this.Text = "Tibia Tools: Hunt Log";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox name_TB;
        private System.Windows.Forms.TextBox date_TB;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox desc_TB;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox duration_TB;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.TextBox profit_TB;
        private System.Windows.Forms.Label profitLabel;
        private System.Windows.Forms.TextBox exp_TB;
        private System.Windows.Forms.Label expLabel;
        private System.Windows.Forms.TextBox party_TB;
        private System.Windows.Forms.Label partyLabel;
        private System.Windows.Forms.Button addHunt_Btn;
        private System.Windows.Forms.ComboBox type_CB;
        private System.Windows.Forms.Button partyBtn;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.TextBox level_TB;
        private System.Windows.Forms.Label label2;
    }
}

