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
			lv.ItemSelected += (sender, e) => {
				if (lv.SelectedItem == null)
					return;
				var eq = (Taco)e.SelectedItem;
				//DisplayAlert("Taco info", eq.ToString(), "OK", null);
				var detailPage = new TacoDetailPage(eq);
				Navigation.PushAsync(detailPage);
				lv.SelectedItem = null;
			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					lv
				}
			};


		}

		private async void RefreshTacos()
		{
			var sv = new TacosWebService();
			var es = await sv.GetTacosAsync();
			Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
				Debug.WriteLine("found " + es.Length + " tacos");
				this.Title = es.Length + " tacos";
				lv.ItemsSource = es;
			});
		}
	}
}

