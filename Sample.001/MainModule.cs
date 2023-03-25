using System;
using System.Windows.Forms;

namespace Occhitta.Example.Message;

/// <summary>
/// 主要画面実行クラスです。
/// </summary>
internal static class MainModule {
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() {
		ApplicationConfiguration.Initialize();
		Application.Run(new MainWindow());
	}
}
