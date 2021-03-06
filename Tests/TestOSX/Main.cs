﻿using System;
using AppKit;
using Foundation;
using SciterSharp;

namespace TestOSX
{
	static class MainClass
	{
		static SciterMessages sm = new SciterMessages();

		static void Main(string[] args)
		{
			NSApplication.Init();

			SciterWindow wnd = new SciterWindow();
			wnd.CreateMainWindow(500, 500);
			wnd.LoadPage("/Users/midiway/Desktop/SciterSharp/Tests/TestOSX/res/index.html");
			wnd.Show();

			NSApplication.Main(args);
		}
	}

	class SciterMessages : SciterDebugOutputHandler
	{
		protected override void OnOutput(SciterSharp.Interop.SciterXDef.OUTPUT_SUBSYTEM subsystem, SciterSharp.Interop.SciterXDef.OUTPUT_SEVERITY severity, string text)
		{
			Console.WriteLine(text);
		}
	}
}