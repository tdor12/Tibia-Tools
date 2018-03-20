namespace Tibia_Tools
{
    partial class PartyCalculatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartyCalculatorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.supplyCost_TB = new System.Windows.Forms.TextBox();
            this.totalLoot_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalProfit_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dividedProfit_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.calculate_btn = new System.Windows.Forms.Button();
            this.populate_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supply cost for each member (comma delimited):";
            // 
            // supplyCost_TB
            // 
            this.supplyCost_TB.Location = new System.Drawing.Point(252, 26);
            this.supplyCost_TB.Name = "supplyCost_TB";
            this.supplyCost_TB.Size = new System.Drawing.Size(536, 20);
            this.supplyCost_TB.TabIndex = 1;
            this.supplyCost_TB.TextChanged += new System.EventHandler(this.supplyCost_TB_TextChanged);
            // 
            // totalLoot_TB
            // 
            this.totalLoot_TB.Location = new System.Drawing.Point(252, 52);
            this.totalLoot_TB.Name = "totalLoot_TB";
            this.totalLoot_TB.Size = new System.Drawing.Size(536, 20);
            this.totalLoot_TB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total loot:";
            // 
            // totalProfit_TB
            // 
            this.totalProfit_TB.Location = new System.Drawing.Point(252, 78);
            this.totalProfit_TB.Name = "totalProfit_TB";
            this.totalProfit_TB.ReadOnly = true;
            this.totalProfit_TB.Size = new System.Drawing.Size(536, 20);
            this.totalProfit_TB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total calculated profit:";
            // 
            // dividedProfit_TB
            // 
            this.dividedProfit_TB.Location = new System.Drawing.Point(252, 104);
            this.dividedProfit_TB.Name = "dividedProfit_TB";
            this.dividedProfit_TB.ReadOnly = true;
            this.dividedProfit_TB.Size = new System.Drawing.Size(536, 20);
            this.dividedProfit_TB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount for each:";
            // 
            // calculate_btn
            // 
            this.calculate_btn.Location = new System.Drawing.Point(261, 143);
            this.calculate_btn.Name = "calculate_btn";
            this.calculate_btn.Size = new System.Drawing.Size(150, 49);
            this.calculate_btn.TabIndex = 8;
            this.calculate_btn.Text = "Calculate";
            this.calculate_btn.UseVisualStyleBackColor = true;
            this.calculate_btn.Click += new System.EventHandler(this.calculate_btn_Click);
            // 
            // populate_btn
            // 
            this.populate_btn.Location = new System.Drawing.Point(439, 143);
            this.populate_btn.Name = "populate_btn";
            this.populate_btn.Size = new System.Drawing.Size(165, 47);
            this.populate_btn.TabIndex = 9;
            this.populate_btn.Text = "Populate Log Form";
            this.populate_btn.UseVisualStyleBackColor = true;
            this.populate_btn.Click += new System.EventHandler(this.populate_btn_Click);
            // 
            // PartyCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 211);
            this.Controls.Add(this.populate_btn);
            this.Controls.Add(this.calculate_btn);
            this.Controls.Add(this.dividedProfit_TB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalProfit_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalLoot_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.supplyCost_TB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PartyCalculatorForm";
            this.Text = "Party Form";
            this.Load += new System.EventHandler(this.PartyCalculatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox supplyCost_TB;
        private System.Windows.Forms.TextBox totalLoot_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalProfit_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dividedProfit_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button calculate_btn;
        private System.Windows.Forms.Button populate_btn;
    }
}