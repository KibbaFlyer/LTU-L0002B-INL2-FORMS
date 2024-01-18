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
            buttonAdd.Location = new Point(348, 21);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(154, 99);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Lägg till";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(348, 144);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(154, 99);
            buttonShow.TabIndex = 5;
            buttonShow.Text = "Visa resultat";
            buttonShow.UseVisualStyleBackColor = true;
            buttonShow.Click += buttonShow_Click;
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
            inputSold.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
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
            ClientSize = new Size(547, 330);
            Controls.Add(label2);
            Controls.Add(inputSold);
            Controls.Add(outputCount);
            Controls.Add(label1);
            Controls.Add(buttonShow);
            Controls.Add(buttonAdd);
            Controls.Add(inputDistrikt);
            Controls.Add(inputPersnr);
            Controls.Add(inputNamn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private Dictionary<Bonusräknare.Person, int> personResultat = new Dictionary<Person, int>();

        // Här har vi en metod som kallas när användaren klickar på knappen "Lägg till"
        private void AddPerson()
        {
            // Vi börjar med att hämta data från infälten
            string name = inputNamn.Text;
            string persnr = inputPersnr.Text;
            string distrikt = inputDistrikt.Text;
            int sold = Convert.ToInt32(inputSold.Value);
            // Vi skapar en ny person
            Person person = new Person();
            // Bool för att hantera error
            bool errorOccurred = false;
            // Nu lägger vi till personen och dess säljresultat till dictionary
            try
            {
                person.AddData(name, persnr, distrikt);
                personResultat.Add(person, sold);
            }
            // Det finns ett exception i klassen "Person" som skickas om inte all indata är ifylld
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                errorOccurred = true;
            }
            // För användarvänlighetens skull återställer vi infält endast om vi lyckades lägga till personen
            // På det viset behöver inte användaren ange fält igen om de råkade missa något
            if (!errorOccurred)
            {
                //Sedan tar vi bort data
                inputNamn.Clear();
                inputPersnr.Clear();
                inputDistrikt.Clear();
                inputSold.Value = 0;
            }
            // Vi ändrar label till antal 
            outputCount.Text = personResultat.Count.ToString();
        }
        // När användaren väljer att visa data triggas denna metod
        // Den öppnar upp ett nytt resultatfönster med dictionary som den har sparat ersoner och säljresultat på
        // Jag har valt att lämna det "smarta" i resultatfönstret logik, så blir koden mer modulär
        private void ShowData()
        {
            resultat resultWindow = new resultat(personResultat);
            resultWindow.ShowDialog();
        }
    }
}