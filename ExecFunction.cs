using System;
using Robin.Core;
using Robin.Core.Attributes;
using System.ComponentModel;
using System.Windows.Forms;
using sharpAHK;

namespace Modules.AhkTest8
{
    [Action(Order = 9)]
    [Throws("ExecFunctionError")] // TODO: change error name (or delete if not needed)
    public class ExecFunction : ActionBase
    {
        #region Properties
        [InputArgument]
        public AutoHotkey.Interop.AutoHotkeyEngine AhkEngine { get; set; }
        [InputArgument, DefaultValue("")]
        public string FunctionName { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg01 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg02 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg03 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg04 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg05 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg06 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg07 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg08 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg09 { get; set; }

        [InputArgument, DefaultValue("")]
        public string Arg10 { get; set; }

        [OutputArgument]
        public string FunctionReturn { get; set; }

        #endregion

        #region Methods Overrides

        public override void Execute(ActionContext context)
        {
            try
            {
                AutoHotkey.Interop.AutoHotkeyEngine ahk = AhkEngine;
                FunctionReturn = ahk.ExecFunction(FunctionName, Arg01, Arg02, Arg03, Arg04, Arg05, Arg06, Arg07, Arg08, Arg09, Arg10);
                if (FunctionReturn == null || FunctionReturn == "") FunctionReturn = "No return value";
            }
            catch (Exception e)
            {
                if (e is ActionException) throw;

                throw new ActionException("ExecFunctionError", "Error calling function", e.InnerException);
            }

            // TODO: set values to Output Arguments here
        }

        #endregion
    }
}
