using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace HttpClientDemo
{

	public class TacosPage : ContentPage
	{
		public NavigationPage parentNavigation;
		ListView lv;

		public TacosPage ()
		{
			var refreshItem = new ToolbarItem {
				Name = "Refresh",
				Command = new Command(this.RefreshTacos),
			};

			this.Title = "Tacos";
			this.ToolbarItems.Add (refreshItem);

			lv = new ListView ();
			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
			lv.ItemTemplate.SetBinding(TextCell.TextProperty, "name");
			RefreshTacos ();

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					lv
				}
			};


		}

		private void updateTacos(Taco[] tacos)
		{
			Debug.WriteLine("found " + tacos.Length + " tacos");
			this.Title = tacos.Length + " tacos";
			lv.ItemsSource = tacos;

			lv.ItemSelected += (sender, e) => {
				if (lv.SelectedItem == null)
					return;
				var eq = (Taco)e.SelectedItem;
//				DisplayAlert("Taco info", eq.ToString(), "OK", null);
				var detailPage = new TacoDetailPage(eq);
				Navigation.PushAsync(detailPage);
				lv.SelectedItem = null;
			};
		}

		private async void RefreshTacos()
		{
			var sv = new TacosWebService();
			var es = await sv.GetTacosAsync();
			Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
				updateTacos(es);
			});
		}
	}
}

