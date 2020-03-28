using System;
using Robin.Core;
using Robin.Core.Attributes;

namespace Modules.AhkTest8
{
    [Action(Order = 4)]
    [Throws("ActionError")] // TODO: change error name (or delete if not needed)
    public class CreateAutoHotkeyEngine : ActionBase
    {
        #region Properties

        [OutputArgument]
        public AutoHotkey.Interop.AutoHotkeyEngine AhkEngine { get; set; }

        #endregion

        #region Methods Overrides

        public override void Execute(ActionContext context)
        {
            try
            {
                var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
                AhkEngine = ahk;
            }
            catch (Exception e)
            {
                throw new ActionException("ActionError", e.Message, e.InnerException); // TODO: change error name (or delete if not needed)
            }

            // TODO: set values to Output Arguments here
            // OutputArgument1 = ...
        }

        #endregion
    }
}
