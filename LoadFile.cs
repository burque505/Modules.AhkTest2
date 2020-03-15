using System;
using Robin.Core;
using Robin.Core.Attributes;
using System.ComponentModel;
using System.Windows.Forms;
using sharpAHK;

namespace Modules.AhkTest2
{
    [Action(Order = 1, Category = "LoadScriptAndCallFunction")]
    [Throws("ActionError")] // TODO: change error name (or delete if not needed)
    public class LoadFile : ActionBase
    {
        [InputArgument, DefaultValue("ie_com3.ahk")]
        public string ScriptName { get; set; }
        [InputArgument, DefaultValue("StartIE")]
        public string FunctionName { get; set; }
        [OutputArgument, DefaultValue("Script completed successfully.")]
        public string AhkResult { get; set; }

        public override void Execute(ActionContext context)
        {
            try
            {
                var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
                ahk.LoadFile(ScriptName);
                ahk.ExecFunction(FunctionName);
                while (ahk.IsReady() == true)
                {
                    System.Threading.Thread.Sleep(100);
                }
                ahk.Reset();
                MessageBox.Show("Engine finished.");
                AhkResult = ("Finished successfully.");
            }
            catch (Exception e)
            {
                if (e is ActionException) throw;

                throw new ActionException("ActionError", e.Message, e.InnerException);
            }

            // TODO: set values to Output Arguments here
        }

    }
}
