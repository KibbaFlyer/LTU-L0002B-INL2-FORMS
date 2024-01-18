using System.IO.Pipes;

namespace Bonusräknare
{
    partial class userInput
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputNamn = new TextBox();
            inputPersnr = new TextBox();
            inputDistrikt = new TextBox();
            buttonAdd = new Button();
            buttonShow = new Button();
            label1 = new Label();
            outputCount = new Label();
            inputSold = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)inputSold).BeginInit();
            SuspendLayout();
            // 
            // inputNamn
            // 
            inputNamn.Location = new Point(24, 21);
            inputNamn.Name = "inputNamn";
            inputNamn.PlaceholderText = "Namn";
            inputNamn.Size = new Size(266, 39);
            inputNamn.TabIndex = 0;
            // 
            // inputPersnr
            // 
            inputPersnr.Location = new Point(24, 111);
            inputPersnr.Name = "inputPersnr";
            inputPersnr.PlaceholderText = "Personnummer";
            inputPersnr.Size = new Size(266, 39);
            inputPersnr.TabIndex = 1;
            // 
            // inputDistrikt
            // 
            inputDistrikt.Location = new Point(24, 66);
            inputDistrikt.Name = "inputDistrikt";
            inputDistrikt.PlaceholderText = "Distrikt";
            inputDistrikt.Size = new Size(266, 39);
            inputDistrikt.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(322, 21);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(154, 99);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Lägg till";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(322, 144);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(154, 99);
            buttonShow.TabIndex = 5;
            buttonShow.Text = "Visa resultat";
            buttonShow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 273);
            label1.Name = "label1";
            label1.Size = new Size(318, 32);
            label1.TabIndex = 6;
            label1.Text = "Antal registrerade försälljare:";
            // 
            // outputCount
            // 
            outputCount.AutoSize = true;
            outputCount.Location = new Point(348, 273);
            outputCount.Name = "outputCount";
            outputCount.Size = new Size(27, 32);
            outputCount.TabIndex = 7;
            outputCount.Text = "0";
            // 
            // inputSold
            // 
            inputSold.Location = new Point(24, 204);
            inputSold.Name = "inputSold";
            inputSold.Size = new Size(266, 39);
            inputSold.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 169);
            label2.Name = "label2";
            label2.Size = new Size(209, 32);
            label2.TabIndex = 9;
            label2.Text = "Antal sålda artiklar";
            // 
            // userInput
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 330);
            Controls.Add(label2);
            Controls.Add(inputSold);
            Controls.Add(outputCount);
            Controls.Add(label1);
            Controls.Add(buttonShow);
            Controls.Add(buttonAdd);
            Controls.Add(inputDistrikt);
            Controls.Add(inputPersnr);
            Controls.Add(inputNamn);
            Name = "userInput";
            Text = "Bonusberäknare";
            ((System.ComponentModel.ISupportInitialize)inputSold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputNamn;
        private TextBox inputPersnr;
        private TextBox inputDistrikt;
        private Button buttonAdd;
        private Button buttonShow;
        private Label label1;
        private Label outputCount;
        private NumericUpDown inputSold;
        private Label label2;
        private Dictionary<Bonusräknare.Person, int> personResultat;

        private void AddPerson()
        {
            string name = inputNamn.Text;
            string persnr = inputPersnr.Text;
            string distrikt = inputDistrikt.Text;
            int sold = Convert.ToInt16(inputSold.Value);
            // Vi skapar en ny person och ger den data
            Person person = new Person();
            person.AddData(name, persnr, distrikt);
            // Nu lägger vi till personen och dess säljresultat till dictionary
            personResultat.Add(person, sold);
        }
        private void ShowData()
        {
            resultat resultWindow = new resultat();
            resultWindow.ShowDialog();
        }


    }
}