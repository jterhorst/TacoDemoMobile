using System;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace TacoDemo
{
	public class App: Application
	{
		NavigationPage tacoNavigationPage = null;
		MasterDetailPage splitPage = null;

		public App ()
		{
			// The root page of your application
			setupTacoListPage ();
			MainPage = tacoNavigationPage;
		}

		void setupTacoListPage()
		{
			TacosPage tacosList = new TacosPage ();
			tacosList.Title = "Tacos";
			tacoNavigationPage = new NavigationPage (tacosList);
			tacoNavigationPage.BarBackgroundColor = Color.FromHex ("#15293c");
			tacoNavigationPage.BarTextColor = Color.White;
			tacoNavigationPage.Title = "Tacos";
			tacoNavigationPage.Icon = "hamburger_icon.png";

			tacosList.listView.ItemSelected += OnSelection;

		}

		void setupMasterDetailPage (Taco t)
		{
			if (splitPage == null) {
				MainPage = new ContentPage();
				splitPage = new MasterDetailPage ();
				splitPage.Master = tacoNavigationPage;
			}

			TacoDetailPage tacoPage = new TacoDetailPage (t);
			tacoPage.Title = "";
			NavigationPage detailNavigation = new NavigationPage (tacoPage);
			detailNavigation.Title = "Taco";
			detailNavigation.BarBackgroundColor = Color.FromHex ("#15293c");
			detailNavigation.BarTextColor = Color.White;
			splitPage.Detail = detailNavigation;

			splitPage.Title = "Taco";

			MainPage = splitPage;
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return;
			}
			//			MainPage.DisplayAlert ("Item Selected", e.SelectedItem.ToString (), "Ok");
			//			((ListView)sender).SelectedItem = null;

			Taco min = (Taco)e.SelectedItem;

			setupMasterDetailPage (min);

			TacoDetailPage sendPage = new TacoDetailPage (min);
			NavigationPage detailNavigation = new NavigationPage (sendPage);
			detailNavigation.BarBackgroundColor = Color.FromHex ("#15293c");
			detailNavigation.BarTextColor = Color.White;
			splitPage.Detail = detailNavigation;

			splitPage.IsPresented = false;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			if (!CrossConnectivity.Current.IsConnected) {
				MainPage.DisplayAlert ("No Internet Connection", "We can't reach WorshipKit. Please double-check your Internet connection.", "OK");
			}
		}
	}
}

