using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramAdBlocker
{
    public static class HostEdit
    {
        public static void edit(String editInternal, ArrayList urls, frmCore f)
        {
            HostEdit h = new HostEdit();
            if (editInternal == "INTERNAL")
                h.doEditIntern(urls, f);
            else if (editInternal == "WORDPAD")
                h.doEditExtern(f);
        }

        public static void edit(String editInteral, ArrayList urls, String editorPath, frmCore f)
        {
            HostEdit h = new HostEdit();
            if (editInternal == "INTERNAL")
                h.doEditIntern(urls, f);
            else if (editInternal == "WORDPAD")
                h.doEditExtern(f);
            else if (editInternal == "CUSTOM")
                h.doEditCustom(editorPath);
        }
        class HostEdit
        {
            public delegate void openHelperDeleg(frmCore f, frmEditHosts f1);
            private void OpenHelper(frmCore f, frmEditHosts f1)
            {
                if (f.InvokeRequired)
                    f.Invoke(new openHelperDeleg(openHelper), new object[] { f, f1 });
                else
                    f1.ShowDialog(f);
            }
            public String doEditIntern(ArrayList urls, frmCore frm)
            {
                String fileText = "";
                try
                {
                    clsUtilitys.Dialogs.dlgOptions o1 = new clsUtilitys.Dialogs.dlgOptions();
                    o1.frm = (frmCore)frm;
                    o1.txt = "Reading hosts file...";
                    System.Threading.Thread start = new Thread(new ParameterizedThreadStart(clsUtilitys.Dialogs.showDialog));
                    start.Start(o1);

                    String txt = System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("windir") + "\\system32\\drivers\\etc\\hosts");


                    frmEditHosts f = new frmEditHosts();
                    f.mText = txt;
                    if (start != null)
                    {
                        clsUtilitys.Dialogs.closeDialog();
                        start.Abort();
                    }
                    openHelper(frm, f);

                    if (f.DialogResult == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(Environment.GetEnvironmentVariable("windir") + "\\system32\\drivers\\etc\\hosts", f.mText);
                        f.mText = "";
                    }
            }
        }
            catch (Exception) {
                clsUtilitys.Dialogs.dlgOptions o1 = new clsUtilitys.Dialogs.dlgOptions();
            o1.frm = (frmCore) frm;
            o1.txt = "Error reading/writing hosts file.";
                o1.okbutton=true;
                System.Threading.Thread start = new Thread(new ParameterizedThreadStart(clsUtilitys.Dialogs.showDialog));
            start.Start(o1);          
            }
            return fileText;
        }

    public void doEditExtern(frmCore f)
    {
        try
        {
            clsUtilitys.Dialogs.dlgOptions o1 = new clsUtilitys.Dialogs.dlgOptions();
            o1.frm = (frmCore)f;
            o1.txt = "File has been opened in external editor.\nPlease close it to continue.";
            System.Threading.Thread start = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(clsUtilitys.Dialogs.showDialog));
            start.Start(o1);

            System.Diagnostics.Process p = System.Diagnostics.Process.Start("wordpad.exe", Environment.GetEnvironmentVariable("windir") + "\\system32\\drivers\\etc\\hosts");
            p.WaitForExit();

            if (start != null)
            {
                clsUtilitys.Dialogs.closeDialog();
                start.Abort();
            }
        }
        catch (Exception) { MessageBox.Show("Could not open external editor."); }
    }

    public void doEditCustom(String editorPath)
    {
        try
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(editorPath, Environment.GetEnvironmentVariable("windir") + "\\system32\\drivers\\etc\\hosts");
            p.WaitForExit();
        }
        catch (Exception) { MessageBox.Show("Could not open external editor."); }
    }
}
