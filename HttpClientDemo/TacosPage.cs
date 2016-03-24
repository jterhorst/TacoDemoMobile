using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace TacoDemo
{

	public class TacosPage : ContentPage
	{
		public NavigationPage parentNavigation;
		public ListView listView = new ListView();

		public TacosPage ()
		{
			var refreshItem = new ToolbarItem {
				Name = "Refresh",
				Command = new Command(this.RefreshTacos),
			};

			this.Title = "Tacos";
			this.ToolbarItems.Add (refreshItem);

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate(typeof(TextCell));
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "name");
			RefreshTacos ();

			Content = new StackLayout {
				Children = {
					listView
				}
			};


		}

		private void updateTacos(Taco[] tacos)
		{
			Debug.WriteLine("found " + tacos.Length + " tacos");
			this.Title = tacos.Length + " tacos";
			listView.ItemsSource = tacos;
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

