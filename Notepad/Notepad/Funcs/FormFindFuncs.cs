using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.Funcs
{
    public class FormFindFuncs
    {
        public static void DoFind(RichTextBox richTxt, string search, bool down, bool match_case)
        {
            string LastFindWord = search;
            bool LastFindDown = down;
            bool LastFindMatchCase = match_case;

            if (down)
            {
                if (match_case)
                {
                    richTxt.Find(search, richTxt.SelectionStart, RichTextBoxFinds.MatchCase);
                }
                else
                {
                    richTxt.Find(search, richTxt.SelectionStart, RichTextBoxFinds.None);
                }
            }
            else
            {
                if (match_case)
                {
                    richTxt.Find(search, richTxt.SelectionStart, RichTextBoxFinds.MatchCase | RichTextBoxFinds.Reverse);
                }
                else
                {
                    richTxt.Find(search, richTxt.SelectionStart, RichTextBoxFinds.None | RichTextBoxFinds.Reverse);
                }
            }
        }
    }
}
