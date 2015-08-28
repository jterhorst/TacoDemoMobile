using System;
using Xamarin.Forms;

namespace HttpClientDemo
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			TacosPage tacopage = new TacosPage ();
			NavigationPage navigation = new NavigationPage (tacopage);

			return navigation;
		}
	}
}

