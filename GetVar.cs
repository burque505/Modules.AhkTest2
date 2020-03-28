using System;
using Robin.Core;
using Robin.Core.Attributes;
using System.ComponentModel;
using System.Windows.Forms;
using sharpAHK;

namespace Modules.AhkTest8
{
    [Action(Order = 6)]
    [Throws("ActionError")] // TODO: change error name (or delete if not needed)
    public class GetVar : ActionBase
    {
        [InputArgument]
        public AutoHotkey.Interop.AutoHotkeyEngine AhkEngine { get; set; }

        [InputArgument, DefaultValue("a")]
        public string AhkVariable { get; set; }

        [OutputArgument]
        public string AhkResult { get; set; }

        public override void Execute(ActionContext context)
        {
            try
            {

                var ahk = AhkEngine;
                var backtoRobin = ahk.GetVar(AhkVariable);
                AhkResult = backtoRobin ;
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