using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using Occhitta.Example.Message.Native;

namespace Occhitta.Example.Message;

/// <summary>
/// 主要画面クラスです。
/// </summary>
/// <remarks>
/// 32ビットアプリを監視する場合は、以下のコマンドで実行する。
/// <para>dotnet run -r win-x86</para>
/// </remarks>
internal sealed class MainWindow : Form {
	#region ログ出力処理定義
	/// <summary>
	/// ログ出力処理
	/// </summary>
	private static NLog.ILogger? logger;
	/// <summary>
	/// ログ出力処理を取得します。
	/// </summary>
	/// <returns>ログ出力設定</returns>
	private static NLog.ILogger Logger => logger ??= NLog.LogManager.GetCurrentClassLogger();
	#endregion ログ出力処理定義

	#region メンバー変数定義
	/// <summary>
	/// 管理番地
	/// </summary>
	private IntPtr nativeCode;
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components;
	/// <summary>
	/// 開始操作
	/// </summary>
	private Button attachMenu;
	/// <summary>
	/// 終了操作
	/// </summary>
	private Button detachMenu;
	/// <summary>
	/// 結果内容
	/// </summary>
	private Label resultText;
	/// <summary>
	/// 受信日時
	/// </summary>
	private DataGridViewTextBoxColumn invokeTime;
	/// <summary>
	/// 実行名称
	/// </summary>
	private DataGridViewTextBoxColumn actionName;
	/// <summary>
	/// 上位引数
	/// </summary>
	private DataGridViewTextBoxColumn parameter1;
	/// <summary>
	/// 下位引数
	/// </summary>
	private DataGridViewTextBoxColumn parameter2;
	/// <summary>
	/// 結果一覧
	/// </summary>
	private DataGridView resultList;
	/// <summary>
	/// 配置管理
	/// </summary>
	private TableLayoutPanel layoutView;
	#endregion メンバー変数定義

	#region 生成メソッド定義
	/// <summary>
	/// 主要画面を生成します。
	/// </summary>
	public MainWindow() {
		InitializeComponent();
		this.nativeCode = IntPtr.Zero;
	}
	#endregion 生成メソッド定義

	#region 破棄メソッド定義
	/// <summary>
	/// 保持情報を破棄します。
	/// </summary>
	/// <param name="disposing">破棄種別(<c>True<c>の場合、管理情報を全て破棄)</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}
	#endregion 破棄メソッド定義

