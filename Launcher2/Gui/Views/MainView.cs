﻿// ClassicalSharp copyright 2014-2016 UnknownShadow200 | Licensed under MIT
using System;
using System.Drawing;
using ClassicalSharp;
using Launcher.Gui.Widgets;

namespace Launcher.Gui.Views {
	public sealed class MainView : IView {
		
		internal int loginIndex, resIndex, dcIndex, spIndex, statusIndex, usernameIndex;
		internal int sslIndex, settingsIndex;
		const int buttonWidth = 220, buttonHeight = 35, sideButtonWidth = 150;
		
		public MainView(LauncherWindow game) : base(game) {
			widgets = new Widget[11];
		}
		
		public override void Init() {
			titleFont = new Font(game.FontName, 16, FontStyle.Bold);
			textFont = new Font(game.FontName, 14, FontStyle.Regular);
			inputHintFont = new Font(game.FontName, 12, FontStyle.Italic);
			MakeWidgets();
		}
		
		string Get(int index) {
			Widget widget = widgets[index];
			return widget == null ? "" : widget.Text;
		}

		
		internal string updateText = "&eChecking..";
		protected override void MakeWidgets() {
			widgetIndex = 0;
			usernameIndex = widgetIndex;
			MakeInput(Get(0), 280, false, 16, "&gUsername..")
				.SetLocation(Anchor.Centre, Anchor.Centre, 0, -120);
			MakeInput(Get(1), 280, true, 64, "&gPassword..")
				.SetLocation(Anchor.Centre, Anchor.Centre, 0, -75);
			
			loginIndex = widgetIndex;
			Makers.Button(this, "Sign in", 100, buttonHeight, titleFont)
				.SetLocation(Anchor.Centre, Anchor.Centre, -90, -25);
			statusIndex = widgetIndex;
			Makers.Label(this, Get(statusIndex), textFont)
				.SetLocation(Anchor.Centre, Anchor.Centre, 0, 20);
			
			
			resIndex = widgetIndex;
			Makers.Button(this, "Resume", 100, buttonHeight, titleFont)
				.SetLocation(Anchor.Centre, Anchor.Centre, 90, -25);
			dcIndex = widgetIndex;
			Makers.Button(this, "Direct connect", 200, buttonHeight, titleFont)
				.SetLocation(Anchor.Centre, Anchor.Centre, 0, 60);
			spIndex = widgetIndex;
			Makers.Button(this, "Singleplayer", 200, buttonHeight, titleFont)
				.SetLocation(Anchor.Centre, Anchor.Centre, 0, 110);

			sslIndex = widgetIndex;
			bool sslVisible = widgets[sslIndex] != null && widgets[sslIndex].Visible;
			Makers.Checkbox(this, true, 30)
				.SetLocation(Anchor.Centre, Anchor.Centre, 160, -20);
			Makers.Label(this, "Skip SSL check", textFont)
				.SetLocation(Anchor.Centre, Anchor.Centre, 250, -20);
			widgets[sslIndex].Visible = sslVisible;
			widgets[sslIndex + 1].Visible = sslVisible;
			
			Makers.Label(this, updateText, inputHintFont)
				.SetLocation(Anchor.Max, Anchor.Max, -10, -45);
			
			settingsIndex = widgetIndex;
			Makers.Button(this, "Options", 100, buttonHeight, titleFont)
				.SetLocation(Anchor.Max, Anchor.Max, -6, -6);
		}
	}
}
