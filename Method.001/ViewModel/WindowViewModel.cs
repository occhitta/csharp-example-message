using System.Collections.ObjectModel;
using Otchitta.Libraries.Screen.Data;
using Otchitta.Libraries.Screen.Hook;

namespace Occhitta.Example.Message.ViewModel;

/// <summary>
/// 主要画面モデルクラスです。
/// </summary>
internal sealed class WindowViewModel : AbstractScreenData {
	#region メンバー変数定義
	/// <summary>
	/// 選択一覧
	/// </summary>
	private readonly ObservableCollection<InvokeViewModel> selectList;
	/// <summary>
	/// 選択番号
	/// </summary>
	private int selectCode;
	/// <summary>
	/// 選択情報
	/// </summary>
	private InvokeViewModel? selectData;
	/// <summary>
	/// 更新操作
	/// </summary>
	private DelegateScreenHook? updateMenu;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 選択一覧を取得します。
	/// </summary>
	/// <value>選択一覧</value>
	public ReadOnlyObservableCollection<InvokeViewModel> SelectList {
		get;
	}
	/// <summary>
	/// 選択番号を取得または設定します。
	/// </summary>
	/// <value>選択番号</value>
	public int SelectCode {
		get => this.selectCode;
		set => Update(ref this.selectCode, value, nameof(SelectCode), ActionSelectCode);
	}
	/// <summary>
	/// 選択情報を取得します。
	/// </summary>
	/// <value>選択情報</value>
	public InvokeViewModel? SelectData {
		get => this.selectData;
		private set => Update(ref this.selectData, value, nameof(SelectData));
	}
	/// <summary>
	/// 実行操作を取得します。
	/// </summary>
	/// <value>実行操作</value>
	public AbstractScreenHook UpdateMenu {
		get => this.updateMenu ??= new DelegateScreenHook(ActionUpdateMenu);
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 主要画面モデルを生成します。
	/// </summary>
	public WindowViewModel() {
		this.selectList = new ObservableCollection<InvokeViewModel>();
		this.selectCode = -1;
		SelectList = new ReadOnlyObservableCollection<InvokeViewModel>(this.selectList);
	}
	#endregion 生成メソッド定義

	#region 内部メソッド定義
	/// <summary>
	/// 選択番号を実行します。
	/// </summary>
	private void ActionSelectCode() {
		if (0 <= this.selectCode && this.selectCode < this.selectList.Count) {
			SelectData = this.selectList[this.selectCode];
		} else {
			SelectData = default;
		}
	}
	/// <summary>
	/// 更新操作を実行します。
	/// </summary>
	private void ActionUpdateMenu() {
		this.selectList.Clear();
		foreach (var choose in InvokeViewModel.CreateList()) {
			this.selectList.Add(choose);
		}
	}
	#endregion 内部メソッド定義
}
