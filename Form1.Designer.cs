namespace PostgresApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox nameTextBox;
        private NumericUpDown ageUpDown;
        private Button insertButton;
        private DataGridView peopleGrid;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            nameTextBox = new TextBox();
            ageUpDown = new NumericUpDown();
            insertButton = new Button();
            peopleGrid = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(ageUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(peopleGrid)).BeginInit();
            SuspendLayout();

            // nameTextBox
            nameTextBox.Location = new Point(30, 30);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 27);
            nameTextBox.PlaceholderText = "Full Name";

            // ageUpDown
            ageUpDown.Location = new Point(250, 30);
            ageUpDown.Name = "ageUpDown";
            ageUpDown.Size = new Size(60, 27);
            ageUpDown.Minimum = 0;
            ageUpDown.Maximum = 120;

            // insertButton
            insertButton.Location = new Point(330, 30);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(100, 27);
            insertButton.Text = "Insert";
            insertButton.Click += InsertButton_Click;

            // peopleGrid
            peopleGrid.Location = new Point(30, 80);
            peopleGrid.Name = "peopleGrid";
            peopleGrid.Size = new Size(740, 300);
            peopleGrid.AllowUserToAddRows = false;
            peopleGrid.AllowUserToDeleteRows = false;
            peopleGrid.ReadOnly = true;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nameTextBox);
            Controls.Add(ageUpDown);
            Controls.Add(insertButton);
            Controls.Add(peopleGrid);
            Name = "Form1";
            Text = "People Manager";
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)(ageUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(peopleGrid)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
