# Modules.AhkTest2
AutoHotkey module for Robin RPA Language

This project is an AutoHotkey module for [Robin](https://robin-language.org). It uses the Robin VSIX introduced with V.0.93.

Build the project in VS 2019 (VS 2017 not tested) with Release configuration. You may have to manage NuGet packages for the project, installing When built, copy the DLL you built
[sharpAHK_505](https://www.nuget.org/packages/sharpAHK_505/). This a very slightly modified version of [LucidMethod's great package](https://www.nuget.org/packages/sharpAHK/),
adding only an IsReady() function, which comes in quite handy and is sometimes indispensable, as in the 'ExecRaw' action of this project. 
Review the code for its use.

N.B.: Both sharpAHK and this project owe their existence to [AutoHotkey.Interop](https://github.com/amazing-andrew/AutoHotkey.Interop). View that page for many examples that can be easily converted to use with Robin.

N.B.: This project is still *a work in progress.* AutoHotkeyEngine functions remaining to be implemented as Robin Actions:
* Eval(string)
* ExecLabel(string)
* GetVar(string) 	*Done*
* InitializePipesModule
* LoadFile	 	*Done* Creates AutoHotkeyEngine, loads script, calls function. Specialized use.
* LoadEngineAndFile	*Done* Requires existing AutoHotkeyEngine, loads script, calls function. Specialized use.
* LoadFunctionFile  	*Done* Requires CreateAutoHotkeyEngine; creating function file must be done with care.
* SetVar		*Done* Requires loaded AutoHotkeyEngine. Sets variable in AHK.
* ExecRawInstant 	*Done* Requires CreateAutoHotkeyEngine; no 'IsReady' functionality. Use for one-shot scripts (not GUIS).
* ExecFunction		*Done* Requires CreateAutoHotkeyEngine and LoadFunctionFile. Up to 10 arguments to function, optional return
* GetVar		*Done* Requires loaded AutoHotkeyEngine. Gets variable from AHK.

Some or all of these *may* be implemented as Actions. Whether they are Actions are not, they are available from the sharpAHK DLL, so they may be used.

N.B.: Many names have been changed.

*Example Robin Code for the ExecRaw action*
With this action you can write your AutoHotkey code directly in the Robin script if you like.

```
set ScriptFile to """
Gui, Add, Edit, w400 h400 vMyEdit, Edit this text to see what happens.
Gui, Add, Button, xp y+5 Default, &ClickMe
Gui, Show, , Ahk Test
return

GuiClose:
Escape::
ExitApp

ButtonClickMe:
Gui, Submit, NoHide
msgbox, 0, Message to Robin, %MyEdit%, 2
ControlSetText, Edit1
ControlSetText, Edit1, Okay`, very good! Try again.
Sleep, 2000
ControlSetText, Edit1
Gui, Submit, NoHide
ControlClick, Edit1
return
"""

Ahk.ExecRaw RawScript: ScriptFile
```
*Example Robin code using the 'LoadScriptAndCallFunction' action*
AutoHotkey scripts must be custom tailored to be called by C# that most RPA platforms (and Robin) use. 
Adjust paths to suit.
(A sample AutoHotkey script appears below the Robin code.)

```
Ahk.LoadFile \
    FunctionName:'StartIE' \
    ScriptName:'C:\work\RobinTests\ie_com3.ahk' \
    AhkResult=> AhkResult

Console.Write Message: AhkResult
```
The script 'ie_com.ahk' is below.
The strange syntax is required make the whole thing work.
'SetTimer' is employed to create a [pseudo-thread](https://www.autohotkey.com/boards/viewtopic.php?f=76&t=10188&p=56558&hilit=pseudo+thread#p56558).

```
#Persistent
; Begin autoexecute section
StartIE()
return
; End autoexecute section
StartIE()
{
	SetTimer, myLabel, -0 ; 'psuedo-thread'
}

myLabel:
wb := ComObjCreate("InternetExplorer.Application")
wb.Visible := True
wb.Navigate("Google.com")
SetTimer ; calling SetTimer with no argument turns it off.
ExitApp

```
MIT license. Thanks for looking.

Best regards,
burque505








