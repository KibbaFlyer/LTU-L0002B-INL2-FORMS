using System.IO;
using static System.Windows.Forms.ListView;

namespace Bonusräknare
{
    partial class resultat
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
            outputListView = new ListView();
            label1 = new Label();
            outputNivå1 = new Label();
            outputNivå2 = new Label();
            label3 = new Label();
            outputNivå3 = new Label();
            label5 = new Label();
            outputNivå4 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // outputListView
            // 
            outputListView.Location = new Point(12, 12);
            outputListView.Name = "outputListView";
            outputListView.Size = new Size(624, 474);
            outputListView.TabIndex = 0;
            outputListView.UseCompatibleStateImageBehavior = false;
            outputListView.View = View.Details;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(658, 24);
            label1.Name = "label1";
            label1.Size = new Size(232, 32);
            label1.TabIndex = 1;
            label1.Text = "Antal säljare i nivå 1:";
            // 
            // outputNivå1
            // 
            outputNivå1.AutoSize = true;
            outputNivå1.Location = new Point(896, 24);
            outputNivå1.Name = "outputNivå1";
            outputNivå1.Size = new Size(27, 32);
            outputNivå1.TabIndex = 2;
            outputNivå1.Text = "0";
            // 
            // outputNivå2
            // 
            outputNivå2.AutoSize = true;
            outputNivå2.Location = new Point(896, 71);
            outputNivå2.Name = "outputNivå2";
            outputNivå2.Size = new Size(27, 32);
            outputNivå2.TabIndex = 4;
            outputNivå2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(658, 71);
            label3.Name = "label3";
            label3.Size = new Size(232, 32);
            label3.TabIndex = 3;
            label3.Text = "Antal säljare i nivå 2:";
            // 
            // outputNivå3
            // 
            outputNivå3.AutoSize = true;
            outputNivå3.Location = new Point(896, 120);
            outputNivå3.Name = "outputNivå3";
            outputNivå3.Size = new Size(27, 32);
            outputNivå3.TabIndex = 6;
            outputNivå3.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(658, 120);
            label5.Name = "label5";
            label5.Size = new Size(232, 32);
            label5.TabIndex = 5;
            label5.Text = "Antal säljare i nivå 3:";
            // 
            // outputNivå4
            // 
            outputNivå4.AutoSize = true;
            outputNivå4.Location = new Point(896, 168);
            outputNivå4.Name = "outputNivå4";
            outputNivå4.Size = new Size(27, 32);
            outputNivå4.TabIndex = 8;
            outputNivå4.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(658, 168);
            label7.Name = "label7";
            label7.Size = new Size(232, 32);
            label7.TabIndex = 7;
            label7.Text = "Antal säljare i nivå 4:";
            // 
            // resultat
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 498);
            Controls.Add(outputNivå4);
            Controls.Add(label7);
            Controls.Add(outputNivå3);
            Controls.Add(label5);
            Controls.Add(outputNivå2);
            Controls.Add(label3);
            Controls.Add(outputNivå1);
            Controls.Add(label1);
            Controls.Add(outputListView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "resultat";
            Text = "Resultat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Dictionary här är den datan vi kommer att populera i listvyn i fönstret
        private Dictionary<Person, int> personData;
        private ListView outputListView;
        private Label label1;
        private Label outputNivå1;
        private Label outputNivå2;
        private Label label3;
        private Label outputNivå3;
        private Label label5;
        private Label outputNivå4;
        private Label label7;

        public resultat(Dictionary<Person, int> initData)
        {
            // Vi initialiserar fönstret med data från användare
            InitializeComponent();
            personData = initData;
            // Nu kallar vi metod som populerar data i fönstret
            InitializeListView();
        }
        private void InitializeListView()
        {
            // Vi börjar med att nollställa tidigare data (för säkerhetsskull)
            outputListView.Items.Clear();
            outputListView.Columns.Clear();
            outputListView.Groups.Clear();
            // Sedan lägger vi till kolumner i vår data
            outputListView.Columns.Add("Namn");
            outputListView.Columns.Add("Personnummer");
            outputListView.Columns.Add("Distrikt");
            outputListView.Columns.Add("Antal");
            // Vi skapar grupper
            outputListView.Groups.Add(new ListViewGroup("Säljgrupp 1"));
            outputListView.Groups.Add(new ListViewGroup("Säljgrupp 2"));
            outputListView.Groups.Add(new ListViewGroup("Säljgrupp 3"));
            outputListView.Groups.Add(new ListViewGroup("Säljgrupp 4"));
            // För varje inlägg i vår dictionary lägger vi till raden till vår listView
            foreach (var rad in personData)
            {
                // Här sätter vi varje kolunvärde för fönstret
                ListViewItem item = new ListViewItem(rad.Key.Namn);
                item.SubItems.Add(rad.Key.Persnr);
                item.SubItems.Add(rad.Key.Distrikt);
                item.SubItems.Add(Convert.ToString(rad.Value));
                // Här lägger vi till raden till fönstret
                outputListView.Items.Add(item);
                // Vi delar antalet sålda varor på 50 för att hitta viljen säljgrupp personen tillhör
                double calculateGroup = rad.Value / 50.0;
                // Låt oss testa vilken grupp personen tillhör och sedan lägga in den i den
                if (calculateGroup < 1.0)
                {
                    item.Group = outputListView.Groups[0];
                }
                else if (calculateGroup < 2.0)
                {
                    item.Group = outputListView.Groups[1];
                }
                else if (calculateGroup < 4.0)
                {
                    item.Group = outputListView.Groups[2];
                }
                else
                {
                    item.Group = outputListView.Groups[3];
                }
            }
            // Vi räknar ut antalet per grupp och sätter det till labels
            outputNivå1.Text = Convert.ToString(outputListView.Groups[0].Items.Count);
            outputNivå2.Text = Convert.ToString(outputListView.Groups[1].Items.Count);
            outputNivå3.Text = Convert.ToString(outputListView.Groups[2].Items.Count);
            outputNivå4.Text = Convert.ToString(outputListView.Groups[3].Items.Count);
            // Vi automatsätter kolumn-bredd
            foreach (ColumnHeader column in outputListView.Columns)
            {
                // Först sätter vi kolumnbredd till header
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                // Sedan hittar vi bredden för texten
                int contentWidth = TextRenderer.MeasureText(column.Text, outputListView.Font).Width;
                // Sedan hämtar vi kolumnbredden (som nu är header-bredd)
                int headerWidth = column.Width;
                // Vi sätter bredden till det största värdet
                column.Width = Math.Max(headerWidth, contentWidth);
            }
            // Här öppnar vi en inputlåda för filnamn
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ange filnamn för den export som skapas över säljresultat",
                       "Filnamn",
                       "Ange filnamn",
                       0,
                       0);
            // Nu initialiserar vi output-strängen till filen
            List<string> output = new List<string>();
            // Vi lägger till kolumnnamn
            output.Add("Namn" + "\t" + "Personnummer".PadLeft(16) + "\t" + "Distrikt".PadLeft(16) + "\t" + "Antal".PadLeft(16));
            // För varje grupp
            foreach (ListViewGroup group in outputListView.Groups)
            {
                // Vi skapar här förklaringstext beroende på vilken grupp det är
                string extraText;
                if (outputListView.Groups.IndexOf(group) == 0)
                {
                    extraText = ": 0-49 artiklar";
                }
                else if (outputListView.Groups.IndexOf(group) == 1)
                {
                    extraText = ": 50-99 artiklar";
                }
                else if (outputListView.Groups.IndexOf(group) == 2)
                {
                    extraText = ": 100-199 artiklar";
                }
                else
                {
                    extraText = ": över 199 artiklar";
                }
                // För varje item i gruppen lägger vi här till rader i output-strängen
                foreach (ListViewItem item in group.Items)
                {
                    string namn = item.SubItems[0].Text;
                    string persnr = item.SubItems[1].Text;
                    string distrikt = item.SubItems[2].Text;
                    string antal = item.SubItems[3].Text;

                    output.Add(namn + "\t" + persnr.PadLeft(16) + "\t" + distrikt.PadLeft(16) + "\t" + antal.PadLeft(16));
                }
                // Vi avslutar genom att beräkna antalet i gruppen och lägger i slutet till en summeringsrad
                int antalIGrupp = group.Items.Count;
                output.Add(antalIGrupp + " säljare har nått nivå "+ outputListView.Groups.IndexOf(group)+extraText+ "\n");

            }
            // Dags att skriva allt till filen.
            File.WriteAllText(input+".txt", string.Join(Environment.NewLine, output));

        }
    }
}