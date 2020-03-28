using System;
using Robin.Core;
using Robin.Core.Attributes;

namespace Modules.AhkTest8
{
    [Action(Order = 7)]
    [Throws("ActionError")] // TODO: change error name (or delete if not needed)
    public class ExecRawInstant : ActionBase
    {
        [InputArgument]
        public AutoHotkey.Interop.AutoHotkeyEngine AhkEngine { get; set; }

        [InputArgument]
        public string RawScript { get; set; }


        public override void Execute(ActionContext context)
        {
            try
            {
                var ahk = AhkEngine;
                ahk.ExecRaw(RawScript);
            }
            catch (Exception e)
            {
                if (e is ActionException) throw;

                throw new ActionException("ActionError", e.Message, e.InnerException);
            }
        }

    }
}
