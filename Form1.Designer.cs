namespace Snort
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            labelDifficulty = new Label();
            comboDifficulty = new ComboBox();
            buttonNewGame = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(232, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 400);
            panel1.TabIndex = 0;
            // 
            // labelDifficulty
            // 
            labelDifficulty.AutoSize = true;
            labelDifficulty.Location = new Point(30, 83);
            labelDifficulty.Name = "labelDifficulty";
            labelDifficulty.Size = new Size(66, 15);
            labelDifficulty.TabIndex = 1;
            labelDifficulty.Text = "Складність";
            // 
            // comboDifficulty
            // 
            comboDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDifficulty.Items.AddRange(new object[] { "Легкий", "Середній", "Складний" });
            comboDifficulty.Location = new Point(30, 105);
            comboDifficulty.Name = "comboDifficulty";
            comboDifficulty.Size = new Size(160, 23);
            comboDifficulty.TabIndex = 2;
            comboDifficulty.SelectedIndex = 1;
            comboDifficulty.SelectedIndexChanged += comboDifficulty_SelectedIndexChanged;
            // 
            // buttonNewGame
            // 
            buttonNewGame.Location = new Point(30, 150);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(160, 35);
            buttonNewGame.TabIndex = 3;
            buttonNewGame.Text = "Нова гра";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += buttonNewGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 570);
            Controls.Add(buttonNewGame);
            Controls.Add(comboDifficulty);
            Controls.Add(labelDifficulty);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Snort";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label labelDifficulty;
        private ComboBox comboDifficulty;
        private Button buttonNewGame;
    }
}