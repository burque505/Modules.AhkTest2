using System;
using Robin.Core;
using Robin.Core.Attributes;
using System.Windows.Forms;
using System.ComponentModel;

namespace Modules.AhkTest8
{
    [Action(Order = 3)]
    [Throws("ActionError")] // TODO: change error name (or delete if not needed)
    public class ExecRaw : ActionBase
    {

        [InputArgument]
        public string RawScript { get; set; }


        public override void Execute(ActionContext context)
        {
            try
            {
                    var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
                    ahk.ExecRaw(RawScript);
                    while (ahk.IsReady() == true)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                  
                    ahk.Reset();
                    // MessageBox.Show("Engine finished.");
             }
                catch (Exception e)
            {
                    if (e is ActionException) throw;

                    throw new ActionException("ActionError", e.Message, e.InnerException);
            }
        }

    }
}
