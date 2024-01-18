namespace Bonusräknare
{
    public partial class userInput : Form
    {
        public userInput()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}