	#region 内部メソッド定義(画面構築関連:InitializeComponent)
	/// <summary>
	/// 画面を構築します。
	/// </summary>
	[MemberNotNull(nameof(components))]
	[MemberNotNull(nameof(attachMenu))]
	[MemberNotNull(nameof(detachMenu))]
	[MemberNotNull(nameof(resultText))]
	[MemberNotNull(nameof(invokeTime))]
	[MemberNotNull(nameof(actionName))]
	[MemberNotNull(nameof(parameter1))]
	[MemberNotNull(nameof(parameter2))]
	[MemberNotNull(nameof(resultList))]
	[MemberNotNull(nameof(layoutView))]
	private void InitializeComponent() {
		const int WindowW = 800;
		const int WindowH = 450;
		const int ButtonH = 20;
		const int DesignW = 7;
		this.components = new System.ComponentModel.Container();
		this.layoutView = new TableLayoutPanel();
		this.attachMenu = new Button();
		this.detachMenu = new Button();
		this.resultText = new Label();
		this.invokeTime = new DataGridViewTextBoxColumn();
		this.actionName = new DataGridViewTextBoxColumn();
		this.parameter1 = new DataGridViewTextBoxColumn();
		this.parameter2 = new DataGridViewTextBoxColumn();
		this.resultList = new DataGridView();
		// 描画停止
		((System.ComponentModel.ISupportInitialize)this.resultList).BeginInit();
		this.layoutView.SuspendLayout();
		SuspendLayout();
		// 開始操作
		this.attachMenu.Name     = nameof(attachMenu);
		this.attachMenu.Text     = "監視開始";
		this.attachMenu.Location = new Point(0, 0);
		this.attachMenu.Size     = new Size(WindowW / 2, ButtonH);
		this.attachMenu.Anchor   = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		this.attachMenu.Margin   = new Padding(0, 0, 0, 0);
		this.attachMenu.Enabled  = true;
		this.attachMenu.TabIndex = 0;
		this.attachMenu.UseVisualStyleBackColor = true;
		this.attachMenu.Click    += ActionAttachMenu;
		// 終了操作
		this.detachMenu.Name     = nameof(detachMenu);
		this.detachMenu.Text     = "監視終了";
		this.detachMenu.Location = new Point(0, 0);
		this.detachMenu.Size     = new Size(WindowW / 2, ButtonH);
		this.detachMenu.Anchor   = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		this.detachMenu.Margin   = new Padding(0, 0, 0, 0);
		this.detachMenu.Enabled  = false;
		this.detachMenu.TabIndex = 1;
		this.detachMenu.UseVisualStyleBackColor = true;
		this.detachMenu.Click    += ActionDetachMenu;
		// 結果内容
		this.resultText.Name     = nameof(resultText);
		this.resultText.Text     = "";
		this.resultText.Location = new Point(0, 0);
		this.resultText.Size     = new Size(WindowW, WindowH);
		this.resultText.Anchor   = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		this.resultText.AutoSize = false;
		this.resultText.TabIndex = 2;
		// 受信日時
		this.invokeTime.Name       = nameof(invokeTime);
		this.invokeTime.HeaderText = "受信日時";
		this.invokeTime.ReadOnly   = true;
		this.invokeTime.Width      = DesignW * 12 + 8;
		// 実行名称
		this.actionName.Name       = nameof(actionName);
		this.actionName.HeaderText = "実行名称";
		this.actionName.ReadOnly   = true;
		this.actionName.Width      = DesignW * 11 + 8;
		// 上位引数
		this.parameter1.Name       = nameof(parameter1);
		this.parameter1.HeaderText = "上位引数";
		this.parameter1.ReadOnly   = true;
		this.parameter1.Width      = DesignW * 22 + 8;
		// 下位引数
		this.parameter2.Name       = nameof(parameter2);
		this.parameter2.HeaderText = "下位引数";
		this.parameter2.ReadOnly   = true;
		this.parameter2.Width      = DesignW * 39 + 8;
		// 結果一覧
		this.resultList.Name     = nameof(resultList);
		this.resultList.Location = new System.Drawing.Point(0, 0);
		this.resultList.Size     = new Size(WindowW, WindowH - ButtonH);
		this.resultList.Anchor   = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		this.resultList.ReadOnly = true;
		this.resultList.Visible  = false;
		this.resultList.TabIndex = 3;
		this.resultList.AllowUserToAddRows = false;
		this.resultList.Columns.AddRange(this.invokeTime, this.actionName, this.parameter1, this.parameter2);
		// 体裁管理
		this.layoutView.Name        = nameof(layoutView);
		this.layoutView.Location    = new Point(0, 0);
		this.layoutView.Size        = new Size(WindowW, WindowH);
		this.layoutView.ColumnCount = 2;
		this.layoutView.RowCount    = 2;
		this.layoutView.Anchor      = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		this.layoutView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		this.layoutView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		this.layoutView.RowStyles.Add(new RowStyle(SizeType.Absolute, 020F));
		this.layoutView.RowStyles.Add(new RowStyle(SizeType.Percent,  100F));
		this.layoutView.SetColumnSpan(this.resultText, 2);
		this.layoutView.SetColumnSpan(this.resultList, 2);
		this.layoutView.Controls.Add(this.attachMenu, 0, 0);
		this.layoutView.Controls.Add(this.detachMenu, 1, 0);
		this.layoutView.Controls.Add(this.resultText, 0, 1);
		this.layoutView.Controls.Add(this.resultList, 0, 1);
		// 全体画面
		Name                = nameof(MainWindow);
		Text                = "ウィンドウメッセージ監視";
		Font                = new Font("MS Gothic", 10);
		AutoScaleMode       = AutoScaleMode.Font;
		AutoScaleDimensions = new SizeF(6F, 12F);
		ClientSize          = new Size(WindowW, WindowH);
		Controls.Add(this.layoutView);
		((System.ComponentModel.ISupportInitialize)this.resultList).EndInit();
		this.layoutView.ResumeLayout(false);
		this.layoutView.PerformLayout();
		ResumeLayout(false);
	}
	#endregion 内部メソッド定義(画面構築関連:InitializeComponent)

