using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SpecialCalculator.Constant;

namespace SpecialCalculator
{
    /// <summary>
    /// for initial color of form, buttons
    /// font of labels and similar setting
    /// </summary>
    static class UniversalSetting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        public static void ApplyBtnFeatures(Button btn)
        {
            // btn.BackColor = Color.YellowGreen;
            btn.BackColor = Color.GreenYellow;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="lbl2"></param>
        public static void getReadyLabels(Label lbl, Label lbl2)
        {
            lbl.Text = string.Empty;
            lbl2.Text = string.Empty;
            // lbl2.Text = "";
        }

        /// <summary>
        /// this code creates a file to save each calculation
        /// for display that in new line in history part
        /// </summary>
        public static void CreateFile()
        {
            File.Create(historyFileName).Close();
        }
    }
}
