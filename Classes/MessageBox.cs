using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ValidSAT.dialogs;
using ValidSAT.Dialogs;

namespace ValidSAT.Classes
{
    public static class MessageBox
    {

        public enum questionResponse
        {
            Yes = 1,
            No = 0
        }

        public static void showAdvise(string text)
        {
            frmDialog dialog = new frmDialog(text);
            dialog.ShowDialog();
        }

        public static void showAdviseModal(string text)
        {
            frmFullScreen modal = new frmFullScreen();
            frmDialog dialog = new frmDialog(text, modal);
            modal.Show();
            dialog.ShowDialog();
        }

        public static questionResponse showAQuestionModal(string text)
        {
            return questionResponse.Yes;
        }

    }
}