	#region 内部メソッド定義(画面操作関連:ActionAttachMenu/ActionDetachMenu)
	/// <summary>
	/// 開始操作を実行します。
	/// </summary>
	/// <param name="sender">要素情報</param>
	/// <param name="values">操作引数</param>
	private void ActionAttachMenu(object? sender, EventArgs values) {
		if (NativeHelper.SearchWindowCode("Notepad", null, out var windowCode) == false) {
			this.resultText.Text = "指定アプリを起動してください";
			this.resultText.Visible = true;
			this.resultList.Visible = false;
		} else if (NativeHelper.SearchThreadCode(windowCode, out var threadCode) == false) {
			this.resultText.Text = "指定アプリの特定に失敗しました";
			this.resultText.Visible = true;
			this.resultList.Visible = false;
		} else if (NativeHelper.AttachThreadCode(threadCode, InvokeAttachData, out var nativeCode) == false) {
			this.resultText.Text = "指定アプリの監視に失敗しました";
			this.resultText.Visible = true;
			this.resultList.Visible = false;
		} else {
			Logger.Info("[開始]メモ帳メッセージ監視");
			this.resultText.Text = String.Empty;
			this.resultText.Visible = false;
			this.resultList.Visible = true;
			this.detachMenu.Enabled = true;
			this.attachMenu.Enabled = false;
			this.nativeCode = nativeCode;
		}
	}
	/// <summary>
	/// 終了操作を実行します。
	/// </summary>
	/// <param name="sender">要素情報</param>
	/// <param name="values">操作引数</param>
	private void ActionDetachMenu(object? sender, EventArgs values) {
		Logger.Info("[終了]メモ帳メッセージ監視");
		NativeHelper.DetachThreadCode(this.nativeCode);
		this.detachMenu.Enabled = false;
		this.attachMenu.Enabled = true;
	}
	#endregion 内部メソッド定義(画面操作関連:ActionAttachMenu/ActionDetachMenu)

