using System;

using Xamarin.Forms;

namespace HttpClientDemo
{
	public class TacoDetailPage : ContentPage
	{
		public Taco taco { get; set; }

		public TacoDetailPage (Taco t)
		{
			taco = t;

			Content = new StackLayout { 
				Children = {
					new Label { Text = String.Format("Name: {0}", taco.name) },
					new Label { Text = String.Format("Details: {0}", taco.details) },
					new Label { Text = String.Format("{0} calories", taco.calories) },
					new Label { Text = String.Format("{0} layers", taco.layers) },
				}
			};
		}


	}
}


