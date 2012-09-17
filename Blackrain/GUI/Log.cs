using System;
using System.Drawing;
using System.Windows.Forms;
using BlackRain.Common;

namespace BlackRain.GUI
{
    /// <summary>
    /// A generic UI item used to display logs.
    /// </summary>
    public partial class Log : Form
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public Log()
        {
            InitializeComponent();

            Logging.OnWrite += Logging_OnWrite;
        }

        void Logging_OnWrite(string message, Color col)
        {
            AppendMessage(textLog, message, col);
        }

        /// <summary>
        /// Writes a message to the specified RichTextBox.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="message">The <see cref="string">message</see> to be written.</param>
        /// <param name="col"></param>
        private static void AppendMessage(RichTextBox textBox, string message, Color col)
        {
            try
            {
                if (!textBox.IsDisposed)
                {
                    if (textBox.InvokeRequired)
                    {
                        textBox.Invoke(new Action<RichTextBox, string, Color>(AppendMessage), textBox, message, col);
                        return;
                    }

                    Color oldColor = textBox.SelectionColor;
                    textBox.SelectionColor = col;
                    textBox.AppendText(message);
                    textBox.SelectionColor = oldColor;
                    textBox.AppendText(Environment.NewLine);
                    textBox.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }
    }
}