	#region 内部メソッド定義(結果一覧関連:ChooseActionName/ChooseParameter1/ChooseParameter2/RegistResultData)
	/// <summary>
	/// 実行名称へ変換します。
	/// </summary>
	/// <param name="actionCode">実行種別</param>
	/// <returns>実行名称</returns>
	private static string ChooseActionName(int actionCode) {
		switch (actionCode) {
			default:     return actionCode.ToString("X08");
			case 0x0000: return "HC_ACTION";
			case 0x0003: return "HC_NOREMOVE";
		}
	}
	/// <summary>
	/// 上位名称へ変換します。
	/// </summary>
	/// <param name="parameter1">上位引数</param>
	/// <returns>上位名称</returns>
	private static string ChooseParameter1(long parameter1) {
		if (Enum.IsDefined(typeof(KeyboardCode), parameter1)) {
			return ((KeyboardCode)parameter1).ToString();
		} else {
			return parameter1.ToString("X016");
		}
	}
	/// <summary>
	/// 上位名称へ変換します。
	/// </summary>
	/// <param name="parameter1">上位引数</param>
	/// <returns>上位名称</returns>
	private static string ChooseParameter1(IntPtr parameter1) =>
		ChooseParameter1(parameter1.ToInt64());
	/// <summary>
	/// 下位名称へ変換します。
	/// </summary>
	/// <param name="parameter2">下位引数</param>
	/// <returns>下位名称</returns>
	private static string ChooseParameter2(int parameter2) {
		var value1 = (parameter2 >> 00) & 0b1111_1111_1111_1111; // 00-15:16bit 回数
		var value2 = (parameter2 >> 16) & 0b0000_0000_1111_1111; // 16-23:08bit 独自
		var value3 = (parameter2 >> 24) & 0b0000_0000_0000_0001; // 24-24:01bit 拡張(ファンクションキー or テンキー)
		var value4 = (parameter2 >> 25) & 0b0000_0000_0000_0011; // 25-28:03bit 予約
		var value5 = (parameter2 >> 29) & 0b0000_0000_0000_0001; // 29-29:01bit ALTキー;
		var value6 = (parameter2 >> 30) & 0b0000_0000_0000_0001; // 30-30:01bit 前回キー状態;
		var value7 = (parameter2 >> 31) & 0b0000_0000_0000_0001; // 31-31:01bit 現在キー状態;
		var param1 = value1.ToString();
		var param2 = value5 == 0? "解放": "押下";
		var param3 = value6 == 0? "稼働": "押下";
		var param4 = value7 == 0? "押下": "解放";
		return $"回数:{param1, 4} 拡張:{param2} 前回:{param3} 今回:{param4}";
	}
	/// <summary>
	/// 下位名称へ変換します。
	/// </summary>
	/// <param name="parameter2">下位引数</param>
	/// <returns>下位名称</returns>
	private static string ChooseParameter2(IntPtr parameter2) =>
		ChooseParameter2(parameter2.ToInt32());

	/// <summary>
	/// 結果情報を登録します。
	/// </summary>
	/// <param name="invokeTime">受信日時</param>
	/// <param name="actionCode">実行種別</param>
	/// <param name="parameter1">上位引数</param>
	/// <param name="parameter2">下位引数</param>
	private void RegistResultData(DateTime invokeTime, int actionCode, IntPtr parameter1, IntPtr parameter2) {
		if (this.resultList.InvokeRequired) {
			this.resultList.Invoke(() => RegistResultData(invokeTime, actionCode, parameter1, parameter2));
		} else {
			this.resultList.Visible = true;
			var value1 = invokeTime.ToString("HH:mm:ss.fff");
			var value2 = ChooseActionName(actionCode);
			var value3 = ChooseParameter1(parameter1);
			var value4 = ChooseParameter2(parameter2);
			this.resultList.Rows.Add(new object[] { value1, value2, value3, value4 });
		}
	}
	#endregion 内部メソッド定義(結果一覧関連:ChooseActionName/ChooseParameter1/ChooseParameter2/RegistResultData)

	#region 内部メソッド定義(キー処理関連:InvokeAttachData)
	/// <summary>
	/// 受信情報を実行します。
	/// </summary>
	/// <param name="actionCode">実行番号</param>
	/// <param name="parameter1">上位引数</param>
	/// <param name="parameter2">下位引数</param>
	/// <returns>実行結果</returns>
	private IntPtr InvokeAttachData(int actionCode, IntPtr parameter1, IntPtr parameter2) {
		Logger.Info("[情報]受信情報:{0:X08}, {1:X016}, {2:X016}", actionCode, parameter1, parameter2);
		RegistResultData(DateTime.Now, actionCode, parameter1, parameter2);
		return NativeHelper.InvokeThreadCode(this.nativeCode, actionCode, parameter1, parameter2);
	}
	#endregion 内部メソッド定義(キー処理関連:InvokeAttachData)
}
