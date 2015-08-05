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
			this.Title = "Tacos";

			var b = new Button { Text = "Get Tacos" };
			b.Clicked += async (sender, e) => {
				var sv = new TacosWebService();
				var es = await sv.GetTacosAsync();
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("found " + es.Length + " tacos");
					this.Title = es.Length + " tacos";
					lv.ItemsSource = es;
				});
			};

			lv = new ListView ();
			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
			lv.ItemTemplate.SetBinding(TextCell.TextProperty, "Summary");
			lv.ItemSelected += (sender, e) => {
				var eq = (Taco)e.SelectedItem;
				DisplayAlert("Taco info", eq.ToString(), "OK", null);
			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					b,
					lv
				}
			};
		}
	}
}

