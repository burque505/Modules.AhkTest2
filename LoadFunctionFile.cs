using System;
using Robin.Core;
using Robin.Core.Attributes;
using System.ComponentModel;
using System.Windows.Forms;
using sharpAHK;

namespace Modules.AhkTest8
{ 
    [Action(Order = 8)]
    [Throws("ActionError")] // TODO: change error name (or delete if not needed)
    public class LoadFunctionFile : ActionBase
    {
        [InputArgument]
        public AutoHotkey.Interop.AutoHotkeyEngine AhkEngine { get; set; }
        [InputArgument]
        public string FunctionFileName { get; set; }

        [OutputArgument, DefaultValue("Function file loaded")]
        public string AhkResult { get; set; }

        public override void Execute(ActionContext context)
        {
            try
            {
                var ahk = AhkEngine;
                ahk.LoadFile(FunctionFileName);
                AhkResult = ("Function file loaded successfully.");
            }
            catch (Exception e)
            {
                if (e is ActionException) throw;

                throw new ActionException("ActionError", "File not loaded", e.InnerException);
            }

            // TODO: set values to Output Arguments here
        }

}
}

