using System;
using System.Windows.Forms;

namespace SpecialCalculator
{
    public partial class Form1 : Form
    {

        public string mainInput
        {
            get { return txtInput.Text; }
        }
        public Form1()
        {
            InitializeComponent();




        }

        // while user types new expression, output clear


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //if (!MyValidators.IsInputNonNull(txtInput.Text))
            if (string.IsNullOrWhiteSpace(mainInput))
            {
                MessageBox.Show("Please insert a expression");
                return;
            }
            try
            {

                double answer = Calculating.ParseAndSolve(mainInput);
                txtOutput.Text = Convert.ToString(answer);

                MyUtility.HistorySave(mainInput, answer);
                lblHistory.Text = MyUtility.HistoryShow();
                lblCurrentExpression.Text = mainInput;

                txtInput.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check your input", "Math Error");
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            UniversalSetting.getReadyLabels(lblHistory, lblCurrentExpression);
            UniversalSetting.ApplyBtnFeatures(btnCalculate);
        }

        private void txtInput_TextChanged_1(object sender, EventArgs e)
        {
            if (txtInput.Text.Length == 1)
            {
                txtOutput.Clear();
                lblCurrentExpression.Text = string.Empty;
            }
        }
    }
}
