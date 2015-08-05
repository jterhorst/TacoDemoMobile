using System;
using Xamarin.Forms;

namespace HttpClientDemo
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			NavigationPage navigation = new NavigationPage ();
			TacosPage tacopage = new TacosPage ();
			tacopage.parentNavigation = navigation;
			return navigation;
		}
	}
}

